// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="MethodCallExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Call)]
    public class MethodSerializer :
        BaseSerializer<MethodCallExpression, MethodExpr>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public MethodSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a <see cref="MethodExpr"/> to a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="json">The <see cref="JsonElement"/> to deserialize.</param>
        /// <returns>The <see cref="MethodCallExpression"/>.</returns>
        public override MethodCallExpression Deserialize(JsonElement json)
        {
            Expression obj = null;
            if (json.TryGetProperty(
                nameof(MethodExpr.MethodObject),
                out JsonElement jsonObj))
            {
                obj = Serializer.Deserialize(jsonObj);
            }

            var method = json.GetProperty(nameof(MethodExpr.MethodInfo));
            var methodProp = JsonSerializer.Deserialize<Method>(method.GetRawText());
            var methodInfo = ReflectionHelper.Instance.GetMethodFromCache(methodProp);

            var list = json.GetProperty(nameof(MethodExpr.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element)).ToList();
            if (obj != null)
            {
                return Expression.Call(obj, methodInfo, argumentList);
            }

            return Expression.Call(methodInfo, argumentList);
        }

        /// <summary>
        /// Serialize a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MethodCallExpression"/> to serialize.</param>
        /// <returns>The serializable <see cref="MethodExpr"/>.</returns>
        public override MethodExpr Serialize(MethodCallExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var method = new MethodExpr(expression)
            {
                MethodObject = Serializer.Serialize(expression.Object),
            };

            foreach (var arg in expression.Arguments)
            {
                method.Arguments.Add(Serializer.Serialize(arg));
            }

            return method;
        }

        /// <summary>
        /// Explicitly implement interface.
        /// </summary>
        /// <param name="json">The <see cref="JsonElement"/>.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(JsonElement json) =>
            Deserialize(json);

        /// <summary>
        /// Explicitly implement interface.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(Expression expression)
            => Serialize(expression as MethodCallExpression);
    }
}
