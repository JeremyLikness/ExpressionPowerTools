// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Configuration;
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
        /// Registers the services used by serialization.
        /// </summary>
        /// <param name="registration">The <see cref="IServiceRegistration"/> to register with.</param>
        public void RegisterDefaultServices(IServiceRegistration registration)
        {
            registration.RegisterSingleton<IReflectionHelper>(
                new ReflectionHelper());
            registration.Register<IConfigurationBuilder, ConfigurationBuilder>();
            registration.RegisterSingleton<IDefaultConfiguration>(new DefaultConfiguration());
            registration.RegisterSingleton<IRulesEngine>(new RulesEngine());
        }
    }
}
