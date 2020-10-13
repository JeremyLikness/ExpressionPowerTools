// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public NewArray()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewArray"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="NewArrayExpression"/> to parse.</param>
        public NewArray(NewArrayExpression expression)
            : base(expression)
        {
            ArrayTypeKey = GetKeyForMember(expression.Type.GetElementType());
        }

        /// <summary>
        /// Gets or sets the type of the array.
        /// </summary>
        [CompressableKey]
        public string ArrayTypeKey { get; set; }

        /// <summary>
        /// Gets the list of expressions.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<SerializableExpression> Expressions { get; private set; } =
            new List<SerializableExpression>();
    }
}
