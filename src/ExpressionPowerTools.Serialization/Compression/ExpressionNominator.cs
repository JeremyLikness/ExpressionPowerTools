// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Compression
{
    /// <summary>
    /// Parses a tree to find candidates for resolution (i.e. variables, local method calls).
    /// </summary>
    public class ExpressionNominator : ExpressionVisitor
    {
        /// <summary>
        /// Candidates to compress.
        /// </summary>
        private HashSet<Expression> candidates;

        /// <summary>
        /// A value indicating if it cannot be evaluated.
        /// </summary>
        private bool cannotBeEvaluated;

        /// <summary>
        /// Vist the expression.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to parse for nominations.</param>
        /// <returns>The <see cref="Expression"/>.</returns>
        public override Expression Visit(Expression expression)
        {
            if (expression != null)
            {
                bool saveCannotBeEvaluated = cannotBeEvaluated;

                cannotBeEvaluated = false;

                base.Visit(expression);

                if (!cannotBeEvaluated)
                {
                    if (expression.NodeType != ExpressionType.Parameter)
                    {
                        if (expression.Type.Namespace.StartsWith($"{nameof(System)}.{nameof(System.Linq)}"))
                        {
                            cannotBeEvaluated = true;
                        }
                        else
                        {
                            candidates.Add(expression);
                        }
                    }
                    else
                    {
                        cannotBeEvaluated = true;
                    }
                }

                cannotBeEvaluated |= saveCannotBeEvaluated;
            }

            return expression;
        }

        /// <summary>
        /// Uses the visitor to return the candidates.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to nominate.</param>
        /// <returns>The list of candiates.</returns>
        public HashSet<Expression> Nominate(Expression expression)
        {
            candidates = new HashSet<Expression>();
            Visit(expression);
            return candidates;
        }
    }
}
