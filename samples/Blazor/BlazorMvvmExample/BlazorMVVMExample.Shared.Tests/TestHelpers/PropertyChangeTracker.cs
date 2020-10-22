using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlazorMVVMExample.Shared.Tests.TestHelpers
{
    /// <summary>
    /// Used to capture change notifications and provide
    /// a simple interface for testing.
    /// </summary>
    public class PropertyChangeTracker : IDisposable
    {
        /// <summary>
        /// The target to watch.
        /// </summary>
        private INotifyPropertyChanged _target;

        /// <summary>
        /// Changes by type with a count by property.
        /// </summary>
        public Dictionary<Type, Dictionary<string, int>>
            PropertyChanges
            = new Dictionary<Type, Dictionary<string, int>>();

        public PropertyChangeTracker()
        {
        }

        /// <summary>
        /// Load the target and hook into change notification.
        /// </summary>
        /// <param name="target">The entity to watch.</param>
        public PropertyChangeTracker(INotifyPropertyChanged target)
        {
            _target = target;
            target.PropertyChanged += Target_PropertyChanged;
        }

        /// <summary>
        /// Wipe out existing data. 
        /// </summary>
        public void Reset()
        {
            PropertyChanges = new Dictionary<Type, Dictionary<string, int>>();
        }

        /// <summary>
        /// Method to process a property change. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The property that changed.</param>
        public void ProcessPropertyChange(object sender,
            PropertyChangedEventArgs e)
        {
            ProcessPropertyChange(sender, e.PropertyName);
        }

        /// <summary>
        /// Interface that takes property instead of args.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="propertyName">The property that changed.</param>
        public void ProcessPropertyChange(object sender,
            string propertyName)
        {
            var type = sender.GetType();
            if (!PropertyChanges.ContainsKey(type))
            {
                PropertyChanges.Add(
                    type,
                    new Dictionary<string, int>());
            }
            var typeList = PropertyChanges[type];
            if (!typeList.ContainsKey(propertyName))
            {
                typeList.Add(propertyName, 1);
            }
            else
            {
                typeList[propertyName] =
                    typeList[propertyName] + 1;
            }
        }

        /// <summary>
        /// Event listener.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The property that changed.</param>
        private void Target_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ProcessPropertyChange(sender, e.PropertyName);
        }

        /// <summary>
        /// Check if any events were fired.
        /// </summary>
        public bool HasChanges => PropertyChanges.Count > 0;

        /// <summary>
        /// Check if a particular viewmodel raised events.
        /// </summary>
        /// <typeparam name="T">The viewmodel type.</typeparam>
        /// <returns>A flag indicating whether a change notification was raised.</returns>
        public bool HasChangesForType<T>()
        {
            return PropertyChanges.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Check if a particular proprty raised a change notification.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>A flag indicating if the property raised a change notification.</returns>
        public bool HasChangesForProperty<T>(string propertyName)
        {
            if (HasChangesForType<T>())
            {
                return PropertyChanges[typeof(T)]
                    .ContainsKey(propertyName);
            }
            return false;
        }

        /// <summary>
        /// Provides a count of the times a property change notification was raised.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The count of times the property raised a change notification.</returns>
        public int ChangeCountForProperty<T>(string propertyName)
        {
            if (HasChangesForType<T>())
            {
                return PropertyChanges[typeof(T)]
                    .ContainsKey(propertyName) ?
                    PropertyChanges[typeof(T)][propertyName]
                    : 0;
            }
            return 0;
        }

        /// <summary>
        /// Release on dispose.
        /// </summary>
        public void Dispose()
        {
            if (_target != null)
            {
                _target.PropertyChanged -= Target_PropertyChanged;
                _target = null;
            }
        }
    }
}
