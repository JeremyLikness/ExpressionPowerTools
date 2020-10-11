// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
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
        /// <param name="template">The template for handling types.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The <see cref="MemberExpression"/>.</returns>
        public override MemberExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            Expression expr = null;
            if (json.TryGetProperty(
                nameof(MemberExpr.Expression),
                out JsonElement jsonObj))
            {
                expr = Serializer.Deserialize(jsonObj, state, Default);
            }

            var member = template as MemberExpr;
            var memberInfo = GetMemberFromKey(member.MemberTypeKey);

            if (json.TryGetProperty(nameof(MemberExpr.Indexer), out JsonElement indexer))
            {
                if (!string.IsNullOrWhiteSpace(indexer.GetString()))
                {
                    return null;
                }
            }

            AuthorizeMembers(new[] { memberInfo });

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
    }
}
