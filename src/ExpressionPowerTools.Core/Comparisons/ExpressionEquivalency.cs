// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Host for comparisons.
    /// </summary>
    public static class ExpressionEquivalency
    {
        /// <summary>
        /// Gets the configured rule set.
        /// </summary>
        private static IExpressionComparisonRuleProvider Rules =>
            ServiceHost.GetService<IExpressionComparisonRuleProvider>();

        /// <summary>
        /// Determine if a <see cref="Type"/> is equivalent to another type.
        /// </summary>
        /// <remarks>
        /// Handles anonymous types converted to dynamic dictionary.
        /// </remarks>
        /// <param name="source">The source <see cref="Type"/>.</param>
        /// <param name="target">The target <see cref="Type"/>.</param>
        /// <returns>A value indicating whether the types are equivalent.</returns>
        public static bool TypesAreEquivalent(Type source, Type target)
        {
            if (source.IsAnonymousType())
            {
                if (target.IsAnonymousType())
                {
                    return source.ToString() == target.ToString();
                }

                return typeof(IDictionary).IsAssignableFrom(target) ||
                    typeof(IDictionary<string, object>).IsAssignableFrom(target);
            }

            return source == target;
        }

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
        /// <remarks>
        /// If one side is <c>null</c> and other is not <c>null</c>, returns <c>false</c>. If the objects are the same reference,
        /// returns <c>true</c>. If the type implements <see cref="IEquatable{T}"/> then the result of <see cref="IEquatable{T}.Equals(T)"/>
        /// is returned. If the type implements <see cref="IComparable"/> then the result is <c>true</c> if
        /// <see cref="IComparable.CompareTo(object)"/> is <c>0</c>. Otherwise, the result of <see cref="object.Equals(object)"/> from
        /// the source to the target is returned.
        /// </remarks>
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

            if (ReferenceEquals(source, target))
            {
                return true;
            }

            if (source is Expression expression)
            {
                return AreEquivalent(expression, target as Expression);
            }

            if (source is MemberBinding memberBinding)
            {
                return MemberBindingsAreEquivalent(memberBinding, target as MemberBinding);
            }

            var type = source.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumerableQuery<>))
            {
                var targetType = target.GetType();
                return targetType.IsGenericType &&
                    targetType.GetGenericTypeDefinition() == typeof(EnumerableQuery<>) &&
                    !targetType.GenericTypeArguments.Except(type.GenericTypeArguments).Any();
            }

            if (type.IsAnonymousType())
            {
                var src = type.GetProperties().Select(p => new { p.Name, Value = p.GetValue(source) })
                    .ToDictionary(p => p.Name, p => p.Value);
                if (target is IDictionary tgt)
                {
                    return DictionariesAreEquivalent(src, tgt);
                }

                if (target is IDictionary<string, object> tgtExpando)
                {
                    return DictionariesAreEquivalent(
                        src,
                        tgtExpando.ToDictionary(t => t.Key, t => t.Value));
                }

                return DictionariesAreEquivalent(
                    src,
                    target.GetType().GetProperties().Select(
                        p => new { p.Name, Value = p.GetValue(target) })
                    .ToDictionary(p => p.Name, p => p.Value));
            }

            if (source is IDictionary dictionary)
            {
                return DictionariesAreEquivalent(dictionary, target as IDictionary);
            }

            if (source is IEnumerable enumerable)
            {
                return NonGenericEnumerablesAreEquivalent(
                    enumerable, target as IEnumerable);
            }

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

            if (source is Exception ex)
            {
                return target is Exception ex2 && ex.Message == ex2.Message;
            }

            return source.Equals(target);
        }

        /// <summary>
        /// Ensures that two <see cref="MemberBinding"/> instances are equivalent.
        /// </summary>
        /// <param name="source">The source <see cref="MemberBinding"/>.</param>
        /// <param name="target">The target <see cref="MemberBinding"/>.</param>
        /// <returns>A value that indicates whether the bindings are equivalent.</returns>
        public static bool MemberBindingsAreEquivalent(
            MemberBinding source,
            MemberBinding target)
        {
            Ensure.NotNull(() => source);
            if (target == null)
            {
                return false;
            }

            if (source.BindingType != target.BindingType ||
                !Equals(source.Member, target.Member))
            {
                return false;
            }

            if (source is MemberAssignment ma)
            {
                var tgtma = target as MemberAssignment;
                return AreEquivalent(ma.Expression, tgtma.Expression);
            }

            if (source is MemberMemberBinding mb)
            {
                var tgtmb = target as MemberMemberBinding;
                return NonGenericEnumerablesAreEquivalent(mb.Bindings, tgtmb.Bindings);
            }

            if (source is MemberListBinding ml)
            {
                var tgtml = target as MemberListBinding;
                return NonGenericEnumerablesAreEquivalent(ml.Initializers, tgtml.Initializers);
            }

            return false;
        }

        /// <summary>
        /// Ensures two dictionaries are equivalent.
        /// </summary>
        /// <param name="source">The source <see cref="IDictionary"/>.</param>
        /// <param name="target">The target <see cref="IDictionary"/>.</param>
        /// <returns>A value indicating whether the dictionaries are equivalent.</returns>
        public static bool DictionariesAreEquivalent(
            IDictionary source,
            IDictionary target)
        {
            Ensure.NotNull(() => source);
            if (target == null)
            {
                return false;
            }

            return NonGenericEnumerablesAreEquivalent(source.Keys, target.Keys) &&
                NonGenericEnumerablesAreEquivalent(source.Values, target.Values);
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
