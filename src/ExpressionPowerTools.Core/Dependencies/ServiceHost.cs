// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Threading;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
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
        /// Reset to new services instance.
        /// </summary>
        public static void Reset()
        {
            Monitor.Enter(MutexLock);
            configured = false;
            Services = new Services();
            Services.RegisterServices(RegisterDefaults);
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
        /// Initialize the container. Can only be done once unless
        /// <see cref="Reset"/> is called.
        /// </summary>
        /// <param name="registration">The registration callback.</param>
        public static void Initialize(Action<IServiceRegistration> registration)
        {
            if (configured)
            {
                throw new InvalidOperationException();
            }

            Monitor.Enter(MutexLock);

            try
            {
                Services = new Services();
                Services.RegisterServices(register =>
                {
                    // defaults first
                    RegisterDefaults(register);

                    // now user overrides
                    registration(register);
                });
                configured = true;
            }
            finally
            {
                Monitor.Exit(MutexLock);
            }
        }

        /// <summary>
        /// Registers the default instances.
        /// </summary>
        private static void RegisterDefaults(IServiceRegistration register)
        {
            register.RegisterSingleton(Services);
            var rules = new DefaultHighPerformanceRules();
            register.RegisterSingleton<IExpressionComparisonRuleProvider>(rules);
            var evaluator = new ExpressionEvaluator();
            register.RegisterSingleton<IExpressionEvaluator>(evaluator);
            register.Register<IExpressionEnumerator, ExpressionEnumerator>();
            register.RegisterGeneric(typeof(IQuerySnapshotHost<>), typeof(QuerySnapshotHost<>));
            register.RegisterGeneric(typeof(IQueryHost<,>), typeof(QueryHost<,>));
            register.RegisterGeneric(typeof(IQueryInterceptingProvider<>), typeof(QueryInterceptingProvider<>));
            register.RegisterGeneric(typeof(IQuerySnapshotProvider<>), typeof(QuerySnapshotProvider<>));
        }
    }
}
