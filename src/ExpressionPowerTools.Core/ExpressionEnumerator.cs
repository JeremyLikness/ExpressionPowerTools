// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core
{
    /// <summary>
    /// Recurse an <see cref="Expression"/> tree.
    /// </summary>
    public class ExpressionEnumerator : IExpressionEnumerator
    {
        /// <summary>
        /// The root <see cref="Expression"/>.
        /// </summary>
        private readonly Expression expression;

        /// <summary>
        /// A queue to track visited expressions.
        /// </summary>
        private Queue<(int level, Expression expression)> queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionEnumerator"/> class.
        /// </summary>
        /// <param name="expr">The <see cref="Expression"/> to enumerate.
        /// </param>
        public ExpressionEnumerator(Expression expr)
        {
            expression = expr;
        }

        /// <summary>
        /// String display of the tree.
        /// </summary>
        /// <returns>The entire tree display.</returns>
        public override string ToString()
        {
            Enqueue();
            var toStr = new StringBuilder();
            while (queue.Count > 0)
            {
                var next = queue.Dequeue();
                var indent = next.level == 0 ?
                    string.Empty : new string(' ', next.level * 2);
                toStr.Append(indent);
                toStr.Append($"[{next.expression.GetType().Name}:{next.expression.NodeType}] : ");
                toStr.Append($"{next.expression.Type.Name} => {next.expression}");
                toStr.Append(Environment.NewLine);
            }

            return toStr.ToString();
        }

        /// <summary>
        /// Implements <see cref="IEnumerable{Expression}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator{Expression}"/>.</returns>
        public IEnumerator<Expression> GetEnumerator()
        {
            // reset the queue
            Enqueue();

            // now return results
            while (queue.Count > 0)
            {
                yield return queue.Dequeue().expression;
            }
        }

        /// <summary>
        /// Non-generic version.
        /// </summary>
        /// <returns>The generic version as a non-generic inteface.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Enqueue()
        {
            // reset the queue
            queue = new Queue<(int level, Expression expression)>();
            if (expression != null)
            {
                // recurse
                RecurseExpression(expression, 0);
            }
        }

        /// <summary>
        /// Main entry, similar to "Visit" on <see cref="ExpressionVisitor"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> under consideration.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseExpression(Expression expression, int level)
        {
            if (expression == null)
            {
                return;
            }

            switch (expression)
            {
                case BinaryExpression binary:
                    RecurseBinaryExpression(binary, level);
                    break;
                case ConstantExpression constant:
                    RecurseConstantExpression(constant, level);
                    break;
                case InvocationExpression invocation:
                    RecurseInvocationExpression(invocation, level);
                    break;
                case LambdaExpression lambda:
                    RecurseLambdaExpression(lambda, level);
                    break;
                case MemberInitExpression init:
                    RecurseMemberInitExpression(init, level);
                    break;
                case MemberExpression member:
                    RecurseMemberExpression(member, level);
                    break;
                case MethodCallExpression method:
                    RecurseMethodCallExpression(method, level);
                    break;
                case UnaryExpression unary:
                    RecurseUnaryExpression(unary, level);
                    break;
                case NewExpression newExpr:
                    RecurseNewExpression(newExpr, level);
                    break;
                case NewArrayExpression newArrayExpr:
                    RecurseNewArrayExpression(newArrayExpr, level);
                    break;
                default:
                    queue.Enqueue((level, expression));
                    break;
            }
        }

        /// <summary>
        /// Recurse a member initialization.
        /// </summary>
        /// <param name="init">The <see cref="MemberInitExpression"/>.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseMemberInitExpression(MemberInitExpression init, int level)
        {
            queue.Enqueue((level, init));
            RecurseExpression(init.NewExpression, level + 1);
        }

        /// <summary>
        /// Recurse a new array.
        /// </summary>
        /// <param name="newArrayExpr">The <see cref="NewArrayExpression"/>.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseNewArrayExpression(NewArrayExpression newArrayExpr, int level)
        {
            queue.Enqueue((level, newArrayExpr));
            foreach (var expr in newArrayExpr.Expressions)
            {
                RecurseExpression(expr, level + 1);
            }
        }

        /// <summary>
        /// Recurse any expression in the new.
        /// </summary>
        /// <param name="newExpr">The <see cref="NewExpression"/>.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseNewExpression(NewExpression newExpr, int level)
        {
            queue.Enqueue((level, newExpr));
            foreach (var expr in newExpr.Arguments)
            {
                RecurseExpression(expr, level + 1);
            }
        }

        /// <summary>
        /// Recurse any expression in the constant.
        /// </summary>
        /// <param name="constant">The <see cref="ConstantExpression"/>.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseConstantExpression(ConstantExpression constant, int level)
        {
            queue.Enqueue((level, constant));
            if (constant.Value is Expression value)
            {
                RecurseExpression(value, level + 1);
            }
        }

        /// <summary>
        /// Recurse a binary expression.
        /// </summary>
        /// <param name="binary">The <see cref="BinaryExpression"/> to parse.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseBinaryExpression(BinaryExpression binary, int level)
        {
            queue.Enqueue((level, binary));
            RecurseExpression(binary.Left, level + 1);
            if (binary.Conversion != null)
            {
                RecurseExpression(binary.Conversion, level + 1);
            }

            RecurseExpression(binary.Right, level + 1);
        }

        /// <summary>
        /// Recurse a member expression.
        /// </summary>
        /// <param name="member">The <see cref="MemberExpression"/> to parse.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseMemberExpression(MemberExpression member, int level)
        {
            queue.Enqueue((level, member));
            RecurseExpression(member.Expression, level + 1);
        }

        /// <summary>
        /// Recurse a lambda expression.
        /// </summary>
        /// <param name="lambda">The <see cref="LambdaExpression"/> to parse.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseLambdaExpression(LambdaExpression lambda, int level)
        {
            queue.Enqueue((level, lambda));
            foreach (var parameter in lambda.Parameters)
            {
                RecurseExpression(parameter, level + 1);
            }

            RecurseExpression(lambda.Body, level + 1);
        }

        /// <summary>
        /// Recurse an invocation expression.
        /// </summary>
        /// <param name="invocation">The <see cref="InvocationExpression"/> to parse.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseInvocationExpression(InvocationExpression invocation, int level)
        {
            queue.Enqueue((level, invocation));
            foreach (var arg in invocation.Arguments)
            {
                RecurseExpression(arg, level + 1);
            }

            RecurseExpression(invocation.Expression, level + 1);
        }

        /// <summary>
        /// Recurse a method call expression.
        /// </summary>
        /// <param name="method">The <see cref="MethodCallExpression"/> to recurse.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseMethodCallExpression(MethodCallExpression method, int level)
        {
            queue.Enqueue((level, method));
            if (method.Object != null)
            {
                RecurseExpression(method.Object, level + 1);
            }

            foreach (var arg in method.Arguments)
            {
                RecurseExpression(arg, level + 1);
            }
        }

        /// <summary>
        /// Recurse a unary expression.
        /// </summary>
        /// <param name="unary">The <see cref="UnaryExpression"/> to parse.</param>
        /// <param name="level">The recursion level.</param>
        private void RecurseUnaryExpression(UnaryExpression unary, int level)
        {
            queue.Enqueue((level, unary));
            RecurseExpression(unary.Operand, level + 1);
        }
    }
}
