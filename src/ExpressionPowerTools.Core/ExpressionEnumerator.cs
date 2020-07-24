// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private Queue<Expression> queue;

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
        /// Implements <see cref="IEnumerable{Expression}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator{Expression}"/>.</returns>
        public IEnumerator<Expression> GetEnumerator()
        {
            // reset the queue
            queue = new Queue<Expression>();
            if (expression != null)
            {
                // recurse
                RecurseExpression(expression);
            }

            // now return results
            while (queue.Count > 0)
            {
                yield return queue.Dequeue();
            }
        }

        /// <summary>
        /// Non-generic version.
        /// </summary>
        /// <returns>The generic version as a non-generic inteface.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Main entry, similar to "Visit" on <see cref="ExpressionVisitor"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> under consideration.</param>
        private void RecurseExpression(Expression expression)
        {
            if (expression == null)
            {
                return;
            }

            switch (expression)
            {
                case BinaryExpression binary:
                    RecurseBinaryExpression(binary);
                    break;
                case ConstantExpression constant:
                    RecurseConstantExpression(constant);
                    break;
                case LambdaExpression lambda:
                    RecurseLambdaExpression(lambda);
                    break;
                case MemberExpression member:
                    RecurseMemberExpression(member);
                    break;
                case MethodCallExpression method:
                    RecurseMethodCallExpression(method);
                    break;
                case UnaryExpression unary:
                    RecurseUnaryExpression(unary);
                    break;
                default:
                    queue.Enqueue(expression);
                    break;
            }
        }

        /// <summary>
        /// Recurse any expression in the constant.
        /// </summary>
        /// <param name="constant">The <see cref="ConstantExpression"/>.</param>
        private void RecurseConstantExpression(ConstantExpression constant)
        {
            queue.Enqueue(constant);
            if (constant.Value is Expression value)
            {
                RecurseExpression(value);
            }
        }

        /// <summary>
        /// Recurse a binary expression.
        /// </summary>
        /// <param name="binary">The <see cref="BinaryExpression"/> to parse.</param>
        private void RecurseBinaryExpression(BinaryExpression binary)
        {
            queue.Enqueue(binary);
            RecurseExpression(binary.Left);
            RecurseExpression(binary.Right);
        }

        /// <summary>
        /// Recurse a member expression.
        /// </summary>
        /// <param name="member">The <see cref="MemberExpression"/> to parse.</param>
        private void RecurseMemberExpression(MemberExpression member)
        {
            queue.Enqueue(member);
            RecurseExpression(member.Expression);
        }

        /// <summary>
        /// Recurse a lambda expression.
        /// </summary>
        /// <param name="lambda">The <see cref="LambdaExpression"/> to parse.</param>
        private void RecurseLambdaExpression(LambdaExpression lambda)
        {
            queue.Enqueue(lambda);
            foreach (var parameter in lambda.Parameters)
            {
                RecurseExpression(parameter);
            }

            RecurseExpression(lambda.Body);
        }

        /// <summary>
        /// Recurse a method call expression.
        /// </summary>
        /// <param name="method">The <see cref="MethodCallExpression"/> to recurse.</param>
        private void RecurseMethodCallExpression(MethodCallExpression method)
        {
            queue.Enqueue(method);
            RecurseExpression(method.Object);
            foreach (var arg in method.Arguments)
            {
                RecurseExpression(arg);
            }
        }

        /// <summary>
        /// Recurse a unary expression.
        /// </summary>
        /// <param name="unary">The <see cref="UnaryExpression"/> to parse.</param>
        private void RecurseUnaryExpression(UnaryExpression unary)
        {
            queue.Enqueue(unary);
            RecurseExpression(unary.Operand);
        }
    }
}
