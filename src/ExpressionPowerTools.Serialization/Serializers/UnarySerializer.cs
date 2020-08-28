// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="UnaryExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.ArrayLength)]
    [ExpressionSerializer(ExpressionType.Convert)]
    [ExpressionSerializer(ExpressionType.ConvertChecked)]
    [ExpressionSerializer(ExpressionType.Decrement)]
    [ExpressionSerializer(ExpressionType.Increment)]
    [ExpressionSerializer(ExpressionType.Negate)]
    [ExpressionSerializer(ExpressionType.NegateChecked)]
    [ExpressionSerializer(ExpressionType.Not)]
    [ExpressionSerializer(ExpressionType.PostDecrementAssign)]
    [ExpressionSerializer(ExpressionType.PostIncrementAssign)]
    [ExpressionSerializer(ExpressionType.PreDecrementAssign)]
    [ExpressionSerializer(ExpressionType.PreIncrementAssign)]
    [ExpressionSerializer(ExpressionType.Quote)]
    [ExpressionSerializer(ExpressionType.Throw)]
    [ExpressionSerializer(ExpressionType.TypeAs)]
    [ExpressionSerializer(ExpressionType.UnaryPlus)]
    [ExpressionSerializer(ExpressionType.Unbox)]
    public class UnarySerializer :
        BaseSerializer<UnaryExpression, Unary>, IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnarySerializer"/> class with a
        /// base serializer for recurision.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public UnarySerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="UnaryExpression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="queryRoot">The query root to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="UnaryExpression"/>.</returns>
        public override UnaryExpression Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options)
        {
            var method = json.GetNullableProperty(nameof(Unary.UnaryMethod));
            var methodProp = JsonSerializer.Deserialize<Method>(method.GetRawText(), options);
            var type = json.GetProperty(nameof(SerializableExpression.Type)).GetString();
            var operandElement = json.GetNullableProperty(nameof(UnaryExpression.Operand));
            var operand = Serializer.Deserialize(operandElement, queryRoot, options);
            var expressionType = GetExpressionTypeFor(type);
            var unaryTypeName = json.GetProperty(nameof(Unary.UnaryType)).GetString();
            var unaryType = ReflectionHelper.Instance.GetTypeFromCache(unaryTypeName);

            if (methodProp != null)
            {
                var methodInfo = GetMemberInfo<MethodInfo, Method>(methodProp);
                return Expression.MakeUnary(
                    expressionType,
                    operand,
                    unaryType,
                    methodInfo);
            }

            return Expression.MakeUnary(expressionType, operand, unaryType);
        }

        /// <summary>
        /// Serialize a <see cref="UnaryExpression"/> to a <see cref="Unary"/>.
        /// </summary>
        /// <param name="expression">The <see cref="UnaryExpression"/>.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Unary"/>.</returns>
        public override Unary Serialize(
            UnaryExpression expression,
            JsonSerializerOptions options)
        {
            if (expression == null)
            {
                return null;
            }

            var unary = new Unary(expression)
            {
                Operand = Serializer.Serialize(expression.Operand, options),
            };

            return unary;
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
            Serialize(expression as UnaryExpression, options);
    }
}
