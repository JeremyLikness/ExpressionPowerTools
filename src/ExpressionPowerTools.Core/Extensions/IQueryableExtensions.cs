// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Contract;
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
        /// var query = new List{IQueryableExtensionsTests}()
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
        /// Generic extension.
        /// </summary>
        /// <typeparam name="T">The query type.</typeparam>
        /// <param name="query">The <see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IExpressionEnumerator"/>.</returns>
        public static IExpressionEnumerator AsEnumerableExpression<T>(
            this IQueryable<T> query)
            => AsEnumerableExpression((IQueryable)query);
    }
}
