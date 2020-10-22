// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMvvmExample.Shared.Signatures
{
    /// <summary>
    /// Host for query operations.
    /// </summary>
    public interface IContactsQuery
    {
        /// <summary>
        /// Gets the base query to operate on.
        /// </summary>
        /// <returns>The base query.</returns>
        IQueryable<Contact> GetBaseQuery();

        /// <summary>
        /// Gets the count for the filter.
        /// </summary>
        /// <param name="query">The source query.</param>
        /// <returns>The items count.</returns>
        Task<int> GetCountAsync(IQueryable<Contact> query);

        /// <summary>
        /// Gets the contact list.
        /// </summary>
        /// <param name="query">The filter.</param>
        /// <returns>The contact list.</returns>
        Task<List<Contact>> GetContactsAsync(IQueryable<Contact> query);

        /// <summary>
        /// Combines two requests to get counts and contacts.
        /// </summary>
        /// <param name="query">The filter.</param>
        /// <param name="queryPage">The filter with paging applied.</param>
        /// <returns>The list of contacts.</returns>
        Task<(int count, List<Contact> contacts)> GetContactsWithCountAsync(
            IQueryable<Contact> query,
            IQueryable<Contact> queryPage);
    }
}
