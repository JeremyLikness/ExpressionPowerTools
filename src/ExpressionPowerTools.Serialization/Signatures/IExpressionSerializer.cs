// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
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
        /// <param name="root">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        T Deserialize(
            TSerializable root,
            SerializationState state);

        /// <summary>
        /// Serializes an <see cref="Expression"/> to a serializable class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The serializeable class.</returns>
        TSerializable Serialize(T expression, SerializationState state);
    }
}
