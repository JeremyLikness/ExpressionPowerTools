using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Host to snapshot a query. Will raise an event when it is executed
    /// to allow inspecting the expression.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IQuerySnapshotHost<T> : IOrderedQueryable<T>, IOrderedQueryable
    {
        /// <summary>
        /// Gets the <see cref="IQuerySnapshotProvider{T}"/> that handles the snapshot.
        /// </summary>
        IQuerySnapshotProvider<T> SnapshotProvider { get; }

        /// <summary>
        /// Register a callback to receive the <see cref="Expression"/> when snapped.
        /// </summary>
        /// <param name="callback">The callback to use.</param>
        void RegisterSnap(Action<Expression> callback);
    }
}
