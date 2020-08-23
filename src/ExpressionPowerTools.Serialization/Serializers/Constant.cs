// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a <see cref="ConstantExpression"/>.
    /// </summary>
    [Serializable]
    public class Constant : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Constant"/> class.
        /// </summary>
        public Constant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constant"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        public Constant(ConstantExpression expression)
            : base(expression)
        {
            ConstantType = expression.Type.FullName;
            Value = expression.Value;
            ValueType = Value == null ? ConstantType : Value.GetType().FullName;
        }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public string ConstantType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public string ValueType { get; set; }
    }
}
