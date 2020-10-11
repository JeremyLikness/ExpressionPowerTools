// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;
using rules = ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Default set of rules to use.
    /// </summary>
    /// <remarks>
    /// <para>The documentation for each rule has remarks that detail the application of the rule.</para>
    /// <para>When documentation refers to "are similar" it means the similarity rules are applied to the child expressions.
    /// Types are similar if one is assignable to the other.</para>
    /// <para>Is a part of refers to the expression tree. For example, a take might be buried inside an include, but a top level
    /// take will pass "is part of" an expression with a nest take.</para>
    /// </remarks>
    public class DefaultComparisonRules : IExpressionComparisonRuleProvider
    {
        /// <summary>
        /// Internal cache of compiled rules.
        /// </summary>
        private readonly IDictionary<Type, ExpressionComparer> cache =
            new Dictionary<Type, ExpressionComparer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultComparisonRules"/> class.
        /// </summary>
        public DefaultComparisonRules()
        {
            cache.Add(
                typeof(ConstantExpression),
                CreateComparer(DefaultConstantRules, DefaultConstantSimilarities));

            cache.Add(
                typeof(InvocationExpression),
                CreateComparer(DefaultInvocationRules, DefaultInvocationSimilarities));

            cache.Add(
                typeof(LambdaExpression),
                CreateComparer(DefaultLambdaRules, DefaultLambdaSimilarities));

            cache.Add(
                typeof(MethodCallExpression),
                CreateComparer(DefaultMethodRules, DefaultMethodSimilarities));

            cache.Add(
                typeof(MemberExpression),
                CreateComparer(DefaultMemberRules, DefaultMemberSimilarities));

            cache.Add(
                typeof(UnaryExpression),
                CreateComparer(DefaultUnaryRules, DefaultUnarySimilarities));

            cache.Add(
                typeof(BinaryExpression),
                CreateComparer(DefaultBinaryRules, DefaultBinarySimilarities));

            cache.Add(
                typeof(ParameterExpression),
                CreateComparer(DefaultParameterRules, DefaultParameterSimilarities));

            cache.Add(
                typeof(NewArrayExpression),
                CreateComparer(DefaultNewArrayRules, DefaultNewArraySimilarities));

            cache.Add(
                typeof(NewExpression),
                CreateComparer(DefaultNewRules, DefaultNewSimilarities));

            cache.Add(
                typeof(MemberInitExpression),
                CreateComparer(DefaultMemberInitRules, DefaultMemberInitSimilarities));

            // show case of default false
            cache.Add(
                typeof(GotoExpression), CreateComparer<GotoExpression>(null, null));
        }

        /// <summary>
        /// Gets the rules for equivalency of <see cref="ConstantExpression"/>.
        /// </summary>
        /// <remarks>
        /// Must be of same type. Both must be null or not null. If the value is an expression, the expressions
        /// must be equivalent. If the values are enumerable, the contents of the enumerable must match. The
        /// values must pass <see cref="eq.ValuesAreEquivalent(object, object)"/>.
        /// </remarks>
        public static Expression<Func<ConstantExpression, ConstantExpression, bool>>
            DefaultConstantRules
        { get; } =
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
                            .Or((s, t) => eq.ValuesAreEquivalent(s.Value, t.Value)));

        /// <summary>
        /// Gets the default rule for similarities between constants.
        /// </summary>
        /// <remarks>
        /// Type type of the values must be assignable to each other. Both values must either
        /// be <c>null</c> or not <c>null</c>. If the values are expressions, the expressions must
        /// be similar. If array, collection, or enumerable then the expressions are similar regardless
        /// of the contents. Otherwise, must pass <see cref="eq.ValuesAreEquivalent(object, object)"/>.
        /// </remarks>
        public static Expression<Func<ConstantExpression, ConstantExpression, bool>>
            DefaultConstantSimilarities
        { get; } =
            rules.If(
                condition: rules.SourceTypeMustBeSimilarToExpression<ConstantExpression>()
                           .Or(rules.TypesMustBeSimilar<ConstantExpression>()),
                ifTrue: rules.If(
                    condition: (s, t) => s.Value == null,
                    ifTrue: (s, t) => t.Value == null,
                    ifFalse: rules.If(
                        condition: (s, t) => s.Value is Expression,
                        ifTrue: rules.ExpressionsMustBeSimilar<ConstantExpression>(e => e.Value as Expression),
                        ifFalse: rules.If(
                            condition: rules.SourceTypeMustBeArrayOrCollection<ConstantExpression>(),
                            ifTrue: rules.True<ConstantExpression>(),
                            ifFalse: rules.If(
                                condition: (s, t) => s.Type == typeof(string),
                                ifTrue: (s, t) => s.Value == t.Value,
                                ifFalse: rules.If(
                                    condition: rules.SourceTypeMustBeTypedEnumerable<ConstantExpression>(),
                                    ifTrue: rules.True<ConstantExpression>(),
                                    ifFalse: (s, t) => eq.ValuesAreEquivalent(s.Value, t.Value)))))),
                ifFalse: rules.False<ConstantExpression>());

        /// <summary>
        /// Gets the default rules for lambda.
        /// </summary>
        /// <remarks>The name of the lambda expressions must be equal. The main expression body must
        /// be equivalent between the source and target, and if one is tail call optimized, the other must be, too.</remarks>
        public static Expression<Func<LambdaExpression, LambdaExpression, bool>>
            DefaultLambdaRules
        { get; } =
            rules.MembersMustMatch<LambdaExpression>(e => e.Name)
            .AndMembersMustMatch(e => e.TailCall)
            .AndExpressionsMustBeEquivalent(e => e.Body);

        /// <summary>
        /// Gets the default similarities for lambda.
        /// </summary>
        /// <remarks>
        /// The name must match, the count of parameters must match, and parameters must be similar.
        /// The source expression must be part of the target expression.
        /// </remarks>
        public static Expression<Func<LambdaExpression, LambdaExpression, bool>>
            DefaultLambdaSimilarities
        { get; } =
            rules.MembersMustMatch<LambdaExpression>(e => e.Name)
            .AndMembersMustMatch(e => e.Parameters.Count)
            .AndEnumerableExpressionsMustBeSimilar(e => e.Parameters)
            .AndSourceMustBePartofTarget(e => e.Body);

        /// <summary>
        /// Gets the default rules for invocations.
        /// </summary>
        /// <remarks>
        /// The return types must match. The expressions must be equivalent. All arguments must be equivalent.
        /// </remarks>
        public static Expression<Func<InvocationExpression, InvocationExpression, bool>>
            DefaultInvocationRules
        { get; } =
                rules.TypesMustMatch<InvocationExpression>()
                .AndExpressionsMustBeEquivalent(e => e.Expression)
                .AndEnumerableExpressionsMustBeEquivalent(e => e.Arguments);

        /// <summary>
        /// Gets the default similarities for lambda.
        /// </summary>
        /// <remarks>
        /// The return types must be similar. Argument counts must match and all arguments must be
        /// similar. The source expression must be part of the target expression.
        /// </remarks>
        public static Expression<Func<InvocationExpression, InvocationExpression, bool>>
            DefaultInvocationSimilarities
        { get; } =
            rules.TypesMustBeSimilar<InvocationExpression>()
            .AndMembersMustMatch(e => e.Arguments.Count)
            .AndEnumerableExpressionsMustBeSimilar(e => e.Arguments)
            .AndSourceMustBePartofTarget(e => e.Expression);

        /// <summary>
        /// Gets the default rules for method calls.
        /// </summary>
        /// <remarks>
        /// The types must match. The method name and declaring type must match. If the
        /// <c>Object</c> property is not null, the properties must be equivalent. The
        /// source and target must have equivalent count of arguments and each argument
        /// must be equivalent.
        /// </remarks>
        public static Expression<Func<MethodCallExpression, MethodCallExpression, bool>>
            DefaultMethodRules
        { get; } =
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
        /// Gets the defeault rules for method call similarities.
        /// </summary>
        /// <remarks>
        /// The types must be similar. The name and count of arguments must be equal. If the
        /// <c>Object</c> property exists, the source object must be part of the target.
        /// Arguments must be similar.
        /// </remarks>
        public static Expression<Func<MethodCallExpression, MethodCallExpression, bool>>
            DefaultMethodSimilarities
        { get; } =
            rules.TypesMustBeSimilar<MethodCallExpression>()
            .AndTypesMustBeSimilar(e => e.Method.DeclaringType)
            .AndMembersMustMatch(e => e.Method.Name)
            .AndMembersMustMatch(e => e.Arguments.Count)
            .AndIf(
                condition: (s, t) => s.Object != null,
                rules.SourceMustBePartofTarget<MethodCallExpression>(
                    e => e.Object))
            .And((s, t) => ExpressionSimilarity.ArgumentsAreSimilar(
                s.Arguments,
                t.Arguments));

        /// <summary>
        /// Gets the default rules for member equivalency.
        /// </summary>
        /// <remarks>
        /// Must be the same type, have the same name and declaring type. If the
        /// member has an expression, the source and target expressions must be
        /// equivalent.
        /// </remarks>
        public static Expression<Func<MemberExpression, MemberExpression, bool>>
            DefaultMemberRules
        { get; } =
            rules.TypesMustMatch<MemberExpression>()
            .AndMembersMustMatch(e => e.Member.Name)
            .AndMembersMustMatch(e => e.Member.DeclaringType)
            .AndIf(
                condition: (s, t) => s.Expression != null,
                ifTrue: (s, t) => eq.AreEquivalent(s.Expression, t.Expression));

        /// <summary>
        /// Gets the default rules for member similarity.
        /// </summary>
        /// <remarks>
        /// The the types must be similar. Names and declarity types must be equal.
        /// If the expression is not <c>null</c>, the source must be part of the
        /// target.
        /// </remarks>
        public static Expression<Func<MemberExpression, MemberExpression, bool>>
            DefaultMemberSimilarities
        { get; } =
            rules.TypesMustBeSimilar<MemberExpression>()
            .AndMembersMustMatch(e => e.Member.Name)
            .AndMembersMustMatch(e => e.Member.DeclaringType)
            .AndIf(
                condition: (s, t) => s.Expression != null,
                ifTrue: rules.SourceMustBePartofTarget<MemberExpression>(e => e.Expression));

        /// <summary>
        /// Gets the default rules for unaries.
        /// </summary>
        /// <remarks>
        /// The types, node type, "is lifted" flag, "is lifted to null" flag must be equal.
        /// If the method is not null, the method name and declaring type must match.
        /// The operands must be equivalent.
        /// </remarks>
        public static Expression<Func<UnaryExpression, UnaryExpression, bool>>
            DefaultUnaryRules
        { get; } =
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
        /// Gets the default rules for unary similarities.
        /// </summary>
        /// <remarks>
        /// The node types must match, the methods, if they exist, must have the
        /// same name and similar declaring type. The source operand must be part
        /// of the target operand.
        /// </remarks>
        public static Expression<Func<UnaryExpression, UnaryExpression, bool>>
            DefaultUnarySimilarities
        { get; } =
            rules.NodeTypesMustMatch<UnaryExpression>()
            .AndMembersMustMatchNullOrNotNull(m => m.Method)
            .AndIf(
                condition: (s, t) => s.Method != null,
                ifTrue: rules.MembersMustMatch<UnaryExpression>(e => e.Method.Name)
                        .AndTypesMustBeSimilar(e => e.Method.DeclaringType))
            .AndSourceMustBePartofTarget(e => e.Operand);

        /// <summary>
        /// Gets the default rules for binaries.
        /// </summary>
        /// <remarks>
        /// The node types (i.e. "Greater than", "Equals", etc.) must be equal.
        /// The left and right expressions must both be equivalent.
        /// </remarks>
        public static Expression<Func<BinaryExpression, BinaryExpression, bool>>
            DefaultBinaryRules
        { get; } =
            rules.NodeTypesMustMatch<BinaryExpression>()
            .AndExpressionsMustBeEquivalent(e => e.Left)
            .AndExpressionsMustBeEquivalent(e => e.Right);

        /// <summary>
        /// Gets the default rules for binary similarities.
        /// </summary>
        /// <remarks>
        /// The node types must be equal. The left and right expressions must be
        /// similar.
        /// </remarks>
        public static Expression<Func<BinaryExpression, BinaryExpression, bool>>
            DefaultBinarySimilarities
        { get; } =
            rules.NodeTypesMustMatch<BinaryExpression>()
            .AndExpressionsMustBeSimilar(e => e.Left)
            .AndExpressionsMustBeSimilar(e => e.Right);

        /// <summary>
        /// Gets the default rules for parameters.
        /// </summary>
        /// <remarks>
        /// The type, name, and "by reference" flags must all be equal.
        /// </remarks>
        public static Expression<Func<ParameterExpression, ParameterExpression, bool>>
            DefaultParameterRules
        { get; } =
            rules.TypesMustMatch<ParameterExpression>()
            .AndMembersMustMatch(e => e.Name)
            .AndMembersMustMatch(e => e.IsByRef);

        /// <summary>
        /// Gets the default rules for parameter similarities.
        /// </summary>
        /// <remarks>
        /// The types must be similar.
        /// </remarks>
        public static Expression<Func<ParameterExpression, ParameterExpression, bool>>
            DefaultParameterSimilarities
        { get; } =
            rules.TypesMustBeSimilar<ParameterExpression>();

        /// <summary>
        /// Gets the default rules for new arrays.
        /// </summary>
        /// <remarks>
        /// The types must be equal. Each expression in the source array must have
        /// an equivalnet expression in the target array.
        /// </remarks>
        public static Expression<Func<NewArrayExpression, NewArrayExpression, bool>>
            DefaultNewArrayRules
        { get; } =
            rules.TypesMustMatch<NewArrayExpression>()
            .AndEnumerableExpressionsMustBeEquivalent(e => e.Expressions);

        /// <summary>
        /// Gets the default rules for new array similarities.
        /// </summary>
        /// <remarks>
        /// Types must be similar. Each expression in the source must have a similar
        /// expression in the target.
        /// </remarks>
        public static Expression<Func<NewArrayExpression, NewArrayExpression, bool>>
            DefaultNewArraySimilarities
        { get; } =
            rules.TypesMustBeSimilar<NewArrayExpression>()
            .AndEnumerableExpressionsMustBeSimilar(e => e.Expressions);

        /// <summary>
        /// Gets the default rules for object initializers.
        /// </summary>
        /// <remarks>
        /// The types must be equal. The constructors must be identical (i.e. not a
        /// different override). The constuctor arguments must be equivalent.
        /// </remarks>
        public static Expression<Func<NewExpression, NewExpression, bool>>
            DefaultNewRules
        { get; } =
            rules.TypesMustMatch<NewExpression>()
            .AndMembersMustMatch(e => e.Constructor)
            .AndEnumerableExpressionsMustBeEquivalent(e => e.Arguments)
            .AndIf(
                condition: (s, t) => s.Members != null,
                ifTrue: rules.NonGenericEnumerablesMustBeEquivalent<NewExpression>(e => e.Members));

        /// <summary>
        /// Gets the default rules for object initializer similarities.
        /// </summary>
        /// <remarks>
        /// The types must be similar, parameters and arguments must be similar.
        /// </remarks>
        public static Expression<Func<NewExpression, NewExpression, bool>>
            DefaultNewSimilarities
        { get; } =
            rules.TypesMustBeSimilar<NewExpression>()
            .And((s, t) => ExpressionSimilarity.ParameterInfosAreSimilar(
                s.Constructor.GetParameters(),
                t.Constructor.GetParameters()))
            .AndEnumerableExpressionsMustBeSimilar(e => e.Arguments);

        /// <summary>
        /// Gets the default rules for member initializers.
        /// </summary>
        /// <remarks>
        /// The types must be equal. The expression for initialization must
        /// be equivalent. All bindings must be equivalent.
        /// </remarks>
        public static Expression<Func<MemberInitExpression, MemberInitExpression, bool>>
            DefaultMemberInitRules
        { get; } =
            rules.TypesMustMatch<MemberInitExpression>()
            .AndExpressionsMustBeEquivalent(e => e.NewExpression)
            .AndNonGenericEnumerablesMustBeEquivalent(e => e.Bindings);

        /// <summary>
        /// Gets the default rules for member initializer similarites.
        /// </summary>
        /// <remarks>
        /// The types must be similar. The expression for initialization must
        /// be similar. All bindings must be similar.
        /// </remarks>
        public static Expression<Func<MemberInitExpression, MemberInitExpression, bool>>
            DefaultMemberInitSimilarities
        { get; } =
            rules.TypesMustBeSimilar<MemberInitExpression>()
            .AndExpressionsMustBeSimilar(e => e.NewExpression)
            .AndMemberBindingsMustBeSimilar(e => e.Bindings);

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
                return (Func<T, T, bool>)cache[typeof(T)].Equivalency.Original;
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

        /// <summary>
        /// Perform the check against all cached types.
        /// </summary>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        /// <exception cref="ArgumentNullException">Throws when either source or target are null.</exception>
        public bool CheckEquivalency(
            Expression source,
            Expression target) => Compare(source, target);

        /// <summary>
        /// Gets a predicate to compare two expressions of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>The rule or null when not found.</returns>
        public Func<T, T, bool> GetRuleForSimilarity<T>()
            where T : Expression
        {
            if (cache.ContainsKey(typeof(T)))
            {
                return (Func<T, T, bool>)cache[typeof(T)].Similarity.Original;
            }

            return null;
        }

        /// <summary>
        /// Perform the check.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are similar.</returns>
        public bool CheckSimilarity<T>(T source, Expression target)
            where T : Expression
        {
            var rule = GetRuleForSimilarity<T>();
            return rule != null && rule(source, target as T);
        }

        /// <summary>
        /// Checks for similarity against all types.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <returns>A value indicating whether a match was found and was successful.</returns>
        public bool CheckSimilarity(Expression source, Expression target) =>
            Compare(source, target, true);

        /// <summary>
        /// Makes generic access possible from non-generic methods.
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <param name="rule">The rule to cast.</param>
        /// <returns>The non-generic function.</returns>
        private Expression<Func<Expression, Expression, bool>> CastToNonGenericRule<T>(
            Expression<Func<T, T, bool>> rule)
            where T : Expression
        {
            Expression<Func<Expression, Expression, bool>> template = (s, t) => true;
            var sourceAs = Expression.Convert(template.Parameters[0], typeof(T));
            var targetAs = Expression.Convert(template.Parameters[1], typeof(T));
            var returnTarget = Expression.Label(typeof(bool));
            var innerInvoke = Expression.Return(
                returnTarget, Expression.Invoke(rule, sourceAs, targetAs));
            var expr = Expression.Block(
                innerInvoke,
                Expression.Label(returnTarget, Expression.Constant(false)));
            return Expression.Lambda<Func<Expression, Expression, bool>>(
                expr,
                template.Parameters);
        }

        /// <summary>
        /// Compare source to target based on all cached rules.
        /// </summary>
        /// <remarks>
        /// Returns on first match, regardless of success.
        /// </remarks>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <param name="similar">A flag indicating whether similarity should be performed instead of equivalency.</param>
        /// <returns>A flag indicating whether a successful comparison was made.</returns>
        private bool Compare(Expression source, Expression target, bool similar = false)
        {
            Ensure.NotNull(() => source);
            Ensure.NotNull(() => target);

            var type = source.GetType();
            var targetType = target.GetType();

            // direct hit?
            if (cache.ContainsKey(type))
            {
                var comparer = cache[type];
                if (!type.IsAssignableFrom(targetType))
                {
                    return false;
                }

                var comparerFn = similar ? comparer.Similarity.NonGeneric
                    : comparer.Equivalency.NonGeneric;
                return comparerFn(source, target);
            }

            // search for indirect hit
            foreach (var entry in cache)
            {
                if (entry.Key.IsAssignableFrom(type))
                {
                    if (entry.Key.IsAssignableFrom(targetType))
                    {
                        var comparer = entry.Value;
                        var comparerFn = similar ? comparer.Similarity.NonGeneric
                            : comparer.Equivalency.NonGeneric;
                        return comparerFn(source, target);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Create an empty rule.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An empty <see cref="Rule"/>.</returns>
        private Rule CreateEmptyRule<T>()
            where T : Expression => CreateRule(rules.False<T>());

        /// <summary>
        /// Create a rule.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule to make.</param>
        /// <returns>The <see cref="Rule"/>.</returns>
        private Rule CreateRule<T>(Expression<Func<T, T, bool>> rule)
            where T : Expression => new Rule
            {
                Original = rule.Compile(),
                NonGeneric = CastToNonGenericRule(rule).Compile(),
            };

        /// <summary>
        /// Creates an entry for quick retrieval from cache.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="equivalencyRule">The rule for equivalency.</param>
        /// <param name="similarityRule">The rule for similarity.</param>
        /// <returns>The <see cref="ExpressionComparer"/>.</returns>
        private ExpressionComparer CreateComparer<T>(
            Expression<Func<T, T, bool>> equivalencyRule,
            Expression<Func<T, T, bool>> similarityRule)
            where T : Expression => new ExpressionComparer
            {
                Equivalency = equivalencyRule == null ?
                    CreateEmptyRule<T>() :
                    CreateRule(equivalencyRule),
                Similarity = similarityRule == null ?
                    CreateEmptyRule<T>() :
                    CreateRule(similarityRule),
            };

        /// <summary>
        /// A comparison item.
        /// </summary>
        protected struct Rule
        {
            /// <summary>
            /// The original rule.
            /// </summary>
            public object Original;

            /// <summary>
            /// The nongeneric version of the rule.
            /// </summary>
            public Func<Expression, Expression, bool> NonGeneric;
        }

        /// <summary>
        /// A comparer with equivalency and similarity rules.
        /// </summary>
        protected struct ExpressionComparer
        {
            /// <summary>
            /// The equivalency rule.
            /// </summary>
            public Rule Equivalency;

            /// <summary>
            /// The similarity rule.
            /// </summary>
            public Rule Similarity;
        }
    }
}
