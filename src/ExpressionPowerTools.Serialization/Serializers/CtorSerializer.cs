// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serialization services for <see cref="NewExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.New)]
    public class CtorSerializer :
        BaseSerializer<NewExpression, CtorExpr>,
        IBaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtorSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public CtorSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a <see cref="CtorExpr"/> to a <see cref="NewExpression"/>.
        /// </summary>
        /// <param name="ctorExpr">The <see cref="JsonElement"/> to deserialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="NewExpression"/>.</returns>
        public override NewExpression Deserialize(
            CtorExpr ctorExpr,
            SerializationState state)
        {
            var ctor = GetMemberFromKey<ConstructorInfo>(ctorExpr.CtorInfo);

            var members = new List<MemberInfo>();

            if (ctorExpr.MemberKeys != null)
            {
                members = ctorExpr.MemberKeys
                    .Select(memberKey => GetMemberFromKey(memberKey))
                    .ToList();
            }

            var args = new List<Expression>();

            foreach (var argElem in ctorExpr.Arguments)
            {
                var arg = Serializer.Deserialize(argElem, state);
                args.Add(arg);
            }

            AuthorizeMembers(ctor);

            if (args.Count == 0)
            {
                return Expression.New(ctor);
            }

            if (members.Count == 0)
            {
                return Expression.New(ctor, args);
            }

            return Expression.New(ctor, args, members);
        }

        /// <summary>
        /// Serialize a <see cref="NewExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewExpression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The serializable <see cref="CtorExpr"/>.</returns>
        public override CtorExpr Serialize(
            NewExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var ctorExpr = new CtorExpr(expression)
            {
                Arguments = expression.Arguments
                    .Select(a => Serializer.Serialize(a, state))
                    .OfType<SerializableExpression>()
                    .ToList(),
            };

            return ctorExpr;
        }
    }
}
