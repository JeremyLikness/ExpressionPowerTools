// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Json
{
    /// <summary>
    /// Json handler for <see cref="AnonType"/>.
    /// </summary>
    public class AnonTypeConverter : JsonConverter<AnonType>
    {
        /// <summary>
        /// Types compressor.
        /// </summary>
        private ITypesCompressor typesCompressor;

        /// <summary>
        /// Member adapter.
        /// </summary>
        private IMemberAdapter memberAdapter;

        /// <summary>
        /// Gets or sets the type index.
        /// </summary>
        public List<string> TypeIndex { get; set; }

        /// <summary>
        /// Gets the types compressor.
        /// </summary>
        private ITypesCompressor Compressor
        {
            get
            {
                if (typesCompressor == null)
                {
                    typesCompressor = ServiceHost.GetService<ITypesCompressor>();
                }

                return typesCompressor;
            }
        }

        /// <summary>
        /// Gets the member adapter.
        /// </summary>
        private IMemberAdapter Adapter
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
        /// Reads to deserialize.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type of the <see cref="AnonType"/>.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="AnonType"/>.</returns>
        public override AnonType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException(nameof(SerializationRoot));
            }

            var result = new AnonType();
            reader.Read(); // start object
            reader.GetString(); // Names
            result.Names = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            reader.Read(); // end array
            reader.GetString(); // Types
            result.Types = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            reader.Read(); // end array
            reader.GetString(); // Anon type
            reader.Read();
            result.AnonymousTypeKey = reader.GetString();
            reader.Read();
            reader.GetString(); // values
            reader.Read(); // start of array

            if (TypeIndex != null)
            {
                Compressor.DecompressTypes(
                    TypeIndex,
                    (result.AnonymousTypeKey, (string key) => result.AnonymousTypeKey = key));

                Action<string> MakeAction(int i) => str => result.Types[i] = str;

                var typeList = new List<(string key, Action<string> keyFn)>();
                for (var j = 0; j < result.Types.Count; j++)
                {
                    typeList.Add((result.Types[j], MakeAction(j)));
                }

                Compressor.DecompressTypes(
                    TypeIndex,
                    typeList.ToArray());
            }

            var idx = 0;
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                var type = Adapter.GetMemberForKey<Type>(result.Types[idx++]);
                result.Values.Add(JsonSerializer.Deserialize(ref reader, type, options));
                reader.Read();
            }

            reader.Read(); // close object
            return result;
        }

        /// <summary>
        /// Writes the <see cref="AnonType"/>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The <see cref="AnonType"/> to serialize.</param>
        /// <param name="options">The options.</param>
        public override void Write(Utf8JsonWriter writer, AnonType value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(value.Names));
            JsonSerializer.Serialize(writer, value.Names, typeof(List<string>), options);
            writer.WritePropertyName(nameof(value.Types));
            JsonSerializer.Serialize(writer, value.Types, typeof(List<string>), options);
            writer.WritePropertyName(nameof(value.AnonymousTypeKey));
            writer.WriteStringValue(value.AnonymousTypeKey);
            writer.WritePropertyName(nameof(value.Values));
            writer.WriteStartArray();
            for (var idx = 0; idx < value.Values.Count; idx++)
            {
                if (value.Values[idx] == null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    var val = value.Values[idx];
                    JsonSerializer.Serialize(writer, val, val.GetType(), options);
                }
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
