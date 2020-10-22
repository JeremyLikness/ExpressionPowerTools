// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using BlazorMvvmExample.Shared.Commands;

namespace BlazorMvvmExample.Shared.ViewModels
{
    /// <summary>
    /// Handles paging concerns.
    /// </summary>
    public class PagingViewModel : BaseViewModel
    {
        /// <summary>
        /// Current page.
        /// </summary>
        private int page;

        /// <summary>
        /// Items on the current page.
        /// </summary>
        private int pageItems;

        /// <summary>
        /// Size of a page.
        /// </summary>
        private int pageSize = 20;

        /// <summary>
        /// Total items for the current filter.
        /// </summary>
        private int totalItemCount;

        /// <summary>
        /// A value indicating whether the paging is disabled.
        /// </summary>
        private bool disabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingViewModel"/> class.
        /// </summary>
        public PagingViewModel()
        {
            PagingNextCommand = new MvvmCommand<object>(() => Page++, () => HasNext)
                .SetName(nameof(PagingNextCommand));
            PagingPrevCommand = new MvvmCommand<object>(() => Page--, () => HasPrev)
                .SetName(nameof(PagingPrevCommand));
            Commands = new[] { PagingNextCommand, PagingPrevCommand };
        }

        /// <summary>
        /// Gets the database page (0 when user page is 1).
        /// </summary>
        public int DbPage => page - 1;

        /// <summary>
        /// Gets or sets current page.
        /// </summary>
        public int Page
        {
            get => page;
            set => SetPropertyAndNotify(ref page, value, nameof(Page));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the paging is disabled.
        /// </summary>
        public bool Disabled
        {
            get => disabled;
            set => SetPropertyAndNotify(ref disabled, value, nameof(Disabled));
        }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int PageCount => (TotalItemCount + PageSize - 1) / PageSize;

        /// <summary>
        /// Gets the number of the next page.
        /// </summary>
        public int NextPage => Page < PageCount ? Page + 1 : Page;

        /// <summary>
        /// Gets a value indicating whether a next page exists.
        /// </summary>
        public bool HasNext => !Disabled && Page < PageCount;

        /// <summary>
        /// Gets the number of the previous page.
        /// </summary>
        public int PrevPage => Page > 1 ? Page - 1 : Page;

        /// <summary>
        /// Gets a value indicating whether a previous page exists.
        /// </summary>
        public bool HasPrev => !Disabled && Page > 1;

        /// <summary>
        /// Gets the next page command.
        /// </summary>
        public Signatures.IMvvmCommand<object> PagingNextCommand { get; private set; }

        /// <summary>
        /// Gets the next page command.
        /// </summary>
        public Signatures.IMvvmCommand<object> PagingPrevCommand { get; private set; }

        /// <summary>
        /// Gets or sets the number of items on the current page (should always be less than or
        /// equal to <see cref="PageSize"/>).
        /// </summary>
        public int PageItems
        {
            get => pageItems;
            set => SetPropertyAndNotify(ref pageItems, value, nameof(PageItems));
        }

        /// <summary>
        /// Gets or sets the size of a page.
        /// </summary>
        public int PageSize
        {
            get => pageSize;
            set
            {
                if (value > 0 && value <= PageCount)
                {
                    SetPropertyAndNotify(ref pageSize, value, nameof(PageSize));
                }
            }
        }

        /// <summary>
        /// Gets how many items to skip to reach the current page.
        /// </summary>
        public int Skip => PageSize * DbPage;

        /// <summary>
        /// Gets or sets the total number of items that match the current filter.
        /// </summary>
        public int TotalItemCount
        {
            get => totalItemCount;
            set => SetPropertyAndNotify(ref totalItemCount, value, nameof(TotalItemCount));
        }

        /// <summary>
        /// String representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString() =>
            $"{Page} of {PageCount} ({PageItems} of {TotalItemCount}) Skip({Skip}) Take({PageSize})";
    }
}
