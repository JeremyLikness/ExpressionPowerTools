// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Host to snapshot a query. Will raise an event when it is executed
    /// to allow inspecting the expression.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IQuerySnapshotHost<T> : IQueryHost<T, IQuerySnapshotProvider<T>>
    {
        /// <summary>
        /// Register a callback to receive the <see cref="Expression"/> when snapped.
        /// </summary>
        /// <param name="callback">The callback to use.</param>
        /// <returns>A unique identifier used to unregister.</returns>
        string RegisterSnap(Action<Expression> callback);

        /// <summary>
        /// Unregister for callbacks.
        /// </summary>
        /// <param name="id">The unique identifier of the registration.</param>
        void UnregisterSnap(string id);
    }
}
