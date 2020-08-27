// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
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
        /// <param name="queryRoot">The query root to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="MethodCallExpression"/>.</returns>
        public override MethodCallExpression Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options)
        {
            Expression obj = null;
            if (json.TryGetProperty(
                nameof(MethodExpr.MethodObject),
                out JsonElement jsonObj))
            {
                obj = Serializer.Deserialize(jsonObj, queryRoot, options);
            }

            var method = json.GetProperty(nameof(MethodExpr.MethodInfo)).GetMethod();
            var methodInfo = GetMemberInfo<MethodInfo, MemberBase>(method);

            var list = json.GetProperty(nameof(MethodExpr.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, queryRoot, options)).ToList();
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
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The serializable <see cref="MethodExpr"/>.</returns>
        public override MethodExpr Serialize(
            MethodCallExpression expression,
            JsonSerializerOptions options)
        {
            if (expression == null)
            {
                return null;
            }

            var method = new MethodExpr(expression)
            {
                MethodObject = Serializer.Serialize(expression.Object, options),
            };

            foreach (var arg in expression.Arguments)
            {
                method.Arguments.Add(Serializer.Serialize(arg, options));
            }

            return method;
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
            Serialize(expression as MethodCallExpression, options);
    }
}
