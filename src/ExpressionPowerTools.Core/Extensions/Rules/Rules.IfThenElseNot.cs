// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions for branching logic.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Enables if ... then logic.
        /// </summary>
        /// <remarks>
        /// Since the logic is Boolean, the statement always returns a <c>bool</c>. If the condition
        /// is true, it evaluates to the result of the <c>ifThen</c> condition. If the condition
        /// is false, it evaluates to the result of the <c>ifFalse</c> condition. The <c>ifFalse</c>
        /// condition evaluates to <c>true</c> by default so it can be part of an "AND" chain. If it
        /// is part of an "OR" chain, you should override <c>ifFalse</c> to return <c>false</c>.
        /// </remarks>
        /// <example>
        /// For example, if first name matches and *if* last name isn't <c>null</c>, then it matches.
        /// <code>
        /// ExpressionRulesExtension.Rule((s, t) => s.FirstName == t.FirstName)
        ///     .And(If(
        ///             condition: (s, t) => s.LastName != null,
        ///             ifTrue: (s, t) => s.LastName == t.LastName
        ///             ));
        /// </code>
        /// In another example, if first name matches *or* if last name is not null and matches.
        /// For last name to "light up" requires that both condition and <c>ifTrue</c> pass.
        /// <code>
        /// ExpressionRulesExtension.Rule((s, t) => s.FirstName == t.FirstName)
        ///     .Or(If(
        ///             condition: (s, t) => s.LastName != null,
        ///             ifTrue: (s, t) => s.LastName == t.LastName,
        ///             ifFalse: ExpressionRuleExtension.False()
        ///             ));
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <param name="condition">The condition that must pass.</param>
        /// <param name="ifTrue">The rule to apply for success.</param>
        /// <param name="ifFalse">The rule to apply for failure.</param>
        /// <returns>The result of the if/then/else evaluation.</returns>
        public static Expression<Func<T, T, bool>> If<T>(
            Expression<Func<T, T, bool>> condition,
            Expression<Func<T, T, bool>> ifTrue,
            Expression<Func<T, T, bool>> ifFalse = null)
            where T : Expression
        {
            var returnTarget = Expression.Label(typeof(bool));
            var test = Expression.Invoke(condition, condition.Parameters);
            var whenTrue = Expression.Return(
                returnTarget, Expression.Invoke(ifTrue, condition.Parameters));
            var whenFalse = Expression.Return(
                returnTarget,
                Expression.Invoke(ifFalse ?? True<T>(), condition.Parameters));
            var expr = Expression.Block(
                Expression.IfThenElse(test, whenTrue, whenFalse),
                Expression.Label(returnTarget, Expression.Constant(false)));
            return Expression.Lambda<Func<T, T, bool>>(
                expr,
                condition.Parameters);
        }

        /// <summary>
        /// Enables if ... then logic with a cast to inner evaluations.
        /// </summary>
        /// <remarks>
        /// This special version allows transitioning from a parent expression to a child. For example,
        /// consider a <see cref="BinaryExpression"/> with a <see cref="ConstantExpression"/> for the
        /// <c>Left</c> property. This rule enables you to test if the type matches, then run rules
        /// against the child <see cref="Expression"/>. See the <see cref="If{T}(Expression{Func{T, T, bool}}, Expression{Func{T, T, bool}}, Expression{Func{T, T, bool}})"/>
        /// definition for more about how the final result is evaluated.
        /// </remarks>
        /// <example>
        /// For example, if child is a constant and the constant type is integer, then it matches.
        /// <code>
        /// ExpressionRulesExtensions.IfWithCast&lt;BinaryExpression, ConstantExpression>(
        ///     condition: (s, t) => s.Left is ConstantExpression,
        ///     conversion: e => e.Left as ConstantExpression,
        ///     ifTrue: (s, t) => ExpressionEquivalency.AreEquivalent(s, t), // runs as ConstantExpression
        ///     ifFalse: ExpressionRulesExtensions.False&lt;ConstantExpression>()).Compile();
        /// );
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <typeparam name="TOther">The type of the child <see cref="Expression"/>.</typeparam>
        /// <param name="condition">The condition that must pass.</param>
        /// <param name="conversion">How to convert to the type (property and cast).</param>
        /// <param name="ifTrue">The rule to apply for success.</param>
        /// <param name="ifFalse">The rule to apply for failure.</param>
        /// <returns>The result of the if/then/else evaluation.</returns>
        public static Expression<Func<T, T, bool>> IfWithCast<T, TOther>(
                Expression<Func<T, T, bool>> condition,
                Expression<Func<T, TOther>> conversion,
                Expression<Func<TOther, TOther, bool>> ifTrue,
                Expression<Func<TOther, TOther, bool>> ifFalse = null)
                where T : Expression
                where TOther : Expression
        {
            var returnTarget = Expression.Label(typeof(bool));
            var sourceParam = condition.Parameters[0];
            var targetParam = condition.Parameters[1];
            var sourceAs = Expression.Invoke(conversion, sourceParam);
            var targetAs = Expression.Invoke(conversion, targetParam);
            var test = Expression.Invoke(condition, condition.Parameters);
            var whenTrue = Expression.Return(
                returnTarget, Expression.Invoke(ifTrue, sourceAs, targetAs));
            var whenFalse = Expression.Return(
                returnTarget,
                Expression.Invoke(ifFalse ?? True<TOther>(), sourceAs, targetAs));
            var expr = Expression.Block(
                Expression.IfThenElse(test, whenTrue, whenFalse),
                Expression.Label(returnTarget, Expression.Constant(false)));
            return Expression.Lambda<Func<T, T, bool>>(
                expr,
                condition.Parameters);
        }

        /// <summary>
        /// Logical NOT of result of rule.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// <![CDATA[
        ///  var source = Expression.Constant(true);
        ///  var target = Expression.Constant(true);
        ///  var rule = rules.Not<ConstantExpression>(
        ///     (s, t) => (bool)s.Value);
        ///  var result = rule.Compile())source, target);
        ///  ]]>
        /// </code>
        /// Because of the call to <c>Not</c>, the result is <c>false</c>.
        /// </example>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule to evaluate.</param>
        /// <returns>The opposite of the rule evaluation.</returns>
        public static Expression<Func<T, T, bool>> Not<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression =>
            If(
                condition: rule,
                ifTrue: False<T>(),
                ifFalse: True<T>());

        /// <summary>
        /// Logical AND applied to rule and <c>If</c> condition.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule that must pass.</param>
        /// <param name="condition">The condition for if/then.</param>
        /// <param name="ifTrue">The rule to evaluate for if/then.</param>
        /// <param name="ifFalse">The rule to evaluate for if/else.</param>
        /// <returns>The result of the <c>If</c> AND the result of the rule.</returns>
        public static Expression<Func<T, T, bool>> AndIf<T>(
            this Expression<Func<T, T, bool>> rule,
            Expression<Func<T, T, bool>> condition,
            Expression<Func<T, T, bool>> ifTrue,
            Expression<Func<T, T, bool>> ifFalse = null)
            where T : Expression => And(rule, If(condition, ifTrue, ifFalse));

        /// <summary>
        /// Logical OR applied to rule and <c>If</c> condition.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="rule">The rule that might pass.</param>
        /// <param name="condition">The condition for if/then.</param>
        /// <param name="ifTrue">The rule to evaluate for if/then.</param>
        /// <param name="ifFalse">The rule to evaluate for if/else.</param>
        /// <returns>The result of the <c>If</c> OR the result of the rule.</returns>
        public static Expression<Func<T, T, bool>> OrIf<T>(
            this Expression<Func<T, T, bool>> rule,
            Expression<Func<T, T, bool>> condition,
            Expression<Func<T, T, bool>> ifTrue,
            Expression<Func<T, T, bool>> ifFalse = null)
            where T : Expression => Or(rule, If(condition, ifTrue, ifFalse));
    }
}
