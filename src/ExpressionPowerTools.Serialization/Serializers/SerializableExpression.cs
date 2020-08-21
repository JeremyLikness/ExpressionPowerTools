// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Class for serialization expressions.
    /// </summary>
    [Serializable]
    public class SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableExpression"/> class.
        /// </summary>
        public SerializableExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableExpression"/> class and captures
        /// the <see cref="ExpressionType"/> of the <see cref="Expression"/> passed in.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public SerializableExpression(Expression expression)
        {
            Ensure.NotNull(() => expression);
            Type = expression.NodeType.ToString();
        }

        /// <summary>
        /// Gets or sets the type of the expression.
        /// </summary>
        public string Type { get; set; }
    }
}
