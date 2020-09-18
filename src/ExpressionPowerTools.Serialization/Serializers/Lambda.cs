// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of <see cref="LambdaExpression"/>.
    /// </summary>
    [Serializable]
    public class Lambda : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lambda"/> class.
        /// </summary>
        public Lambda()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lambda"/> class with
        /// the provided <see cref="LambdaExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/> to parse.</param>
        public Lambda(LambdaExpression expression)
            : base(expression)
        {
            Name = expression.Name;
            LambdaTypeKey = GetKeyForMember(expression.Type);
            ReturnTypeKey = GetKeyForMember(expression.ReturnType);
        }

        /// <summary>
        /// Gets or sets the body of the lambda.
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Gets or sets the name of the lambda.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the list of parameters for the lambda.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<Parameter> Parameters { get; private set; } =
            new List<Parameter>();

        /// <summary>
        /// Gets or sets the type of the lambda.
        /// </summary>
        public string LambdaTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the return type of the lambda.
        /// </summary>
        public string ReturnTypeKey { get; set; }
    }
}
