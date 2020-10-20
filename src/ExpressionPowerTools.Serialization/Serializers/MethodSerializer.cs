// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializer for <see cref="MethodCallExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Call)]
    public class MethodSerializer :
        BaseSerializer<MethodCallExpression, MethodExpr>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public MethodSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a <see cref="MethodExpr"/> to a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="method">The <see cref="MethodExpr"/> to deserialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="MethodCallExpression"/>.</returns>
        public override MethodCallExpression Deserialize(
            MethodExpr method,
            SerializationState state)
        {
            Expression obj = null;

            if (method.MethodObject != null)
            {
                obj = Serializer.Deserialize(method.MethodObject, state);
            }

            var methodInfo = GetMemberFromKey<MethodInfo>(method.MethodInfoKey);

            AuthorizeMembers(methodInfo);

            var argumentList = method.Arguments.Select(element =>
                Serializer.Deserialize(element, state)).ToList();

            // check to unwind expression for query host
            var type = methodInfo.GetParameters().Select(p => p.ParameterType).FirstOrDefault();

            if (type != null &&
                type.IsGenericType &&
                !type.IsGenericTypeDefinition &&
                typeof(IQueryable<>).IsAssignableFrom(type.GetGenericTypeDefinition()))
            {
                if (argumentList[0] is ConstantExpression ce && ce.Value is Expression e)
                {
                    argumentList[0] = e;
                }
            }

            if (obj != null)
            {
                return Expression.Call(obj, methodInfo, argumentList);
            }

            return Expression.Call(methodInfo, argumentList);
        }

        /// <summary>
        /// Serialize a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MethodCallExpression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The serializable <see cref="MethodExpr"/>.</returns>
        public override MethodExpr Serialize(
            MethodCallExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var method = new MethodExpr(expression)
            {
                MethodObject = Serializer.Serialize(expression.Object, state),
            };

            foreach (var arg in expression.Arguments)
            {
                method.Arguments.Add(Serializer.Serialize(arg, state));
            }

            return method;
        }
    }
}
