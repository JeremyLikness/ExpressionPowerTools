// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;
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
        /// <param name="member">The <see cref="MemberExpr"/> to deserialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="MemberExpression"/>.</returns>
        public override MemberExpression Deserialize(
            MemberExpr member,
            SerializationState state)
        {
            Expression expr = null;
            if (member.Expression != null)
            {
                expr = Serializer.Deserialize(member.Expression, state);
            }

            var memberInfo = GetMemberFromKey(member.MemberTypeKey);

            if (!string.IsNullOrWhiteSpace(member.Indexer))
            {
                return null;
            }

            AuthorizeMembers(new[] { memberInfo });

            return Expression.MakeMemberAccess(expr, memberInfo);
        }

        /// <summary>
        /// Serialize a <see cref="MemberExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MemberExpression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
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
