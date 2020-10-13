// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Non-generic interface for serializers.
    /// </summary>
    public interface IBaseSerializer
    {
        /// <summary>
        /// Deserialize to an <see cref="Expression"/>.
        /// </summary>
        /// <param name="root">The fragment to deserialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="Expression"/>, or <c>null</c>.</returns>
        Expression Deserialize(
            SerializableExpression root,
            SerializationState state);

        /// <summary>
        /// Serialize to a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression Serialize(Expression expression, SerializationState state);

        /// <summary>
        /// Compress the types on the serializable class.
        /// </summary>
        /// <param name="serializable">The serializable entity.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        void CompressTypes(
            SerializableExpression serializable,
            SerializationState state);

        /// <summary>
        /// Deompress the types on the serializable class.
        /// </summary>
        /// <param name="serializable">The serializable entity.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        void DecompressTypes(
            SerializableExpression serializable,
            SerializationState state);
    }
}
