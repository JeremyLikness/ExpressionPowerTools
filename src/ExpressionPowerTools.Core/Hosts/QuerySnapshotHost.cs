// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Hosts
{
    /// <summary>
    /// A host to snapshot the query on execution.
    /// </summary>
    /// <typeparam name="T">The type of the query.</typeparam>
    public class QuerySnapshotHost<T> : IQuerySnapshotHost<T>
    {
        private readonly Stack<Action<Expression>> callbacks =
            new Stack<Action<Expression>>();

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
            : this(expression, new QuerySnapshotProvider<T>(source))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotHost{T}"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/>.</param>
        /// <param name="provider">The <see cref="IQuerySnapshotProvider{T}"/>.</param>
        public QuerySnapshotHost(
            Expression expression,
            IQuerySnapshotProvider<T> provider)
        {
            Expression = expression;
            SnapshotProvider = provider;
        }

        /// <summary>
        /// Gets the type of element.
        /// </summary>
        public Type ElementType => typeof(T);

        /// <summary>
        /// Gets the <see cref="Expression"/> for the query.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IQueryProvider"/>.
        /// </summary>
        public IQueryProvider Provider => SnapshotProvider;

        /// <summary>
        /// Gets the instance of the <see cref="IQuerySnapshotProvider{T}"/>.
        /// </summary>
        public IQuerySnapshotProvider<T> SnapshotProvider { get; private set; }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> for the query results.
        /// </summary>
        /// <returns>The <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator() =>
            SnapshotProvider.ExecuteEnumerable(Expression).GetEnumerator();

        /// <summary>
        /// Register for a callback when the <see cref="Expression"/> is executed.
        /// </summary>
        /// <param name="callback">The callback to pass the expression to.</param>
        public void RegisterSnap(Action<Expression> callback)
        {
            callbacks.Push(callback);
            if (!registered)
            {
                SnapshotProvider.QueryExecuted += SnapshotProvider_QueryExecuted;
                registered = true;
            }
        }

        /// <summary>
        /// Gets the non-typed <see cref="IEnumerator"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Handle snap.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="QuerySnapshotEventArgs"/>.</param>
        private void SnapshotProvider_QueryExecuted(object sender, QuerySnapshotEventArgs e)
        {
            while (callbacks.Count > 0)
            {
                var callback = callbacks.Pop();
                callback(e.Expression);
            }

            registered = false;
            SnapshotProvider.QueryExecuted -= SnapshotProvider_QueryExecuted;
        }
    }
}
