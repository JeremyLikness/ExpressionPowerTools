// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Host for comparisons.
    /// </summary>
    public static class ExpressionEquivalency
    {
        /// <summary>
        /// Default rule set.
        /// </summary>
        private static readonly IExpressionComparisonRuleProvider Rules =
            new DefaultComparisonRules();

        /// <summary>
        /// Entry for equivalency comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are equivalent.</returns>
        public static bool AreEquivalent(
            Expression source,
            Expression target) =>
            ReferenceEquals(source, target) ||
            (NullAndTypeCheck(source, target) &&
            Rules.CheckEquivalency(source, target));

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
            Ensure.NotNull(() => source);
            if (target == null)
            {
                return false;
            }

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
        /// Attempts to compare values in various ways.
        /// </summary>
        /// <param name="source">The source value.</param>
        /// <param name="target">The target value.</param>
        /// <returns>A flag indicating equivalency.</returns>
        public static bool ValuesAreEquivalent(
            object source,
            object target)
        {
            if (source == null)
            {
                return target == null;
            }

            var type = source.GetType();

            var equatableType = typeof(IEquatable<>)
                    .MakeGenericType(type);

            if (equatableType.IsAssignableFrom(type))
            {
                var equatable = equatableType.GetMethod(nameof(IEquatable<object>.Equals));
                return (bool)equatable.Invoke(source, new object[] { target });
            }

            if (typeof(IComparable).IsAssignableFrom(type))
            {
                return ((IComparable)source).CompareTo(target) == 0;
            }

            return source.Equals(target);
        }

        /// <summary>
        /// Ensures two enumerables are same length an each value is equivalent.
        /// </summary>
        /// <param name="srcEnumerable">The source <see cref="IEnumerable"/>.</param>
        /// <param name="tgtEnumerable">The target <see cref="IEnumerable"/>.</param>
        /// <returns>A flag indicating whether the two are equivalent.</returns>
        public static bool NonGenericEnumerablesAreEquivalent(
            IEnumerable srcEnumerable,
            IEnumerable tgtEnumerable)
        {
            Ensure.NotNull(() => srcEnumerable);
            if (tgtEnumerable == null)
            {
                return false;
            }

            var src = srcEnumerable.GetEnumerator();
            var tgt = tgtEnumerable.GetEnumerator();

            while (src.MoveNext())
            {
                if (!tgt.MoveNext())
                {
                    return false;
                }

                if (src.Current == null && tgt.Current == null)
                {
                    continue;
                }

                if (src.Current == null || tgt.Current == null)
                {
                    return false;
                }

                if (!ValuesAreEquivalent(
                    src.Current,
                    tgt.Current))
                {
                    return false;
                }
            }

            return !tgt.MoveNext();
        }

        /// <summary>
        /// Comparison matrix for types and nulls.
        /// </summary>
        /// <param name="source">The source to compare.</param>
        /// <param name="other">The target to compare to.</param>
        /// <returns>A flag indicating whether the types are
        /// equal and the values are both not null.</returns>
        public static bool NullAndTypeCheck(
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
