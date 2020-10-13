// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serialization logic for expressions of type <see cref="LambdaExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Lambda)]
    public class LambdaSerializer :
        BaseSerializer<LambdaExpression, Lambda>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LambdaSerializer"/> class with a
        /// base serializer for recurision.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public LambdaSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="LambdaExpression"/>.
        /// </summary>
        /// <param name="lambda">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="LambdaExpression"/>.</returns>
        public override LambdaExpression Deserialize(
            Lambda lambda,
            SerializationState state)
        {
            var materializedType = GetMemberFromKey<Type>(
                lambda.LambdaTypeKey);

            var materializedReturnType = GetMemberFromKey<Type>(lambda.ReturnTypeKey);

            var parameterList =
                lambda.Parameters != null ?
                lambda.Parameters.Select(element =>
                    Serializer.Deserialize(element, state) as ParameterExpression).ToList() :
                new List<ParameterExpression>();

            Expression body = Serializer.Deserialize(lambda.Body, state);

            return Expression.Lambda(
                materializedType,
                body,
                lambda.Name,
                parameterList);
        }

        /// <summary>
        /// Serialize a <see cref="LambdaExpression"/> to a <see cref="Lambda"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/>.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="Lambda"/>.</returns>
        public override Lambda Serialize(
            LambdaExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Lambda(expression)
            {
                Body = Serializer.Serialize(expression.Body, state),
            };

            foreach (var parameter in expression.Parameters)
            {
                result.Parameters.Add(Serializer.Serialize(parameter, state) as Parameter);
            }

            return result;
        }
    }
}
