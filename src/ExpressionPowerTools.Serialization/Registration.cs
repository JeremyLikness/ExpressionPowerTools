// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Compression;
using ExpressionPowerTools.Serialization.Configuration;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Rules;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization
{
    /// <summary>
    /// Registration of services for serialization.
    /// </summary>
    public class Registration : IDependentServiceRegistration
    {
        /// <summary>
        /// The list of primitives.
        /// </summary>
        private static Type[] primitiveTypes = null;

        /// <summary>
        /// The list of collections.
        /// </summary>
        private static Type[] collectionTypes = null;

        /// <summary>
        /// Registers the default rules.
        /// </summary>
        /// <param name="rules">The <see cref="IRulesConfiguration"/>.</param>
        public static void RegisterDefaultRules(IRulesConfiguration rules)
        {
            if (primitiveTypes == null)
            {
                primitiveTypes = ServiceHost.SafeGetTypes(t => t.Namespace != null &&
                    t.Namespace.StartsWith(nameof(System)) &&
                    t.IsPrimitive &&
                    t != typeof(IntPtr) &&
                    t != typeof(UIntPtr))
                .ToArray();
            }

            if (collectionTypes == null)
            {
                var collectionNamespace = typeof(IEnumerable).Namespace;
                collectionTypes = ServiceHost.SafeGetTypes(
                    t => t.Namespace != null &&
                    t.Namespace.StartsWith(collectionNamespace) &&
                    t.IsPublic &&
                    t.IsSerializable &&
                    !t.IsEnum &&
                    !typeof(Exception).IsAssignableFrom(t))
                .ToArray();
            }

            foreach (var primitive in primitiveTypes.Union(collectionTypes))
            {
                rules.RuleForType(primitive);
            }

            foreach (var common in new[]
            {
                typeof(Math),
                typeof(Enumerable),
                typeof(Queryable),
                typeof(string),
                typeof(DateTime),
                typeof(TimeSpan),
                typeof(Guid),
            })
            {
                rules.RuleForType(common);
            }

            rules.RuleForMethod(
                    selector =>
                    selector.ByNameForType<MethodInfo, object>(
                        nameof(object.ToString)));
        }

        /// <summary>
        /// Registers the services used by serialization.
        /// </summary>
        /// <param name="registration">The <see cref="IServiceRegistration"/> to register with.</param>
        public void RegisterDefaultServices(IServiceRegistration registration)
        {
            registration.RegisterSingleton<IReflectionHelper>(
                new ReflectionHelper());
            registration.Register<IConfigurationBuilder, ConfigurationBuilder>();
            registration.RegisterSingleton<IDefaultConfiguration>(new DefaultConfiguration());
            var rules = new RulesEngine
            {
                LoadingDefaults = true,
            };
            registration.RegisterSingleton<IRulesEngine>(rules);
            registration.RegisterSingleton<IRulesConfiguration>(rules);
            registration.RegisterSingleton<IAnonymousTypeAdapter>(
                new AnonymousTypeAdapter());
            registration.RegisterSingleton<ITypesCompressor>(
                new TypesCompressor());
        }

        /// <summary>
        /// Adds default "safe" rules for serialization.
        /// </summary>
        public void AfterRegistered()
        {
            var rules = ServiceHost.GetService<IRulesConfiguration>();
            RegisterDefaultRules(rules);
        }
    }
}
