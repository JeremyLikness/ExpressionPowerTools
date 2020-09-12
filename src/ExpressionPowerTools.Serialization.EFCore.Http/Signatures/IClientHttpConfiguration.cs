// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Net.Http;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Signatures
{
    /// <summary>
    /// Configuration for connecting to the remote services.
    /// </summary>
    public interface IClientHttpConfiguration
    {
        /// <summary>
        /// Gets the template to use, defaults to <c>/efcore/{context}/{collection}</c>.
        /// </summary>
        string PathTemplate { get; }

        /// <summary>
        /// Gets the factory to generate the client. Defaults to a call from the service provider.
        /// </summary>
        Func<IRemoteQueryClient> ClientFactory { get; }

        /// <summary>
        /// Sets the template for the path.
        /// </summary>
        /// <param name="path">The path tempate.</param>
        /// <returns>The <see cref="IClientHttpConfiguration"/>.</returns>
        IClientHttpConfiguration SetPathTemplate(string path);

        /// <summary>
        /// Set the client factory.
        /// </summary>
        /// <param name="factory">The factory to use.</param>
        /// <returns>The <see cref="IClientHttpConfiguration"/>.</returns>
        IClientHttpConfiguration SetClientFactory(Func<IRemoteQueryClient> factory);
    }
}
