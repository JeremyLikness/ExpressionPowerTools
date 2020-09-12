// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Net.Http;
using System.Threading.Tasks;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Signatures
{
    /// <summary>
    /// Typed <see cref="HttpClient"/> for queries.
    /// </summary>
    public interface IRemoteQueryClient
    {
        /// <summary>
        /// Fetches the remote content.
        /// </summary>
        /// <param name="path">The relative path.</param>
        /// <param name="queryContent">The query.</param>
        /// <returns>The result.</returns>
        Task<string> FetchRemoteQueryAsync(
            string path,
            HttpContent queryContent);
    }
}
