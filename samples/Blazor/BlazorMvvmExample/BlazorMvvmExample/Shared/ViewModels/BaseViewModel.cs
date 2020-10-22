// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BlazorMvvmExample.Shared.Commands;
using BlazorMvvmExample.Shared.Signatures;

namespace BlazorMvvmExample.Shared.ViewModels
{
    /// <summary>
    /// Base view model.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// List of items being listened to.
        /// </summary>
        private readonly List<WeakReference<INotifyPropertyChanged>> observables =
            new List<WeakReference<INotifyPropertyChanged>>();

        /// <summary>
        /// A value indicating whether it has already disposed.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Event to notify on property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the list of commands to notify.
        /// </summary>
        protected virtual ICommand[] Commands { get; set; } = new ICommand[0];

        /// <summary>
        /// Implementation of <see cref="IDisposable"/>.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method to raise property change notification.
        /// </summary>
        /// <param name="propertyName">The optional name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Helper for setting properties. Only raises changes if the property changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The field to reference the value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>A value indicating whether the property changed.</returns>
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            field = newValue;

            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Helper for setting properties. Only raises changes if the property changed. Also
        /// notifies commands that properties changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The field to reference the value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="commands">The list of commands to notify.</param>
        /// <returns>A value indicating whether the property changed.</returns>
        protected bool SetPropertyAndNotify<T>(
            ref T field,
            T newValue,
            [CallerMemberName] string propertyName = null,
            ICommand[] commands = null)
        {
            var notified = false;
            commands = commands ?? Commands;
            if (SetProperty(ref field, newValue, propertyName))
            {
                NotifyCommands(commands);
                notified = true;
            }

            return notified;
        }

        /// <summary>
        /// Called when an observed item raises property change notifications.
        /// </summary>
        /// <param name="sender">The <see cref="INotifyPropertyChanged"/> source.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected virtual void ObservedChanged(INotifyPropertyChanged sender, string propertyName)
        {
        }

        /// <summary>
        /// Registers a dependent listener.
        /// </summary>
        /// <typeparam name="T">The type to listen to.</typeparam>
        /// <param name="observable">The item to listen to.</param>
        protected void ListenTo<T>(T observable)
            where T : INotifyPropertyChanged
        {
            observable.PropertyChanged += Observable_PropertyChanged;
            observables.Add(new WeakReference<INotifyPropertyChanged>(observable));
        }

        /// <summary>
        /// Dispose implementation. Overridable so derived view models can plug into the event.
        /// </summary>
        /// <param name="disposing">A value indicating whether currently disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var reference in observables)
                    {
                        if (reference.TryGetTarget(out var observable))
                        {
                            observable.PropertyChanged -= Observable_PropertyChanged;
                        }
                    }

                    observables.Clear();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Helper to update a property and notify if it changes.
        /// </summary>
        /// <param name="commandsToNotify">The commands to notify of the change.</param>
        private void NotifyCommands(params ICommand[] commandsToNotify)
        {
            foreach (var command in commandsToNotify)
            {
                var type = command.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(MvvmCommand<>))
                {
                    var method = type.GetMethod(nameof(IMvvmCommand<object>.RaiseCanExecuteChanged));
                    method.Invoke(command, new object[0]);
                }
            }
        }

        /// <summary>
        /// Event fired when an observed item changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The property changed.</param>
        private void Observable_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ObservedChanged(sender as INotifyPropertyChanged, e.PropertyName);
        }
    }
}
