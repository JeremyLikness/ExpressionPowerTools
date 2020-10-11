// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serialization services for <see cref="MemberExpression"/>.
    /// </summary>
    [ExpressionSerializer(ExpressionType.MemberInit)]
    public class MemberInitSerializer :
        BaseSerializer<MemberInitExpression, MemberInit>,
        IBaseSerializer
    {
        /// <summary>
        /// Types compressor service.
        /// </summary>
        private readonly Lazy<ITypesCompressor> typesCompressor =
            ServiceHost.GetLazyService<ITypesCompressor>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberInitSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The base serializer.</param>
        public MemberInitSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Deserialize a <see cref="MemberInit"/> to a <see cref="MemberInitExpression"/>.
        /// </summary>
        /// <param name="json">The <see cref="JsonElement"/> to deserialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <param name="template">The template for working with types.</param>
        /// <param name="expressionType">The type of the expression.</param>
        /// <returns>The <see cref="MemberInitExpression"/>.</returns>
        public override MemberInitExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            NewExpression expr = null;
            if (json.TryGetProperty(
                nameof(MemberInit.NewExpression),
                out JsonElement jsonObj))
            {
                expr = Serializer.Deserialize(jsonObj, state, ExpressionType.New) as NewExpression;
            }

            var bindings = json.GetProperty(nameof(MemberInit.Bindings)).EnumerateArray();
            var memberBindings = DeserializeBindings(bindings, state);
            return Expression.MemberInit(expr, memberBindings.ToArray());
        }

        /// <summary>
        /// Serialize a <see cref="MemberInitExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MemberInitExpression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the serialization.</param>
        /// <returns>The serializable <see cref="MemberInit"/>.</returns>
        public override MemberInit Serialize(
            MemberInitExpression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            var memberInit = new MemberInit(expression)
            {
                NewExpression = Serializer.Serialize(expression.NewExpression, state),
            };
            memberInit.Bindings.AddRange(SerializeBindings(expression.Bindings, state));
            return memberInit;
        }

        /// <summary>
        /// Deserialize the list of <see cref="MemberBinding"/>.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        /// <returns>The list of member bindings.</returns>
        private IEnumerable<MemberBinding> DeserializeBindings(
            IEnumerable<JsonElement> list, SerializationState state)
        {
            var result = new List<MemberBinding>();
            foreach (var element in list)
            {
                var type = (MemberBindingType)element
                    .GetProperty(nameof(MemberBinding.BindingType))
                    .GetInt32();

                switch (type)
                {
                    case MemberBindingType.Assignment:
                        result.Add(DeserializeAssignment(element, state));
                        break;
                    case MemberBindingType.MemberBinding:
                        result.Add(DeserializeMember(element, state));
                        break;
                    case MemberBindingType.ListBinding:
                        result.Add(DeserializeList(element, state));
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Deserializes a list.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        /// <returns>The <see cref="MemberListBinding"/>.</returns>
        private MemberBinding DeserializeList(
            JsonElement element,
            SerializationState state)
        {
            var member = GetMemberFromKey(
                element.GetProperty(nameof(MemberBindingList.MemberKey))
                .GetString());
            var auth = new List<MemberInfo>
            {
                member,
            };
            var initializers = new List<ElementInit>();
            foreach (var init in
                element.GetProperty(
                    nameof(MemberBindingList.Initializers))
                .EnumerateArray())
            {
                var addMethodKey = init.GetProperty(nameof(MemberBindingInitializer.AddMethodKey))
                    .GetString();
                typesCompressor.Value.DecompressTypes(
                    state.TypeIndex,
                    (addMethodKey, newKey => addMethodKey = newKey));
                var addMethod = GetMemberFromKey<MethodInfo>(addMethodKey);
                auth.Add(addMethod);
                initializers.Add(Expression.ElementInit(
                    addMethod,
                    init.GetProperty(nameof(MemberBindingInitializer.Arguments))
                    .EnumerateArray().Select(json => Serializer.Deserialize(json, state, Default))
                    .ToArray()));
            }

            AuthorizeMembers(auth.ToArray());

            return Expression.ListBind(member, initializers);
        }

        /// <summary>
        /// Deserializes a member binding.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <param name="state">The <seealso cref="SerializationState"/>.</param>
        /// <returns>The <see cref="MemberMemberBinding"/>.</returns>
        private MemberBinding DeserializeMember(
            JsonElement element,
            SerializationState state)
        {
            var memberKey = element.GetProperty(
                nameof(MemberBindingMember.MemberKey)).GetString();
            typesCompressor.Value.DecompressTypes(
                state.TypeIndex,
                (memberKey, newKey => memberKey = newKey));
            var member = GetMemberFromKey(memberKey);

            AuthorizeMembers(member);

            var bindings = DeserializeBindings(
                element.GetProperty(nameof(MemberBindingMember.Bindings))
                .EnumerateArray(), state).ToArray();
            return Expression.MemberBind(member, bindings);
        }

        /// <summary>
        /// Deserializes an assignment.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        /// <returns>The <see cref="MemberAssignment"/>.</returns>
        private MemberBinding DeserializeAssignment(JsonElement element, SerializationState state)
        {
            var key = element.GetProperty(
                nameof(MemberBindingAssignment.MemberInfoKey)).GetString();
            typesCompressor.Value.DecompressTypes(
                state.TypeIndex,
                (key, newKey => key = newKey));
            var member = GetMemberFromKey(key);

            AuthorizeMembers(member);

            var expression = Serializer.Deserialize(
                element.GetProperty(nameof(MemberBindingAssignment.Expression)),
                state,
                Default);
            return Expression.Bind(member, expression);
        }

        /// <summary>
        /// Recurse the bindings for serialization.
        /// </summary>
        /// <param name="list">The list of <see cref="MemberBinding"/>.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        /// <returns>The list of serialized bindings.</returns>
        private IEnumerable<object> SerializeBindings(IEnumerable<MemberBinding> list, SerializationState state)
        {
            var result = new List<object>();
            foreach (var binding in list)
            {
                switch (binding)
                {
                    case MemberAssignment assignment:
                        var serializableBinding = new MemberBindingAssignment
                        {
                            Expression =
                            Serializer.Serialize(assignment.Expression, state),
                            MemberInfoKey = GetKeyForMember(assignment.Member),
                        };
                        typesCompressor.Value.CompressTypes(
                            state.TypeIndex,
                            (serializableBinding.MemberInfoKey, key => serializableBinding.MemberInfoKey = key));
                        result.Add(serializableBinding);
                        break;

                    case MemberMemberBinding memberBinding:
                        var memberBindingSerializable = new MemberBindingMember
                        {
                            MemberKey = GetKeyForMember(memberBinding.Member),
                        };
                        typesCompressor.Value.CompressTypes(
                            state.TypeIndex,
                            (memberBindingSerializable.MemberKey, key => memberBindingSerializable.MemberKey = key));
                        memberBindingSerializable.Bindings.AddRange(
                            SerializeBindings(memberBinding.Bindings, state));
                        result.Add(memberBindingSerializable);
                        break;

                    case MemberListBinding listBinding:
                        var memberListSerializable = new MemberBindingList
                        {
                            MemberKey =
                            GetKeyForMember(listBinding.Member),
                        };
                        foreach (var initializer in listBinding.Initializers)
                        {
                            var init = new MemberBindingInitializer
                            {
                                AddMethodKey = GetKeyForMember(initializer.AddMethod),
                            };
                            foreach (var argument in initializer.Arguments)
                            {
                                init.Arguments.Add(Serializer.Serialize(argument, state));
                            }

                            memberListSerializable.Initializers.Add(init);
                        }

                        result.Add(memberListSerializable);
                        break;
                }
            }

            return result;
        }
    }
}
