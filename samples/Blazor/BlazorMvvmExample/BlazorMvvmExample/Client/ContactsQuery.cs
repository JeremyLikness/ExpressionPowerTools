// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared;
using BlazorMvvmExample.Shared.Data;
using BlazorMvvmExample.Shared.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;

namespace BlazorMvvmExample.Client
{
    /// <summary>
    /// Materializes queries for contacts.
    /// </summary>
    public class ContactsQuery : IContactsQuery
    {
        /// <summary>
        /// Gets the base query to operate on.
        /// </summary>
        /// <returns>The base query.</returns>
        public IQueryable<Contact> GetBaseQuery() =>
            DbClientContext<ContactContext>.Query(ctx => ctx.Contacts);

        /// <summary>
        /// Gets the count for the filter.
        /// </summary>
        /// <param name="query">The source query.</param>
        /// <returns>The items count.</returns>
        public Task<int> GetCountAsync(IQueryable<Contact> query) =>
            query.ExecuteRemote().CountAsync();

        /// <summary>
        /// Gets the contact list.
        /// </summary>
        /// <param name="query">The filter.</param>
        /// <returns>The contact list.</returns>
        public Task<List<Contact>> GetContactsAsync(IQueryable<Contact> query) =>
            query.ExecuteRemote().ToListAsync();

        /// <summary>
        /// Combines two requests to get counts and contacts.
        /// </summary>
        /// <param name="query">The filter.</param>
        /// <param name="queryPage">The filter with paging applied.</param>
        /// <returns>The list of contacts.</returns>
        public async Task<(int count, List<Contact> contacts)>
            GetContactsWithCountAsync(IQueryable<Contact> query, IQueryable<Contact> queryPage) =>
            (await GetCountAsync(query).ConfigureAwait(false),
             await GetContactsAsync(queryPage).ConfigureAwait(false));
    }
}
