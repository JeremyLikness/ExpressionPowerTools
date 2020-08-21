// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using System.Text.Json;
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
        /// <param name="json">The fragment to deserialize.</param>
        /// <returns>The <see cref="Expression"/>, or <c>null</c>.</returns>
        Expression Deserialize(JsonElement json);

        /// <summary>
        /// Serialize to a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression Serialize(Expression expression);
    }
}
