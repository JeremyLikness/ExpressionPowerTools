// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures
{
    /// <summary>
    /// Configuration for authorization rules.
    /// </summary>
    public interface IAuthorizationRulesBuilder
    {
        /// <summary>
        /// User must be authenticated to execute query.
        /// </summary>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        IAuthorizationRulesBuilder MustBeAuthenticatedToQueryAnyCollection();

        /// <summary>
        /// User must be authenticated to access the context.
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext"/>.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        IAuthorizationRulesBuilder MustBeAuthenticatedToQueryDbContext(Type dbContext);

        /// <summary>
        /// User must be authenticated to access the context.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the <see cref="DbContext"/>.</typeparam>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        IAuthorizationRulesBuilder MustBeAuthenticatedToQueryDbContext<TDbContext>()
            where TDbContext : DbContext;

        /// <summary>
        /// User must be authenticated to execute queries against the collection.
        /// </summary>
        /// <param name="dbContextType">The type of the <see cref="DbContext"/>.</param>
        /// <param name="collectionName">The name of the collection.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        IAuthorizationRulesBuilder MustBeAuthenticatedToQueryCollection(Type dbContextType, string collectionName);

        /// <summary>
        /// User must be authenticated to execute queries against the collection.
        /// </summary>
        /// <typeparam name="TDbContext">The context the rule applies to.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        IAuthorizationRulesBuilder MustBeAuthenticatedToQueryCollection<TDbContext>(string collectionName)
            where TDbContext : DbContext;

        /// <summary>
        /// User must be authenticated to execute queries against the collection.
        /// </summary>
        /// <typeparam name="TDbContext">The <see cref="DbContext"/> the rule applies to.</typeparam>
        /// <typeparam name="TEntityType">The type the collection contains.</typeparam>
        /// <param name="selector">An expression that references the collection.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        IAuthorizationRulesBuilder MustBeAuthenticatedToQueryCollection<TDbContext, TEntityType>(
            Expression<Func<TDbContext, DbSet<TEntityType>>> selector)
            where TDbContext : DbContext
            where TEntityType : class;
    }
}
