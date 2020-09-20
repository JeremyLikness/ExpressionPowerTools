// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using Microsoft.EntityFrameworkCore;
using SimpleBlazorWasm.Shared;

namespace SimpleBlazorWasm.Client.Shared
{
    /// <summary>
    /// Options for take.
    /// </summary>
    public enum TakeOptions
    {
        /// <summary>
        /// Everything.
        /// </summary>
        All,

        /// <summary>
        /// Just 5.
        /// </summary>
        Take5,

        /// <summary>
        /// Just 20.
        /// </summary>
        Take20,
    }

    /// <summary>
    /// Options for skip.
    /// </summary>
    public enum SkipOptions
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Just 5.
        /// </summary>
        Skip5,

        /// <summary>
        /// Skip 20.
        /// </summary>
        Skip20,
    }

    /// <summary>
    /// Options for created.
    /// </summary>
    public enum CreatedOptions
    {
        /// <summary>
        /// Any time.
        /// </summary>
        Anytime,

        /// <summary>
        /// Over one week ago.
        /// </summary>
        WeekAgo,

        /// <summary>
        /// Over two weeks ago.
        /// </summary>
        TwoWeeksAgo,
    }

    /// <summary>
    /// Tracks the last call.
    /// </summary>
    public enum LastCall
    {
        /// <summary>
        /// Currently loading.
        /// </summary>
        Loading,

        /// <summary>
        /// Refresh list.
        /// </summary>
        Refresh,

        /// <summary>
        /// Count items.
        /// </summary>
        Count,

        /// <summary>
        /// Request single.
        /// </summary>
        Single,
    }

    /// <summary>
    /// Handles remote queries.
    /// </summary>
    public class RemoteQueryService
    {
        /// <summary>
        /// Raw name filter.
        /// </summary>
        private string nameFilterRaw;

        /// <summary>
        /// Name filter stripped of non-alpha.
        /// </summary>
        private string nameFilterSafe;

        /// <summary>
        /// The last call.
        /// </summary>
        private LastCall lastCall = LastCall.Refresh;

        /// <summary>
        /// Gets the list of things.
        /// </summary>
        public IList<Thing> Things { get; private set; } = null;

        /// <summary>
        /// Gets the count from the last count operation.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not it is currently loading.
        /// </summary>
        public bool Loading { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the sort is up or down.
        /// </summary>
        public bool Ascending { get; private set; }

        /// <summary>
        /// Gets the current sort.
        /// </summary>
        public string SortString
        {
            get => Ascending ? "Ascending" : "Descending";
        }

        /// <summary>
        /// Gets a value indicating whether the active flag should be filtered.
        /// </summary>
        public bool UseActive { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the filter is for active or not.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets the field for the ordering.
        /// </summary>
        public string OrderBy { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the result is a count.
        /// </summary>
        public bool IsCount { get; private set; }

        /// <summary>
        /// Gets the take status.
        /// </summary>
        public TakeOptions Take { get; private set; }

        /// <summary>
        /// Gets the skip status.
        /// </summary>
        public SkipOptions Skip { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the name should be filtered.
        /// </summary>
        public bool FilterOnName { get; private set; }

        /// <summary>
        /// Gets or sets the name filter.
        /// </summary>
        public string NameFilter
        {
            get => nameFilterRaw;
            set
            {
                if (value != nameFilterRaw)
                {
                    nameFilterRaw = value;
                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    nameFilterSafe = rgx.Replace(nameFilterRaw, string.Empty)
                        .Trim();
                }
            }
        }

        /// <summary>
        /// Gets the options for created date filtering.
        /// </summary>
        public CreatedOptions CreatedOptions { get; private set; }

        /// <summary>
        /// Gets the query text.
        /// </summary>
        public string Query
        {
            get => BuildQuery().Expression.ToString();
        }

        /// <summary>
        /// Method to change the order field.
        /// </summary>
        /// <param name="orderby">The name of the field.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SetOrderByAsync(string orderby)
        {
            OrderBy = orderby;
            return RefreshAsync();
        }

        /// <summary>
        /// Method to toggle a switch.
        /// </summary>
        /// <param name="name">The name of the switch.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task ToggleSwitchAsync(string name)
        {
            switch (name)
            {
                case nameof(Ascending):
                    Ascending = !Ascending;
                    break;
                case nameof(UseActive):
                    UseActive = !UseActive;
                    break;
                case nameof(IsActive):
                    IsActive = !IsActive;
                    break;
                case nameof(FilterOnName):
                    FilterOnName = !FilterOnName;
                    break;
            }

            return RefreshAsync();
        }

        /// <summary>
        /// Sets the <see cref="TakeOptions"/>.
        /// </summary>
        /// <param name="take">The option to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SetTakeAsync(TakeOptions take)
        {
            Take = take;
            return RefreshAsync();
        }

        /// <summary>
        /// Sets the <see cref="SkipOptions"/>.
        /// </summary>
        /// <param name="skip">The option to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SetSkipAsync(SkipOptions skip)
        {
            Skip = skip;
            return RefreshAsync();
        }

        /// <summary>
        /// Sets the <see cref="CreatedOptions"/>.
        /// </summary>
        /// <param name="create">The option to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SetCreatedAsync(CreatedOptions create)
        {
            CreatedOptions = create;
            return RefreshAsync();
        }

        /// <summary>
        /// Auto-refresh logic.
        /// </summary>
        /// <returns>A <see cref="Task"/> for asynchronous operations.</returns>
        public Task RefreshAsync()
        {
            if (Loading)
            {
                return Task.CompletedTask;
            }

            if (lastCall == LastCall.Refresh)
            {
                return LoadAsync();
            }

            if (lastCall == LastCall.Count)
            {
                return CountAsync();
            }

            return SingleAsync();
        }

        /// <summary>
        /// Loads a list.
        /// </summary>
        /// <returns>The <see cref="Task"/> for asynchronous operations.</returns>.
        public async Task LoadAsync()
        {
            var query = BuildQueryForRefresh();
            IsCount = false;
            lastCall = LastCall.Refresh;

            try
            {
                Things = await query.ExecuteRemote().ToListAsync();
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
        /// Grabs the count.
        /// </summary>
        /// <returns>The <see cref="Task"/> for asynchronous operations.</returns>
        public async Task CountAsync()
        {
            var query = BuildQueryForRefresh();
            IsCount = true;
            lastCall = LastCall.Count;

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
        /// Grabs a single item.
        /// </summary>
        /// <returns>The <see cref="Task"/> for asynchronous processing.</returns>
        public async Task SingleAsync()
        {
            var query = BuildQueryForRefresh();
            IsCount = false;
            lastCall = LastCall.Single;

            try
            {
                var thing = await query.ExecuteRemote().FirstOrSingleAsync();
                if (thing != null)
                {
                    Things = new List<Thing>
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
        /// Builds the query and sets default flags.
        /// </summary>
        /// <returns>The query.</returns>
        private IQueryable<Thing> BuildQueryForRefresh()
        {
            lastCall = LastCall.Loading;
            Error = null;
            Loading = true;
            Things = null;

            return BuildQuery();
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns>The query.</returns>
        private IQueryable<Thing> BuildQuery()
        {
            var core = DbClientContext<ThingContext>.Query(context => context.Things);
            core = QueryActive(core);
            core = QueryName(core);
            core = QueryCreated(core);
            core = Ascending ? QueryAscending(core) : QueryDescending(core);
            core = QuerySkip(core);
            core = QueryTake(core);
            return core;
        }

        /// <summary>
        /// Active portion.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QueryActive(IQueryable<Thing> core) =>
            UseActive ? core.Where(t => t.IsActive == IsActive) : core;

        /// <summary>
        /// Name portion.
        /// </summary>
        /// <remarks>
        /// Shows using a database-specific extension from the client.
        /// </remarks>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QueryName(IQueryable<Thing> core) =>
            FilterOnName && !string.IsNullOrWhiteSpace(nameFilterSafe) ?
            core.Where(t => EF.Functions.Like(t.Name, $"%{nameFilterSafe}%")) : core;

        /// <summary>
        /// Created portion.
        /// </summary>
        /// <remarks>
        /// This uses the EF static method showing that even those queries
        /// translate.
        /// </remarks>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QueryCreated(IQueryable<Thing> core) =>
            CreatedOptions == CreatedOptions.Anytime ?
            core : core.Where(
                t => EF.Property<DateTime>(t, nameof(Thing.Created)) < DateTime.Now.AddDays(
                    -1 * (CreatedOptions == CreatedOptions.WeekAgo ? 7 : 14)));

        /// <summary>
        /// Sort ascending.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QueryAscending(IQueryable<Thing> core) =>
            OrderBy switch
            {
                nameof(Thing.Id) => core.OrderBy(t => t.Id),
                nameof(Thing.Created) => core.OrderBy(t => t.Created),
                nameof(Thing.Value) => core.OrderBy(t => t.Value),
                _ => core.OrderBy(t => t.Name),
            };

        /// <summary>
        /// Sort ascending.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QueryDescending(IQueryable<Thing> core) =>
            OrderBy switch
            {
                nameof(Thing.Id) => core.OrderByDescending(t => t.Id),
                nameof(Thing.Created) => core.OrderByDescending(t => t.Created),
                nameof(Thing.Value) => core.OrderByDescending(t => t.Value),
                _ => core.OrderBy(t => t.Name),
            };

        /// <summary>
        /// Skip portion.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QuerySkip(IQueryable<Thing> core) =>
            Skip == SkipOptions.None ?
            core : core.Skip(Skip == SkipOptions.Skip5 ? 5 : 20);

        /// <summary>
        /// Take portion.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<Thing> QueryTake(IQueryable<Thing> core) =>
            Take == TakeOptions.All ?
            core : core.Take(Take == TakeOptions.Take5 ? 5 : 20);
    }
}
