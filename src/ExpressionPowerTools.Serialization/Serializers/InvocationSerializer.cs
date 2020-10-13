// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serialization logic for expressions of type <see cref="InvocationExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.Invoke)]
    public class InvocationSerializer :
        BaseSerializer<InvocationExpression, Invocation>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvocationSerializer"/> class
        /// with a base serializer for recurision.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public InvocationSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserializes a <see cref="InvocationExpression"/>.
        /// </summary>
        /// <param name="expr">The serialized fragment.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="InvocationExpression"/>.</returns>
        public override InvocationExpression Deserialize(
            Invocation expr,
            SerializationState state)
        {
            var expression = Serializer.Deserialize(expr.Expression, state);
            var argumentList = expr.Arguments.Select(element =>
                Serializer.Deserialize(element, state)).ToList();
            return Expression.Invoke(expression, argumentList);
        }

        /// <summary>
        /// Serialize an <see cref="InvocationExpression"/> to an <see cref="Invocation"/>.
        /// </summary>
        /// <param name="expression">The <see cref="InvocationExpression"/>.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="Invocation"/>.</returns>
        public override Invocation Serialize(
            InvocationExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Invocation()
            {
                Expression = Serializer.Serialize(expression.Expression, state),
            };

            foreach (var argument in expression.Arguments)
            {
                result.Arguments.Add(Serializer.Serialize(argument, state));
            }

            return result;
        }
    }
}
