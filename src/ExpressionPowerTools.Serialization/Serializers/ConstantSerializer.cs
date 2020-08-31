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
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public override ConstantExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            var value = json.GetNullableProperty(nameof(Constant.Value)).GetRawText();
            var type = json.GetProperty(nameof(Constant.ConstantType)).GetDeserializedType();
            var valueTypeNode = json.GetNullableProperty(nameof(Constant.ValueType)).GetRawText();
            var valueTypeName = JsonSerializer.Deserialize<SerializableType>(valueTypeNode, state.Options);

            var valueType = ReflectionHelper.Instance.DeserializeType(valueTypeName);

            if (typeof(SerializableExpression).IsAssignableFrom(valueType))
            {
                var innerValue = Serializer.Deserialize(
                    json.GetProperty(nameof(Constant.Value)),
                    state);
                return Expression.Constant(innerValue, innerValue.GetType());
            }

            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition()
                == typeof(EnumerableQuery<>))
            {
                if (state.QueryRoot is ConstantExpression ce)
                {
                    return ce;
                }

                return state.QueryRoot != null ? Expression.Constant(state.QueryRoot) : Expression.Constant(null, valueType);
            }

            var constantVal = JsonSerializer.Deserialize(value, valueType, state.Options);

            if (constantVal is AnonType anonType)
            {
                // normalize values
                foreach (var propValue in anonType.PropertyValues)
                {
                    if (propValue.AnonVal == null)
                    {
                        continue;
                    }

                    var valuetype = ReflectionHelper.Instance.DeserializeType(propValue.AnonValueType);
                    var jsonValue = (JsonElement)propValue.AnonVal;
                    propValue.AnonVal = JsonSerializer.Deserialize(jsonValue.GetRawText(), valuetype, state.Options);
                }

                return Expression.Constant(anonType.GetValue());
            }

            return type == valueType ? Expression.Constant(constantVal) :
                Expression.Constant(constantVal, type);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The serializable <see cref="Constant"/>.</returns>
        public override Constant Serialize(ConstantExpression expression, SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Constant(expression);
            if (expression.Value is Expression expr)
            {
                result.Value = Serializer.Serialize(expr, state);
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
            Serialize(expression as ConstantExpression, state);
    }
}
