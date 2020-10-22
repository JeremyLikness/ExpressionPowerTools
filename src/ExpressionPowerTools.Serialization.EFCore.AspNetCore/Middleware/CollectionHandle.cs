// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware
{
    /// <summary>
    /// A handle that points to a context type and the property for the collection.
    /// </summary>
    public class CollectionHandle : IEquatable<CollectionHandle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionHandle"/> class with
        /// a <see cref="DbContext"/> type and <see cref="PropertyInfo"/> for the collection.
        /// </summary>
        /// <param name="dbContext">The type of the <see cref="DbContext"/>.</param>
        /// <param name="collection">The <see cref="PropertyInfo"/> of the collection.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context or collection are null.</exception>
        /// <exception cref="ArgumentException">Thrown when the type is not a <see cref="DbContext"/>.</exception>
        public CollectionHandle(Type dbContext, PropertyInfo collection)
        {
            Ensure.NotNull(() => dbContext);
            Ensure.NotNull(() => collection);
            if (!typeof(DbContext).IsAssignableFrom(dbContext))
            {
                throw new ArgumentException(
                    $"{dbContext.Name}!=DbContext",
                    nameof(dbContext));
            }

            if (collection.DeclaringType != dbContext)
            {
                throw new ArgumentException(
                    $"{collection.DeclaringType}!={dbContext}",
                    nameof(collection));
            }

            var propertyType = collection.PropertyType;
            if (!propertyType.IsGenericType ||
                !typeof(DbSet<>).IsAssignableFrom(propertyType.GetGenericTypeDefinition()))
            {
                throw new ArgumentException(
                    $"{propertyType}!={typeof(DbSet<>)}",
                    nameof(collection));
            }

            DbContextType = dbContext;
            Collection = collection;
        }

        /// <summary>
        /// Gets the type of the context.
        /// </summary>
        public Type DbContextType { get; private set; }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> of the collection.
        /// </summary>
        public PropertyInfo Collection { get; private set; }

        /// <summary>
        /// String view of collection handle.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (DbContextType == null)
            {
                return "<empty>";
            }

            if (Collection == null)
            {
                return $"{DbContextType.Name}:??";
            }

            var type = Collection.PropertyType.GenericTypeArguments[0];
            return $"${DbContextType.Name}: {Collection.Name}<{type}>";
        }

        /// <summary>
        /// Hash code for comparisons.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => HashCode.Combine(DbContextType, Collection);

        /// <summary>
        /// Determine equality in collection handles.
        /// </summary>
        /// <param name="other">The <see cref="CollectionHandle"/> to compare to.</param>
        /// <returns>A value indicating whether the two are equal.</returns>
        public bool Equals(CollectionHandle other)
        {
            if (other == null)
            {
                return false;
            }

            return DbContextType == other.DbContextType &&
                ReferenceEquals(Collection, other.Collection);
        }
    }
}
