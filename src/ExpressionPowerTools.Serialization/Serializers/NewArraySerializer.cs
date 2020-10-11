﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="NewArrayExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.NewArrayInit)]
    public class NewArraySerializer
        : BaseSerializer<NewArrayExpression, NewArray>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewArraySerializer"/> class with a
        /// base serializer for recurision.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public NewArraySerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="NewArrayExpression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <param name="template">The template for handling types.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The <see cref="NewArrayExpression"/>.</returns>
        public override NewArrayExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            var newArray = template as NewArray;
            var materializedType = GetMemberFromKey<Type>(newArray.ArrayTypeKey);
            var list = json.GetProperty(nameof(NewArray.Expressions));
            var expressionList = list.EnumerateArray().Select(element => Serializer.Deserialize(
                element, state, Default)).ToList();
            return Expression.NewArrayInit(materializedType, expressionList);
        }

        /// <summary>
        /// Serialize a <see cref="NewArrayExpression"/> to a <see cref="NewArray"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewArrayExpression"/>.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The <see cref="NewArray"/>.</returns>
        public override NewArray Serialize(
            NewArrayExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new NewArray(expression);
            foreach (var child in expression.Expressions)
            {
                result.Expressions.Add(Serializer.Serialize(child, state));
            }

            return result;
        }
    }
}
