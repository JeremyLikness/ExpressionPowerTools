// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Comparison rules related to members on the <see cref="Expression"/>.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Member on source must match member on target.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">Member access.</param>
        /// <returns>An expression that evaluates whether the members match.</returns>
        public static Expression<Func<T, T, bool>> MembersMustMatch<T>(
            Func<T, object> member)
            where T : Expression => (s, t) =>
            eq.ValuesAreEquivalent(
                member(s),
                member(t));

        /// <summary>
        /// And match members.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The exist rule to combine with.</param>
        /// <param name="member">Member access.</param>
        /// <returns>An expression that evaluates whether the members match.</returns>
        public static Expression<Func<T, T, bool>> AndMembersMustMatch<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, object> member)
            where T : Expression => And(rule, MembersMustMatch(member));

        /// <summary>
        /// Both expressions must either have null members, or not null members.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The access for the member property.</param>
        /// <returns>An expression that evaluates whether the expressions are both null or both not null.</returns>
        public static Expression<Func<T, T, bool>> MembersMustMatchNullOrNotNull<T>(
            Func<T, object> member)
            where T : Expression => (s, t) =>
                (member(s) == null && member(t) == null) ||
                (member(s) != null && member(t) != null);

        /// <summary>
        /// Both expressions must either have null members, or not null members.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule to add.</param>
        /// <param name="member">The access for the member property.</param>
        /// <returns>An expression that evaluates whether the expressions are both null or both not null.</returns>
        public static Expression<Func<T, T, bool>> AndMembersMustMatchNullOrNotNull<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, object> member)
            where T : Expression => And(rule, MembersMustMatchNullOrNotNull(member));
    }
}
