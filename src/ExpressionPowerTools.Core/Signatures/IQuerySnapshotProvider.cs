// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Providers;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Provider to intercept query execution for inspection.
    /// </summary>
    /// <typeparam name="T">The type of snapshot to provide for.</typeparam>
    public interface IQuerySnapshotProvider<T> : IQueryProvider
    {
        /// <summary>
        /// Event to raise when the query is triggered.
        /// </summary>
        event EventHandler<QuerySnapshotEventArgs> QueryExecuted;

        /// <summary>
        /// Execute enumeration from the <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to enumerate.</param>
        /// <returns>An instance of <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<T> ExecuteEnumerable(Expression expression);
    }
}
