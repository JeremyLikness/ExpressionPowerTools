// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Providers;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Non-generic interface for snapshot host.
    /// </summary>
    public interface IQuerySnapshot
    {
        /// <summary>
        /// Event to raise when the query is triggered.
        /// </summary>
        event EventHandler<QuerySnapshotEventArgs> QueryExecuted;

        /// <summary>
        /// Gets the parent provider for bubbling events.
        /// </summary>
        IQuerySnapshot Parent { get; }

        /// <summary>
        /// Method to raise call.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to snapshot.</param>
        void OnExecuteEnumerableCalled(Expression expression);
    }
}
