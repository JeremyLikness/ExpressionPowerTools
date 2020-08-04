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
        /// A rule that checks for equality of enumerable lists.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="enumAccess">The access to the <see cref="System.Collections.IEnumerable"/>.</param>
        /// <returns>A flag indicating whether the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> NonGenericEnumerablesMustMatch<T>(
            Func<T, System.Collections.IEnumerable> enumAccess)
            where T : Expression => (s, t) =>
                eq.NonGenericEnumerablesAreEquivalent(
                    enumAccess(s), enumAccess(t));

        /// <summary>
        /// A rule that checks for equality of enumerable lists AND another rule..
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule that must also pass.</param>
        /// <param name="enumAccess">The access to the <see cref="System.Collections.IEnumerable"/>.</param>
        /// <returns>A flag indicating whether the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> AndNonGenericEnumerablesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, System.Collections.IEnumerable> enumAccess)
            where T : Expression => rule.And(NonGenericEnumerablesMustMatch(enumAccess));

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
