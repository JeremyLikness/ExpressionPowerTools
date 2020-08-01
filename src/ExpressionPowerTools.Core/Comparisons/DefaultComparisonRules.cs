// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;
using rules = ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Default set of rules to use.
    /// </summary>
    public class DefaultComparisonRules : IExpressionComparisonRuleProvider
    {
        /// <summary>
        /// Internal cache of compiled rules.
        /// </summary>
        private readonly IDictionary<Type, (object equivalency, object similarity)> cache =
            new Dictionary<Type, (object equivalency, object similiarity)>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultComparisonRules"/> class.
        /// </summary>
        public DefaultComparisonRules()
        {
            cache.Add(
                typeof(ConstantExpression),
                (equivalency: DefaultConstantRules.Compile(), similarity: null));

            cache.Add(
                typeof(LambdaExpression),
                (equivalency: DefaultLambdaRules.Compile(), similarity: null));

            cache.Add(
                typeof(MethodCallExpression),
                (equivalency: DefaultMethodRules.Compile(), similarity: null));

            cache.Add(
                typeof(MemberExpression),
                (equivalency: DefaultMemberRules.Compile(), similarity: null));

            cache.Add(
                typeof(UnaryExpression),
                (equivalency: DefaultUnaryRules.Compile(), similarity: null));

            cache.Add(
                typeof(BinaryExpression),
                (equivalency: DefaultBinaryRules.Compile(), similarity: null));

            cache.Add(
                typeof(ParameterExpression),
                (equivalency: DefaultParameterRules.Compile(), similarity: null));
        }

        /// <summary>
        /// Gets the rules for equivalency of <see cref="ConstantExpression"/>.
        /// </summary>
        public static Expression<Func<ConstantExpression, ConstantExpression, bool>>
            DefaultConstantRules
        { get; private set; } =
                rules.TypesMustMatch<ConstantExpression>()
                .And(
                    rules.If(
                        condition: (s, t) => s.Value == null,
                        ifTrue: (s, t) => t.Value == null,
                        ifFalse: rules.False<ConstantExpression>())
                    .OrIf(
                            condition: (s, t) => s.Value is Expression,
                            ifTrue: (s, t) => eq.AreEquivalent(
                                s.Value as Expression,
                                t.Value as Expression),
                            ifFalse: rules.False<ConstantExpression>())
                        .OrIf(
                                condition: (s, t) => s.Value is System.Collections.IEnumerable,
                                ifTrue: (s, t) => eq.NonGenericEnumerablesAreEquivalent(
                                    s.Value as System.Collections.IEnumerable,
                                    t.Value as System.Collections.IEnumerable),
                                ifFalse: rules.False<ConstantExpression>())
                            .Or((s, t) => eq.ValuesAreEquivalent(s.Value, t.Value)));

        /// <summary>
        /// Gets the rules for lambda.
        /// </summary>
        public static Expression<Func<LambdaExpression, LambdaExpression, bool>>
            DefaultLambdaRules
        { get; private set; } =
            rules.MembersMustMatch<LambdaExpression>(e => e.Name)
            .AndMembersMustMatch(e => e.TailCall)
            .AndExpressionsMustBeEquivalent(e => e.Body);

        /// <summary>
        /// Gets the rules for method calls.
        /// </summary>
        public static Expression<Func<MethodCallExpression, MethodCallExpression, bool>>
            DefaultMethodRules
        { get; private set; } =
            rules.TypesMustMatch<MethodCallExpression>()
            .AndMembersMustMatch(e => e.Method.Name)
            .AndMembersMustMatch(e => e.Method.DeclaringType)
            .AndMembersMustMatch(e => e.Arguments.Count)
            .AndIf(
                condition: (s, t) => s.Object != null,
                ifTrue: (s, t) => eq.AreEquivalent(s.Object, t.Object))
            .AndEnumerableExpressionsMustBeEquivalent(
                e => e.Arguments);

        /// <summary>
        /// Gets the default rules for member equivalency.
        /// </summary>
        public static Expression<Func<MemberExpression, MemberExpression, bool>>
            DefaultMemberRules
        { get; private set; } =
            rules.TypesMustMatch<MemberExpression>()
            .AndMembersMustMatch(e => e.Member.Name)
            .AndMembersMustMatch(e => e.Member.DeclaringType)
            .AndIf(
                condition: (s, t) => s.Expression != null,
                ifTrue: (s, t) => eq.AreEquivalent(s.Expression, t.Expression));

        /// <summary>
        /// Gets the default rules for unaries.
        /// </summary>
        public static Expression<Func<UnaryExpression, UnaryExpression, bool>>
            DefaultUnaryRules
        { get; private set; } =
            rules.TypesMustMatch<UnaryExpression>()
            .AndNodeTypesMustMatch()
            .AndMembersMustMatch(m => m.IsLifted)
            .AndMembersMustMatch(m => m.IsLiftedToNull)
            .AndMembersMustMatchNullOrNotNull(m => m.Method)
            .AndIf(
                condition: (s, t) => s.Method != null,
                ifTrue: rules.MembersMustMatch<UnaryExpression>(e => e.Method.Name)
                        .AndMembersMustMatch(e => e.Method.DeclaringType))
            .And((s, t) => eq.AreEquivalent(s.Operand, t.Operand));

        /// <summary>
        /// Gets the default rules for binaries.
        /// </summary>
        public static Expression<Func<BinaryExpression, BinaryExpression, bool>>
            DefaultBinaryRules
        { get; private set; } =
            rules.NodeTypesMustMatch<BinaryExpression>()
            .AndExpressionsMustBeEquivalent(e => e.Left)
            .AndExpressionsMustBeEquivalent(e => e.Right);

        /// <summary>
        /// Gets the default rules for parameters.
        /// </summary>
        public static Expression<Func<ParameterExpression, ParameterExpression, bool>>
            DefaultParameterRules
        { get; private set; } =
            rules.TypesMustMatch<ParameterExpression>()
            .AndMembersMustMatch(e => e.Name)
            .AndMembersMustMatch(e => e.IsByRef);

        /// <summary>
        /// Gets a predicate to compare two expressions of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>The rule.</returns>
        public Func<T, T, bool> GetRuleForEquivalency<T>()
            where T : Expression
        {
            if (cache.ContainsKey(typeof(T)))
            {
                return (Func<T, T, bool>)cache[typeof(T)].equivalency;
            }

            return null;
        }

        /// <summary>
        /// Perform the check.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        public bool CheckEquivalency<T>(
            T source,
            Expression target)
            where T : Expression
        {
            var rule = GetRuleForEquivalency<T>();
            return rule != null && rule(source, target as T);
        }
    }
}
