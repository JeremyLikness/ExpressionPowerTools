// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Authorization
{
    /// <summary>
    /// Authorization rules to manage access to queries.
    /// </summary>
    public class AuthorizationRules : IAuthorizationRules, IAuthorizationRulesBuilder
    {
        /// <summary>
        /// Collections that require authentication.
        /// </summary>
        private readonly HashSet<CollectionHandle> requiredCollectionAuth = new HashSet<CollectionHandle>();

        /// <summary>
        /// Types of <see cref="DbContext"/> that require authentication.
        /// </summary>
        private readonly HashSet<Type> requiredContextAuth = new HashSet<Type>();

        /// <summary>
        /// A value indicating whether users must be authenticated to access any collections.
        /// </summary>
        private bool mustBeAuthenticatedAny = false;

        /// <summary>
        /// Gets or sets the delegate to obtain the principal.
        /// </summary>
        private Func<HttpContext> getContext = null;

        /// <summary>
        /// One time setup of the principal.
        /// </summary>
        /// <param name="func">The function to return the <see cref="HttpContext"/>.</param>
        public void SetContextGetter(Func<HttpContext> func)
        {
            if (getContext == null)
            {
                getContext = func;
            }
        }

        /// <summary>
        /// Requires the user to be successfully signed in.
        /// </summary>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        public IAuthorizationRulesBuilder MustBeAuthenticatedToQueryAnyCollection()
        {
            mustBeAuthenticatedAny = true;
            return this;
        }

        /// <summary>
        /// User must be authenticated to execute queries against the collection.
        /// </summary>
        /// <param name="dbContextType">The type of the <see cref="DbContext"/>.</param>
        /// <param name="collectionName">The name of the collection.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        public IAuthorizationRulesBuilder MustBeAuthenticatedToQueryCollection(
            Type dbContextType,
            string collectionName)
        {
            Ensure.NotNull(() => dbContextType);
            Ensure.NotNullOrWhitespace(() => collectionName);
            if (!TryVerifyTemplate(dbContextType, collectionName, out CollectionHandle handle))
            {
                throw new ArgumentException($"{collectionName} != DbSet", nameof(collectionName));
            }

            requiredCollectionAuth.Add(handle);
            return this;
        }

        /// <summary>
        /// User must be authenticated to execute queries against the collection.
        /// </summary>
        /// <typeparam name="TDbContext">The context the rule applies to.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        public IAuthorizationRulesBuilder MustBeAuthenticatedToQueryCollection<TDbContext>(string collectionName)
            where TDbContext : DbContext
            => MustBeAuthenticatedToQueryCollection(typeof(TDbContext), collectionName);

        /// <summary>
        /// User must be authenticated to execute queries against the collection.
        /// </summary>
        /// <typeparam name="TDbContext">The <see cref="DbContext"/> the rule applies to.</typeparam>
        /// <typeparam name="TEntityType">The type the collection contains.</typeparam>
        /// <param name="selector">An expression that references the collection.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        public IAuthorizationRulesBuilder MustBeAuthenticatedToQueryCollection<TDbContext, TEntityType>(
            Expression<Func<TDbContext, DbSet<TEntityType>>> selector)
            where TDbContext : DbContext
            where TEntityType : class
        {
            Ensure.NotNull(() => selector);
            var memberExpression = selector.AsEnumerable().OfType<MemberExpression>().First();
            return MustBeAuthenticatedToQueryCollection(typeof(TDbContext), memberExpression.Member.Name);
        }

        /// <summary>
        /// User must be authenticated to access the context.
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext"/>.</param>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        public IAuthorizationRulesBuilder MustBeAuthenticatedToQueryDbContext(Type dbContext)
        {
            Ensure.NotNull(() => dbContext);
            if (typeof(DbContext).IsAssignableFrom(dbContext))
            {
                requiredContextAuth.Add(dbContext);
                return this;
            }

            throw new ArgumentException($"{typeof(DbContext).Name} != DbContext", nameof(dbContext));
        }

        /// <summary>
        /// User must be authenticated to access the context.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the <see cref="DbContext"/>.</typeparam>
        /// <returns>The <see cref="IAuthorizationRulesBuilder"/>.</returns>
        public IAuthorizationRulesBuilder MustBeAuthenticatedToQueryDbContext<TDbContext>()
            where TDbContext : DbContext => MustBeAuthenticatedToQueryDbContext(typeof(TDbContext));

        /// <summary>
        /// Single method determines whether the user is authorized or not.
        /// </summary>
        /// <returns>A value indicating whether the user is authorized to run queries.</returns>
        public bool IsAuthorized()
        {
            var context = getContext == null ? null : getContext();
            var currentPrincipal = context?.User;
            var isAuthenticated = currentPrincipal != null &&
                currentPrincipal.Identity != null &&
                currentPrincipal.Identity.IsAuthenticated;

            var handle = context.Items[nameof(CollectionHandle)] as CollectionHandle;

            if (mustBeAuthenticatedAny)
            {
                return isAuthenticated;
            }

            if (handle != null && requiredCollectionAuth.Contains(handle))
            {
                return isAuthenticated;
            }

            return true;
        }

        /// <summary>
        /// Verifies the collection name passed is a collection on the context.
        /// </summary>
        /// <param name="dbContextType">The type of the <see cref="DbContext"/>.</param>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="collectionHandle">The <see cref="CollectionHandle"/>.</param>
        /// <returns>A value indicating whether it is a collection on the context.</returns>
        private bool TryVerifyTemplate(Type dbContextType, string collectionName, out CollectionHandle collectionHandle)
        {
            collectionHandle = null;

            if (typeof(DbContext).IsAssignableFrom(dbContextType))
            {
                var property = dbContextType.GetProperty(collectionName);
                if (property != null &&
                    property.PropertyType.IsGenericType &&
                    !property.PropertyType.IsGenericTypeDefinition &&
                    typeof(DbSet<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
                {
                    collectionHandle = new CollectionHandle(dbContextType, property);
                }
            }

            return collectionHandle != null;
        }
    }
}
