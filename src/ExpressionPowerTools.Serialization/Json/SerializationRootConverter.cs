// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Json
{
    /// <summary>
    /// Converter for overall <see cref="SerializationRoot"/>.
    /// </summary>
    public class SerializationRootConverter : JsonConverter<SerializationRoot>
    {
        /// <summary>
        /// References the expression converter so it can pass types.
        /// </summary>
        private readonly SerializableExpressionConverter converter;

        /// <summary>
        /// References to pass types.
        /// </summary>
        private readonly AnonTypeConverter anonTypeConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationRootConverter"/> class.
        /// </summary>
        /// <param name="converter">The expression converter (to set types).</param>
        /// <param name="anonTypeConverter">The anonymous type converter.</param>
        public SerializationRootConverter(
            SerializableExpressionConverter converter,
            AnonTypeConverter anonTypeConverter)
        {
            this.converter = converter;
            this.anonTypeConverter = anonTypeConverter;
        }

        /// <summary>
        /// Reads to deserialize.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type of the <see cref="SerializationRoot"/>.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="SerializationRoot"/>.</returns>
        public override SerializationRoot Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException(nameof(SerializationRoot));
            }

            var result = new SerializationRoot();
            reader.Read(); // start object
            reader.GetString(); // TypeIndex
            result.TypeIndex = JsonSerializer.Deserialize<string[]>(ref reader, options);
            reader.Read(); // end array
            converter.TypeIndex = result.TypeIndex.ToList();
            anonTypeConverter.TypeIndex = result.TypeIndex.ToList();
            reader.GetString(); // Expression
            result.Expression = JsonSerializer.Deserialize<SerializableExpression>(ref reader, options);
            reader.Read(); // close object
            return result;
        }

        /// <summary>
        /// Writes the <see cref="SerializationRoot"/>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The <see cref="SerializationRoot"/> to serialize.</param>
        /// <param name="options">The options.</param>
        public override void Write(Utf8JsonWriter writer, SerializationRoot value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(value.TypeIndex));
            JsonSerializer.Serialize(writer, value.TypeIndex, typeof(string[]), options);
            writer.WritePropertyName(nameof(value.Expression));
            JsonSerializer.Serialize(writer, value.Expression, typeof(SerializableExpression), options);
            writer.WriteEndObject();
        }
    }
}
