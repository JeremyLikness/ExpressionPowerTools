// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Interface for serialization/deserialization.
    /// </summary>
    /// <typeparam name="T">The type of the expression.</typeparam>
    /// <typeparam name="TSerializable">The type of the serializable expression.</typeparam>
    public interface IExpressionSerializer<T, TSerializable>
        where T : Expression
        where TSerializable : SerializableExpression
    {
        /// <summary>
        /// Deserialize an <see cref="Expression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        T Deserialize(
            JsonElement json,
            SerializationState state,
            ExpressionType expressionType);

        /// <summary>
        /// Serializes an <see cref="Expression"/> to a serializable class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The serializeable class.</returns>
        TSerializable Serialize(T expression, SerializationState state);
    }
}
