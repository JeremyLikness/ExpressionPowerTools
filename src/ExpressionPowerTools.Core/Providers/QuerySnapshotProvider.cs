using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.XPath;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Providers
{
    /// <summary>
    /// Provider that raises an event just before the query is executed.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class QuerySnapshotProvider<T> : IQuerySnapshotProvider<T>
    {
        /// <summary>
        /// Pass through to the original provider.
        /// </summary>
        private readonly IQueryable sourceQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotProvider{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">The query to snapshot.</param>
        public QuerySnapshotProvider(IQueryable sourceQuery)
        {
            this.sourceQuery = sourceQuery;
        }

        /// <summary>
        /// Event raised when the query executes.
        /// </summary>
        public event EventHandler<QuerySnapshotEventArgs> QueryExecuted;

        /// <summary>
        /// Creates the query.
        /// </summary>
        /// <param name="expression">The query <see cref="Expression"/>.</param>
        /// <returns>The query.</returns>
        public IQueryable CreateQuery(Expression expression) =>
            new QuerySnapshotHost<T>(expression, this);

        /// <summary>
        /// Creates the query.
        /// </summary>
        /// <typeparam name="TElement">The entity type.</typeparam>
        /// <param name="expression">The query <see cref="Expression"/>.</param>
        /// <returns>The query.</returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var provider = new QuerySnapshotProvider<TElement>(sourceQuery);
            provider.QueryExecuted += (o, e) => QueryExecuted?.Invoke(o, e);
            return new QuerySnapshotHost<TElement>(expression, provider);
        }

        /// <summary>
        /// Runs the query and returns the result.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to use.</param>
        /// <returns>The query result.</returns>
        public object Execute(Expression expression) =>
            sourceQuery.Provider.Execute(expression);

        /// <summary>
        /// Runs the query and returns the typed result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The query <see cref="Expression"/>.</param>
        /// <returns>The query result.</returns>
        public TResult Execute<TResult>(Expression expression)
        {
            object result = (this as IQueryProvider).Execute(expression);
            return (TResult)result;
        }

        /// <summary>
        /// Return the enumerable result.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to parse.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public IEnumerable<T> ExecuteEnumerable(Expression expression)
        {
            QueryExecuted?.Invoke(this, new QuerySnapshotEventArgs(expression));
            return sourceQuery.Provider.CreateQuery<T>(expression);
        }
    }
}
