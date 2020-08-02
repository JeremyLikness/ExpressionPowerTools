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

        /// <summary>
        /// The <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates whether the node types match.</returns>
        public static Expression<Func<T, T, bool>> NodeTypesMustMatch<T>()
            where T : Expression => (s, t) => s.NodeType == t.NodeType;

        /// <summary>
        /// The <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <param name="rule">The existing rule.</param>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates whether the node types match.</returns>
        public static Expression<Func<T, T, bool>> AndNodeTypesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => And(rule, NodeTypesMustMatch<T>());

        /// <summary>
        /// The <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <param name="rule">The existing rule.</param>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates whether the node types match.</returns>
        public static Expression<Func<T, T, bool>> OrNodeTypesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => Or(rule, NodeTypesMustMatch<T>());

        /// <summary>
        /// The source type must be similar to <see cref="Expression"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>A flag indicating whether the source type is similar to an expression.</returns>
        public static Expression<Func<T, T, bool>> SourceTypeMustBeSimilarToExpression<T>()
            where T : Expression => (s, t) => ExpressionSimilarity.TypesAreSimilar(
                 s.Type, typeof(Expression));

        public static Expression<Func<T, T, bool>> SourceTypeMustBeTypedEnumerable<T>()
            where T : Expression => (s, t) =>
                s.Type.GetInterfaces().Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        public static Expression<Func<T, T, bool>> SourceTypeMustBeArrayOrCollection<T>()
            where T : Expression => (s, t) => typeof(Array).IsAssignableFrom(s.Type)
                     || typeof(System.Collections.ICollection).IsAssignableFrom(s.Type);

        /// <summary>
        /// Types of the expressions must be the same.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types match.</returns>
        public static Expression<Func<T, T, bool>> TypesMustMatch<T>()
            where T : Expression => (s, t) => s.Type == t.Type;

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <param name="rule">The rule to include.</param>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> AndTypesMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => And(rule, TypesMustBeSimilar<T>());

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> TypesMustBeSimilar<T>()
            where T : Expression => (s, t) => ExpressionSimilarity.TypesAreSimilar(s.Type, t.Type);

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <param name="rule">The rule to attach to.</param>
        /// <param name="typeAccess">Access to the type.</param>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> AndTypesMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, Type> typeAccess)
            where T : Expression => rule.And(TypesMustBeSimilar<T>(typeAccess));

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <param name="typeAccess">Access to the type.</param>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> TypesMustBeSimilar<T>(
            Func<T, Type> typeAccess)
            where T : Expression => (s, t) => ExpressionSimilarity.TypesAreSimilar(
                typeAccess(s), typeAccess(t));

        /// <summary>
        /// Shortcut to match members.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The exist rule to combine with.</param>
        /// <param name="member">Member access.</param>
        /// <returns>An expression that evaluates whether the members match.</returns>
        public static Expression<Func<T, T, bool>> AndMembersMustMatch<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, object> member)
            where T : Expression => And(rule, MembersMustMatch(member));

        /// <summary>
        /// Member on source must match member on target.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">Member access.</param>
        /// <returns>An expression that evaluates whether the members match.</returns>
        public static Expression<Func<T, T, bool>> MembersMustMatch<T>(
            Func<T, object> member)
            where T : Expression => (s, t) =>
            eq.ValuesAreEquivalent(
                member(s),
                member(t));

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
        /// Expressions must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">Reference the property that is an expression.</param>
        /// <returns>A value indicating whether the expressions are similar.</returns>
        public static Expression<Func<T, T, bool>> ExpressionsMustBeSimilar<T>(
            Func<T, Expression> member)
            where T : Expression => (s, t) =>
             ExpressionSimilarity.AreSimilar(member(s), member(t));

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
             ExpressionSimilarity.IsPartOf(member(s), member(t));

        /// <summary>
        /// Expression in each enumerable must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The existing rule.</param>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> AndEnumerableExpressionsMustBeEquivalent<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => And(rule, EnumerableExpressionsMustBeEquivalent(member));

        /// <summary>
        /// Expression in each enumerable must be equivalent.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> EnumerableExpressionsMustBeEquivalent<T>(
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => (s, t) =>
                eq.AreEquivalent(member(s), member(t));

        /// <summary>
        /// Expression in each enumerable must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The existing rule.</param>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables are similar.</returns>
        public static Expression<Func<T, T, bool>> AndEnumerableExpressionsMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => And(rule, EnumerableExpressionsMustBeSimilar(member));

        /// <summary>
        /// Expression in each enumerable must be similar.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="member">The enumerable child expressions.</param>
        /// <returns>A value indicating whether or not the enumerables are similar.</returns>
        public static Expression<Func<T, T, bool>> EnumerableExpressionsMustBeSimilar<T>(
            Func<T, IEnumerable<Expression>> member)
            where T : Expression => (s, t) =>
                ExpressionSimilarity.AreSimilar(member(s), member(t));

        public static Expression<Func<T, T, bool>> AndMembersMustMatchNullOrNotNull<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, object> member)
            where T : Expression => And(rule, MembersMustMatchNullOrNotNull(member));

        public static Expression<Func<T, T, bool>> MembersMustMatchNullOrNotNull<T>(
            Func<T, object> member)
            where T : Expression => (s, t) =>
                (member(s) == null && member(t) == null) ||
                (member(s) != null && member(t) != null);

        public static Expression<Func<T, T, bool>> AndNonGenericEnumerablesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, System.Collections.IEnumerable> enumAccess)
            where T : Expression => rule.And(NonGenericEnumerablesMustMatch(enumAccess));

        /// <summary>
        /// A rule that checks for equality of enumerable lists.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="enumAccess">The access to the <see cref="System.Collections.IEnumerable"/>.</param>
        /// <returns>A flag indicating whether the enumerables match.</returns>
        public static Expression<Func<T, T, bool>> NonGenericEnumerablesMustMatch<T>(
            Func<T, System.Collections.IEnumerable> enumAccess)
            where T : Expression => (s, t) =>
                eq.NonGenericEnumerablesAreEquivalent(
                    enumAccess(s), enumAccess(t));
    }
}
