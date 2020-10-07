// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Compression
{
    /// <summary>
    /// Parses the candidates and evaluates so that variables are collapsed to constants.
    /// </summary>
    public class SubtreeEvaluator : ExpressionVisitor
    {
        /// <summary>
        /// The list of candidates.
        /// </summary>
        private HashSet<Expression> candidates;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubtreeEvaluator"/> class
        /// with the list of nominated candidates.
        /// </summary>
        /// <param name="candidates">The candidates for compression.</param>
        public SubtreeEvaluator(HashSet<Expression> candidates)
        {
            var subtreeEvaluator = this;
            subtreeEvaluator.candidates = candidates;
        }

        /// <summary>
        /// Vists the node.
        /// </summary>
        /// <param name="exp">The <see cref="Expression"/> to visit.</param>
        /// <returns>The modified <see cref="Expression"/>.</returns>
        public override Expression Visit(Expression exp)
        {
            if (exp == null)
            {
                return null;
            }

            if (candidates.Contains(exp))
            {
                return Evaluate(exp);
            }

            return base.Visit(exp);
        }

        /// <summary>
        /// Evaluate the expression.
        /// </summary>
        /// <param name="exp">The expression to visit.</param>
        /// <returns>The transformed expression.</returns>
        public Expression Eval(Expression exp) => Visit(exp);

        /// <summary>
        /// Evaluate to compress.
        /// </summary>
        /// <param name="e">The <see cref="Expression"/>.</param>
        /// <returns>The evaluated expression.</returns>
        private Expression Evaluate(Expression e)
        {
            if (e.NodeType == ExpressionType.Constant
                || e.NodeType == ExpressionType.New)
            {
                return e;
            }

            var type = e.Type;
            if (type.IsGenericType && !type.IsGenericTypeDefinition)
            {
                type = type.GetGenericTypeDefinition();
            }

            if (typeof(EnumerableQuery<>).IsAssignableFrom(type))
            {
                return e;
            }

            LambdaExpression lambda = Expression.Lambda(e);
            Delegate fn = lambda.Compile();
            var result = Expression.Constant(fn.DynamicInvoke(null), e.Type);
            return result;
        }
    }
}
