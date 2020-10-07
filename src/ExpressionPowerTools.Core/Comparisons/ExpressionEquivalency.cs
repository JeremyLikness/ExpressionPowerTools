// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
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
        /// A lazy proxy to the rules.
        /// </summary>
        private static readonly Lazy<IExpressionComparisonRuleProvider> Provider =
            ServiceHost.GetLazyService<IExpressionComparisonRuleProvider>();

        /// <summary>
        /// Lazy proxy for member information.
        /// </summary>
        private static readonly Lazy<IMemberAdapter> MemberAdapter =
            ServiceHost.GetLazyService<IMemberAdapter>();

        /// <summary>
        /// Gets the configured rule set.
        /// </summary>
        private static IExpressionComparisonRuleProvider Rules =>
            Provider.Value;

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
                if (!target.IsAnonymousType())
                {
                    return false;
                }
                else
                {
                    var srcTypes = source.GetProperties()
                        .Select(p => p.PropertyType).ToArray();
                    var tgtTypes = target.GetProperties()
                        .Select(p => p.PropertyType).ToArray();
                    if (srcTypes.Length != tgtTypes.Length)
                    {
                        return false;
                    }

                    for (var idx = 0; idx < srcTypes.Length; idx++)
                    {
                        if (!TypesAreEquivalent(
                            srcTypes[idx],
                            tgtTypes[idx]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
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

            if (source is Type srcType)
            {
                return TypesAreEquivalent(srcType, target as Type);
            }

            if (source is Expression expression)
            {
                return AreEquivalent(expression, target as Expression);
            }

            if (source is MemberBinding memberBinding)
            {
                return MemberBindingsAreEquivalent(memberBinding, target as MemberBinding);
            }

            if (source is ElementInit elemInit)
            {
                if (target is ElementInit tgtElemInit)
                {
                    if (!ReferenceEquals(elemInit.AddMethod, tgtElemInit.AddMethod))
                    {
                        return false;
                    }

                    return AreEquivalent(elemInit.Arguments, tgtElemInit.Arguments);
                }

                return false;
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
                return AnonymousValuesAreEquivalent(source, target);
            }

            if (source is IDictionary dictionary)
            {
                return DictionariesAreEquivalent(dictionary, target as IDictionary);
            }

            var equatableType = typeof(IEquatable<>)
                    .MakeGenericType(type);

            if (equatableType.IsAssignableFrom(type))
            {
                if (!equatableType.IsAssignableFrom(target.GetType()))
                {
                    return false;
                }

                var equatable = equatableType.GetMethod(nameof(IEquatable<object>.Equals));
                return (bool)equatable.Invoke(source, new object[] { target });
            }

            if (typeof(IComparable).IsAssignableFrom(type))
            {
                return ((IComparable)source).CompareTo(target) == 0;
            }

            if (source is ConstructorInfo info)
            {
                if (target is ConstructorInfo targetInfo)
                {
                    return TypesAreEquivalent(
                        info.DeclaringType,
                        targetInfo.DeclaringType) &&
                        NonGenericEnumerablesAreEquivalent(
                            info.GetParameters()
                            .Select(p => p.ParameterType),
                            targetInfo.GetParameters()
                            .Select(p => p.ParameterType));
                }

                return false;
            }

            if (source is Exception ex)
            {
                return target is Exception ex2 && ex.Message == ex2.Message;
            }

            if (type != typeof(string) && source is IEnumerable enumerable)
            {
                return NonGenericEnumerablesAreEquivalent(
                    enumerable, target as IEnumerable);
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

        private static bool AnonymousValuesAreEquivalent(object source, object target)
        {
            var srcProps = source.GetType().GetProperties();
            var tgtProps = target.GetType().GetProperties();

            if (srcProps.Length != tgtProps.Length ||
                srcProps.Select(p => p.PropertyType)
                .Except(tgtProps.Select(p => p.PropertyType))
                .Any())
            {
                return false;
            }

            for (var idx = 0; idx < srcProps.Length; idx++)
            {
                var srcVal = srcProps[idx].GetValue(source);
                var tgtVal = tgtProps[idx].GetValue(target);

                if (!ValuesAreEquivalent(srcVal, tgtVal))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
