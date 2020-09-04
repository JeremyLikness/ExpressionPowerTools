// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Interface to implement in other projects that will plug into the registration
    /// pipeline for dependency injection.
    /// </summary>
    public interface IDependentServiceRegistration
    {
        /// <summary>
        /// Implement to register default services.
        /// </summary>
        /// <param name="registration">The <see cref="IServiceRegistration"/>.</param>
        void RegisterDefaultServices(IServiceRegistration registration);
    }
}
