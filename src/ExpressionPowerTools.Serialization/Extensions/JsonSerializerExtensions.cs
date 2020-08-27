// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Extensions
{
    /// <summary>
    /// Extensions for serialization/deserialization.
    /// </summary>
    public static class JsonSerializerExtensions
    {
        /// <summary>
        /// Gets the type, including generic arguments.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> that contains the type.</param>
        /// <returns>The deserialized <see cref="Type"/>.</returns>
        public static Type GetDeserializedType(this JsonElement element)
        {
            var serializedType = JsonSerializer
                .Deserialize<SerializableType>(element.GetRawText());
            return ReflectionHelper.Instance.DeserializeType(serializedType);
        }

        /// <summary>
        /// Gets the method from the <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <returns>The deserialized <see cref="Method"/>.</returns>
        public static Method GetMethod(this JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<Method>(json);
        }
    }
}
