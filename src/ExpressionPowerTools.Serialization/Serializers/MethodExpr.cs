// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable container for <see cref="MethodCallExpression"/>.
    /// </summary>
    [Serializable]
    public class MethodExpr : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodExpr"/> class.
        /// </summary>
        public MethodExpr()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodExpr"/> class
        /// initialized with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="methodCall">The <see cref="MethodCallExpression"/> to
        /// serialize.</param>
        public MethodExpr(MethodCallExpression methodCall)
            : base(methodCall)
        {
            MethodInfo = new Method(methodCall.Method);
            MethodCallType = methodCall.Type.FullName;
        }

        /// <summary>
        /// Gets or sets the serializable <see cref="MethodInfo"/>.
        /// </summary>
        public Method MethodInfo { get; set; }

        /// <summary>
        /// Gets or sets the method call type.
        /// </summary>
        public string MethodCallType { get; set; }

        /// <summary>
        /// Gets or sets the method's object.
        /// </summary>
        public object MethodObject { get; set; }

        /// <summary>
        /// Gets or sets the list of arguments.
        /// </summary>
        public List<object> Arguments { get; set; } =
            new List<object>();
    }
}
