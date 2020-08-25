// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// A serializable version of <see cref="InvocationExpression"/>.
    /// </summary>
    public class Invocation : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invocation"/> class.
        /// </summary>
        public Invocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invocation"/> class
        /// initialized with an <see cref="InvocationExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="InvocationExpression"/>
        /// to serialize.</param>
        public Invocation(InvocationExpression expression)
            : base(expression)
        {
            InvocationType = expression.Type.FullName;
        }

        /// <summary>
        /// Gets or sets the target <see cref="Expression"/>.
        /// </summary>
        public object Expression { get; set; }

        /// <summary>
        /// Gets or sets the arguments list.
        /// </summary>
        public List<object> Arguments { get; set; }
            = new List<object>();

        /// <summary>
        /// Gets or sets the type of the invocation.
        /// </summary>
        public string InvocationType { get; set; }
    }
}
