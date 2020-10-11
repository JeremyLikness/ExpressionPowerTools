// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializable <see cref="ConstantExpression"/>.
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
            ConstantTypeKey = GetKeyForMember(expression.Type);
            ValueTypeKey = expression.Value == null ?
                null : GetKeyForMember(expression.Value.GetType());
            Value = expression.Value;

            if (Value is MemberInfo member)
            {
                Value = GetKeyForMember(member);
            }
        }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        [CompressableKey]
        public string ConstantTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        [CompressableKey]
        public string ValueTypeKey { get; set; }
    }
}
