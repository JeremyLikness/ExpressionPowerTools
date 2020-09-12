// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Configuration;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;

namespace ExpressionPowerTools.Serialization.EFCore.Http
{
    /// <summary>
    /// Internal service registration.
    /// </summary>
    public class Registration : IDependentServiceRegistration
    {
        /// <summary>
        /// Called after registration complete.
        /// </summary>
        public void AfterRegistered()
        {
        }

        /// <summary>
        /// Register the services.
        /// </summary>
        /// <param name="registration">The <see cref="IServiceRegistration"/> provider.</param>
        public void RegisterDefaultServices(IServiceRegistration registration)
        {
            registration.RegisterSingleton<IClientHttpConfiguration>(new ClientHttpConfiguration());
            registration.RegisterSingleton<IRemoteQueryResolver>(new HttpRemoteQueryResolver());
        }
    }
}
