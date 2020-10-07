// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleBlazorWasm.Shared
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
        /// Gets or sets the list of things.
        /// </summary>
        public IList<TypeThing> Things { get; protected set; } = null;

        /// <summary>
        /// Gets or sets the grouped things.
        /// </summary>
        public IList<GroupedThing> GroupedThings
        { get; protected set; } = null;

        /// <summary>
        /// Gets or sets the related things.
        /// </summary>
        public IList<RelatedThing> RelatedThings
        { get; protected set; } = null;

        /// <summary>
        /// Gets or sets the count from the last count operation.
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Error { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not it is currently loading.
        /// </summary>
        public bool Loading { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sort is up or down.
        /// </summary>
        public bool Ascending { get; protected set; }

        /// <summary>
        /// Gets the current sort.
        /// </summary>
        public string SortString
        {
            get => Ascending ? "Ascending" : "Descending";
        }

        /// <summary>
        /// Gets or sets a value indicating whether the active flag should be filtered.
        /// </summary>
        public bool UseActive { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the filter is for active or not.
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// Gets or sets the field for the ordering.
        /// </summary>
        public string OrderBy { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the result is a count.
        /// </summary>
        public bool IsCount { get; protected set; }

        /// <summary>
        /// Gets or sets the take status.
        /// </summary>
        public TakeOptions Take { get; protected set; }

        /// <summary>
        /// Gets or sets the skip status.
        /// </summary>
        public SkipOptions Skip { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the name should be filtered.
        /// </summary>
        public bool FilterOnName { get; protected set; }

        /// <summary>
        /// Gets or sets the name filter.
        /// </summary>
        public string NameFilter
        {
            get => NameFilterRaw;
            set
            {
                if (value != NameFilterRaw)
                {
                    NameFilterRaw = value;
                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    NameFilterSafe = rgx.Replace(NameFilterRaw, string.Empty)
                        .Trim();
                }
            }
        }

        /// <summary>
        /// Gets the options for created date filtering.
        /// </summary>
        public CreatedOptions CreatedOptions { get; private set; }

        /// <summary>
        /// Gets the root query.
        /// </summary>
        protected virtual IQueryable<TypeThing> RootQuery =>
            new List<TypeThing>().AsQueryable();

        /// <summary>
        /// Gets or sets the last call type.
        /// </summary>
        protected LastCall LastCall { get; set; } = LastCall.Refresh;

        /// <summary>
        /// Gets or sets the raw name filter.
        /// </summary>
        protected string NameFilterRaw { get; set; }

        /// <summary>
        /// Gets or sets the safe name filter.
        /// </summary>
        protected string NameFilterSafe { get; set; }

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
        /// Refresh.
        /// </summary>
        /// <returns>The asynchronous <see cref="Task"/>.</returns>
        public virtual Task RefreshAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Builds the query and sets default flags.
        /// </summary>
        /// <returns>The query.</returns>
        protected IQueryable<TypeThing> BuildQueryForRefresh()
        {
            LastCall = LastCall.Loading;
            Error = null;
            Loading = true;
            Things = null;

            return BuildQuery();
        }

        /// <summary>
        /// Build the query for group by.
        /// </summary>
        /// <returns>The query.</returns>
        protected IQueryable<GroupedThing> BuildQueryForGroupBy()
        {
            var query = BuildQuery();
            var result = query
                    .GroupBy(t => t.Name)
                    .Select(g =>
                    new GroupedThing
                    {
                        Name = g.Key,
                        Count = g.Count(),
                    })
                    .OrderBy(group => group.Name);
            return result;
        }

        /// <summary>
        /// Build the query for related things.
        /// </summary>
        /// <returns>The query.</returns>
        protected IQueryable<RelatedThing> BuildQueryForRelated()
        {
            var query = BuildQuery();
            var result = query
                    .Where(t => t.Name != null)
                    .SelectMany(
                        t =>
                        t.Methods, (t, m) =>
                        new
                        {
                            t.Name,
                            MethodName = m.Name,
                            m.Parameters,
                        })
                    .SelectMany(
                        tm => tm.Parameters,
                        (tm, p) =>
                        new RelatedThing
                        {
                            TypeName = tm.Name,
                            MethodName = tm.MethodName,
                            ParameterName = p.Name,
                        })
                    .OrderBy(r => r.TypeName)
                    .ThenBy(r => r.MethodName)
                    .ThenBy(r => r.ParameterName);
            return result;
        }

        /// <summary>
        /// Query name.
        /// </summary>
        /// <param name="core">The core query.</param>
        /// <returns>The queryable.</returns>
        protected virtual IQueryable<TypeThing> QueryName(IQueryable<TypeThing> core) =>
            core;

        /// <summary>
        /// The created query.
        /// </summary>
        /// <param name="core">The core of the query.</param>
        /// <returns>The queryable.</returns>
        protected virtual IQueryable<TypeThing> QueryCreated(IQueryable<TypeThing> core) =>
            core;

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns>The query.</returns>
        protected IQueryable<TypeThing> BuildQuery()
        {
            var core = RootQuery;
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
        protected virtual IQueryable<TypeThing> QueryActive(IQueryable<TypeThing> core) =>
            UseActive ? core.Where(t => t.IsActive == IsActive) : core;

        /// <summary>
        /// Sort ascending.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        protected IQueryable<TypeThing> QueryAscending(IQueryable<TypeThing> core) =>
            OrderBy switch
            {
                nameof(TypeThing.Id) => core.OrderBy(t => t.Id),
                nameof(TypeThing.Created) => core.OrderBy(t => t.Created),
                nameof(TypeThing.Value) => core.OrderBy(t => t.Value),
                _ => core.OrderBy(t => t.Name),
            };

        /// <summary>
        /// Sort ascending.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<TypeThing> QueryDescending(IQueryable<TypeThing> core) =>
            OrderBy switch
            {
                nameof(TypeThing.Id) => core.OrderByDescending(t => t.Id),
                nameof(TypeThing.Created) => core.OrderByDescending(t => t.Created),
                nameof(TypeThing.Value) => core.OrderByDescending(t => t.Value),
                _ => core.OrderBy(t => t.Name),
            };

        /// <summary>
        /// Skip portion.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<TypeThing> QuerySkip(IQueryable<TypeThing> core) =>
            Skip == SkipOptions.None ?
            core : core.Skip(Skip == SkipOptions.Skip5 ? 5 : 20);

        /// <summary>
        /// Take portion.
        /// </summary>
        /// <param name="core">The query.</param>
        /// <returns>The modified query.</returns>
        private IQueryable<TypeThing> QueryTake(IQueryable<TypeThing> core) =>
            Take == TakeOptions.All ?
            core : core.Take(Take == TakeOptions.Take5 ? 5 : 20);
    }
}
