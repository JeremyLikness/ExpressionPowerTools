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
        /// <returns>The <see cref="InvocationExpression"/>.</returns>
        public override InvocationExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            var expr = json.GetProperty(nameof(Invocation.Expression));
            var expression = Serializer.Deserialize(expr, state);
            var list = json.GetNullableProperty(nameof(Invocation.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, state)).ToList();
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
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(
            Expression expression,
            SerializationState state) =>
            Serialize(expression as InvocationExpression, state);
    }
}
