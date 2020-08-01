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
    }
}
