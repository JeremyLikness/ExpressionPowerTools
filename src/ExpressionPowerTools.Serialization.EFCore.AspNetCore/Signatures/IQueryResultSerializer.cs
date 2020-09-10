// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures
{
    /// <summary>
    /// Executes the query and serializes the result.
    /// </summary>
    public interface IQueryResultSerializer
    {
        /// <summary>
        /// Serializes the query result.
        /// </summary>
        /// <param name="response">The <see cref="Stream"/> to serialize to.</param>
        /// <param name="query">The <see cref="IQueryable"/> to execute.</param>
        /// <param name="isCount">A value indicating whether a count should be run.</param>
        Task SerializeAsync(
            Stream response,
            IQueryable query,
            bool isCount = false);
    }
}
