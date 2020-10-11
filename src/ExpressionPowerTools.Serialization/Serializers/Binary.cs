// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializable <see cref="BinaryExpression"/>.
    /// </summary>
    [Serializable]
    public class Binary : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class.
        /// </summary>
        public Binary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class and
        /// initialies with a <see cref="BinaryExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="BinaryExpression"/> to parse.</param>
        public Binary(BinaryExpression expression)
            : base(expression)
        {
            if (expression.Method != null)
            {
                BinaryMethod = GetKeyForMember(expression.Method);
            }

            LiftToNull = expression.IsLiftedToNull;
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is lifted to null.
        /// </summary>
        public bool LiftToNull { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LambdaExpression"/> for conversion.
        /// </summary>
        public object Conversion { get; set; }

        /// <summary>
        /// Gets or sets the related method.
        /// </summary>
        [CompressableKey]
        public string BinaryMethod { get; set; }

        /// <summary>
        /// Gets or sets the left expression.
        /// </summary>
        public object Left { get; set; }

        /// <summary>
        /// Gets or sets the right expression.
        /// </summary>
        public object Right { get; set; }
    }
}
