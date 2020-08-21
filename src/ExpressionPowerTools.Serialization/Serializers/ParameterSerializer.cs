// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="ParameterExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Parameter)]
    public class ParameterSerializer :
        BaseSerializer, IBaseSerializer, IExpressionSerializer<ParameterExpression, Parameter>
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
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public ParameterExpression Deserialize(JsonElement json)
        {
            var type = Type.GetType(json.GetProperty(nameof(Parameter.ParameterType)).GetString());
            var name = json.GetProperty(nameof(Parameter.Name)).GetString();
            return string.IsNullOrWhiteSpace(name) ? Expression.Parameter(type) :
                Expression.Parameter(type, name);
        }

        /// <summary>
        /// Serializes the expression.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to serialize.</param>
        /// <returns>The serializable <see cref="Constant"/>.</returns>
        public Parameter Serialize(ParameterExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Parameter(expression);
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
            Serialize(expression as ParameterExpression);
    }
}
