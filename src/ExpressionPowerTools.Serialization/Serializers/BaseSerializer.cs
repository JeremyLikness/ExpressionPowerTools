// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Base class for serializers.
    /// </summary>
    /// <typeparam name="TExpression">The <see cref="Expression"/> supported by the serialize.</typeparam>
    /// <typeparam name="TSerializable">The serializer component it targets.</typeparam>
    public abstract class BaseSerializer<TExpression, TSerializable>
        : IExpressionSerializer<TExpression, TSerializable>
        where TExpression : Expression
        where TSerializable : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSerializer{T, TSerializable}"/> class with a default serializer.
        /// </summary>
        /// <param name="serializer">The default serializer.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when serializer is null.</exception>
        public BaseSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
        {
            Ensure.NotNull(() => serializer);
            Serializer = serializer;
        }

        /// <summary>
        /// Gets the anonymous type name.
        /// </summary>
        protected string AnonymousType => nameof(AnonymousType);

        /// <summary>
        /// Gets the default <see cref="IExpressionSerializer{T, TSerializable}"/>.
        /// </summary>
        protected IExpressionSerializer<Expression, SerializableExpression> Serializer { get; private set; }

        /// <summary>
        /// Deserialize a <see cref="JsonElement"/> to an <see cref="Expression"/>.
        /// </summary>
        /// <param name="json">The <see cref="JsonElement"/> to deserialize.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public abstract TExpression Deserialize(JsonElement json);

        /// <summary>
        /// Serialize an <see cref="Expression"/> to a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        public abstract TSerializable Serialize(TExpression expression);

        /// <summary>
        /// Gets the <see cref="ExpressionType"/> from the string representation.
        /// </summary>
        /// <param name="type">The string representation of the <see cref="ExpressionType"/>.</param>
        /// <returns>The <see cref="ExpressionType"/>.</returns>
        protected ExpressionType GetExpressionTypeFor(string type)
        {
            if (Enum.TryParse(type, out ExpressionType result))
            {
                return result;
            }

            return default;
        }
    }
}
