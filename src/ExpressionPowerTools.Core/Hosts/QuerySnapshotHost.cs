// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Hosts
{
    /// <summary>
    /// A host to snapshot the query on execution.
    /// </summary>
    /// <typeparam name="T">The type of the query.</typeparam>
    public class QuerySnapshotHost<T> :
        QueryHost<T, IQuerySnapshotProvider<T>>, IQuerySnapshotHost<T>
    {
        private readonly Dictionary<string, Action<Expression>> callbacks =
            new Dictionary<string, Action<Expression>>();

        private bool registered = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotHost{T}"/> class.
        /// </summary>
        /// <param name="source">The <see cref="IQueryable{T}"/> to snapshot.</param>
        public QuerySnapshotHost(IQueryable<T> source)
            : this(source, source.Expression)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotHost{T}"/> class.
        /// </summary>
        /// <param name="source">The query source.</param>
        /// <param name="expression">The <see cref="Expression"/> to use.</param>
        public QuerySnapshotHost(IQueryable source, Expression expression)
            : base(expression, new QuerySnapshotProvider<T>(source))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotHost{T}"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to use.</param>
        /// <param name="provider">The <see cref="IQuerySnapshotProvider{T}"/> instance.</param>
        public QuerySnapshotHost(Expression expression, IQuerySnapshotProvider<T> provider)
            : base(expression, provider)
        {
        }

        /// <summary>
        /// Register for a callback when the <see cref="Expression"/> is executed.
        /// </summary>
        /// <param name="callback">The callback to pass the expression to.</param>
        /// <returns>A unique identifier for the registration.</returns>
        /// <exception cref="ArgumentNullException">Thrown when callback is null.</exception>
        public string RegisterSnap(Action<Expression> callback)
        {
            Ensure.NotNull(() => callback);
            var id = Guid.NewGuid().ToString();
            callbacks.Add(id, callback);
            if (!registered)
            {
                CustomProvider.QueryExecuted += SnapshotProvider_QueryExecuted;
                registered = true;
            }

            return id;
        }

        /// <summary>
        /// Stop listenining.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        public void UnregisterSnap(string id)
        {
            if (callbacks.ContainsKey(id))
            {
                callbacks.Remove(id);
                if (callbacks.Count < 1)
                {
                    CustomProvider.QueryExecuted -= SnapshotProvider_QueryExecuted;
                    registered = false;
                }
            }
        }

        /// <summary>
        /// Handle snap.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="QuerySnapshotEventArgs"/>.</param>
        private void SnapshotProvider_QueryExecuted(object sender, QuerySnapshotEventArgs e)
        {
            foreach (var callback in callbacks.Values)
            {
                callback(e.Expression);
            }
        }
    }
}
