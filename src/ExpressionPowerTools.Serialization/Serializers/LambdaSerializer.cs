// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serialization logic for expressions of type <see cref="LambdaExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Lambda)]
    public class LambdaSerializer :
        BaseSerializer<LambdaExpression, Lambda>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LambdaSerializer"/> class with a
        /// base serializer for recurision.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public LambdaSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="LambdaExpression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="LambdaExpression"/>.</returns>
        public override LambdaExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            var materializedType = GetMemberFromKey<Type>(
                json.GetProperty(nameof(Lambda.LambdaTypeKey))
                .GetString());
            var materializedReturnType = GetMemberFromKey<Type>(json.GetProperty(nameof(Lambda.ReturnTypeKey))
                .GetString());
            var body = Serializer.Deserialize(json.GetProperty(nameof(Lambda.Body)), state);
            var name = json.GetNullableProperty(nameof(Lambda.Name)).GetString();
            var list = json.GetNullableProperty(nameof(Lambda.Parameters));
            var parameterList = list.ValueKind == JsonValueKind.Array ?
                list.EnumerateArray().Select(element =>
                    Serializer.Deserialize(element, state) as ParameterExpression).ToList() :
                new List<ParameterExpression>();
            return
                AnonymousTypeAdapter.TransformLambda(
                    Expression.Lambda(materializedType, body, name, parameterList));
        }

        /// <summary>
        /// Serialize a <see cref="LambdaExpression"/> to a <see cref="Lambda"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/>.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The <see cref="Lambda"/>.</returns>
        public override Lambda Serialize(
            LambdaExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            expression = AnonymousTypeAdapter.TransformLambda(expression);

            var result = new Lambda(expression)
            {
                Body = Serializer.Serialize(expression.Body, state),
            };

            foreach (var parameter in expression.Parameters)
            {
                result.Parameters.Add(Serializer.Serialize(parameter, state) as Parameter);
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
            Serialize(expression as LambdaExpression, state);
    }
}
