// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Net.Http;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Configuration
{
    /// <summary>
    /// Class to handle configuration of the client.
    /// </summary>
    public class ClientHttpConfiguration : IClientHttpConfiguration
    {
        /// <summary>
        /// Context parameter.
        /// </summary>
        public const string ContextKey = "{context}";

        /// <summary>
        /// Collection parameter.
        /// </summary>
        public const string CollectionKey = "{collection}";

        /// <summary>
        /// Gets the template for the server path. Default is <c>/efcore/{context}/{collection}</c>.
        /// </summary>
        public string PathTemplate { get; private set; } = $"/efcore/{ContextKey}/{CollectionKey}";

        /// <summary>
        /// Gets the client factory to generate the <see cref="HttpClient"/>.
        /// </summary>
        public Func<IRemoteQueryClient> ClientFactory { get; private set; } = () =>
            throw new InvalidOperationException("You must configure a remote query client instance.");

        /// <summary>
        /// Set the factory to generate instances of <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="factory">The factory to use.</param>
        /// <returns>The <see cref="IClientHttpConfiguration"/>.</returns>
        public IClientHttpConfiguration SetClientFactory(Func<IRemoteQueryClient> factory)
        {
            Ensure.NotNull(() => factory);
            ClientFactory = factory;
            return this;
        }

        /// <summary>
        /// Set the path template.
        /// </summary>
        /// <remarks>
        /// This is used to compose the URL for the query request. It must contain
        /// a reference to <c>{context}</c> and <c>{collection}</c>. The default
        /// is <c>/efcore/{context}/{collection}</c> so a <see cref="DbContext"/>
        /// named ProductsContext with a list named Products will resolve to
        /// <c>/efcore/ProductsContext/Products</c>.
        /// </remarks>
        /// <param name="pathTemplate">The path template.</param>
        /// <returns>The <see cref="IClientHttpConfiguration"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when path template is null, empty, or does not contain the proper segments.</exception>
        public IClientHttpConfiguration SetPathTemplate(string pathTemplate)
        {
            Ensure.NotNullOrWhitespace(() => pathTemplate);
            var parts = pathTemplate.Split('/');
            if (parts.Length < 2)
            {
                throw new ArgumentException("Not enough segments.", nameof(pathTemplate));
            }

            foreach (var iteration in new[] { ContextKey, CollectionKey })
            {
                var key = iteration == ContextKey ? nameof(ContextKey) : nameof(CollectionKey);
                var count = parts.Count(p => p == iteration);
                if (count == 0)
                {
                    throw new ArgumentException($"Missing key: {key}", nameof(pathTemplate));
                }

                if (count > 1)
                {
                    throw new ArgumentException($"Too many segments for: {key}", nameof(pathTemplate));
                }
            }

            PathTemplate = pathTemplate;

            return this;
        }
    }
}
