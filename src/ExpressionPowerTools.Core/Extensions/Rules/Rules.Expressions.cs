// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions related to comparison of <see cref="Expression"/> values.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Expressions must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">Rule to combine with.</param>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the expressions are equivalent.</returns>
        public static Expression<Func<T, T, bool>> AndExpressionsMustBeEquivalent<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, Expression> member)
            where T : Expression => And(rule, ExpressionsMustBeEquivalent(member));

        /// <summary>
        /// Expressions must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the expressions are equivalent.</returns>
        public static Expression<Func<T, T, bool>> ExpressionsMustBeEquivalent<T>(
            Func<T, Expression> member)
            where T : Expression => (s, t) =>
             eq.AreEquivalent(member(s), member(t));

        /// <summary>
        /// Expressions must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the expressions are similar.</returns>
        public static Expression<Func<T, T, bool>> ExpressionsMustBeSimilar<T>(
            Func<T, Expression> member)
            where T : Expression => (s, t) =>
             Comparisons.ExpressionSimilarity.AreSimilar(member(s), member(t));

        /// <summary>
        /// And expressions must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule to consider.</param>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the expressions are similar.</returns>
        public static Expression<Func<T, T, bool>> AndExpressionsMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, Expression> member)
            where T : Expression => rule.And(ExpressionsMustBeSimilar(member));

        /// <summary>
        /// Expression must be part of another.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule to include.</param>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the source is part of the target.</returns>
        public static Expression<Func<T, T, bool>> AndSourceMustBePartofTarget<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, Expression> member)
            where T : Expression => And(rule, SourceMustBePartofTarget(member));

        /// <summary>
        /// Expression must be part of another.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the source is part of the target.</returns>
        public static Expression<Func<T, T, bool>> SourceMustBePartofTarget<T>(
            Func<T, Expression> member)
            where T : Expression => (s, t) =>
             Comparisons.ExpressionSimilarity.IsPartOf(member(s), member(t));
    }
}
