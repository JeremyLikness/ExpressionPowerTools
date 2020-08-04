// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Service registration and resolution.
    /// </summary>
    public interface IServices
    {
        /// <summary>
        /// Gets a configured service.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the service.</typeparam>
        /// <param name="parameters">List of parameters.</param>
        /// <returns>The service instance.</returns>
        /// <exception cref="InvalidOperationException">Throws when service not found.</exception>
        T GetService<T>(params object[] parameters);

        /// <summary>
        /// Register multiple service and set configured.
        /// </summary>
        /// <param name="register">The action to register.</param>
        void RegisterServices(Action<IServiceRegistration> register);
    }
}
