// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Comparisons;
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
        /// Each value in the enumerable must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The enumerable child.</param>
        /// <returns>A value indicating whether or not the enumerable values match.</returns>
        public static Expression<Func<T, T, bool>> NonGenericEnumerablesMustBeEquivalent<T>(
            Func<T, IEnumerable> member)
            where T : Expression => (s, t) =>
                eq.NonGenericEnumerablesAreEquivalent(member(s), member(t));

        /// <summary>
        /// Each value in the enumerable must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The existing rule.</param>
        /// <param name="member">The enumerable child.</param>
        /// <returns>A value indicating whether or not the enumerable values match.</returns>
        public static Expression<Func<T, T, bool>> AndNonGenericEnumerablesMustBeEquivalent<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, IEnumerable> member)
            where T : Expression => And(rule, NonGenericEnumerablesMustBeEquivalent(member));

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

        /// <summary>
        /// Each value in the binding list must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The binding list child.</param>
        /// <returns>A value indicating whether or not the bindings are all similar.</returns>
        public static Expression<Func<T, T, bool>> MemberBindingsMustBeSimilar<T>(
            Func<T, IList<MemberBinding>> member)
            where T : Expression => (s, t) =>
                ExpressionSimilarity.MemberBindingsAreSimilar(member(s), member(t));

        /// <summary>
        /// Each value in the binding list must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The existing rule.</param>
        /// <param name="member">The binding list child.</param>
        /// <returns>A value indicating whether or not the bindings are all similar.</returns>
        public static Expression<Func<T, T, bool>> AndMemberBindingsMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, IList<MemberBinding>> member)
            where T : Expression => And(rule, MemberBindingsMustBeSimilar(member));
    }
}
