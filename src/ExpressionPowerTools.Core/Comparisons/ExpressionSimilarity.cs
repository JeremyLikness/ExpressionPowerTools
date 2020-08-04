// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Expression similarity methods.
    /// </summary>
    public static class ExpressionSimilarity
    {
        /// <summary>
        /// Gets the configured rule set.
        /// </summary>
        private static IExpressionComparisonRuleProvider Rules =>
            ServiceHost.GetService<IExpressionComparisonRuleProvider>();

        /// <summary>
        /// Entry for similarity comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are similar.</returns>
        public static bool AreSimilar(
            Expression source,
            Expression target) =>
                source != null &&
                target != null &&
                Rules.CheckSimilarity(source, target);

        /// <summary>
        /// Comparison of multiple expressions. Similar
        /// only when all elements match, in order, and
        /// pass the similarity test. It's fine if the
        /// source does not have the same number of entities
        /// as the target.
        /// </summary>
        /// <param name="source">The source expressions.</param>
        /// <param name="target">The target expressions.</param>
        /// <returns>A flag indicating whether the two sets of
        /// expressions are Similar.</returns>
        public static bool AreSimilar(
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

                if (!AreSimilar(
                    src.Current,
                    tgt.Current))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether an <see cref="Expression"/> is part of another expression.
        /// </summary>
        /// <remarks>
        /// A source is part of a target if an <see cref="Expression"/> exists in the
        /// target's tree that is similar to the source.
        /// </remarks>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to parse.</param>
        /// <returns>A flag indicating whether the source is part of the target.</returns>
        public static bool IsPartOf(
            Expression source,
            Expression target)
        {
            if (target == null)
            {
                return false;
            }

            var targetTree = ServiceHost.GetService<IExpressionEnumerator>(target);
            return targetTree.Any(t => AreSimilar(source, t));
        }

        /// <summary>
        /// Determines whether types are similar.
        /// </summary>
        /// <remarks>
        /// Object must match object. Value types must match exactly.
        /// Other types can be derived from each other.
        /// </remarks>
        /// <param name="source">The source <see cref="Type"/> to check.</param>
        /// <param name="target">The target <see cref="Type"/> to check.</param>
        /// <returns>A flag indicating whether the types are similar.</returns>
        public static bool TypesAreSimilar(
            Type source,
            Type target)
        {
            if (source == typeof(object))
            {
                return target == typeof(object);
            }

            if (source.IsValueType)
            {
                return source == target;
            }

            return source.IsAssignableFrom(target) ||
                target.IsAssignableFrom(source);
        }

        /// <summary>
        /// Determines whether arguments are similar.
        /// </summary>
        /// <param name="source">The source list.</param>
        /// <param name="target">The target list.</param>
        /// <returns>A value that indicates whether the arguments are similar.</returns>
        public static bool ArgumentsAreSimilar(
            IList<Expression> source,
            IList<Expression> target)
        {
            for (var idx = 0; idx < source.Count; idx += 1)
            {
                bool similar;
                if (source[idx].GetType() == target[idx].GetType())
                {
                    similar = IsPartOf(source[idx], target[idx]);
                }
                else
                {
                    similar = TypesAreSimilar(source[idx].Type, target[idx].Type);
                }

                if (!similar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
