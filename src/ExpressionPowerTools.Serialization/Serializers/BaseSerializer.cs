// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Base class for serializers.
    /// </summary>
    /// <typeparam name="TExpression">The <see cref="Expression"/> supported by the serialize.</typeparam>
    /// <typeparam name="TSerializable">The serializer component it targets.</typeparam>
    public abstract class BaseSerializer<TExpression, TSerializable>
        : IExpressionSerializer<TExpression, TSerializable>
        where TExpression : Expression
        where TSerializable : SerializableExpression
    {
        /// <summary>
        /// Instance of the member adapter.
        /// </summary>
        private readonly Lazy<IMemberAdapter> memberAdapter =
            ServiceHost.GetLazyService<IMemberAdapter>();

        /// <summary>
        /// Instance of the anonymous type adapter.
        /// </summary>
        private readonly Lazy<IAnonymousTypeAdapter> anonTypeAdapter =
            ServiceHost.GetLazyService<IAnonymousTypeAdapter>();

        /// <summary>
        /// The <see cref="IRulesEngine"/> implementation.
        /// </summary>
        private readonly IRulesEngine rulesEngine = ServiceHost.GetService<IRulesEngine>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSerializer{T, TSerializable}"/> class with a default serializer.
        /// </summary>
        /// <param name="serializer">The default serializer.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when serializer is null.</exception>
        public BaseSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
        {
            Ensure.NotNull(() => serializer);
            Serializer = serializer;
        }

        /// <summary>
        /// Gets the default <see cref="IExpressionSerializer{T, TSerializable}"/>.
        /// </summary>
        protected IExpressionSerializer<Expression, SerializableExpression> Serializer { get; private set; }

        /// <summary>
        /// Deserialize a <see cref="JsonElement"/> to an <see cref="Expression"/>.
        /// </summary>
        /// <param name="json">The <see cref="JsonElement"/> to deserialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public abstract TExpression Deserialize(
            JsonElement json,
            SerializationState state);

        /// <summary>
        /// Serialize an <see cref="Expression"/> to a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State, such as <see cref="JsonSerializerOptions"/>, for the deserialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        public abstract TSerializable Serialize(TExpression expression, SerializationState state);

        /// <summary>
        /// Check the <see cref="MemberInfo"/> against the rules.
        /// </summary>
        /// <param name="members">The list of members to check.</param>
        /// <exception cref="UnauthorizedAccessException">Thrown when acccess is not allowed.</exception>
        protected void AuthorizeMembers(params MemberInfo[] members)
        {
            foreach (var member in members)
            {
                if (!rulesEngine.MemberIsAllowed(member))
                {
                    throw new UnauthorizedAccessException($"{member.DeclaringType}: {member}");
                }
            }
        }

        /// <summary>
        /// Gets the unique key for a member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The unique key.</returns>
        protected string GetKeyForMember(MemberInfo member) =>
            memberAdapter.Value.GetKeyForMember(member);

        /// <summary>
        /// Gets the member from a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The member info.</returns>
        protected MemberInfo GetMemberFromKey(string key) =>
            memberAdapter.Value.GetMemberForKey(key);

        /// <summary>
        /// Typed version of get member from a key.
        /// </summary>
        /// <typeparam name="TMemberInfo">The type of the member.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The member.</returns>
        protected TMemberInfo GetMemberFromKey<TMemberInfo>(string key)
            where TMemberInfo : MemberInfo =>
            GetMemberFromKey(key) as TMemberInfo;

        /// <summary>
        /// Convert from anonymous type to <see cref="AnonType"/>.
        /// </summary>
        /// <param name="anonymousType">The anonymous type.</param>
        /// <returns>The <see cref="AnonType"/> instance.</returns>
        protected AnonType ConvertAnonymousTypeToAnonType(object anonymousType)
            => anonTypeAdapter.Value.ConvertToAnonType(anonymousType);

        /// <summary>
        /// Convert from <see cref="AnonType"/> back to anonymous type instance.
        /// </summary>
        /// <param name="anonType">The <see cref="AnonType"/>.</param>
        /// <param name="options">Serializer options.</param>
        /// <returns>The anonymous object.</returns>
        protected object ConvertAnonTypeToAnonymousType(
            AnonType anonType,
            JsonSerializerOptions options)
            => anonTypeAdapter.Value.ConvertFromAnonType(
                anonType,
                options);
    }
}
