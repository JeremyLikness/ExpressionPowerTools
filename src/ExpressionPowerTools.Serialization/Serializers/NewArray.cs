// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// New array serialization.
    /// </summary>
    [Serializable]
    public class NewArray : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewArray"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="NewArrayExpression"/> to parse.</param>
        public NewArray(NewArrayExpression expression)
            : base(expression)
        {
            ArrayType = expression.Type.GetElementType().FullName;
        }

        /// <summary>
        /// Gets or sets the type of the array.
        /// </summary>
        public string ArrayType { get; set; }

        /// <summary>
        /// Gets or sets the list of expressions.
        /// </summary>
        public List<object> Expressions { get; set; } =
            new List<object>();
    }
}
