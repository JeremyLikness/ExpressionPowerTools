// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;

namespace BlazorMvvmExample.Shared.ViewModels
{
    /// <summary>
    /// Filter view model.
    /// </summary>
    public class FilteringViewModel : BaseViewModel
    {
        /// <summary>
        /// A value indicating whether to show the filter.
        /// </summary>
        private bool showFilter;

        /// <summary>
        /// Filter for last name.
        /// </summary>
        private string lastNameFilter = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether to show the filter.
        /// </summary>
        public bool ShowFilter
        {
            get => showFilter;
            set => SetProperty(ref showFilter, value);
        }

        /// <summary>
        /// Gets or sets the last name filter.
        /// </summary>
        public string LastNameFilter
        {
            get => lastNameFilter;
            set => SetProperty(ref lastNameFilter, value);
        }

        /// <summary>
        /// Applies the filter logic to the query.
        /// </summary>
        /// <param name="query">The query to filter.</param>
        /// <returns>The filtered query.</returns>
        public IQueryable<Contact> ApplyFilter(IQueryable<Contact> query)
        {
            if (lastNameFilter.Length > 2)
            {
                query = query.Where(c => c.LastName.StartsWith(lastNameFilter));
            }

            return query;
        }
    }
}
