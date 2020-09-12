// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using Microsoft.Extensions.Logging;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures
{
    /// <summary>
    /// Deserializes the query.
    /// </summary>
    public interface IQueryDeserializer
    {
        /// <summary>
        /// Performs the deserialization.
        /// </summary>
        /// <param name="template">The template to use (built from a <c>DbSet</c>).</param>
        /// <param name="json">The serialized query.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>The functional <see cref="IQueryable"/>.</returns>
        Task<QueryResult> DeserializeAsync(IQueryable template, Stream json, ILogger logger = null);
    }
}
