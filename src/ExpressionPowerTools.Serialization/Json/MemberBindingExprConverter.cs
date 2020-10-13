// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Json
{
    /// <summary>
    /// Converter for member bindings.
    /// </summary>
    public class MemberBindingExprConverter : JsonConverter<MemberBindingExpr>
    {
        /// <summary>
        /// Read the <see cref="MemberBindingExpr"/>.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="MemberBindingExpr"/>.</returns>
        public override MemberBindingExpr Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException(nameof(MemberBindingExpr));
            }

            reader.Read(); // start object

            string typeText = string.Empty;
            var memberType = reader.GetString();
            var type = Type.GetType(memberType);

            var result = JsonSerializer.Deserialize(ref reader, type, options) as MemberBindingExpr;

            reader.Read(); // end object
            return result;
        }

        /// <summary>
        /// Write the <see cref="MemberBindingExpr"/>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">The options.</param>
        public override void Write(Utf8JsonWriter writer, MemberBindingExpr value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(value.GetType().FullName);
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
            writer.WriteEndObject();
        }
    }
}
