// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Dependencies
{
    /// <summary>
    /// Container for services. Can be configured to use <see cref="IServiceProvider"/> for certain types.
    /// </summary>
    /// <remarks>
    /// Use the register overloads to register services. Call <see cref="Configured"/> when done setting up and
    /// before attempting to retrieve other instances.
    /// </remarks>
    public class Services : IServices, IServiceRegistration
    {
        /// <summary>
        /// Service catalog.
        /// </summary>
        private readonly IDictionary<Type, Type> services = new Dictionary<Type, Type>();

        /// <summary>
        /// Service catalog.
        /// </summary>
        private readonly IDictionary<Type, object> singletons = new Dictionary<Type, object>();

        /// <summary>
        /// Object for synchronization.
        /// </summary>
        private readonly object mutex = new object();

        /// <summary>
        /// Can only configure once.
        /// </summary>
        private bool configured = false;

        /// <summary>
        /// Register multiple services and call configured.
        /// </summary>
        /// <param name="register">The action to register.</param>
        public void RegisterServices(Action<IServiceRegistration> register)
        {
            ConfigureCheck();
            register(this);
            Configured();
        }

        /// <summary>
        /// Register a service.
        /// </summary>
        /// <typeparam name="T">The type of the signature.</typeparam>
        /// <typeparam name="TImpl">The type of the implementation.</typeparam>
        /// <returns>An <see cref="IServiceRegistration"/> for chaining.</returns>
        public IServiceRegistration Register<T, TImpl>()
            where TImpl : T
        {
            ConfigureCheck();

            Monitor.Enter(mutex);

            var type = typeof(T);

            if (singletons.ContainsKey(type))
            {
                singletons.Remove(type);
            }

            if (services.ContainsKey(type))
            {
                services[type] = typeof(TImpl);
            }
            else
            {
                services.Add(type, typeof(TImpl));
            }

            Monitor.Exit(mutex);
            return this;
        }

        /// <summary>
        /// Register a singleton to satisfy a type request.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="instance">The singleton.</param>
        /// <returns>The <see cref="IServiceRegistration"/> for chaining.</returns>
        public IServiceRegistration RegisterSingleton<T>(T instance)
        {
            Ensure.NotNull(() => instance);
            ConfigureCheck();

            var type = typeof(T);

            Monitor.Enter(mutex);
            if (services.ContainsKey(type))
            {
                services.Remove(type);
            }

            if (singletons.ContainsKey(type))
            {
                singletons[type] = instance;
            }
            else
            {
                singletons.Add(type, instance);
            }

            Monitor.Exit(mutex);
            return this;
        }

        /// <summary>
        /// Register a generic service.
        /// </summary>
        /// <param name="signature">The signature type.</param>
        /// <param name="implementation">The implementation type.</param>
        /// <returns>An <see cref="IServiceRegistration"/> for chaining.</returns>
        public IServiceRegistration RegisterGeneric(Type signature, Type implementation)
        {
            ConfigureCheck();

            // test that open generic is assignable from other open generic
            if (!IsAssignableToGenericType(implementation, signature))
            {
                throw new InvalidOperationException();
            }

            Monitor.Enter(mutex);

            if (services.ContainsKey(signature))
            {
                services[signature] = implementation;
            }
            else
            {
                services.Add(signature, implementation);
            }

            Monitor.Exit(mutex);
            return this;
        }

        /// <summary>
        /// Get a service based on registration.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the service.</typeparam>
        /// <param name="parameters">Constructor parameters.</param>
        /// <returns>The instance.</returns>
        public T GetService<T>(params object[] parameters)
        {
            ConfigureCheck(true);
            var type = typeof(T);

            if (singletons.ContainsKey(type))
            {
                return (T)singletons[type];
            }

            if (services.ContainsKey(type))
            {
                return (T)Activator.CreateInstance(services[type], parameters);
            }

            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                if (services.ContainsKey(genericType))
                {
                    var template = services[genericType];
                    var closedType = template.MakeGenericType(type.GetGenericArguments());
                    return (T)Activator.CreateInstance(closedType, parameters);
                }
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Test that an open generic is assignable to another open generic.
        /// </summary>
        /// <param name="givenType">The <see cref="Type"/> to test.</param>
        /// <param name="genericType">The <see cref="Type"/> to test against.</param>
        /// <returns>A value indicating whether the given type is assignable to the generic type.</returns>
        private bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenType.IsGenericType &&
                givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            Type baseType = givenType.BaseType;
            if (baseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(baseType, genericType);
        }

        /// <summary>
        /// Inform that configuratoin is complete.
        /// </summary>
        private void Configured()
        {
            try
            {
                Monitor.Enter(mutex);
                ConfigureCheck();
                configured = true;
            }
            finally
            {
                Monitor.Exit(mutex);
            }
        }

        /// <summary>
        /// Check that configuration is in correct state.
        /// </summary>
        /// <param name="expected">The expected state.</param>
        private void ConfigureCheck(bool expected = false)
        {
            if (expected != configured)
            {
                // TODO: clear description in resources
                throw new InvalidOperationException();
            }
        }
    }
}
