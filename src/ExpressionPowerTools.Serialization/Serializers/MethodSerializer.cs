// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="MethodCallExpression"/>.</returns>
        public override MethodCallExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            Expression obj = null;
            if (json.TryGetProperty(
                nameof(MethodExpr.MethodObject),
                out JsonElement jsonObj))
            {
                obj = Serializer.Deserialize(jsonObj, state);
            }

            var key = json.GetProperty(nameof(MethodExpr.MethodInfoKey))
                .GetString();

            var methodInfo = GetMemberFromKey<MethodInfo>(key);

            AuthorizeMembers(methodInfo);

            var list = json.GetProperty(nameof(MethodExpr.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, state)).ToList();

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
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The serializable <see cref="MethodExpr"/>.</returns>
        public override MethodExpr Serialize(
            MethodCallExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var method = new MethodExpr(expression)
            {
                MethodObject = Serializer.Serialize(expression.Object, state),
            };

            foreach (var arg in expression.Arguments)
            {
                method.Arguments.Add(Serializer.Serialize(arg, state));
            }

            return method;
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
            Serialize(expression as MethodCallExpression, state);
    }
}
