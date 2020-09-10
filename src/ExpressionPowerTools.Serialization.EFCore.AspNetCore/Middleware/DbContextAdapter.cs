// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware
{
    /// <summary>
    /// Adapter to <see cref="DbContext"/>.
    /// </summary>
    public class DbContextAdapter : IDbContextAdapter
    {
        /// <summary>
        /// Creates a query with the provided <see cref="DbContext"/>.
        /// </summary>
        /// <remarks>
        /// This is the same as doing <c>Context.Products.AsQueryable()</c>.
        /// </remarks>
        /// <param name="context">The <see cref="DbContext"/>.</param>
        /// <param name="collection">The <see cref="PropertyInfo"/> for the collection.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the context or collection are null.</exception>.
        /// <exception cref="NullReferenceException">Thrown when the collection or queryable won't resolve.</exception>
        public IQueryable CreateQuery(DbContext context, PropertyInfo collection)
        {
            Ensure.NotNull(() => context);
            Ensure.NotNull(() => collection);
            var dbSet = collection.GetValue(context);
            Ensure.VariableNotNull(() => dbSet);
            if (!collection.PropertyType.IsGenericType ||
                !typeof(DbSet<>).IsAssignableFrom(collection.PropertyType.GetGenericTypeDefinition()))
            {
                throw new ArgumentException(
                    $"{collection.PropertyType}!={typeof(DbSet<>)}",
                    nameof(collection));
            }

            var asQueryable = dbSet.GetType().GetMethod(nameof(Queryable.AsQueryable));
            Ensure.VariableNotNull(() => asQueryable);
            return asQueryable.Invoke(dbSet, null) as IQueryable;
        }

        /// <summary>
        /// Tries to match context name with the list of eligible types.
        /// </summary>
        /// <param name="eligibleTypes">The list of potential <see cref="DbContext"/> types.</param>
        /// <param name="context">The context name.</param>
        /// <param name="dbContextType">The type of the matched <see cref="DbContext"/>.</param>
        /// <returns>A value indicating whether the match was successful.</returns>
        public bool TryGetContext(Type[] eligibleTypes, string context, out Type dbContextType)
        {
            eligibleTypes = eligibleTypes ?? new Type[0];
            context = context ?? string.Empty;
            var match = context.ToLowerInvariant().Trim();
            dbContextType = eligibleTypes.FirstOrDefault(t =>
                typeof(DbContext).IsAssignableFrom(t) &&
                t.Name.ToLowerInvariant() == match);
            return dbContextType != null;
        }

        /// <summary>
        /// Tries to match the collection to a property on the context.
        /// </summary>
        /// <param name="context">The type of the <see cref="DbContext"/>.</param>
        /// <param name="collection">The name of the collection.</param>
        /// <param name="dbSet">The <see cref="PropertyInfo"/> for the collection.</param>
        /// <returns>A value indicating whether the property matched.</returns>
        public bool TryGetDbSet(Type context, string collection, out PropertyInfo dbSet)
        {
            if (context == null || string.IsNullOrWhiteSpace(collection))
            {
                dbSet = null;
                return false;
            }

            if (typeof(DbContext).IsAssignableFrom(context))
            {
                var match = collection.ToLowerInvariant().Trim();
                dbSet = context.GetProperties().FirstOrDefault(
                    p => p.Name.ToLowerInvariant() == match
                    && p.PropertyType.IsGenericType
                    && typeof(DbSet<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()));
                return dbSet != null;
            }

            dbSet = null;
            return false;
        }
    }
}
