// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

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
        /// <param name="queryRoot">The query root to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="LambdaExpression"/>.</returns>
        public override LambdaExpression Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options)
        {
            var materializedType = json.GetProperty(nameof(Lambda.LambdaType))
                .GetDeserializedType();
            var materializedReturnType = json.GetProperty(nameof(Lambda.ReturnType))
                .GetDeserializedType();
            var body = Serializer.Deserialize(json.GetProperty(nameof(Lambda.Body)), queryRoot, options);
            var name = json.GetProperty(nameof(Lambda.Name)).GetString();
            var list = json.GetProperty(nameof(Lambda.Parameters));
            var parameterList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, queryRoot, options) as ParameterExpression).ToList();
            return Expression.Lambda(materializedType, body, name, parameterList);
        }

        /// <summary>
        /// Serialize a <see cref="LambdaExpression"/> to a <see cref="Lambda"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/>.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Lambda"/>.</returns>
        public override Lambda Serialize(
            LambdaExpression expression,
            JsonSerializerOptions options)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Lambda(expression)
            {
                Body = Serializer.Serialize(expression.Body, options),
            };
            foreach (var parameter in expression.Parameters)
            {
                result.Parameters.Add(Serializer.Serialize(parameter, options) as Parameter);
            }

            return result;
        }

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="queryRoot">The query root to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options) => Deserialize(json, queryRoot, options);

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(
            Expression expression,
            JsonSerializerOptions options) =>
            Serialize(expression as LambdaExpression, options);
    }
}
