// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using System.Reflection;
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
        /// <param name="root">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="BinaryExpression"/>.</returns>
        public override BinaryExpression Deserialize(
            Binary root,
            SerializationState state)
        {
            var methodInfo = string.IsNullOrWhiteSpace(root.BinaryMethod) ?
                null :
                GetMemberFromKey<MethodInfo>(root.BinaryMethod);

            if (methodInfo != null)
            {
                AuthorizeMembers(methodInfo);
            }

            var left = Serializer.Deserialize(root.Left, state);
            var right = Serializer.Deserialize(root.Right, state);
            var type = (ExpressionType)root.Type;

            if (root.Conversion != null && Serializer.Deserialize(root.Conversion, state) is LambdaExpression conversion)
            {
                return Expression.MakeBinary(
                    type,
                    left,
                    right,
                    root.LiftToNull,
                    methodInfo,
                    conversion);
            }

            if (methodInfo != null)
            {
                return Expression.MakeBinary(
                    type,
                    left,
                    right,
                    root.LiftToNull,
                    methodInfo);
            }

            return Expression.MakeBinary(type, left, right);
        }

        /// <summary>
        /// Serialize a <see cref="BinaryExpression"/> to a <see cref="Binary"/>.
        /// </summary>
        /// <param name="expression">The <see cref="BinaryExpression"/>.</param>
        /// <param name="state">State for the serialization.</param>
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
                binary.Conversion = (Lambda)Serializer.Serialize(expression.Conversion, state);
            }

            return binary;
        }
    }
}
