// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// The type comparer to use.
        /// </summary>
        private static readonly IEqualityComparer<SerializableType> TypeComparer
            = new SerializableTypeComparer();

        /// <summary>
        /// Gets the type, including generic arguments.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> that contains the type.</param>
        /// <param name="state">The state for the serialization operation.</param>
        /// <returns>The deserialized <see cref="Type"/>.</returns>
        public static Type GetDeserializedType(
            this JsonElement element,
            SerializationState state)
        {
            var serializedType = JsonSerializer
                .Deserialize<SerializableType>(element.GetRawText());
            return state.GetType(serializedType);
        }

        /// <summary>
        /// Gets the method from the <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <param name="state">The state of serialization.</param>
        /// <returns>The deserialized <see cref="Method"/>.</returns>
        public static Method GetMethod(
            this JsonElement element,
            SerializationState state)
        {
            var json = element.GetRawText();
            var method = JsonSerializer.Deserialize<Method>(json);

            if (method != null)
            {
                state.DecompressMemberTypes(method);

                if (method.GenericMethodDefinition != null)
                {
                    state.DecompressMemberTypes(method.GenericMethodDefinition);
                    var decompressed = method.GenericArguments.Select(t => state.DecompressType(t))
                        .ToArray();
                    method.GenericArguments = decompressed;
                }
            }

            return method;
        }

        /// <summary>
        /// Gets the property from the <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <param name="state">The state of serialization.</param>
        /// <returns>The deserialized <see cref="Property"/>.</returns>
        public static Property GetSerializedProperty(
            this JsonElement element,
            SerializationState state)
        {
            var json = element.GetRawText();
            var prop = JsonSerializer.Deserialize<Property>(json);

            if (prop != null)
            {
                state.DecompressMemberTypes(prop);
            }

            return prop;
        }

        /// <summary>
        /// Gets the field from the <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <param name="state">The state of serialization.</param>
        /// <returns>The deserialized <see cref="Field"/>.</returns>
        public static Field GetSerializedField(
            this JsonElement element,
            SerializationState state)
        {
            var json = element.GetRawText();
            var field = JsonSerializer.Deserialize<Field>(json);

            if (field != null)
            {
                state.DecompressMemberTypes(field);
            }

            return field;
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

        /// <summary>
        /// Cast <see cref="JsonSerializerOptions"/> into the <see cref="SerializationState"/> the APIs expect.
        /// </summary>
        /// <param name="options">The <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The initialized <see cref="SerializationState"/> instance.</returns>
        public static SerializationState ToSerializationState(this JsonSerializerOptions options) =>
            new SerializationState { Options = options };

        /// <summary>
        /// Cast an <see cref="Expression"/> into the <see cref="SerializationState"/> the APIs expect.
        /// </summary>
        /// <param name="queryRoot">The <see cref="Expression"/> that is the root fo the query..</param>
        /// <returns>The initialized <see cref="SerializationState"/> instance.</returns>
        public static SerializationState ToSerializationState(this Expression queryRoot) =>
            new SerializationState { QueryRoot = queryRoot };

        /// <summary>
        /// Gets the index of the <see cref="SerializableType"/> in the list.
        /// </summary>
        /// <param name="typeList">The list to parse.</param>
        /// <param name="type">The type to index.</param>
        /// <returns>The index of the type.</returns>
        public static int IndexOfType(
            this IList<SerializableType> typeList,
            SerializableType type)
        {
            for (var idx = 0; idx < typeList.Count(); idx += 1)
            {
                if (TypeComparer.Equals(type, typeList[idx]))
                {
                    return idx;
                }
            }

            return -1;
        }
    }
}
