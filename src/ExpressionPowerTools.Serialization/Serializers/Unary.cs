// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of the <see cref="UnaryExpression"/>.
    /// </summary>
    [Serializable]
    public class Unary : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Unary"/> class.
        /// </summary>
        public Unary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unary"/> class and
        /// initialies with a <see cref="UnaryExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="UnaryExpression"/> to parse.</param>
        public Unary(UnaryExpression expression)
            : base(expression)
        {
            if (expression.Method != null)
            {
                UnaryMethod = new Method(expression.Method);
            }

            UnaryType = expression.Type.FullName;
        }

        /// <summary>
        /// Gets or sets the <see cref="Method"/> this expression uses.
        /// </summary>
        public Method UnaryMethod { get; set; }

        /// <summary>
        /// Gets or sets the full type of the <see cref="UnaryExpression"/>.
        /// </summary>
        public string UnaryType { get; set; }

        /// <summary>
        /// Gets or sets the operand or main <see cref="Expression"/> for the operation.
        /// </summary>
        public object Operand { get; set; }
    }
}
