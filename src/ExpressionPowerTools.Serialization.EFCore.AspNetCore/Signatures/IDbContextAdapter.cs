// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures
{
    /// <summary>
    /// Services to interface with a configured <see cref="DbContext"/>.
    /// </summary>
    public interface IDbContextAdapter
    {
        /// <summary>
        /// Tries to get the <see cref="PropertyInfo"/> to access the collection.
        /// </summary>
        /// <param name="context">The type of the <c>DbContext</c>.</param>
        /// <param name="collection">The name of the collection. This is the <c>DbSet&lt;T></c> property name.</param>
        /// <param name="dbSet">The resolved <see cref="PropertyInfo"/> for the collection.</param>
        /// <returns>A value indicating whether nor not the collection on the context is valid.</returns>
        bool TryGetDbSet(Type context, string collection, out PropertyInfo dbSet);

        /// <summary>
        /// Tries to match the text to the context.
        /// </summary>
        /// <param name="eligibleTypes">The list of registered <see cref="DbContext"/> types.</param>
        /// <param name="context">The name of the <c>DbContext</c>.</param>
        /// <param name="dbContextType">The resolved type.</param>
        /// <returns>A value indicating whether nor not the collection on the context is valid.</returns>
        bool TryGetContext(Type[] eligibleTypes, string context, out Type dbContextType);

        /// <summary>
        /// Creates an <see cref="IQueryable"/> based on the context and collection. Takes an action for the
        /// resolution of the context. This is typically <c>t => serviceProvider.GetService(t)</c>.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/>.</param>
        /// <param name="collection">The name of the collection used as the basis for the query.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable CreateQuery(DbContext context, PropertyInfo collection);
    }
}
