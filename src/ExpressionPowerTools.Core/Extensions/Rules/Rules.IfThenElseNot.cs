using System;
using System.Linq.Expressions;
using rules = ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions;

namespace ExpressionPowerTools.Core.Extensions
{
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

        public static Expression<Func<T, T, bool>> Not<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression =>
            If(
                condition: rule,
                ifTrue: False<T>(),
                ifFalse: True<T>());

        public static Expression<Func<T, T, bool>> AndIf<T>(
            this Expression<Func<T, T, bool>> rule,
            Expression<Func<T, T, bool>> condition,
            Expression<Func<T, T, bool>> ifTrue,
            Expression<Func<T, T, bool>> ifFalse = null)
            where T : Expression => And(rule, If(condition, ifTrue, ifFalse));

        public static Expression<Func<T, T, bool>> OrIf<T>(
            this Expression<Func<T, T, bool>> rule,
            Expression<Func<T, T, bool>> condition,
            Expression<Func<T, T, bool>> ifTrue,
            Expression<Func<T, T, bool>> ifFalse = null)
            where T : Expression => Or(rule, If(condition, ifTrue, ifFalse));

    }
}
