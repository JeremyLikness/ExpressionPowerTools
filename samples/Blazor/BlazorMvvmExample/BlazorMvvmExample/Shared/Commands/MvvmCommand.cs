// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared.Signatures;

namespace BlazorMvvmExample.Shared.Commands
{
    /// <summary>
    /// Command abstraction.
    /// </summary>
    /// <typeparam name="T">Type of the parameter to use.</typeparam>
    public class MvvmCommand<T> : IMvvmCommand<T>
    {
        /// <summary>
        /// The action to take.
        /// </summary>
        private readonly Action<T> action = null;

        /// <summary>
        /// The async action to take.
        /// </summary>
        private readonly Func<T, Task> asyncAction = null;

        /// <summary>
        /// Delegate to determine if it can execute.
        /// </summary>
        private readonly Func<T, bool> canExecute = t => true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        public MvvmCommand(Action<T> action) => this.action = action;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="asyncAction">The action to perform.</param>
        public MvvmCommand(Func<T, Task> asyncAction) => this.asyncAction = asyncAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="canExecute">The delegate to determine if it is allowed.</param>
        public MvvmCommand(Action<T> action, Func<T, bool> canExecute)
            : this(action) => this.canExecute = canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="asyncAction">The action to perform.</param>
        /// <param name="canExecute">The delegate to determine if it is allowed.</param>
        public MvvmCommand(Func<T, Task> asyncAction, Func<T, bool> canExecute)
            : this(asyncAction) => this.canExecute = canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        public MvvmCommand(Action action)
            : this(obj => action())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="asyncAction">The action to perform.</param>
        public MvvmCommand(Func<Task> asyncAction)
            : this(obj => asyncAction())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="canExecute">The delegate to determine if it is allowed.</param>
        public MvvmCommand(Action action, Func<bool> canExecute)
            : this(action) => this.canExecute = obj => canExecute();

        /// <summary>
        /// Initializes a new instance of the <see cref="MvvmCommand{T}"/> class.
        /// </summary>
        /// <param name="asyncAction">The action to perform.</param>
        /// <param name="canExecute">The delegate to determine if it is allowed.</param>
        public MvvmCommand(Func<Task> asyncAction, Func<bool> canExecute)
            : this(asyncAction) => this.canExecute = obj => canExecute();

        /// <summary>
        /// Event raised if the executation status changes.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Gets the <see cref="Task"/> for asynchronous commands.
        /// </summary>
        public Task AsyncTask { get; private set; }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Sets the name of the command.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The command.</returns>
        public IMvvmCommand<T> SetName([CallerMemberName]string name = null)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// Method to request whether it can execute.
        /// </summary>
        /// <param name="parameter">The parameter (ignored).</param>
        /// <returns>A value indicating whether it can execute.</returns>
        public bool CanExecute(object parameter)
        {
            var result = canExecute((T)parameter);
            return result;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="parameter">The parameter (ignored).</param>
        public void Execute(object parameter)
        {
            if (canExecute((T)parameter))
            {
                if (action != null)
                {
                    action((T)parameter);
                }
                else
                {
                    ExecuteAsync((T)parameter);
                }
            }
        }

        /// <summary>
        /// Execute asynchronously.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <returns>The asynchronous <see cref="Task"/>.</returns>
        public Task ExecuteAsync(T parameter)
        {
            if (canExecute(parameter))
            {
                return AsyncTask = asyncAction(parameter);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Raise the can execute changed event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <returns>The command name.</returns>
        public override string ToString() => $"Command {Name}<{typeof(T)}>";
    }
}
