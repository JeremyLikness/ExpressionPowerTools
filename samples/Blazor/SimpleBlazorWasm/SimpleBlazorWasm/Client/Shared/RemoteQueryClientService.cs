// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization;
using ExpressionPowerTools.Serialization.Compression;
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
        /// Toggle for display.
        /// </summary>
        public enum DisplayType
        {
            /// <summary>
            /// Raw query.
            /// </summary>
            Query,

            /// <summary>
            /// Expression tree.
            /// </summary>
            QueryTree,

            /// <summary>
            /// Serialized tree.
            /// </summary>
            SerializedQuery,

            /// <summary>
            /// Compiled for transport.
            /// </summary>
            CompiledQuery,

            /// <summary>
            /// Type compressed.
            /// </summary>
            TypeCompressQuery,
        }

        /// <summary>
        /// Gets the query mode.
        /// </summary>
        public DisplayType QueryMode { get; private set; } = DisplayType.Query;

        /// <summary>
        /// Gets the query version based on the mode.
        /// </summary>
        public string QueryForMode
        {
            get
            {
                return QueryMode switch
                {
                    DisplayType.QueryTree => QueryTree,
                    DisplayType.SerializedQuery => SerializedQuery,
                    DisplayType.CompiledQuery => CompiledQuery,
                    DisplayType.TypeCompressQuery => TypeCompressedQuery,
                    _ => Query,
                };
            }
        }

        /// <summary>
        /// Gets the query text.
        /// </summary>
        public string Query { get; private set; }

        /// <summary>
        /// Gets the tree view of the query.
        /// </summary>
        public string QueryTree { get; private set; }

        /// <summary>
        /// Gets the serialized query.
        /// </summary>
        public string SerializedQuery { get; private set; }

        /// <summary>
        /// Gets the query after compilation/compression.
        /// </summary>
        public string CompiledQuery { get; private set; }

        /// <summary>
        /// Gets the query after type compression.
        /// </summary>
        public string TypeCompressedQuery { get; private set; }

        /// <summary>
        /// Gets the root query.
        /// </summary>
        protected override IQueryable<TypeThing> RootQuery =>
            DbClientContext<ThingContext>.Query(ctx => ctx.Types);

        /// <summary>
        /// Sets the current query mode.
        /// </summary>
        /// <param name="type">The <see cref="DisplayType"/> to use.</param>
        public void SetQueryMode(DisplayType type) =>
            QueryMode = type;

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
            WireUpQueryData(query);
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
            WireUpQueryData(query);
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
            WireUpQueryData(query);
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
                WireUpQueryData(query);
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
                WireUpQueryData(query);
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

        /// <summary>
        /// Wires up the data to display.
        /// </summary>
        /// <param name="query">The query.</param>
        protected void WireUpQueryData(IQueryable query)
        {
            Query = ParseForDisplay(query.Expression.ToString());
            QueryTree = query.AsEnumerableExpression().ToString();
            SerializedQuery = ParseForDisplay(
                Serializer.Serialize(
                    query,
                    config =>
                    config.CompressExpressionTree(true).CompressTypes(false)), true);
            CompiledQuery = ParseForDisplay(
                new TreeCompressionVisitor()
                .EvalAndCompress(query.Expression).ToString());
            TypeCompressedQuery = ParseForDisplay(
                Serializer.Serialize(
                    query,
                    config =>
                        config.CompressExpressionTree(true).CompressTypes(true)), true);
        }

        /// <summary>
        /// Parse to show.
        /// </summary>
        /// <param name="query">Source text.</param>
        /// <param name="json">A value indicating whether the payload is JSON.</param>
        /// <returns>The parsed text.</returns>
        private string ParseForDisplay(string query, bool json = false)
        {
            query = query.Replace(@"\u0060", "`")
                .Replace(@"\u00601", "`")
                .Replace(@"\u00602", "`");

            if (json)
            {
                var jsonParts = query.Split(":{");
                var firstSplit = string.Join(":{\r\n", jsonParts);
                jsonParts = firstSplit.Split("\":[");
                return string.Join("\":[\r\n", jsonParts);
            }

            var parts = query.Split(")");
            return string.Join(")\r\n", parts);
        }
    }
}
