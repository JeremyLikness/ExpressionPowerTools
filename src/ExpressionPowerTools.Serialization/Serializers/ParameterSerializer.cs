// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="ParameterExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Parameter)]
    public class ParameterSerializer :
        BaseSerializer<ParameterExpression, Parameter>, IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The serializer to use.</param>
        public ParameterSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a serializable class to an actionable <see cref="Expression"/>.
        /// </summary>
        /// <param name="param">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public override ParameterExpression Deserialize(
            Parameter param,
            SerializationState state)
        {
            Type type = GetMemberFromKey<Type>(param.ParameterTypeKey);
            var parameter = string.IsNullOrWhiteSpace(param.Name) ? Expression.Parameter(type) :
                Expression.Parameter(type, param.Name);
            return state.GetOrCacheParameter(parameter);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The serializable <see cref="Constant"/>.</returns>
        public override Parameter Serialize(
            ParameterExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Parameter(expression);
            return result;
        }
    }
}
