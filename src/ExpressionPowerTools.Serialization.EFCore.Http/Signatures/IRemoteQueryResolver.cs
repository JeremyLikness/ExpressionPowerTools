// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Signatures
{
    /// <summary>
    /// Responsible for resolving remote queries.
    /// </summary>
    public interface IRemoteQueryResolver
    {
        /// <summary>
        /// Returns a single entity.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to return.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The entity.</returns>
        Task<T> FirstOrSingleAsync<T>(IQueryable<T> query);

        /// <summary>
        /// Resolves to a list.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
        /// <param name="query">The query to run remotely.</param>
        /// <returns>The list.</returns>
        Task<IList<T>> ToListAsync<T>(IQueryable<T> query);

        /// <summary>
        /// Resolves to an array.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
        /// <param name="query">The query to run remotely.</param>
        /// <returns>The array.</returns>
        Task<T[]> ToArrayAsync<T>(IQueryable<T> query);

        /// <summary>
        /// Resolves to a hash set.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
        /// <param name="query">The query to run remotely.</param>
        /// <returns>The <see cref="HashSet{T}"/>.</returns>
        Task<HashSet<T>> ToHashSetAsync<T>(IQueryable<T> query);

        /// <summary>
        /// Resolves to an enumerable.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
        /// <param name="query">The query to run remotely.</param>
        /// <returns>The enumerable.</returns>
        Task<IEnumerable<T>> AsEnumerableAsync<T>(IQueryable<T> query);

        /// <summary>
        /// Resolves to a count..
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
        /// <param name="query">The query to run remotely.</param>
        /// <returns>The count.</returns>
        Task<int> CountAsync<T>(IQueryable<T> query);
    }
}
