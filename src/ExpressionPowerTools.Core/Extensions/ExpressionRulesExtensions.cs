using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Comparisons;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Building blocks for expression rules.
    /// </summary>
    public static class ExpressionRulesExtensions
    {
        public static Expression<Func<T, T, bool>> True<T>()
            where T : Expression => (_, __) => true;

        public static Expression<Func<T, T, bool>> False<T>()
            where T : Expression => (_, __) => false;

        public static Expression<Func<T, T, bool>> Rule<T>(
            Expression<Func<T, T, bool>> rule) => rule;

        public static Expression<Func<T, T, bool>> Or<T>(
            this Expression<Func<T, T, bool>> left,
            Expression<Func<T, T, bool>> right)
            where T : Expression => StartWithOr(left, right);

        public static Expression<Func<T, T, bool>> StartWithOr<T>(
            Expression<Func<T, T, bool>> left,
            Expression<Func<T, T, bool>> right)
            where T : Expression
        {
            var expr = Expression.Invoke(right, left.Parameters);
            return Expression.Lambda<Func<T, T, bool>>(
                Expression.OrElse(left.Body, expr), left.Parameters);
        }

        public static Expression<Func<T, T, bool>> And<T>(
            this Expression<Func<T, T, bool>> left,
            Expression<Func<T, T, bool>> right)
            where T : Expression => StartWithAnd(left, right);

        public static Expression<Func<T, T, bool>> StartWithAnd<T>(
            Expression<Func<T, T, bool>> left,
            Expression<Func<T, T, bool>> right)
            where T : Expression
        {
            var expr = Expression.Invoke(right, left.Parameters);
            return Expression.Lambda<Func<T, T, bool>>(
                Expression.AndAlso(left.Body, expr), left.Parameters);
        }

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

        /// <summary>
        /// The <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <param name="rule">The existing rule.</param>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates where the node types match.</returns>
        public static Expression<Func<T, T, bool>> AndNodeTypesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => And(rule, NodeTypesMustMatch<T>());

        /// <summary>
        /// The <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates where the node types match.</returns>
        public static Expression<Func<T, T, bool>> NodeTypesMustMatch<T>()
            where T : Expression => (s, t) => s.NodeType == t.NodeType;

        /// <summary>
        /// Types of the expressions must be the same.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types match.</returns>
        public static Expression<Func<T, T, bool>> TypesMustMatch<T>()
            where T : Expression => (s, t) => s.Type == t.Type;

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

        public static Expression<Func<T, T, bool>> AndMembersMustMatchNullOrNotNull<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, object> member)
            where T : Expression => And(rule, MembersMustMatchNullOrNotNull(member));

        public static Expression<Func<T, T, bool>> MembersMustMatchNullOrNotNull<T>(
            Func<T, object> member)
            where T : Expression => (s, t) =>
                (member(s) == null && member(t) == null) ||
                (member(s) != null && member(t) != null);

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
