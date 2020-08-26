// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
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
        /// <returns>The <see cref="LambdaExpression"/>.</returns>
        public override LambdaExpression Deserialize(JsonElement json)
        {
            var type = json.GetProperty(nameof(Lambda.LambdaType)).GetString();
            var returnType = json.GetProperty(nameof(Lambda.ReturnType)).GetString();
            var body = Serializer.Deserialize(json.GetProperty(nameof(Lambda.Body)));
            var name = json.GetProperty(nameof(Lambda.Name)).GetString();
            var materializedType = ReflectionHelper.Instance.GetTypeFromCache(type);
            var materializedReturnType = ReflectionHelper.Instance.GetTypeFromCache(returnType);
            var list = json.GetProperty(nameof(Lambda.Parameters));
            var parameterList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element) as ParameterExpression).ToList();
            return Expression.Lambda(materializedType, body, name, parameterList);
        }

        /// <summary>
        /// Serialize a <see cref="LambdaExpression"/> to a <see cref="Lambda"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/>.</param>
        /// <returns>The <see cref="Lambda"/>.</returns>
        public override Lambda Serialize(LambdaExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Lambda(expression)
            {
                Body = Serializer.Serialize(expression.Body),
            };
            foreach (var parameter in expression.Parameters)
            {
                result.Parameters.Add(Serializer.Serialize(parameter) as Parameter);
            }

            return result;
        }

        /// <summary>
        /// Explicit implementation of <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(JsonElement json) => Deserialize(json);

        /// <summary>
        /// Explicit implementation of <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(Expression expression) =>
            Serialize(expression as LambdaExpression);
    }
}
