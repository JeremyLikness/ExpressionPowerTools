// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
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
        /// A lazy proxy to the rules.
        /// </summary>
        private static readonly Lazy<IExpressionComparisonRuleProvider> Provider =
            ServiceHost.GetLazyService<IExpressionComparisonRuleProvider>();

        /// <summary>
        /// Gets the configured rule set.
        /// </summary>
        private static IExpressionComparisonRuleProvider Rules =>
            Provider.Value;

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
        /// Determines whether a list of parameters for a method or constructor are similar.
        /// </summary>
        /// <param name="source">The source parameter list.</param>
        /// <param name="target">The target parameter list.</param>
        /// <returns>A flag that indicates whether the parameters are similar.</returns>
        public static bool ParameterInfosAreSimilar(
            IList<ParameterInfo> source,
            IList<ParameterInfo> target)
        {
            Ensure.NotNull(() => source);
            if (target == null)
            {
                return false;
            }

            if (source.Count() != target.Count())
            {
                return false;
            }

            var sourceList = source.Select(p => Expression.Parameter(p.ParameterType, p.Name));
            var targetList = target.Select(p => Expression.Parameter(p.ParameterType, p.Name));

            return AreSimilar(sourceList, targetList);
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

        /// <summary>
        /// Determines whether two lists of <see cref="MemberBinding"/> are similar.
        /// </summary>
        /// <param name="source">The source list.</param>
        /// <param name="target">The target list.</param>
        /// <returns>A value indicating whether the individual bindings are similar.</returns>
        public static bool MemberBindingsAreSimilar(
            IList<MemberBinding> source,
            IList<MemberBinding> target)
        {
            if (source.Count() != target.Count())
            {
                return false;
            }

            var similar = true;

            for (var idx = 0; idx < source.Count() && similar; idx += 1)
            {
                if (source[idx].BindingType != target[idx].BindingType)
                {
                    return false;
                }

                if (source[idx] is MemberAssignment assign)
                {
                    var targetAssign = target[idx] as MemberAssignment;
                    similar = assign.Member.MemberType == targetAssign.Member.MemberType &&
                        TypesAreSimilar(assign.Member.DeclaringType, targetAssign.Member.DeclaringType) &&
                        IsPartOf(assign.Expression, targetAssign.Expression);
                }

                if (source[idx] is MemberMemberBinding memberMemberBinding)
                {
                    var targetMemberBinding = target[idx] as MemberMemberBinding;
                    similar = memberMemberBinding.Member.MemberType == targetMemberBinding.Member.MemberType &&
                        TypesAreSimilar(memberMemberBinding.Member.DeclaringType, targetMemberBinding.Member.DeclaringType) &&
                        MemberBindingsAreSimilar(memberMemberBinding.Bindings, targetMemberBinding.Bindings);
                }

                if (source[idx] is MemberListBinding memberListBinding)
                {
                    var targetListBinding = target[idx] as MemberListBinding;
                    similar = memberListBinding.Member.MemberType == targetListBinding.Member.MemberType &&
                        TypesAreSimilar(memberListBinding.Member.DeclaringType, targetListBinding.Member.DeclaringType) &&
                        ExpressionEquivalency.NonGenericEnumerablesAreEquivalent(
                            memberListBinding.Initializers, targetListBinding.Initializers);
                }
            }

            return similar;
        }
    }
}
