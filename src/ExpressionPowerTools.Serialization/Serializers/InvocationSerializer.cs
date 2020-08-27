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
        /// <param name="queryRoot">The query root to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="InvocationExpression"/>.</returns>
        public override InvocationExpression Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options)
        {
            var expr = json.GetProperty(nameof(Invocation.Expression));
            var expression = Serializer.Deserialize(expr, queryRoot, options);
            var list = json.GetProperty(nameof(Invocation.Arguments));
            var argumentList = list.EnumerateArray().Select(element =>
                Serializer.Deserialize(element, queryRoot, options)).ToList();
            return Expression.Invoke(expression, argumentList);
        }

        /// <summary>
        /// Serialize an <see cref="InvocationExpression"/> to an <see cref="Invocation"/>.
        /// </summary>
        /// <param name="expression">The <see cref="InvocationExpression"/>.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Invocation"/>.</returns>
        public override Invocation Serialize(
            InvocationExpression expression,
            JsonSerializerOptions options)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new Invocation(expression)
            {
                Expression = Serializer.Serialize(expression.Expression, options),
            };

            foreach (var argument in expression.Arguments)
            {
                result.Arguments.Add(Serializer.Serialize(argument, options));
            }

            return result;
        }

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="json">The serialized fragment.</param>
        /// <param name="queryRoot">The query root to apply.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(
            JsonElement json,
            Expression queryRoot,
            JsonSerializerOptions options) => Deserialize(json, queryRoot, options);

        /// <summary>
        /// Implements <see cref="IBaseSerializer"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="options">The optional <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(
            Expression expression,
            JsonSerializerOptions options) =>
            Serialize(expression as InvocationExpression, options);
    }
}
