// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Host for comparisons.
    /// </summary>
    public static class ExpressionEquivalency
    {
        /// <summary>
        /// Entry for equivalency comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are equivalent.</returns>
        public static bool AreEquivalent(
            Expression source,
            Expression target)
        {
            if (NullAndTypeCheck(source, target))
            {
                if (source is ConstantExpression constant)
                {
                    return ConstantsAreEquivalent(
                        constant,
                        (ConstantExpression)target);
                }

                if (source is ParameterExpression parameter)
                {
                    return ParametersAreEquivalent(
                        parameter,
                        (ParameterExpression)target);
                }
            }

            return false;
        }

        /// <summary>
        /// Comparison of multiple expressions. Equivalent
        /// only when all elements match, in order, and
        /// pass the equivalent test.
        /// </summary>
        /// <param name="source">The source expressions.</param>
        /// <param name="target">The target expressions.</param>
        /// <returns>A flag indicating whether the two sets of
        /// expressions are equivalent.</returns>
        public static bool AreEquivalent(
            IEnumerable<Expression> source,
            IEnumerable<Expression> target)
        {
            var src = source.GetEnumerator();
            var tgt = target.GetEnumerator();
            while (src.MoveNext())
            {
                if (!tgt.MoveNext())
                {
                    return false;
                }

                if (!AreEquivalent(
                    src.Current,
                    tgt.Current))
                {
                    return false;
                }
            }

            return !tgt.MoveNext();
        }

        /// <summary>
        /// Method to compare two <seealso cref="ConstantExpression"/>
        /// instances.
        /// </summary>
        /// <remarks>
        /// To be true, both must have the same type and value. If the
        /// value is an expression tree, it is recursed.
        /// </remarks>
        /// <param name="source">The source constant.</param>
        /// <param name="target">The target constant.</param>
        /// <returns>A flag indicating whether the two are equivalent.</returns>
        private static bool ConstantsAreEquivalent(
            ConstantExpression source,
            ConstantExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            if (source.Value == null)
            {
                return target.Value == null;
            }

            if (source.Value is Expression src)
            {
                return AreEquivalent(
                    src,
                    target.Value as Expression);
            }

            return source.Value.Equals(target.Value);
        }

        private static bool ParametersAreEquivalent(
            ParameterExpression source,
            ParameterExpression target) =>
            source.Type == target.Type &&
            source.Name == target.Name &&
            source.IsByRef == target.IsByRef;

        /// <summary>
        /// Comparison matrix for types and nulls.
        /// </summary>
        /// <param name="source">The source to compare.</param>
        /// <param name="other">The target to compare to.</param>
        /// <returns>A flag indicating whether the types are
        /// equal and the values are both not null.</returns>
        private static bool NullAndTypeCheck(
            Expression source,
            Expression other)
        {
            if (source == null || other == null)
            {
                return false;
            }

            if (other.GetType() != source.GetType())
            {
                return false;
            }

            return true;
        }
    }
}
