// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// A serializable version of <see cref="InvocationExpression"/>.
    /// </summary>
    [Serializable]
    public class Invocation : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invocation"/> class.
        /// </summary>
        public Invocation()
        {
            Type = (int)ExpressionType.Invoke;
        }

        /// <summary>
        /// Gets or sets the target <see cref="Expression"/>.
        /// </summary>
        public SerializableExpression Expression { get; set; }

        /// <summary>
        /// Gets or sets the arguments list.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<SerializableExpression> Arguments { get; set; }
            = new List<SerializableExpression>();
    }
}
