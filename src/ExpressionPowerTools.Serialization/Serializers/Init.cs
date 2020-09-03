// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializable <see cref="NewExpression"/>.
    /// </summary>
    public class Init : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Init"/> class.
        /// </summary>
        public Init()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Init"/> class with
        /// a <see cref="NewExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewExpression"/> to initialize.</param>
        public Init(NewExpression expression)
            : base(expression)
        {
        }
    }
}
