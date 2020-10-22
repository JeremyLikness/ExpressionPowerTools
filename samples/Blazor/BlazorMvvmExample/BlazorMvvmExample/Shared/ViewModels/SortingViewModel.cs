// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BlazorMvvmExample.Shared.Commands;
using BlazorMvvmExample.Shared.Signatures;

namespace BlazorMvvmExample.Shared.ViewModels
{
    /// <summary>
    /// View model to handle sorting.
    /// </summary>
    public class SortingViewModel : BaseViewModel
    {
        /// <summary>
        /// Selectors for each column.
        /// </summary>
        private readonly IDictionary<string, Expression<Func<Contact, string>>> selectors =
            new Dictionary<string, Expression<Func<Contact, string>>>
            {
                { nameof(Contact.FirstName), c => c.FirstName },
                { nameof(Contact.LastName), c => c.LastName },
                { nameof(Contact.Phone), c => c.Phone },
                { nameof(Contact.Street), c => c.Street },
                { nameof(Contact.City), c => c.City },
                { nameof(Contact.State), c => c.State },
                { nameof(Contact.ZipCode), c => c.ZipCode },
            };

        /// <summary>
        /// The sort column.
        /// </summary>
        private string sortColumn = nameof(Contact.LastName);

        /// <summary>
        /// A value indicating the direction of the sort.
        /// </summary>
        private bool sortAscending = true;

        /// <summary>
        /// The second sort column.
        /// </summary>
        private string thenByColumn = nameof(Contact.FirstName);

        /// <summary>
        /// A value indicating the direction of the second sort.
        /// </summary>
        private bool thenByAscending = true;

        /// <summary>
        /// Disabled while loading.
        /// </summary>
        private bool disabled = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingViewModel"/> class.
        /// </summary>
        public SortingViewModel()
        {
            SortCommand = new MvvmCommand<string>(
                col => SortExecute(this, col),
                col => SortCanExecute(this, col))
                .SetName(nameof(SortCommand));
            ThenByCommand = new MvvmCommand<string>(
                col => ThenByExecute(this, col),
                col => ThenByCanExecute(this, col))
                .SetName(nameof(ThenByCommand));
            ClearCommand = new MvvmCommand<string>(
                col => ClearSecondarySort(),
                col => col == ThenByColumn)
                .SetName(nameof(ClearCommand));
            Commands = new[] { SortCommand, ThenByCommand, ClearCommand };
        }

        /// <summary>
        /// Gets the sort command.
        /// </summary>
        public IMvvmCommand<string> SortCommand { get; private set; }

        /// <summary>
        /// Gets the then by command.
        /// </summary>
        public IMvvmCommand<string> ThenByCommand { get; private set; }

        /// <summary>
        /// Gets the clear command.
        /// </summary>
        public IMvvmCommand<string> ClearCommand { get; private set; }

