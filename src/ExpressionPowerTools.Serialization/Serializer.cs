// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization
{
    /// <summary>
    /// Class for serialization and de-deserialization of <see cref="Expression"/> trees.
    /// </summary>
    /// <remarks>
    /// By default, the serializer will compress types and ignore null and readonly values. You can override the configuration for a session
    /// by using the <see cref="IConfigurationBuilder"/>. You can also set defaults for all sessions using <see cref="ConfigureDefaults(Action{IConfigurationBuilder})"/>.
    /// For permissions, use the <see cref="ConfigureRules(Action{IRulesConfiguration}, bool)"/> option. By default, perimssions are given for:
    /// <see cref="Math"/>, <see cref="Enumerable"/>, <see cref="Queryable"/> and <see cref="string"/> types (all methods and properties are allowed).
    /// See the <see cref="ExpressionPowerTools.Serialization.Rules.RulesEngine"/> documentation for more on rules.
    /// </remarks>
    public static class Serializer
    {
        /// <summary>
        /// The serializer for expressions.
        /// </summary>
        private static readonly IExpressionSerializer<Expression, SerializableExpression>
            SerializerValue = new ExpressionSerializer();

        /// <summary>
        /// The default configuration when not specified.
        /// </summary>
        private static readonly Lazy<IDefaultConfiguration> DefaultConfiguration =
            ServiceHost.GetLazyService<IDefaultConfiguration>();

        /// <summary>
        /// Serialize an expression tree.
        /// </summary>
        /// <param name="root">The root <see cref="Expression"/>.</param>
        /// <param name="config">Optional configuration.</param>
        /// <returns>The serialized <see cref="Expression"/> tree.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Expression"/> is <c>null</c>.</exception>
        public static string Serialize(
        Expression root,
        Action<IConfigurationBuilder> config = null)
        {
            Ensure.NotNull(() => root);
            SerializationState state;
            if (config != null)
            {
                var builder = ServiceHost.GetService<IConfigurationBuilder>();
                config(builder);
                state = builder.Configure();
            }
            else
            {
                state = DefaultConfiguration.Value.GetDefaultState();
            }

            var serializeRoot = new SerializationRoot(SerializerValue.Serialize(root, state))
            {
                TypeIndex = state.TypeIndex.ToArray(),
            };
            return JsonSerializer.Serialize(serializeRoot, state.Options);
        }

        /// <summary>
        /// Serialize an <see cref="IQueryable"/>.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable"/> to serialize.</param>
        /// <param name="config">Option configuration.</param>
        /// <returns>The serialized <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when the query is null.</exception>
        public static string Serialize(
            IQueryable query,
            Action<IConfigurationBuilder> config = null)
        {
            Ensure.NotNull(() => query);
            return Serialize(query.Expression, config);
        }

        /// <summary>
        /// Deserialize to an <see cref="Expression"/> tree.
        /// </summary>
        /// <param name="json">The json text.</param>
        /// <param name="queryRoot">The root of the query to apply.</param>
        /// <param name="config">Optional configuration.</param>
        /// <returns>The deserialized <see cref="Expression"/> or <c>null</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the json is <c>null</c> or whitespace.</exception>
        public static Expression Deserialize(
            string json,
            Expression queryRoot = null,
            Action<IConfigurationBuilder> config = null)
        {
            Ensure.NotNullOrWhitespace(() => json);

            SerializationState state;
            if (config != null)
            {
                var builder = ServiceHost.GetService<IConfigurationBuilder>();
                config(builder);
                state = builder.Configure();
            }
            else
            {
                state = DefaultConfiguration.Value.GetDefaultState();
            }

            state.QueryRoot = queryRoot;

            var root = JsonSerializer.Deserialize<SerializationRoot>(json, state.Options);
            state.TypeIndex = new List<SerializableType>(
                root.TypeIndex ?? new SerializableType[0]);
            if (root.Expression is JsonElement jsonChild)
            {
                return SerializerValue.Deserialize(jsonChild, state);
            }

            return null;
        }

        /// <summary>
        /// Deserializes a query from the raw json.
        /// </summary>
        /// <param name="host">The host to create the <see cref="IQueryable"/>.</param>
        /// <param name="json">The json text.</param>
        /// <param name="config">Optional configuratoin.</param>
        /// <returns>The deserialized <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when host is null.</exception>
        /// <exception cref="ArgumentException">Throws when the json is empty or whitespace.</exception>
        public static IQueryable DeserializeQuery(
            IQueryable host,
            string json,
            Action<IConfigurationBuilder> config = null)
        {
            Ensure.NotNull(() => host);
            Ensure.NotNullOrWhitespace(() => json);
            var expression = Deserialize(json, host.Expression, config);
            return host.Provider.CreateQuery(expression);
        }

        /// <summary>
        /// Deserializes a query from the raw json.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="json">The json text.</param>
        /// <param name="host">The <see cref="IQueryable{T}"/> host to create the query.</param>
        /// <param name="config">The optional configuration.</param>
        /// <returns>The deserialized <see cref="IQueryable{T}"/>.</returns>
        public static IQueryable<T> DeserializeQuery<T>(
            string json,
            IQueryable<T> host = null,
            Action<IConfigurationBuilder> config = null)
        {
            host = host ?? IQueryableExtensions.CreateQueryTemplate<T>();
            return DeserializeQuery(host, json, config) as IQueryable<T>;
        }

        /// <summary>
        /// Overload to return a specific type.
        /// </summary>
        /// <remarks>
        /// Do not use this method to deserialize <see cref="IQueryable"/> or <see cref="IQueryable{T}"/>.
        /// The <see cref="DeserializeQuery(IQueryable, string, Action{IConfigurationBuilder})"/> method is provided for this.
        /// </remarks>
        /// <typeparam name="T">The type of the <see cref="Expression"/> root.</typeparam>
        /// <param name="json">The json.</param>
        /// <param name="queryRoot">The root of the query to apply.</param>
        /// <param name="config">Optional configuration.</param>
        /// <returns>The <see cref="Expression"/> or <c>null</c>.</returns>
        public static T Deserialize<T>(
            string json,
            Expression queryRoot = null,
            Action<IConfigurationBuilder> config = null)
            where T : Expression => (T)Deserialize(json, queryRoot, config);

        /// <summary>
        /// Configure default settings.
        /// </summary>
        /// <param name="config">The configuration builder.</param>
        /// <remarks>
        /// Will set the global defaults moving forward. Can be called multiple times.
        /// </remarks>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// Serializer.ConfigureDefaults(config => config.CompressTypes(false).Configure());
        /// </code>
        /// </example>
        public static void ConfigureDefaults(Action<IConfigurationBuilder> config) =>
            DefaultConfiguration.Value.SetDefaultState(builder => config(builder));

        /// <summary>
        /// Configures the rule set for serialization.
        /// </summary>
        /// <param name="rules">The <see cref="IRulesConfiguration"/> to configure rules.</param>
        /// <param name="noDefaults">A value that indicates whether the default type permissions can be applied.</param>
        public static void ConfigureRules(
            Action<IRulesConfiguration> rules = null,
            bool noDefaults = false)
        {
            var rulesEngine = ServiceHost.GetService<IRulesEngine>();
            var rulesConfig = ServiceHost.GetService<IRulesConfiguration>();
            rulesEngine.Reset();
            if (noDefaults == false)
            {
                Registration.RegisterDefaultRules(rulesConfig);
            }

            rules?.Invoke(rulesConfig);

            rulesEngine.Compile();
        }
    }
}
