// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
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
        /// Registers the default rules.
        /// </summary>
        /// <param name="rules">The <see cref="IRulesConfiguration"/>.</param>
        public static void RegisterDefaultRules(IRulesConfiguration rules)
        {
            rules.RuleForType(typeof(Math))
                .RuleForType(typeof(Enumerable))
                .RuleForType(typeof(Queryable))
                .RuleForType<string>()
                .RuleForMethod(
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
            var rules = new RulesEngine();
            registration.RegisterSingleton<IRulesEngine>(rules);
            registration.RegisterSingleton<IRulesConfiguration>(rules);
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
