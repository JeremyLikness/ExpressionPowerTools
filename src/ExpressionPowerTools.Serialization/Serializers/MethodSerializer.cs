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
        /// <param name="template">The template for handling types.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The <see cref="MethodCallExpression"/>.</returns>
        public override MethodCallExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            Expression obj = null;

            var method = template as MethodExpr;

            if (json.TryGetProperty(
                nameof(MethodExpr.MethodObject),
                out JsonElement jsonObj))
            {
                obj = Serializer.Deserialize(jsonObj, state, Default);
            }

            var methodInfo = GetMemberFromKey<MethodInfo>(method.MethodInfoKey);

            AuthorizeMembers(methodInfo);

            var list = json.GetProperty(nameof(MethodExpr.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, state, Default)).ToList();

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
    }
}
