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
    }
}
