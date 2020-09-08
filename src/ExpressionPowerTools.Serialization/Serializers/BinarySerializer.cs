// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serialization services for <see cref="BinaryExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Add)]
    [ExpressionSerializer(ExpressionType.AddAssign)]
    [ExpressionSerializer(ExpressionType.AddAssignChecked)]
    [ExpressionSerializer(ExpressionType.AddChecked)]
    [ExpressionSerializer(ExpressionType.And)]
    [ExpressionSerializer(ExpressionType.AndAlso)]
    [ExpressionSerializer(ExpressionType.AndAssign)]
    [ExpressionSerializer(ExpressionType.Assign)]
    [ExpressionSerializer(ExpressionType.Coalesce)]
    [ExpressionSerializer(ExpressionType.Divide)]
    [ExpressionSerializer(ExpressionType.DivideAssign)]
    [ExpressionSerializer(ExpressionType.Equal)]
    [ExpressionSerializer(ExpressionType.ExclusiveOr)]
    [ExpressionSerializer(ExpressionType.ExclusiveOrAssign)]
    [ExpressionSerializer(ExpressionType.GreaterThan)]
    [ExpressionSerializer(ExpressionType.GreaterThanOrEqual)]
    [ExpressionSerializer(ExpressionType.LeftShift)]
    [ExpressionSerializer(ExpressionType.LeftShiftAssign)]
    [ExpressionSerializer(ExpressionType.LessThan)]
    [ExpressionSerializer(ExpressionType.LessThanOrEqual)]
    [ExpressionSerializer(ExpressionType.Modulo)]
    [ExpressionSerializer(ExpressionType.ModuloAssign)]
    [ExpressionSerializer(ExpressionType.Multiply)]
    [ExpressionSerializer(ExpressionType.MultiplyAssign)]
    [ExpressionSerializer(ExpressionType.MultiplyAssignChecked)]
    [ExpressionSerializer(ExpressionType.MultiplyChecked)]
    [ExpressionSerializer(ExpressionType.NotEqual)]
    [ExpressionSerializer(ExpressionType.Or)]
    [ExpressionSerializer(ExpressionType.OrAssign)]
    [ExpressionSerializer(ExpressionType.OrElse)]
    [ExpressionSerializer(ExpressionType.Power)]
    [ExpressionSerializer(ExpressionType.PowerAssign)]
    [ExpressionSerializer(ExpressionType.RightShift)]
    [ExpressionSerializer(ExpressionType.RightShiftAssign)]
    [ExpressionSerializer(ExpressionType.Subtract)]
    [ExpressionSerializer(ExpressionType.SubtractAssign)]
    [ExpressionSerializer(ExpressionType.SubtractAssignChecked)]
    [ExpressionSerializer(ExpressionType.SubtractChecked)]
    public class BinarySerializer :
        BaseSerializer<BinaryExpression, Binary>, IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class with a
        /// base serializer for recursion.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public BinarySerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="BinaryExpression"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="BinaryExpression"/>.</returns>
        public override BinaryExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            var method = json.GetNullableProperty(nameof(Binary.BinaryMethod));
            var methodProp = method.GetMethod(state);
            var expressionType = (ExpressionType)json.GetProperty(nameof(SerializableExpression.Type)).GetInt32();
            var conversionElement = json.GetNullableProperty(nameof(Binary.Conversion));
            var liftToNull = json.GetProperty(nameof(Binary.LiftToNull)).GetBoolean();
            var left = Serializer.Deserialize(json.GetProperty(nameof(Binary.Left)), state);
            var right = Serializer.Deserialize(json.GetProperty(nameof(Binary.Right)), state);
            MethodInfo methodInfo = null;
            if (methodProp != null)
            {
                methodInfo = GetMemberInfo<MethodInfo, Method>(methodProp);
                AuthorizeMembers(methodInfo);
            }

            if (Serializer.Deserialize(conversionElement, state) is LambdaExpression conversion)
            {
                return Expression.MakeBinary(
                    expressionType,
                    left,
                    right,
                    liftToNull,
                    methodInfo,
                    conversion);
            }

            if (methodInfo != null)
            {
                return Expression.MakeBinary(
                    expressionType,
                    left,
                    right,
                    liftToNull,
                    methodInfo);
            }

            return Expression.MakeBinary(expressionType, left, right);
        }

        /// <summary>
        /// Serialize a <see cref="BinaryExpression"/> to a <see cref="Binary"/>.
        /// </summary>
        /// <param name="expression">The <see cref="BinaryExpression"/>.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The <see cref="Binary"/>.</returns>
        public override Binary Serialize(
            BinaryExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var binary = new Binary(expression)
            {
                Left = Serializer.Serialize(expression.Left, state),
                Right = Serializer.Serialize(expression.Right, state),
            };

            if (expression.Conversion != null)
            {
                binary.Conversion = Serializer.Serialize(expression.Conversion, state);
            }

            if (binary.BinaryMethod != null)
            {
                state.CompressMemberTypes(binary.BinaryMethod);
            }

            return binary;
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
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(
            Expression expression,
            SerializationState state) =>
            Serialize(expression as BinaryExpression, state);
    }
}
