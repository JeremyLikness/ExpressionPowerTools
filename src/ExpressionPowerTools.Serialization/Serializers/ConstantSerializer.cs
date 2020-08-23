// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="ConstantExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Constant)]
    public class ConstantSerializer :
        BaseSerializer, IBaseSerializer, IExpressionSerializer<ConstantExpression, Constant>
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
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public ConstantExpression Deserialize(JsonElement json)
        {
            var value = json.GetProperty(nameof(Constant.Value)).GetRawText();
            var typeName = json.GetProperty(nameof(Constant.ConstantType)).GetString();
            var valueTypeName = json.GetProperty(nameof(Constant.ValueType)).GetString();
            Type type;

            if (valueTypeName.Contains(AnonymousType))
            {
                var val = JsonSerializer.Deserialize<Dictionary<string, object>>(value);
                return Expression.Constant(val);
            }

            type = ReflectionHelper.Instance.GetTypeFromCache(valueTypeName);

            var constantType = typeName == valueTypeName ? type :
                ReflectionHelper.Instance.GetTypeFromCache(typeName);

            if (typeof(SerializableExpression).IsAssignableFrom(type))
            {
                var innerValue = Serializer.Deserialize(json.GetProperty(nameof(Constant.Value)));
                return Expression.Constant(innerValue, innerValue.GetType());
            }

            var constantVal = JsonSerializer.Deserialize(value, type);

            return type == constantType ? Expression.Constant(constantVal) :
                Expression.Constant(constantVal, constantType);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <returns>The serializable <see cref="Constant"/>.</returns>
        public Constant Serialize(ConstantExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Constant(expression);
            if (expression.Value is Expression expr)
            {
                result.Value = Serializer.Serialize(expr);
                result.ConstantType = result.ValueType = result.Value.GetType().FullName;
            }

            return result;
        }

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <returns>The <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(JsonElement json) => Deserialize(json);

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(Expression expression) =>
            Serialize(expression as ConstantExpression);
    }
}
