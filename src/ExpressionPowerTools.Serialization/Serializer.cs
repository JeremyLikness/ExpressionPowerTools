// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;
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
            var opt = new JsonSerializerOptions();
            options = options ?? new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
            };
            var serializeRoot = new SerializationRoot(SerializerValue.Serialize(root, options));
            return JsonSerializer.Serialize(serializeRoot, options);
        }

        /// <summary>
        /// Serialize an <see cref="IQueryable"/>.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable"/> to serialize.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The serialized <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when the query is null.</exception>
        public static string Serialize(IQueryable query, JsonSerializerOptions options = null)
        {
            Ensure.NotNull(() => query);
            return Serialize(query.Expression, options);
        }

        /// <summary>
        /// Deserialize to an <see cref="Expression"/> tree.
        /// </summary>
        /// <param name="json">The json text.</param>
        /// <param name="queryRoot">The root of the query to apply.</param>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The deserialized <see cref="Expression"/> or <c>null</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the json is <c>null</c> or whitespace.</exception>
        public static Expression Deserialize(
            string json,
            Expression queryRoot = null,
            JsonSerializerOptions options = null)
        {
            Ensure.NotNullOrWhitespace(() => json);
            var root = JsonSerializer.Deserialize<SerializationRoot>(json, options);
            if (root.Expression is JsonElement jsonChild)
            {
                return SerializerValue.Deserialize(jsonChild, queryRoot, options);
            }

            return null;
        }

        /// <summary>
        /// Deserializes a query from the raw json.
        /// </summary>
        /// <param name="host">The host to create the <see cref="IQueryable"/>.</param>
        /// <param name="json">The json text.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The deserialized <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when host is null.</exception>
        /// <exception cref="ArgumentException">Throws when the json is empty or whitespace.</exception>
        public static IQueryable DeserializeQuery(
            IQueryable host,
            string json,
            JsonSerializerOptions options = null)
        {
            Ensure.NotNull(() => host);
            Ensure.NotNullOrWhitespace(() => json);
            var expression = Deserialize(json, host.Expression, options);
            return host.Provider.CreateQuery(expression);
        }

        /// <summary>
        /// Deserializes a query from the raw json.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="host">The <see cref="IQueryable{T}"/> host to create the query.</param>
        /// <param name="json">The json text.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The deserialized <see cref="IQueryable{T}"/>.</returns>
        public static IQueryable<T> DeserializeQuery<T>(
            IQueryable<T> host,
            string json,
            JsonSerializerOptions options = null) =>
            DeserializeQuery((IQueryable)host, json, options) as IQueryable<T>;

        /// <summary>
        /// Overload to return a specific type.
        /// </summary>
        /// <remarks>
        /// Do not use this method to deserialize <see cref="IQueryable"/> or <see cref="IQueryable{T}"/>.
        /// The <see cref="DeserializeQuery(IQueryable, string, JsonSerializerOptions)"/> method is provided for this.
        /// </remarks>
        /// <typeparam name="T">The type of the <see cref="Expression"/> root.</typeparam>
        /// <param name="json">The json.</param>
        /// <param name="queryRoot">The root of the query to apply.</param>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Expression"/> or <c>null</c>.</returns>
        public static T Deserialize<T>(string json, Expression queryRoot = null, JsonSerializerOptions options = null)
            where T : Expression => (T)Deserialize(json, queryRoot, options);
    }
}
