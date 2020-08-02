// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Interface for a class that provides rules for comparisons.
    /// </summary>
    public interface IExpressionComparisonRuleProvider
    {
        /// <summary>
        /// Gets a predicate to compare two expressions of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>The rule or null when not found.</returns>
        Func<T, T, bool> GetRuleForEquivalency<T>()
            where T : Expression;

        /// <summary>
        /// Perform the check.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        bool CheckEquivalency<T>(
            T source,
            Expression target)
            where T : Expression;

        /// <summary>
        /// Perform the check against all cached types.
        /// </summary>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        /// <exception cref="ArgumentNullException">Throws when either source or target are null.</exception>
        bool CheckEquivalency(
            Expression source,
            Expression target);

        /// <summary>
        /// Gets a predicate to compare two expressions of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>The rule or null when not found.</returns>
        Func<T, T, bool> GetRuleForSimilarity<T>()
            where T : Expression;

        /// <summary>
        /// Perform the check.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are similar.</returns>
        bool CheckSimilarity<T>(
            T source,
            Expression target)
            where T : Expression;

        /// <summary>
        /// Perform the check against all cached types.
        /// </summary>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are similar.</returns>
        /// <exception cref="ArgumentNullException">Throws when either source or target are null.</exception>
        bool CheckSimilarity(
            Expression source,
            Expression target);
    }
}
