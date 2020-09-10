// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware
{
    /// <summary>
    /// Represents the result of deserializing a query payload.
    /// </summary>
    public class QueryResult
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        public IQueryable Query { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the query is a count operation.
        /// </summary>
        public bool IsCount { get; set; }
    }
}
