// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
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
            var ctor = json.GetProperty(nameof(CtorExpr.CtorInfo))
                .GetSerializedCtor(state);

            var parms = ctor.Parameters;
            ctor.Parameters = parms.Select(
                p => new { p.Key, Value = state.DecompressType(p.Value) })
                .ToDictionary(p => p.Key, p => p.Value);

            var members = new List<MemberInfo>();

            var properties = new List<Property>();

            if (json.TryGetProperty(
                nameof(CtorExpr.Properties),
                out JsonElement propertyList))
            {
                foreach (var propertyElem in propertyList.EnumerateArray())
                {
                    var prop = propertyElem.GetSerializedProperty(state);
                    properties.Add(prop);
                }
            }

            var fields = new List<Field>();

            if (json.TryGetProperty(
                nameof(CtorExpr.Fields),
                out JsonElement fieldList))
            {
                foreach (var fieldElem in fieldList.EnumerateArray())
                {
                    var prop = fieldElem.GetSerializedField(state);
                    fields.Add(prop);
                }
            }

            if (json.TryGetProperty(
                nameof(CtorExpr.MemberTypeList),
                out JsonElement jsonObj))
            {
                int pIdx = 0, fIdx = 0;
                foreach (var memberElem in jsonObj.EnumerateArray())
                {
                    var memberType = (MemberTypes)memberElem
                        .GetInt32();
                    if (memberType == MemberTypes.Property)
                    {
                        var propInfo = GetMemberInfo<PropertyInfo, Property>(properties[pIdx++]);
                        members.Add(propInfo);
                    }
                    else if (memberType == MemberTypes.Field)
                    {
                        var fieldInfo = GetMemberInfo<FieldInfo, Field>(fields[fIdx++]);
                        members.Add(fieldInfo);
                    }
                }
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

            var ctorInfo = GetMemberInfo<ConstructorInfo, Ctor>(ctor);
            if (ctorInfo == null)
            {
                return null;
            }

            AuthorizeMembers(ctorInfo);

            if (args.Count == 0)
            {
                return Expression.New(ctorInfo);
            }

            if (members.Count == 0)
            {
                return Expression.New(ctorInfo, args);
            }

            return Expression.New(ctorInfo, args, members);
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

            var ctorExpr = new CtorExpr(expression)
            {
                Arguments = expression.Arguments
                    .Select(a => Serializer.Serialize(a, state))
                    .OfType<object>()
                    .ToList(),
            };

            state.CompressMemberTypes(ctorExpr.CtorInfo);

            var parms = ctorExpr.CtorInfo.Parameters;
            ctorExpr.CtorInfo.Parameters = parms.Select(
                p => new { p.Key, Value = state.CompressType(p.Value) })
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var member in ctorExpr.Properties)
            {
                state.CompressMemberTypes(member);
            }

            foreach (var member in ctorExpr.Fields)
            {
                state.CompressMemberTypes(member);
            }

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
