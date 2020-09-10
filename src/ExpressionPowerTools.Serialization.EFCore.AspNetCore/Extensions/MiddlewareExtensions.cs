// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.Signatures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions
{
    /// <summary>
    /// Extensions to configure the middleware.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Context parameter of route.
        /// </summary>
        public const string Context = "context";

        /// <summary>
        /// Collection parameter of route.
        /// </summary>
        public const string Collection = "collection";

        /// <summary>
        /// The default base route pattern.
        /// </summary>
        public const string DefaultPattern = "/efcore/{context}/{collection}";

        /// <summary>
        /// Map a route and allow two <see cref="DbContext"/> instances.
        /// </summary>
        /// <typeparam name="T1Context">The type of the first <see cref="DbContext"/>.</typeparam>
        /// <typeparam name="T2Context">The type of the second <see cref="DbContext"/>.</typeparam>
        /// <param name="endpointRouteBuilder">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <param name="pattern">The root path. The context and controller will be appended.</param>
        /// <param name="rules">The <see cref="IRulesConfiguration"/> to configure serialization rules.</param>
        /// <param name="noDefaultRules">Determines whether the default rule set should be applied.</param>
        /// <param name="options">The <see cref="IConfigurationBuilder"/> to configure options.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/>.</returns>
        public static IEndpointConventionBuilder MapPowerToolsEFCore<T1Context, T2Context>(
            this IEndpointRouteBuilder endpointRouteBuilder,
            string pattern = DefaultPattern,
            Action<IRulesConfiguration> rules = null,
            bool noDefaultRules = false,
            Action<IConfigurationBuilder> options = null)
            where T1Context : DbContext
            where T2Context : DbContext => MapPowerToolsEFCore(
                endpointRouteBuilder,
                RoutePatternFactory.Parse(pattern),
                new Type[] { typeof(T1Context), typeof(T2Context) },
                rules,
                noDefaultRules,
                options);

        /// <summary>
        /// Map a route and allow a <see cref="DbContext"/>.
        /// </summary>
        /// <typeparam name="TContext">The type of the <see cref="DbContext"/>.</typeparam>
        /// <param name="endpointRouteBuilder">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <param name="pattern">The path pattern.</param>
        /// <param name="rules">The <see cref="IRulesConfiguration"/> to configure serialization rules.</param>
        /// <param name="noDefaultRules">Determines whether the default rule set should be applied.</param>
        /// <param name="options">The <see cref="IConfigurationBuilder"/> to configure options.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/>.</returns>
        public static IEndpointConventionBuilder MapPowerToolsEFCore<TContext>(
            this IEndpointRouteBuilder endpointRouteBuilder,
            string pattern = DefaultPattern,
            Action<IRulesConfiguration> rules = null,
            bool noDefaultRules = false,
            Action<IConfigurationBuilder> options = null)
            where TContext : DbContext => MapPowerToolsEFCore(
                endpointRouteBuilder,
                RoutePatternFactory.Parse(pattern),
                new Type[] { typeof(TContext) },
                rules,
                noDefaultRules,
                options);

        /// <summary>
        /// Main configuration method for Power Tools EF Core middleware.
        /// </summary>
        /// <param name="endpointRouteBuilder">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <param name="pattern">The pattern for the route (defaults to <c>/efcore</c>).</param>
        /// <param name="dbContextTypes">The list of <c>DbContext</c> types to support.</param>
        /// <param name="rules">The <see cref="IRulesConfiguration"/> to configure serialization rules.</param>
        /// <param name="noDefaultRules">Determines whether the default rule set should be applied.</param>
        /// <param name="options">The <see cref="IConfigurationBuilder"/> to configure options.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/>.</returns>
        public static IEndpointConventionBuilder MapPowerToolsEFCore(
            this IEndpointRouteBuilder endpointRouteBuilder,
            RoutePattern pattern,
            Type[] dbContextTypes,
            Action<IRulesConfiguration> rules = null,
            bool noDefaultRules = false,
            Action<IConfigurationBuilder> options = null)
        {
            Ensure.NotNull(() => endpointRouteBuilder);
            Ensure.NotNull(() => pattern);
            Ensure.NotNull(() => dbContextTypes);

            if (pattern.Parameters.Count != 2)
            {
                throw new ArgumentException(
                    $"{DefaultPattern}<~>{pattern.RawText}",
                    nameof(pattern));
            }

            if (!pattern.Parameters.Any(p => p.Name == Context))
            {
                throw new ArgumentException(Context, nameof(pattern));
            }

            if (!pattern.Parameters.Any(p => p.Name == Collection))
            {
                throw new ArgumentException(Collection, nameof(pattern));
            }

            if (dbContextTypes.Length == 0)
            {
                throw new ArgumentException(
                    $"{nameof(dbContextTypes)}.Length = 0",
                    nameof(dbContextTypes));
            }

            var badType = dbContextTypes.FirstOrDefault(
                t => !typeof(DbContext).IsAssignableFrom(t));

            if (badType != null)
            {
                throw new ArgumentException(
                    $"{badType} != {typeof(DbContext)}",
                    nameof(dbContextTypes));
            }

            // passed tests, check configuration
            if (options != null)
            {
                Serializer.ConfigureDefaults(options);
            }

            if (rules != null || noDefaultRules == true)
            {
                Serializer.ConfigureRules(rules, noDefaultRules);
            }

            var appBuilder = endpointRouteBuilder.CreateApplicationBuilder();
            appBuilder.UseMiddleware<ExpressionPowerToolsEFCoreMiddleware>(
                pattern.RawText,
                dbContextTypes);
            return endpointRouteBuilder.Map(pattern, appBuilder.Build())
                .WithDisplayName($"Expression Power Tools Serialization Pipeline");
        }
    }
}
