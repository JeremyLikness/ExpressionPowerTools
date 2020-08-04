// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions that relate to enumerable comparisons.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Expression in each enumerable must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> EnumerableExpressionsMustBeEquivalent<T>(
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => (s, t) =>
                eq.AreEquivalent(member(s), member(t));

        /// <summary>
        /// Expression in each enumerable must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The existing rule.</param>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> AndEnumerableExpressionsMustBeEquivalent<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => And(rule, EnumerableExpressionsMustBeEquivalent(member));

        /// <summary>
        /// Expression in each enumerable must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables are similar.</returns>
        public static Expression<Func<T, T, bool>> EnumerableExpressionsMustBeSimilar<T>(
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => (s, t) =>
                Comparisons.ExpressionSimilarity.AreSimilar(member(s), member(t));

        /// <summary>
        /// Expression in each enumerable must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The existing rule.</param>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables are similar.</returns>
        public static Expression<Func<T, T, bool>> AndEnumerableExpressionsMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => And(rule, EnumerableExpressionsMustBeSimilar(member));
    }
}
