// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
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
