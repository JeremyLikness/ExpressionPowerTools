// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using BlazorMvvmExample.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorMvvmExample.Client.Shared
{
    /// <summary>
    /// Wrapper to expose view models to views.
    /// </summary>
    /// <typeparam name="TViewModel">The type of view model.</typeparam>
    public partial class MVVMWrapper<TViewModel>
        where TViewModel : BaseViewModel
    {
        /// <summary>
        /// The view model instance.
        /// </summary>
        private TViewModel vm;

        /// <summary>
        /// Gets or sets  the child controls that can inherit the viewmodel.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets public binding for the viewmodel.
        /// </summary>
        [Parameter]
        public TViewModel VM
        {
            get => vm;
            set
            {
                if (!ReferenceEquals(vm, value))
                {
                    if (vm != null)
                    {
                        vm.PropertyChanged -= Vm_PropertyChanged;
                    }

                    vm = value;
                    vm.PropertyChanged += Vm_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets the delegaate called when the viewmodel changes.
        /// </summary>
        [Parameter]
        public EventCallback<TViewModel> VMChanged { get; set; }

        /// <summary>
        /// Dispose: disconnect the event listener so the viewmodel is eligible for
        /// garbage collection (and the wrapper can be disposed).
        /// </summary>
        public void Dispose()
        {
            vm.PropertyChanged -= Vm_PropertyChanged;
            vm.Dispose();
        }

        /// <summary>
        /// Properties have changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The property that changed.</param>
        private async void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            await VMChanged.InvokeAsync(VM);
        }
    }
}
