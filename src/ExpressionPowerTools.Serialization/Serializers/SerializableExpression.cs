// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Class for serialization expressions.
    /// </summary>
    [Serializable]
    public class SerializableExpression
    {
        /// <summary>
        /// Reflection helper instance.
        /// </summary>
        private readonly IReflectionHelper reflectionHelper =
            ServiceHost.GetService<IReflectionHelper>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableExpression"/> class.
        /// </summary>
        public SerializableExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableExpression"/> class and captures
        /// the <see cref="ExpressionType"/> of the <see cref="Expression"/> passed in.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public SerializableExpression(Expression expression)
        {
            Ensure.NotNull(() => expression);
            Type = (int)expression.NodeType;
        }

        /// <summary>
        /// Gets or sets the type of the expression.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Helper for serializing types.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to serialize.</param>
        /// <returns>The <see cref="SerializableType"/>.</returns>
        protected SerializableType SerializeType(Type type) =>
            reflectionHelper.SerializeType(type);

        /// <summary>
        /// Serialize the type of an object.
        /// </summary>
        /// <param name="target">The target to inspect the type of.</param>
        /// <returns>The <see cref="SerializableType"/>.</returns>
        protected SerializableType SerializeTypeOf(object target) =>
            reflectionHelper.SerializeType(target.GetType());
    }
}
