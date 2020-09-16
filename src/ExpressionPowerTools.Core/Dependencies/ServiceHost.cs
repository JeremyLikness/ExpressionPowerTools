// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Members;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Resources;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Dependencies
{
    /// <summary>
    /// Host to obtain services.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is a very simple dependency injection container. It allows registration
    /// of type implementations, generic implementations, and singletons. It does not
    /// recursively resolve dependencies. Registration happens in the call to <see cref="Initialize(Action{IServiceRegistration})"/>
    /// and can only be done once. <see cref="Reset"/> is provided mainly for testing purposes.
    /// </para>
    /// <para>
    /// Satellite assemblies can hook into the registration by implementing <see cref="IDependentServiceRegistration"/>. This is
    /// scanned and loaded before user overridees.
    /// </para>
    /// <para>
    /// The <see cref="IServiceRegistration"/> provided by initialization is chainable (each call returns itself).
    /// </para>
    /// </remarks>
    /// <example>
    /// To register a type <c>MyType</c> that implements <c>IMyType</c>:
    /// <code lang="csharp"><![CDATA[
    /// ServiceHost.Initialize(register => register.Register<IMyType, MyType>());
    /// ]]></code>
    /// To register a singleton:
    /// <code lang="csharp"><![CDATA[
    /// var singleton = new MyType();
    /// ServiceHost.Initialize(register => register.RegisterSingleton<IMyType>(singleton);
    /// ]]></code>
    /// To register a generic type <c>IGenericType&lt;T></c> that is implemented by
    /// <c>GenericType&lt;T></c>:
    /// <code lang="csharp"><![CDATA[
    /// ServiceHost.Initialize(register =>
    ///     register.RegisterGeneric(typeof(IGenericType<>), typeof(GenericType<>)));
    /// ]]></code>
    /// To retrive a service:
    /// <code lang="csharp"><![CDATA[
    /// var implementation = ServiceHost.GetService<IMyType>();
    /// ]]></code>
    /// Retrieving a generic service (closed) with parameters:
    /// <code lang="csharp"><![CDATA[
    /// var implementation = ServiceHost.GetService<IGenericType<string>>(5, 6);
    /// ]]></code>
    /// </example>
    public static class ServiceHost
    {
        /// <summary>
        /// A lock object.
        /// </summary>
        private static readonly object MutexLock = new object();

        /// <summary>
        /// The satellite registrations.
        /// </summary>
        private static readonly Stack<IDependentServiceRegistration> Satellites =
            new Stack<IDependentServiceRegistration>();

        /// <summary>
        /// A value indicating whether the container has already been configured.
        /// </summary>
        private static bool configured = false;

        /// <summary>
        /// Initializes static members of the <see cref="ServiceHost"/> class.
        /// </summary>
        static ServiceHost()
        {
            Reset();
        }

        /// <summary>
        /// Gets or sets the global instance of <see cref="IServices"/>.
        /// </summary>
        private static IServices Services { get; set; }

        /// <summary>
        /// Gets the shipped default.
        /// </summary>
        private static IExpressionComparisonRuleProvider DefaultRules { get; }
            = new DefaultComparisonRules();

        /// <summary>
        /// Reset to new services instance.
        /// </summary>
        public static void Reset()
        {
            Monitor.Enter(MutexLock);
            configured = false;
            Services = new Services();
            Services.RegisterServices(register =>
            {
                RegisterDefaults(register);

                // now satellite assemblies
                RegisterSatellites(register);
            });

            AfterRegistered();

            Monitor.Exit(MutexLock);
        }

        /// <summary>
        /// Get the service implementation.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to resolve.</typeparam>
        /// <param name="parameters">The constructor parameters.</param>
        /// <returns>The instance.</returns>
        public static T GetService<T>(params object[] parameters) =>
            Services.GetService<T>(parameters);

        /// <summary>
        /// Gets a lazy loaded service.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the service.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The lazy intialization for the service.</returns>
        public static Lazy<T> GetLazyService<T>(params object[] parameters) =>
            new Lazy<T>(() => GetService<T>(parameters), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Initialize the container. Can only be done once unless
        /// <see cref="Reset"/> is called.
        /// </summary>
        /// <param name="registration">The registration callback.</param>
        public static void Initialize(Action<IServiceRegistration> registration)
        {
            if (configured)
            {
                throw ExceptionHelper.AlreadyInitialized.AsInvalidOperationException();
            }

            Monitor.Enter(MutexLock);

            try
            {
                Services = new Services();

                Services.RegisterServices(register =>
                {
                    // defaults first
                    RegisterDefaults(register);

                    // now satellite assemblies
                    RegisterSatellites(register);

                    // now user overrides
                    registration(register);
                });
                configured = true;
                AfterRegistered();
            }
            finally
            {
                Monitor.Exit(MutexLock);
            }
        }

        /// <summary>
        /// Notifies satellite assemblies registation is done.
        /// </summary>
        private static void AfterRegistered()
        {
            while (Satellites.Count > 0)
            {
                var satellite = Satellites.Pop();
                satellite.AfterRegistered();
            }
        }

        /// <summary>
        /// Registers the default instances.
        /// </summary>
        private static void RegisterDefaults(IServiceRegistration register)
        {
            var evaluator = new ExpressionEvaluator();
            register.RegisterSingleton(Services)
                .RegisterSingleton(DefaultRules)
                .RegisterSingleton<IExpressionEvaluator>(evaluator)
                .RegisterSingleton<IMemberAdapter>(new MemberAdapter())
                .Register<IExpressionEnumerator, ExpressionEnumerator>()
                .RegisterGeneric(typeof(IQuerySnapshotHost<>), typeof(QuerySnapshotHost<>))
                .RegisterGeneric(typeof(IQueryHost<,>), typeof(QueryHost<,>))
                .RegisterGeneric(typeof(IQueryInterceptingProvider<>), typeof(QueryInterceptingProvider<>))
                .RegisterGeneric(typeof(IQuerySnapshotProvider<>), typeof(QuerySnapshotProvider<>));
        }

        /// <summary>
        /// Register defaults from satellite assemblies.
        /// </summary>
        /// <param name="register">The <see cref="IServiceRegistration"/>.</param>
        private static void RegisterSatellites(IServiceRegistration register)
        {
            // now satellite assemblies
            foreach (var dependent in AppDomain.CurrentDomain.GetAssemblies().SelectMany(
                a => a.GetTypes()
                .Where(t => typeof(IDependentServiceRegistration).IsAssignableFrom(t) &&
                !t.IsInterface)))
            {
                var satelliteRegistration = Activator.CreateInstance(dependent) as IDependentServiceRegistration;
                satelliteRegistration.RegisterDefaultServices(register);
                Satellites.Push(satelliteRegistration);
            }
        }
    }
}
