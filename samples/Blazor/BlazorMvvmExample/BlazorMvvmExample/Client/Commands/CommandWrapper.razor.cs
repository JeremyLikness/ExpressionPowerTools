// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared.Signatures;
using ExpressionPowerTools.Core.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorMvvmExample.Client.Commands
{
    /// <summary>
    /// Wrapper to expose commands to elements.
    /// </summary>
    /// <typeparam name="TCommand">The type of command.</typeparam>
    /// <typeparam name="TCommandType">The type the command works with.</typeparam>
    public partial class CommandWrapper<TCommand, TCommandType>
        : IDisposable
        where TCommand : IMvvmCommand<TCommandType>
    {
        /// <summary>
        /// Flag to prevent rendering loops.
        /// </summary>
        private bool canExecute = false;

        /// <summary>
        /// Gets or sets the JavaScript runtime reference.
        /// </summary>
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Gets or sets the child controls that can inherit the viewmodel.
        /// </summary>
        [Parameter]
        public TCommand Command { get; set; }

        /// <summary>
        /// Gets or sets the command change notification.
        /// </summary>
        [Parameter]
        public EventCallback<TCommand> CommandChanged { get; set; }

        /// <summary>
        /// Gets or sets the parameter to pass to the command.
        /// </summary>
        [Parameter]
        public TCommandType CommandParameter { get; set; }

        /// <summary>
        /// Gets or sets the classes to attach when enabled.
        /// </summary>
        [Parameter]
        public string EnabledClasses { get; set; }

        /// <summary>
        /// Gets or sets the classes to attach when disabled.
        /// </summary>
        [Parameter]
        public string DisabledClasses { get; set; }

        /// <summary>
        /// Gets or sets the delegate to the element reference.
        /// </summary>
        [Parameter]
        public Func<ElementReference> Target { get; set; }

        /// <summary>
        /// JavaScript exposed invoke command.
        /// </summary>
        [JSInvokable]
        public void ExecuteCommand()
        {
            Command.Execute(CommandParameter);
        }

        /// <summary>
        /// Unwire event handlers, dispose commands.
        /// </summary>
        public void Dispose()
        {
            if (Command != null)
            {
                Command.CanExecuteChanged -= TargetCommandChanged;
            }
        }

        /// <summary>
        /// Called after render.
        /// </summary>
        /// <param name="firstRender">A value indicating whether this is the first render.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Ensure.NotNull(() => Target);
            var elem = Target();

            if (firstRender)
            {
                canExecute = !Command.CanExecute(CommandParameter);
                var obj = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("CommandWrapper.setClick", elem, obj, nameof(ExecuteCommand))
                    .ConfigureAwait(false);
                Command.CanExecuteChanged += TargetCommandChanged;
            }

            await RenderChangesAsync();
        }

        /// <summary>
        /// Renders the changes.
        /// </summary>
        /// <returns>The asynchronous <see cref="Task"/>.</returns>
        protected async Task RenderChangesAsync()
        {
            var allowed = Command.CanExecute(CommandParameter);
            if (allowed != canExecute)
            {
                canExecute = allowed;
                var elem = Target();
                var fn = allowed ? "removeDisabled" : "setDisabled";
                await JSRuntime.InvokeVoidAsync($"CommandWrapper.{fn}", elem).ConfigureAwait(false);
                string classes = allowed ? EnabledClasses : DisabledClasses;
                classes ??= string.Empty;
                await JSRuntime.InvokeVoidAsync("CommandWrapper.setClasses", elem, classes).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Raised when the command changes.
        /// </summary>
        /// <param name="sender">The command.</param>
        /// <param name="e">The event args.</param>
        protected async void TargetCommandChanged(object sender, EventArgs e)
        {
            await RenderChangesAsync().ConfigureAwait(false);
            await CommandChanged.InvokeAsync(Command).ConfigureAwait(false);
        }
    }
}
