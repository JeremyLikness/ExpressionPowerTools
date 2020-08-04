// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Providers
{
    /// <summary>
    /// Provider that raises an event just before the query is executed.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class QuerySnapshotProvider<T> : CustomQueryProvider<T>, IQuerySnapshotProvider<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotProvider{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">The query to snapshot.</param>
        public QuerySnapshotProvider(IQueryable sourceQuery)
            : base(sourceQuery)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotProvider{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">The query to snapshot.</param>
        /// <param name="parent">The parent that created this.</param>
        public QuerySnapshotProvider(IQueryable sourceQuery, IQuerySnapshot parent)
            : base(sourceQuery)
        {
            Parent = parent;
        }

        /// <summary>
        /// Event raised when the query executes.
        /// </summary>
        public event EventHandler<QuerySnapshotEventArgs> QueryExecuted;

        /// <summary>
        /// Gets or sets the <see cref="IQuerySnapshot"/> parent.
        /// </summary>
        public IQuerySnapshot Parent { get; set; }

        /// <summary>
        /// Creates the query.
        /// </summary>
        /// <param name="expression">The query <see cref="Expression"/>.</param>
        /// <returns>The query.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public override IQueryable CreateQuery(Expression expression)
        {
            Ensure.NotNull(() => expression);
            return ServiceHost.GetService<IQuerySnapshotHost<T>>(expression, this);
        }

        /// <summary>
        /// Creates the query.
        /// </summary>
        /// <typeparam name="TElement">The entity type.</typeparam>
        /// <param name="expression">The query <see cref="Expression"/>.</param>
        /// <returns>The query.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Ensure.NotNull(() => expression);
            if (typeof(TElement) == typeof(T))
            {
                return CreateQuery(expression) as IQueryable<TElement>;
            }

            var provider = ServiceHost.GetService<IQuerySnapshotProvider<TElement>>(Source, this);

            return ServiceHost.GetService<IQuerySnapshotHost<TElement>>(expression, provider);
        }

        /// <summary>
        /// Return the enumerable result.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to parse.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public override IEnumerable<T> ExecuteEnumerable(Expression expression)
        {
            Ensure.NotNull(() => expression);
            OnExecuteEnumerableCalled(expression);
            return Source.Provider.CreateQuery<T>(expression);
        }

        /// <summary>
        /// Raise the event.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> used.</param>
        public void OnExecuteEnumerableCalled(Expression expression)
        {
            if (Parent != null)
            {
                Parent.OnExecuteEnumerableCalled(expression);
                return;
            }

            QueryExecuted?.Invoke(this, new QuerySnapshotEventArgs(expression));
        }
    }
}
