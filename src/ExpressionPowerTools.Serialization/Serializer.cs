// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization
{
    /// <summary>
    /// Class for serialization and de-deserialization of <see cref="Expression"/> trees.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// The serializer for expressions.
        /// </summary>
        private static readonly IExpressionSerializer<Expression, SerializableExpression>
            SerializerValue = new ExpressionSerializer();

        /// <summary>
        /// Serialize an expression tree.
        /// </summary>
        /// <param name="root">The root <see cref="Expression"/>.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The serialized <see cref="Expression"/> tree.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Expression"/> is <c>null</c>.</exception>
        public static string Serialize(Expression root, JsonSerializerOptions options = null)
        {
            Ensure.NotNull(() => root);
            var serializeRoot = new SerializationRoot(SerializerValue.Serialize(root));
            return JsonSerializer.Serialize(serializeRoot, options);
        }

        /// <summary>
        /// Deserialize to an <see cref="Expression"/> tree.
        /// </summary>
        /// <param name="json">The json text.</param>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The deserialized <see cref="Expression"/> or <c>null</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the json is <c>null</c> or whitespace.</exception>
        public static Expression Deserialize(string json, JsonSerializerOptions options = null)
        {
            Ensure.NotNullOrWhitespace(() => json);
            var root = JsonSerializer.Deserialize<SerializationRoot>(json, options);
            if (root.Expression is JsonElement jsonChild)
            {
                return SerializerValue.Deserialize(jsonChild);
            }

            return null;
        }

        /// <summary>
        /// Overload to return a specific type.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/> root.</typeparam>
        /// <param name="json">The json.</param>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Expression"/> or <c>null</c>.</returns>
        public static T Deserialize<T>(string json, JsonSerializerOptions options = null)
            where T : Expression => (T)Deserialize(json, options);
    }
}
