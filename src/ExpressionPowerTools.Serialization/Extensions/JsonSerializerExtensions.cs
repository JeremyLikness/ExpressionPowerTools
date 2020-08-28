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
        /// A null document.
        /// </summary>
        private static readonly JsonElement NullDoc =
            JsonDocument.Parse("{\"null\": null}").RootElement;

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

        /// <summary>
        /// Safe way to access a property. Returns an element that evaluates to <c>null</c>
        /// when the underlying property doesn't exist.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to inspect.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The property node, or a <c>null</c> node.</returns>
        public static JsonElement GetNullableProperty(this JsonElement element, string propertyName)
        {
            if (element.TryGetProperty(propertyName, out JsonElement property))
            {
                return property;
            }

            return NullDoc.Clone().GetProperty("null");
        }
    }
}
