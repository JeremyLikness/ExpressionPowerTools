// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Extensions;
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
        /// <param name="constant">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public override ConstantExpression Deserialize(
            Constant constant,
            SerializationState state)
        {
            var type = GetMemberFromKey<Type>(constant.ConstantTypeKey);
            var valueType = string.IsNullOrWhiteSpace(constant.ValueTypeKey) ?
                type :
                GetMemberFromKey<Type>(constant.ValueTypeKey);

            if (typeof(SerializableExpression).IsAssignableFrom(valueType))
            {
                var innerValue = Serializer.Deserialize(constant.Value as SerializableExpression, state);
                return Expression.Constant(innerValue, innerValue.GetType());
            }

            if (valueType.IsGenericType &&
                valueType.GetGenericTypeDefinition()
                == typeof(EnumerableQuery<>))
            {
                if (state.QueryRoot is ConstantExpression ce)
                {
                    return ce;
                }

                return state.QueryRoot != null ?
                    Expression.Constant(state.QueryRoot) : Expression.Constant(null, valueType);
            }

            if (typeof(MemberInfo).IsAssignableFrom(valueType))
            {
                var memberKey = constant.Value as string;
                return Expression.Constant(GetMemberFromKey(memberKey));
            }

            if (constant.Value is AnonType anonType)
            {
                constant.Value = ConvertAnonTypeToAnonymousType(anonType);
            }

            return type == valueType && constant.Value != null ? Expression.Constant(constant.Value) :
                Expression.Constant(constant.Value, type);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The serializable <see cref="Constant"/>.</returns>
        public override Constant Serialize(ConstantExpression expression, SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            if (expression.Type.IsAnonymousType())
            {
                expression = Expression.Constant(
                    ConvertAnonymousTypeToAnonType(expression.Value),
                    typeof(AnonType));
            }

            var result = new Constant(expression);

            if (expression.Value is Expression expr)
            {
                result.Value = Serializer.Serialize(expr, state);
                result.ValueTypeKey = GetKeyForMember(result.Value.GetType());
            }

            if (result.ValueTypeKey == result.ConstantTypeKey)
            {
                result.ValueTypeKey = null;
            }

            return result;
        }
    }
}
