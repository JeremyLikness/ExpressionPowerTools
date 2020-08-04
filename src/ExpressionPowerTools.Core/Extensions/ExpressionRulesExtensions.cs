// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Comparisons;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Building blocks for expression rules.
    /// </summary>
    /// <remarks>
    /// The purpose of these extensions are to provide fluent building blocks for rules. They
    /// can be chained to test any aspect of comparison. See <see cref="DefaultComparisonRules"/> for
    /// example implementations.
    /// </remarks>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Basic rule definition. Exists as a base to provide typed template.
        /// </summary>
        /// <example>
        /// For example:
        /// <code>
        /// ExpressionRulesExtensions.Rule&lt;ConstantExpression>((s, t) => s.Value == t.Vale);
        /// </code>
        /// </example>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule to make.</param>
        /// <returns>The rule as an expression.</returns>
        public static Expression<Func<T, T, bool>> Rule<T>(
            Expression<Func<T, T, bool>> rule)
            where T : Expression => rule;
        }
}