        /// <summary>
        /// Gets or sets the primary sort column.
        /// </summary>
        public string SortColumn
        {
            get => sortColumn;
            set => SetPropertyAndNotify(ref sortColumn, value, nameof(SortColumn));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sort is ascending.
        /// </summary>
        public bool SortAscending
        {
            get => sortAscending;
            set => SetPropertyAndNotify(ref sortAscending, value, nameof(SortAscending));
        }

        /// <summary>
        /// Gets or sets the secondary sort column.
        /// </summary>
        public string ThenByColumn
        {
            get => thenByColumn;
            set => SetPropertyAndNotify(ref thenByColumn, value, nameof(ThenByColumn));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the secondary sort is ascending.
        /// </summary>
        public bool ThenByAscending
        {
            get => thenByAscending;
            set => SetPropertyAndNotify(ref thenByAscending, value, nameof(ThenByAscending));
        }

        /// <summary>
        /// Gets or sets a value indicating whether interaction is disabled.
        /// </summary>
        public bool Disabled
        {
            get => disabled;
            set => SetPropertyAndNotify(ref disabled, value, nameof(Disabled));
        }

        /// <summary>
        /// Toggle the sort direction, or toggle the secondary sort, or
        /// choose a new sort column.
        /// </summary>
        /// <param name="columnName">The name of the column to toggle sort.</param>
        public void ToggleColumn(string columnName)
        {
            if (disabled)
            {
                return;
            }

            if (sortColumn == columnName)
            {
                SortAscending = !SortAscending;
            }
            else if (thenByColumn == columnName)
            {
                ToggleSecondaryColumn(columnName);
            }
            else
            {
                sortAscending = true;
                thenByColumn = string.Empty;
                SortColumn = columnName;
            }
        }

        /// <summary>
        /// Add a secondary sort, toggle secondary sort direction,
        /// or change secondary sort.
        /// </summary>
        /// <param name="columnName">The name of the column to toggle.</param>
        public void ToggleSecondaryColumn(string columnName)
        {
            if (disabled)
            {
                return;
            }

            if (thenByColumn == columnName)
            {
                ThenByAscending = !ThenByAscending;
            }
            else if (sortColumn == columnName)
            {
                ToggleColumn(columnName);
            }
            else
            {
                thenByAscending = true;
                ThenByColumn = columnName;
            }
        }

        /// <summary>
        /// Clears the secondary sort.
        /// </summary>
        public void ClearSecondarySort()
        {
            if (disabled)
            {
                return;
            }

            ThenByColumn = string.Empty;
        }

        /// <summary>
        /// Applies the sort to the query.
        /// </summary>
        /// <param name="query">The query to apply the sort to.</param>
        /// <returns>The sorted query.</returns>
        public IQueryable<Contact> ApplySort(IQueryable<Contact> query)
        {
            var sortCol = selectors[SortColumn];
            IOrderedQueryable<Contact> result =
                sortAscending ? query.OrderBy(sortCol)
                : query.OrderByDescending(sortCol);
            if (!string.IsNullOrEmpty(ThenByColumn))
            {
                var thenCol = selectors[ThenByColumn];
                result = thenByAscending ? result.ThenBy(thenCol)
                    : result.ThenByDescending(thenCol);
            }

            return result.AsQueryable();
        }

        /// <summary>
        /// Logic to allow toggling the column.
        /// </summary>
        /// <remarks>
        /// If the column is the sort column or the secondary sort column, it
        /// will toggle the sort direction. If there is no secondary sort column,
        /// it will change the primary sort. Otherwise it does nothing.
        /// </remarks>
        /// <param name="vm">The <see cref="SortingViewModel"/>.</param>
        /// <param name="col">The column name.</param>
        /// <returns>A value indicating whether it should be clickable.</returns>
        private static bool SortCanExecute(SortingViewModel vm, string col)
        {
            if (vm.Disabled)
            {
                return false;
            }

            return col ==
                vm.SortColumn ||
                col == vm.ThenByColumn ||
                (col != vm.SortColumn && string.IsNullOrWhiteSpace(vm.ThenByColumn));
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <remarks>
        /// The base class handles checking "can execute".
        /// </remarks>
        /// <param name="vm">The <see cref="SortingViewModel"/>.</param>
        /// <param name="col">The column to toggle.</param>
        private static void SortExecute(SortingViewModel vm, string col)
        {
            if (col == vm.SortColumn)
            {
                vm.ToggleColumn(col);
            }
            else if (col == vm.ThenByColumn)
            {
                vm.ToggleSecondaryColumn(col);
            }
            else if (col != vm.SortColumn && string.IsNullOrWhiteSpace(vm.ThenByColumn))
            {
                vm.ToggleColumn(col);
            }
        }

        /// <summary>
        /// Logic to allow toggling the column.
        /// </summary>
        /// <remarks>
        /// Anything not the selected sort column is valid.
        /// </remarks>
        /// <param name="vm">The <see cref="SortingViewModel"/>.</param>
        /// <param name="col">The column name.</param>
        /// <returns>A value indicating whether it should be clickable.</returns>
        private static bool ThenByCanExecute(SortingViewModel vm, string col)
        {
            if (vm.Disabled || !string.IsNullOrEmpty(vm.ThenByColumn))
            {
                return false;
            }

            return col != vm.SortColumn;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <remarks>
        /// The base class handles checking "can execute".
        /// </remarks>
        /// <param name="vm">The <see cref="SortingViewModel"/>.</param>
        /// <param name="col">The column to toggle.</param>
        private static void ThenByExecute(SortingViewModel vm, string col)
        {
            vm.ToggleSecondaryColumn(col);
        }
    }
}
