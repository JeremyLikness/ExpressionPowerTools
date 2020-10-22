// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlazorMvvmExample.Shared.Signatures
{
    /// <summary>
    /// Interfaces for a view model command.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the parameter.</typeparam>
    public interface IMvvmCommand<T> : ICommand
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the async <see cref="Task"/>, if present.
        /// </summary>
        Task AsyncTask { get; }

        /// <summary>
        /// Set the name of the command.
        /// </summary>
        /// <param name="name">the command name.</param>
        IMvvmCommand<T> SetName(string name);

        /// <summary>
        /// Execute the command asynchronously.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The asynchronous <see cref="Task"/>.</returns>
        Task ExecuteAsync(T parameter);

        /// <summary>
        /// Raise the status has changed.
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}
