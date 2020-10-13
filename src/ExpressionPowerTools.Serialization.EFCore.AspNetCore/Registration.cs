// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore
{
    /// <summary>
    /// Register internal middleware services.
    /// </summary>
    public class Registration : IDependentServiceRegistration
    {
        /// <summary>
        /// Called after registration is complete.
        /// </summary>
        /// <remarks>
        /// Registers some useful EF Core types.
        /// </remarks>
        public void AfterRegistered()
        {
            ServiceHost.GetService<IRulesConfiguration>()
                .RuleForType(typeof(Microsoft.EntityFrameworkCore.EF))
                .RuleForType(typeof(Microsoft.EntityFrameworkCore.DbFunctionsExtensions))
                .RuleForType(typeof(Microsoft.EntityFrameworkCore.DbFunctions));
        }

        /// <summary>
        /// Register defaults for project.
        /// </summary>
        /// <param name="registration">The <see cref="IServiceRegistration"/>.</param>
        public void RegisterDefaultServices(IServiceRegistration registration)
        {
            registration.RegisterSingleton<IDbContextAdapter>(
                new DbContextAdapter());
            registration.RegisterSingleton<IRouteProcessor>(
                new RouteProcessor());
            registration.RegisterSingleton<IQueryDeserializer>(
                new QueryDeserializer());
            registration.RegisterSingleton<IQueryResultSerializer>(
                new QueryResultSerializer());
            registration.RegisterSingleton<Func<JsonSerializerOptions>>(
                () => new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true,
                });
        }
    }
}
