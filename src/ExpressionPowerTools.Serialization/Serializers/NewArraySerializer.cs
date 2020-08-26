// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

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
        /// <returns>The <see cref="NewArrayExpression"/>.</returns>
        public override NewArrayExpression Deserialize(JsonElement json)
        {
            var type = json.GetProperty(nameof(NewArray.ArrayType)).GetString();
            var materializedType = ReflectionHelper.Instance.GetTypeFromCache(type);
            var list = json.GetProperty(nameof(NewArray.Expressions));
            var expressionList = list.EnumerateArray().Select(element => Serializer.Deserialize(element)).ToList();
            return Expression.NewArrayInit(materializedType, expressionList);
        }

        /// <summary>
        /// Serialize a <see cref="NewArrayExpression"/> to a <see cref="NewArray"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewArrayExpression"/>.</param>
        /// <returns>The <see cref="NewArray"/>.</returns>
        public override NewArray Serialize(NewArrayExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var result = new NewArray(expression);
            foreach (var child in expression.Expressions)
            {
                result.Expressions.Add(Serializer.Serialize(child));
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
            Serialize(expression as NewArrayExpression);
    }
}
