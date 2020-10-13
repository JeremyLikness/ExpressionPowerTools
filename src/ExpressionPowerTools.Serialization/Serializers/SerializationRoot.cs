// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using ExpressionPowerTools.Core.Contract;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Root of <see cref="Expression"/> tree.
    /// </summary>
    [Serializable]
    public class SerializationRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationRoot"/> class.
        /// </summary>
        public SerializationRoot()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationRoot"/> class and sets the
        /// <see cref="SerializableExpression"/> property.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public SerializationRoot(SerializableExpression expression)
        {
            Ensure.NotNull(() => expression);
            Expression = expression;
        }

        /// <summary>
        /// Gets or sets the top level index of types to reference and de-reference.
        /// </summary>
        public string[] TypeIndex { get; set; }

        /// <summary>
        /// Gets or sets the root <see cref="SerializableExpression"/>.
        /// </summary>
        /// <remarks>
        /// For deserialization, this will be a <see cref="System.Text.Json.JsonElement"/>.
        /// </remarks>
        public SerializableExpression Expression { get; set; }
    }
}
