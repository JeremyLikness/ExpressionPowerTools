// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared.Signatures;

namespace BlazorMvvmExample.Shared.ViewModels
{
    /// <summary>
    /// View model for contacts querying.
    /// </summary>
    public class ContactsViewModel : BaseViewModel
    {
        /// <summary>
        /// Reference to the query provider.
        /// </summary>
        private readonly IContactsQuery querySource;

        /// <summary>
        /// Paging properties to listen to.
        /// </summary>
        private readonly string[] pagingProperties = new[]
            {
                nameof(PagingViewModel.Page),
                nameof(PagingViewModel.PageSize),
            };

        /// <summary>
        /// Sorting properties to ignore.
        /// </summary>
        private readonly string[] sortingPropertiesIgnore = new[]
            {
                nameof(SortingViewModel.Disabled),
            };

        /// <summary>
        /// Loading indicator.
        /// </summary>
        private bool loading;

        /// <summary>
        /// Preview indicator.
        /// </summary>
        private bool preview = false;

        /// <summary>
        /// Error message.
        /// </summary>
        private string errorMessage = string.Empty;

        /// <summary>
        /// Tracks the last task.
        /// </summary>
        private Task lastTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsViewModel"/> class.
        /// </summary>
        public ContactsViewModel()
        {
            Pager = new PagingViewModel();
            SortingVm = new SortingViewModel();
            FilterVm = new FilteringViewModel();
            ListenTo(Pager);
            ListenTo(SortingVm);
            ListenTo(FilterVm);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsViewModel"/> class.
        /// </summary>
        /// <param name="querySource">Provider to materialize queries.</param>
        public ContactsViewModel(
            IContactsQuery querySource)
            : this() => this.querySource = querySource;

        /// <summary>
        /// Gets the <see cref="PagingViewModel"/>.
        /// </summary>
        public PagingViewModel Pager { get; private set; }

        /// <summary>
        /// Gets the <see cref="SortingViewModel"/>.
        /// </summary>
        public SortingViewModel SortingVm { get; private set; }

        /// <summary>
        /// Gets the <see cref="FilteringViewModel"/>.
        /// </summary>
        public FilteringViewModel FilterVm { get; private set; }

        /// <summary>
        /// Gets the error message if one exists.
        /// </summary>
        public string ErrorMessage
        {
            get => errorMessage;
            private set => SetProperty(ref errorMessage, value, nameof(ErrorMessage));
        }

        /// <summary>
        /// Gets or sets a value indicating whether a preview (name only) should be used.
        /// </summary>
        public bool Preview
        {
            get => preview;
            set
            {
                if (SetProperty(ref preview, value, nameof(Preview)))
                {
                    lastTask = LoadAsync();
                }
            }
        }

        /// <summary>
        /// Gets the list of <see cref="Contact"/> entries.
        /// </summary>
        public ReadOnlyCollection<Contact> Contacts { get; private set; }

        /// <summary>
        /// Gets a value indicating whether data is loading.
        /// </summary>
        public bool Loading
        {
            get => loading;
            private set => SetProperty(ref loading, value, nameof(Loading));
        }

        /// <summary>
        /// Loads the data asynchronously.
        /// </summary>
        /// <param name="resetPage">Set to <c>true</c> to reset page to 1.</param>
        /// <returns>An asynchronous <see cref="Task"/>.</returns>
        public async Task LoadAsync(bool resetPage = false)
        {
            if (Loading)
            {
                await lastTask;
                return;
            }

            ErrorMessage = string.Empty;
            var taskTracker = new TaskCompletionSource<bool>();

            try
            {
                lastTask = taskTracker.Task;
                var query = querySource.GetBaseQuery();

                Loading = true;
                Pager.Disabled = true;
                if (resetPage)
                {
                    Pager.Page = 1;
                }

                SortingVm.Disabled = true;

                query = SortingVm.ApplySort(query);
                query = FilterVm.ApplyFilter(query);
                var queryPage = query.Skip(Pager.Skip).Take(Pager.PageSize);
                if (preview)
                {
                    queryPage = queryPage.Select(c =>
                    new Contact
                    {
                        LastName = c.LastName,
                        FirstName = c.FirstName,
                    });
                }

                (int count, List<Contact> contacts) = await
                    querySource.GetContactsWithCountAsync(query, queryPage)
                    .ConfigureAwait(false);
                Contacts = new ReadOnlyCollection<Contact>(contacts);
                Pager.TotalItemCount = count;
                Pager.PageItems = Contacts.Count;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Oops! Something unexpected happened: {ex.Message}";
            }
            finally
            {
                taskTracker.SetResult(true);
                Loading = false;
                Pager.Disabled = false;
                SortingVm.Disabled = false;
            }
        }

        /// <summary>
        /// Wait for paging changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="propertyName">The property name.</param>
        protected override async void ObservedChanged(INotifyPropertyChanged sender, string propertyName)
        {
            if (!Loading
                && ((sender is FilteringViewModel && propertyName != nameof(FilterVm.ShowFilter)) ||
                    (sender is SortingViewModel && !sortingPropertiesIgnore.Contains(propertyName)) ||
                    (sender is PagingViewModel && pagingProperties.Contains(propertyName))))
            {
                var resetPage = sender is FilteringViewModel;
                await LoadAsync(resetPage: resetPage);
            }
        }
    }
}
