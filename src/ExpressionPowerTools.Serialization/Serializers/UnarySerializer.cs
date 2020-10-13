// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Reflection;
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
        /// <param name="unary">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="UnaryExpression"/>.</returns>
        public override UnaryExpression Deserialize(
            Unary unary,
            SerializationState state)
        {
            MethodInfo methodInfo = null;
            if (!string.IsNullOrWhiteSpace(unary.UnaryMethodKey))
            {
                methodInfo = GetMemberFromKey<MethodInfo>(unary.UnaryMethodKey);
            }

            var operand = unary.Operand == null ? null : Serializer.Deserialize(unary.Operand, state);
            var unaryType = GetMemberFromKey<Type>(unary.UnaryTypeKey);

            if (methodInfo != null)
            {
                return Expression.MakeUnary(
                    (ExpressionType)unary.Type,
                    operand,
                    unaryType,
                    methodInfo);
            }

            return Expression.MakeUnary((ExpressionType)unary.Type, operand, unaryType);
        }

        /// <summary>
        /// Serialize a <see cref="UnaryExpression"/> to a <see cref="Unary"/>.
        /// </summary>
        /// <param name="expression">The <see cref="UnaryExpression"/>.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="Unary"/>.</returns>
        public override Unary Serialize(
            UnaryExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var unary = new Unary(expression)
            {
                Operand = Serializer.Serialize(expression.Operand, state),
            };

            return unary;
        }
    }
}
