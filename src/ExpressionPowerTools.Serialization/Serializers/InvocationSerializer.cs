// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
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
        /// <returns>The <see cref="InvocationExpression"/>.</returns>
        public override InvocationExpression Deserialize(JsonElement json)
        {
            var expr = json.GetProperty(nameof(Invocation.Expression));
            var expression = Serializer.Deserialize(expr);
            var list = json.GetProperty(nameof(Invocation.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element)).ToList();
            return Expression.Invoke(expression, argumentList);
        }

        /// <summary>
        /// Serialize an <see cref="InvocationExpression"/> to an <see cref="Invocation"/>.
        /// </summary>
        /// <param name="expression">The <see cref="InvocationExpression"/>.</param>
        /// <returns>The <see cref="Invocation"/>.</returns>
        public override Invocation Serialize(InvocationExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Invocation(expression)
            {
                Expression = Serializer.Serialize(expression.Expression),
            };

            foreach (var argument in expression.Arguments)
            {
                result.Arguments.Add(Serializer.Serialize(argument));
            }

            return result;
        }

        /// <summary>
        /// Explicit implementation of <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(JsonElement json) => Deserialize(json);

        /// <summary>
        /// Explicit implementation of <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(Expression expression) =>
            Serialize(expression as InvocationExpression);
    }
}
