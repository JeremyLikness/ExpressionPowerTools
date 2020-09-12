// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Transport
{
    /// <summary>
    /// Configured for the query client.
    /// </summary>
    public class RemoteQueryClient : IRemoteQueryClient
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteQueryClient"/> class.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to use.</param>
        public RemoteQueryClient(HttpClient client)
        {
            httpClient = client;
        }

        /// <summary>
        /// Performs the remote fetch.
        /// </summary>
        /// <param name="path">The path to the query server.</param>
        /// <param name="queryContent">The content to post.</param>
        /// <returns>The result.</returns>
        /// <exception cref="ArgumentException">Thrown when path is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when query content is null.</exception>
        public async Task<string> FetchRemoteQueryAsync(string path, HttpContent queryContent)
        {
            Ensure.NotNullOrWhitespace(() => path);
            Ensure.NotNull(() => queryContent);
            var result = await httpClient.PostAsync(path, queryContent);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsStringAsync();
        }
    }
}
