// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using Microsoft.EntityFrameworkCore;
using SimpleBlazorWasm.Shared;

namespace SimpleBlazorWasm.Client.Shared
{
    /// <summary>
    /// The client remote query service.
    /// </summary>
    public class RemoteQueryClientService : RemoteQueryService
    {
        /// <summary>
        /// Gets the query text.
        /// </summary>
        public string Query
        {
            get => BuildQuery().Expression.ToString();
        }

        /// <summary>
        /// Gets the root query.
        /// </summary>
        protected override IQueryable<TypeThing> RootQuery =>
            DbClientContext<ThingContext>.Query(ctx => ctx.Types);

        /// <summary>
        /// Auto-refresh logic.
        /// </summary>
        /// <returns>A <see cref="Task"/> for asynchronous operations.</returns>
        public override Task RefreshAsync()
        {
            if (Loading)
            {
                return Task.CompletedTask;
            }

            if (LastCall == LastCall.Refresh)
            {
                return LoadAsync();
            }

            if (LastCall == LastCall.Count)
            {
                return CountAsync();
            }

            return SingleAsync();
        }

        /// <summary>
        /// Grabs a single item.
        /// </summary>
        /// <returns>The <see cref="Task"/> for asynchronous processing.</returns>
        public async Task SingleAsync()
        {
            var query = BuildQueryForRefresh();
            IsCount = false;
            LastCall = LastCall.Single;

            try
            {
                var thing = await query.ExecuteRemote().FirstOrSingleAsync();
                if (thing != null)
                {
                    Things = new List<TypeThing>
                    {
                        thing,
                    };
                    Count = 0;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Grabs the count.
        /// </summary>
        /// <returns>The <see cref="Task"/> for asynchronous operations.</returns>
        public async Task CountAsync()
        {
            var query = BuildQueryForRefresh();
            IsCount = true;
            LastCall = LastCall.Count;

            try
            {
                Count = await query.ExecuteRemote().CountAsync();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Loads a list.
        /// </summary>
        /// <returns>The <see cref="Task"/> for asynchronous operations.</returns>.
        public async Task LoadAsync()
        {
            var query = BuildQueryForRefresh();
            IsCount = false;
            LastCall = LastCall.Refresh;

            try
            {
                Things = await query.ExecuteRemote().ToListAsync();
                GroupedThings = null;
                RelatedThings = null;
                Count = 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Call group by.
        /// </summary>
        /// <returns>The grouped list.</returns>
        public async Task GroupByAsync()
        {
            Loading = true;
            Things = null;
            GroupedThings = null;
            RelatedThings = null;
            try
            {
                var query = BuildQueryForGroupBy();

                GroupedThings = await query.ExecuteRemote()
                    .ToListAsync();
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Call related things.
        /// </summary>
        /// <returns>The related list.</returns>
        public async Task RelatedThingsAsync()
        {
            Loading = true;
            Things = null;
            GroupedThings = null;
            RelatedThings = null;
            try
            {
                var query = BuildQueryForRelated();

                RelatedThings = await query.ExecuteRemote()
                    .ToListAsync();
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Name portion.
        /// </summary>
        /// <remarks>
        /// Shows using a database-specific extension from the client.
        /// </remarks>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        protected override IQueryable<TypeThing> QueryName(IQueryable<TypeThing> core) =>
            FilterOnName && !string.IsNullOrWhiteSpace(NameFilterSafe) ?
            core.Where(t => EF.Functions.Like(t.Name, $"%{NameFilterSafe}%")) : core;

        /// <summary>
        /// Created portion.
        /// </summary>
        /// <remarks>
        /// This uses the EF static method showing that even those queries
        /// translate.
        /// </remarks>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        protected override IQueryable<TypeThing> QueryCreated(IQueryable<TypeThing> core) =>
            CreatedOptions == CreatedOptions.Anytime ?
            core : core.Where(
                t => EF.Property<DateTime>(t, nameof(TypeThing.Created)) < DateTime.Now.AddDays(
                    -1 * (CreatedOptions == CreatedOptions.WeekAgo ? 7 : 14)));
     }
}
