// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;

namespace ExpressionPowerTools.Serialization.Compression
{
    /// <summary>
    /// Visitor that compresses expressions.
    /// </summary>
    public class TreeCompressionVisitor : ExpressionVisitor
    {
        private bool treeModified = false;

        /// <summary>
        /// Performs evaluation and replacement of independent sub-trees.
        /// </summary>
        /// <remarks>
        /// Logic borrowed from https://docs.microsoft.com/en-us/archive/blogs/mattwar/linq-building-an-iqueryable-provider-series post.
        /// Heavily modified to work here.
        /// </remarks>
        /// <param name="expression">The root of the expression tree.</param>
        /// <returns>A new tree with sub-trees evaluated and replaced.</returns>
        public Expression EvalAndCompress(
            Expression expression) =>
                Compress(Eval(expression));

        /// <summary>
        /// Evaluates the expression for segments that can be invoked.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to parse.</param>
        /// <returns>The compiled expression.</returns>
        public Expression Eval(Expression expression) =>
            new SubtreeEvaluator(new ExpressionNominator().Nominate(expression)).Eval(expression);

        /// <summary>
        /// Compress the <see cref="Expression"/> tree by collapsing logical nodes that
        /// can be evaluated.
        /// </summary>
        /// <param name="source">The <see cref="Expression"/> to compress.</param>
        /// <returns>The compressed <see cref="Expression"/>.</returns>
        public Expression Compress(Expression source)
        {
            Expression result = source;
            do
            {
                treeModified = false;
                result = Visit(result);
            }
            while (treeModified);
            return result;
        }

        /// <summary>
        /// Transforms conditional statements.
        /// </summary>
        /// <param name="node">The <see cref="ConditionalExpression"/> to parse.</param>
        /// <returns>The compressed <see cref="Expression"/>.</returns>
        protected override Expression VisitConditional(ConditionalExpression node)
        {
            if (node.Test is ConstantExpression)
            {
                if (TryCheckBoolean(node.Test, out bool result))
                {
                    treeModified = true;
                    return result ? node.IfTrue : node.IfFalse;
                }
            }

            return base.VisitConditional(node);
        }

        /// <summary>
        /// Flattens a constant when it has an <see cref="Expression"/>.
        /// </summary>
        /// <param name="node">The <see cref="ConstantExpression"/> to flatten.</param>
        /// <returns>The compressed <see cref="Expression"/>.</returns>
        protected override Expression VisitConstant(ConstantExpression node) =>
            node.Value is Expression ex ? Visit(ex) : node;

        /// <summary>
        /// Collapses binary expressions.
        /// </summary>
        /// <param name="node">The <see cref="BinaryExpression"/> to parse.</param>
        /// <returns>The compressed expression.</returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.And ||
                node.NodeType == ExpressionType.AndAlso)
            {
                return CompressAnd(node);
            }

            if (node.NodeType == ExpressionType.Or ||
                node.NodeType == ExpressionType.OrElse)
            {
                return CompressOr(node);
            }

            return base.VisitBinary(node);
        }

        /// <summary>
        /// Compress or.
        /// </summary>
        /// <param name="node">The <see cref="BinaryExpression"/> to compress.</param>
        /// <returns>The compressed <see cref="Expression"/>.</returns>
        private Expression CompressOr(BinaryExpression node)
        {
            if (TryCheckBoolean(node.Left, out bool orLeft))
            {
                if (orLeft)
                {
                    treeModified = true;
                    return Expression.Constant(true);
                }

                if (TryCheckBoolean(node.Right, out bool innerOrRight))
                {
                    treeModified = true;
                    return Expression.Constant(innerOrRight);
                }

                treeModified = true;
                return Visit(node.Right);
            }

            if (TryCheckBoolean(node.Right, out bool orRight))
            {
                if (orRight)
                {
                    treeModified = true;
                    return Expression.Constant(true);
                }

                treeModified = true;
                return Visit(node.Left);
            }

            return base.VisitBinary(node);
        }

        /// <summary>
        /// Compress and.
        /// </summary>
        /// <param name="node">The <see cref="BinaryExpression"/> to compress.</param>
        /// <returns>The compressed <see cref="Expression"/>.</returns>
        private Expression CompressAnd(BinaryExpression node)
        {
            if (TryCheckBoolean(node.Left, out bool left))
            {
                if (!left)
                {
                    treeModified = true;
                    return Expression.Constant(false);
                }

                if (TryCheckBoolean(node.Right, out bool innerRight))
                {
                    treeModified = true;
                    return Expression.Constant(innerRight);
                }

                treeModified = true;
                return Visit(node.Right);
            }

            if (TryCheckBoolean(node.Right, out bool right))
            {
                if (!right)
                {
                    treeModified = true;
                    return Expression.Constant(false);
                }

                treeModified = true;
                return Visit(node.Left);
            }

            return base.VisitBinary(node);
        }

        /// <summary>
        /// Try to collapse constants that are boolean.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to evaluate.</param>
        /// <param name="value">The potential value.</param>
        /// <returns>A value indicating whether the expression was a <see cref="bool"/> constant.</returns>
        private bool TryCheckBoolean(Expression expression, out bool value)
        {
            if (expression is ConstantExpression ce
                && ce.Type == typeof(bool))
            {
                value = (bool)ce.Value;
                return true;
            }

            value = false;
            return false;
        }
    }
}
