﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
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
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <param name="template">The template for handling types.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public override ParameterExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            var param = template as Parameter;
            Type type = GetMemberFromKey<Type>(param.ParameterTypeKey);
            var name = json.GetNullableProperty(nameof(Parameter.Name)).GetString();
            var parameter = string.IsNullOrWhiteSpace(name) ? Expression.Parameter(type) :
                Expression.Parameter(type, name);
            return state.GetOrCacheParameter(parameter);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
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
