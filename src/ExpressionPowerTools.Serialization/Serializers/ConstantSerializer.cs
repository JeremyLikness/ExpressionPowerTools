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
    /// Serializer for <see cref="ConstantExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Constant)]
    public class ConstantSerializer :
        BaseSerializer<ConstantExpression, Constant>, IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The serializer to use.</param>
        public ConstantSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a serializable class to an actionable <see cref="Expression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="queryRoot">The root query to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public override ConstantExpression Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options)
        {
            var value = json.GetProperty(nameof(Constant.Value)).GetRawText();
            var type = json.GetProperty(nameof(Constant.ConstantType)).GetDeserializedType();
            var valueTypeNode = json.GetProperty(nameof(Constant.ValueType)).GetRawText();
            var valueTypeName = JsonSerializer.Deserialize<SerializableType>(valueTypeNode, options);

            if (valueTypeName.TypeName.Contains(AnonymousType))
            {
                var val = JsonSerializer.Deserialize<Dictionary<string, object>>(value, options);
                return Expression.Constant(val);
            }

            var valueType = ReflectionHelper.Instance.DeserializeType(valueTypeName);

            if (typeof(SerializableExpression).IsAssignableFrom(valueType))
            {
                var innerValue = Serializer.Deserialize(
                    json.GetProperty(nameof(Constant.Value)),
                    queryRoot,
                    options);
                return Expression.Constant(innerValue, innerValue.GetType());
            }

            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition()
                == typeof(EnumerableQuery<>))
            {
                if (queryRoot is ConstantExpression ce)
                {
                    return ce;
                }

                return queryRoot != null ? Expression.Constant(queryRoot) : Expression.Constant(null, valueType);
            }

            var constantVal = JsonSerializer.Deserialize(value, valueType, options);

            return type == valueType ? Expression.Constant(constantVal) :
                Expression.Constant(constantVal, type);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The serializable <see cref="Constant"/>.</returns>
        public override Constant Serialize(ConstantExpression expression, JsonSerializerOptions options)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Constant(expression);
            if (expression.Value is Expression expr)
            {
                result.Value = Serializer.Serialize(expr, options);
                result.ValueType =
                    ReflectionHelper.Instance.SerializeType(
                        result.Value.GetType());
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
            Serialize(expression as ConstantExpression, options);
    }
}
