// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// A serializable type for <see cref="ParameterExpression"/>.
    /// </summary>
    [Serializable]
    public class Parameter : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        public Parameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="ParameterExpression"/> to serialize.</param>
        public Parameter(ParameterExpression expression)
            : base(expression)
        {
            ParameterType = SerializeType(expression.Type);
            Name = expression.Name;
        }

        /// <summary>
        /// Gets or sets the parameter type.
        /// </summary>
        public SerializableType ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
