// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
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
        /// <param name="json">The serialized fragment.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <param name="template">The template to decompress types.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The <see cref="InvocationExpression"/>.</returns>
        public override InvocationExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            var expr = json.GetProperty(nameof(Invocation.Expression));
            var expression = Serializer.Deserialize(expr, state, Default);
            var list = json.GetNullableProperty(nameof(Invocation.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, state, Default)).ToList();
            return Expression.Invoke(expression, argumentList);
        }

        /// <summary>
        /// Serialize an <see cref="InvocationExpression"/> to an <see cref="Invocation"/>.
        /// </summary>
        /// <param name="expression">The <see cref="InvocationExpression"/>.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
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
