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
    /// Serialization services for <see cref="MemberExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.MemberAccess)]
    public class MemberSerializer :
        BaseSerializer<MemberExpression, MemberExpr>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public MemberSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a <see cref="MemberExpr"/> to a <see cref="MemberExpression"/>.
        /// </summary>
        /// <param name="json">The <see cref="JsonElement"/> to deserialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="MemberExpression"/>.</returns>
        public override MemberExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            Expression expr = null;
            if (json.TryGetProperty(
                nameof(MemberExpr.Expression),
                out JsonElement jsonObj))
            {
                expr = Serializer.Deserialize(jsonObj, state);
            }

            var membertype = json.GetProperty(nameof(MemberExpr.MemberType)).GetString();

            MemberInfo memberInfo = null;

            if (membertype == MemberTypes.Property.ToString())
            {
                var property = json.GetProperty(nameof(MemberExpr.PropertyInfo))
                    .GetSerializedProperty();
                memberInfo = GetMemberInfo<PropertyInfo, Property>(property);
            }
            else if (membertype == MemberTypes.Field.ToString())
            {
                var field = json.GetProperty(nameof(MemberExpr.FieldInfo))
                    .GetSerializedField();
                memberInfo = GetMemberInfo<FieldInfo, Field>(field);
            }

            return Expression.MakeMemberAccess(expr, memberInfo);
        }

        /// <summary>
        /// Serialize a <see cref="MemberExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MemberExpression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The serializable <see cref="MemberExpr"/>.</returns>
        public override MemberExpr Serialize(
            MemberExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var member = new MemberExpr(expression)
            {
                Expression = Serializer.Serialize(expression.Expression, state),
            };

            return member;
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
            Serialize(expression as MemberExpression, state);
    }
}
