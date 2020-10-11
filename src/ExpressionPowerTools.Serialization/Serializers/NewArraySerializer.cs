// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="NewArrayExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.NewArrayInit)]
    public class NewArraySerializer
        : BaseSerializer<NewArrayExpression, NewArray>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewArraySerializer"/> class with a
        /// base serializer for recurision.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public NewArraySerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="NewArrayExpression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="NewArrayExpression"/>.</returns>
        public override NewArrayExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            var template = DecompressTypes(json, state);
            var materializedType = GetMemberFromKey<Type>(template.ArrayTypeKey);
            var list = json.GetProperty(nameof(NewArray.Expressions));
            var expressionList = list.EnumerateArray().Select(element => Serializer.Deserialize(
                element, state)).ToList();
            return Expression.NewArrayInit(materializedType, expressionList);
        }

        /// <summary>
        /// Serialize a <see cref="NewArrayExpression"/> to a <see cref="NewArray"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewArrayExpression"/>.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The <see cref="NewArray"/>.</returns>
        public override NewArray Serialize(
            NewArrayExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new NewArray(expression);
            foreach (var child in expression.Expressions)
            {
                result.Expressions.Add(Serializer.Serialize(child, state));
            }

            return result;
        }

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(
            JsonElement json,
            SerializationState state) => Deserialize(json, state);

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(
            Expression expression,
            SerializationState state) =>
            Serialize(expression as NewArrayExpression, state);
    }
}
