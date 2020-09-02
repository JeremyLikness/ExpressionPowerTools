// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a <see cref="ConstantExpression"/>.
    /// </summary>
    [Serializable]
    public class Constant : SerializableExpression
    {
        /// <summary>
        /// Anonymous type for reference.
        /// </summary>
        public static readonly SerializableType AnonType =
            ServiceHost.GetService<IReflectionHelper>().SerializeType(typeof(AnonType));

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
            ConstantType = SerializeType(expression.Type);
            ValueType = expression.Value == null ?
                ConstantType : SerializeTypeOf(expression.Value);
            var isAnonymous = expression.Value == null ?
                expression.Type.IsAnonymousType() :
                expression.Value.GetType().IsAnonymousType();
            if (isAnonymous)
            {
                ValueType = AnonType;
                Value = new AnonType(expression.Value);
            }
            else
            {
                Value = expression.Value;
            }
        }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public SerializableType ConstantType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public SerializableType ValueType { get; set; }
    }
}
