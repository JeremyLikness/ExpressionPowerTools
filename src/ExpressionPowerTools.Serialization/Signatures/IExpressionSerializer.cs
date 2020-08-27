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
        /// <param name="queryRoot">The root of the query to recreate.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        T Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options);

        /// <summary>
        /// Serializes an <see cref="Expression"/> to a serializable class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The serializeable class.</returns>
        TSerializable Serialize(T expression, JsonSerializerOptions options);
    }
}
