// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Json
{
    /// <summary>
    /// Converter writes the type so it can deserialize the derived type.
    /// </summary>
    public class SerializableExpressionConverter : JsonConverter<SerializableExpression>
    {
        /// <summary>
        /// Reference for <see cref="IMemberAdapter"/>.
        /// </summary>
        private IMemberAdapter memberAdapter;

        /// <summary>
        /// Reference for <see cref="ITypesCompressor"/>.
        /// </summary>
        private ITypesCompressor compressor;

        /// <summary>
        /// Gets or sets the type index to decompress types.
        /// </summary>
        public List<string> TypeIndex { get; set; }

        /// <summary>
        /// Gets the <see cref="IMemberAdapter"/> instance.
        /// </summary>
        private IMemberAdapter MemberAdapter
        {
            get
            {
                if (memberAdapter == null)
                {
                    memberAdapter = ServiceHost.GetService<IMemberAdapter>();
                }

                return memberAdapter;
            }
        }

        /// <summary>
        /// Gets the <see cref="ITypesCompressor"/> instance.
        /// </summary>
        private ITypesCompressor Compressor
        {
            get
            {
                if (compressor == null)
                {
                    compressor = ServiceHost.GetService<ITypesCompressor>();
                    compressor.DecompressTypes(TypeIndex, null);
                }

                return compressor;
            }
        }

        /// <summary>
        /// Read a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type.</param>
        /// <param name="options">The options.</param>
        /// <returns>The serializable expression.</returns>
        public override SerializableExpression Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException(nameof(SerializableExpression));
            }

            reader.Read(); // start object

            string typeText = reader.GetString();
            var type = Type.GetType(typeText);

            SerializableExpression result = null;

            if (type == typeof(Constant))
            {
                result = DeserializeConstant(ref reader, options);
            }
            else
            {
                result = JsonSerializer.Deserialize(ref reader, type, options) as SerializableExpression;
            }

            reader.Read(); // end object
            return result;
        }

        /// <summary>
        /// Write the <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">The options.</param>
        public override void Write(Utf8JsonWriter writer, SerializableExpression value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(value.GetType().FullName);
            if (value.GetType() == typeof(Constant))
            {
                SerializeConstant(writer, value as Constant, options);
            }
            else
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Writes a constant with type info to deserialize the value.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="constant">The constant.</param>
        /// <param name="options">The options.</param>
        private void SerializeConstant(Utf8JsonWriter writer, Constant constant, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(Constant.ConstantTypeKey));
            writer.WriteStringValue(constant.ConstantTypeKey);
            writer.WritePropertyName(nameof(Constant.ValueTypeKey));
            if (string.IsNullOrWhiteSpace(constant.ValueTypeKey))
            {
                writer.WriteStringValue("null");
            }
            else
            {
                writer.WriteStringValue(constant.ValueTypeKey);
            }

            writer.WritePropertyName("IsNull");
            writer.WriteBooleanValue(constant.Value == null);
            if (constant.Value != null)
            {
                writer.WritePropertyName(nameof(constant.Value));
                JsonSerializer.Serialize(writer, constant.Value, options);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize a constant.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="options">The options.</param>
        /// <returns>The constant.</returns>
        private SerializableExpression DeserializeConstant(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var constant = new Constant
            {
                Type = (int)ExpressionType.Constant,
            };

            while (reader.TokenType != JsonTokenType.PropertyName)
            {
                reader.Read();
            }

            reader.Read(); // constant
            reader.Read(); // start object
            reader.Read(); // constant type key
            constant.ConstantTypeKey = reader.GetString();
            reader.Read();
            reader.Read(); // value type key
            var val = reader.GetString();
            reader.Read();
            if (val != "null")
            {
                constant.ValueTypeKey = val;
            }
            else
            {
                constant.ValueTypeKey = null;
            }

            reader.Read(); // isNull
            var isNull = reader.GetBoolean();
            reader.Read();
            if (!isNull)
            {
                Compressor.DecompressTypes(TypeIndex, (constant.ConstantTypeKey, unpackedKey => constant.ConstantTypeKey = unpackedKey));
                if (constant.ValueTypeKey != null)
                {
                    Compressor.DecompressTypes(TypeIndex, (constant.ValueTypeKey, unpackedKey => constant.ValueTypeKey = unpackedKey));
                }

                var type = MemberAdapter.GetMemberForKey<Type>(constant.ValueTypeKey ?? constant.ConstantTypeKey);

                reader.GetString(); // "Value"
                reader.Read();

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumerableQuery<>))
                {
                    type = typeof(List<object>);
                }

                constant.Value = JsonSerializer.Deserialize(ref reader, type, options);
            }

            reader.Read(); // end object
            return constant;
        }
    }
}
