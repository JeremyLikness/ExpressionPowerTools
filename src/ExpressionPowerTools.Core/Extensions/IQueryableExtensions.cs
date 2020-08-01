// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions over the <see cref="IQueryable"/> interface.
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Providers a way to enumerate the expression behind a query.
        /// </summary>
        /// <param name="query">The query to enumerate.</param>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// var query = new List&lt;IQueryableExtensionsTests>()
        ///        .AsQueryable()
        ///        .Where(t => t.GetHashCode() == int.MaxValue);
        /// var target = query.AsEnumerableExpression();
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown when query is null.</exception>
        /// <returns>The <see cref="IExpressionEnumerator"/> instance.</returns>
        public static IExpressionEnumerator AsEnumerableExpression(
             this IQueryable query)
        {
            Ensure.NotNull(() => query);
            return new ExpressionEnumerator(query.Expression);
        }

        /// <summary>
        /// Determines whether the expression tree of the query is equivalent to the other query.
        /// </summary>
        /// <param name="source">The source <see cref="IQueryable"/>.</param>
        /// <param name="target">The target <see cref="IQueryable"/>.</param>
        /// <returns>A flag indicating whether the queries are equivalent.</returns>
        public static bool IsEquivalentTo(
            this IQueryable source,
            IQueryable target) =>
            ExpressionEquivalency.AreEquivalent(
                source.Expression, target?.Expression);

        /// <summary>
        /// Determines whether the expression tree of the query is equivalent to the other query.
        /// </summary>
        /// <typeparam name="T">The entity being queried.</typeparam>
        /// <param name="source">The source <see cref="IQueryable{T}"/>.</param>
        /// <param name="target">The target <see cref="IQueryable{T}"/>.</param>
        /// <returns>A flag indicating whether the queries are equivalent.</returns>
        public static bool IsEquivalentTo<T>(
            this IQueryable<T> source,
            IQueryable<T> target) =>
                IsEquivalentTo(
                    (IQueryable)source, target);

        /// <summary>
        /// Determines whether the expression tree of the query is similar to the other query.
        /// </summary>
        /// <param name="source">The source <see cref="IQueryable"/>.</param>
        /// <param name="target">The target <see cref="IQueryable"/>.</param>
        /// <returns>A flag indicating whether the queries are similar.</returns>
        public static bool IsSimilarTo(
            this IQueryable source,
            IQueryable target) =>
            ExpressionSimilarity.AreSimilar(
                source.Expression, target?.Expression);

        /// <summary>
        /// Determines whether the expression tree of the query is similar to the other query.
        /// </summary>
        /// <typeparam name="T">The entity being queried.</typeparam>
        /// <param name="source">The source <see cref="IQueryable{T}"/>.</param>
        /// <param name="target">The target <see cref="IQueryable{T}"/>.</param>
        /// <returns>A flag indicating whether the queries are similar.</returns>
        public static bool IsSimilarTo<T>(
            this IQueryable<T> source,
            IQueryable<T> target) =>
                IsSimilarTo(
                    (IQueryable)source, target);

        /// <summary>
        /// Generic extension.
        /// </summary>
        /// <typeparam name="T">The query type.</typeparam>
        /// <param name="query">The <see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IExpressionEnumerator"/>.</returns>
        public static IExpressionEnumerator AsEnumerableExpression<T>(
            this IQueryable<T> query)
            => AsEnumerableExpression((IQueryable)query);

        /// <summary>
        /// Creates a queryable from an empty list used for templates to compare.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <returns>The <see cref="IQueryable{T}"/> to build on.</returns>
        public static IQueryable<T> CreateQueryTemplate<T>() =>
            new List<T>().AsQueryable();

        /// <summary>
        /// Creates a new queryable to build a template from.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="noop">The source <see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/> to build on.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Style",
            "IDE0060:Remove unused parameter",
            Justification = "Needed for template")]
        public static IQueryable<T> CreateQueryTemplate<T>(
            this IQueryable<T> noop) =>
            CreateQueryTemplate<T>();

        /// <summary>
        /// Determine whether a fragment of queryable exists in the
        /// target query.
        /// </summary>
        /// <remarks>
        /// This will return true if all parts of the fragment's expression tree
        /// are similar to all parts of a similar expression in the source.
        /// </remarks>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="source">The <see cref="IQueryable{T}"/> to check.</param>
        /// <param name="fragment">The fragment to test.</param>
        /// <returns>A flag indicating whether the fragment is part of the parent query.</returns>
        public static bool HasFragment<T>(
            this IQueryable<T> source,
            Func<IQueryable<T>, IQueryable<T>> fragment)
        {
            var target = fragment(source.CreateQueryTemplate());
            return target.Expression.IsPartOf(source.Expression);
        }

        /// <summary>
        /// Creates a snapshot that allows a registered callback to
        /// inspect the expression when the query is executed.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="source">The source query.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The query with snapshot applied.</returns>
        public static IQuerySnapshotHost<T> CreateSnapshotQueryable<T>(
            this IQueryable<T> source,
            Action<Expression> callback)
        {
            var snapshot = new QuerySnapshotHost<T>(source);
            snapshot.RegisterSnap(callback);
            return snapshot;
        }

        /// <summary>
        /// Creates a query that can transformation the <see cref="Expression"/>
        /// wen run.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="source">The source query.</param>
        /// <param name="transformation">The transformation to apply.</param>
        /// <returns>The new intercepting query.</returns>
        public static IQueryable<T> CreateInterceptedQueryable<T>(
            this IQueryable<T> source,
            ExpressionTransformer transformation)
        {
            var provider = new QueryInterceptingProvider<T>(source);
            var interceptingHost = new QueryHost<T, QueryInterceptingProvider<T>>(
                source.Expression, provider);
            provider.RegisterInterceptor(transformation);
            return interceptingHost;
        }
    }
}
