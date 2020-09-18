// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Core.Extensions;
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
        /// <param name="json">The <see cref="JsonElement"/> to deserialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="NewExpression"/>.</returns>
        public override NewExpression Deserialize(
            JsonElement json,
            SerializationState state)
        {
            var ctorDescriptor = json.GetProperty(nameof(CtorExpr.CtorInfo)).GetString();

            var ctor = GetMemberFromKey<ConstructorInfo>(ctorDescriptor);

            var members = new List<MemberInfo>();

            if (json.TryGetProperty(
                nameof(CtorExpr.MemberKeys),
                out JsonElement memberList))
            {
                members = memberList.EnumerateArray()
                    .Select(memberJson => memberJson.GetString())
                    .Select(memberKey => GetMemberFromKey(memberKey))
                    .ToList();
            }

            var args = new List<Expression>();

            if (json.TryGetProperty(
                nameof(CtorExpr.Arguments),
                out JsonElement arguments))
            {
                foreach (var argElem in arguments.EnumerateArray())
                {
                    var arg = Serializer.Deserialize(argElem, state);
                    args.Add(arg);
                }
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
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The serializable <see cref="CtorExpr"/>.</returns>
        public override CtorExpr Serialize(
            NewExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            if (expression.Type.IsAnonymousType())
            {
                // rebuild expression to use anonymous type helpers
                var ctor = typeof(AnonInitializer).GetConstructors()
                    .First(c => c.GetParameters().Length == 3);
                var valueCtor = typeof(AnonValue).GetConstructors()
                    .First(c => c.GetParameters().Length == 2);
                var name = Expression.Constant(expression.Type.FullName);
                var properties = expression.Type.GetProperties()
                    .Select(p => p.Name.AsConstantExpression())
                    .ToArray();
                var initProperties = Expression.NewArrayInit(typeof(string), properties);
                var initValues = expression.Arguments.Select(
                    a => Expression.New(
                        valueCtor,
                        new Expression[] { a.Type.AsConstantExpression(), Expression.Convert(a, typeof(object)) }));
                var initExpr = Expression.NewArrayInit(typeof(AnonValue), initValues);
                var newArgs = new Expression[] { name, initProperties, initExpr };
                expression = Expression.New(ctor, newArgs);
            }

            var ctorExpr = new CtorExpr(expression)
            {
                Arguments = expression.Arguments
                    .Select(a => Serializer.Serialize(a, state))
                    .OfType<object>()
                    .ToList(),
            };

            return ctorExpr;
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
            Serialize(expression as NewExpression, state);
    }
}
