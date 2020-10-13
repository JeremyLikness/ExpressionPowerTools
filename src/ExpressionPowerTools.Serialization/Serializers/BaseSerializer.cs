// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        : IExpressionSerializer<TExpression, TSerializable>, IBaseSerializer
        where TExpression : Expression
        where TSerializable : SerializableExpression, new()
    {
        /// <summary>
        /// Cache to hold key references for compression/decompression.
        /// </summary>
        private static readonly List<KeyCacheEntry> KeyCache = null;

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
        /// Initializes static members of the <see cref="BaseSerializer{TExpression, TSerializable}"/> class.
        /// Captures the key delegates for compression.
        /// </summary>
        static BaseSerializer()
        {
            KeyCache = new List<KeyCacheEntry>();
            var props = typeof(TSerializable).GetProperties()
                .Where(p => p.CustomAttributes.Any(
                    c => c.AttributeType == typeof(CompressableKeyAttribute)));
            foreach (var prop in props)
            {
                if (typeof(ICollection<string>).IsAssignableFrom(prop.PropertyType))
                {
                    string[] GetList(TSerializable obj) => (prop.GetValue(obj) as ICollection<string>).ToArray();
                    void SetList(TSerializable obj, string[] key)
                    {
                        var collection = prop.GetValue(obj) as ICollection<string>;
                        collection.Clear();
                        foreach (var transformedKey in key)
                        {
                            collection.Add(transformedKey);
                        }
                    }

                    KeyCache.Add(new KeyCacheEntry
                    {
                        PropName = prop.Name,
                        IsCollection = true,
                        GetKeys = GetList,
                        SetKeys = SetList,
                    });
                }
                else
                {
                    string[] Getter(TSerializable obj) => new[] { prop.GetValue(obj) as string };
                    void Setter(TSerializable obj, string[] key) => prop.SetValue(obj, key[0]);
                    KeyCache.Add(
                        new KeyCacheEntry
                        {
                            PropName = prop.Name,
                            IsCollection = false,
                            GetKeys = Getter,
                            SetKeys = Setter,
                        });
                }
            }
        }

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
        /// Deserialize a <see cref="SerializableExpression"/> to an <see cref="Expression"/>.
        /// </summary>
        /// <param name="root">The <see cref="SerializableExpression"/> to deserialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public abstract TExpression Deserialize(
            TSerializable root,
            SerializationState state);

        /// <summary>
        /// Serialize an <see cref="Expression"/> to a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        public abstract TSerializable Serialize(TExpression expression, SerializationState state);

        /// <summary>
        /// Serialize to a <see cref="SerializableExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State for the serialization.</param>
        /// <returns>The <see cref="SerializableExpression"/>.</returns>
        SerializableExpression IBaseSerializer.Serialize(Expression expression, SerializationState state)
            => Serialize(expression as TExpression, state);

        /// <summary>
        /// Compress the types on the serializable class.
        /// </summary>
        /// <param name="serializable">The serializable entity.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        public void CompressTypes(
            SerializableExpression serializable,
            SerializationState state)
        {
            if (KeyCache.Count < 1)
            {
                return;
            }

            var expression = (TSerializable)serializable;

            // single props
            var parameters = KeyCache
                .Where(entry => !entry.IsCollection)
                .Select(
                    cache =>
                        (cache.GetKeys(expression)[0],
                        (Action<string>)(
                            s => cache.SetKeys(expression, new[] { s }))))
                .ToArray();

            state.CompressTypesForKeys(parameters);

            // lists
            foreach (var parameter in KeyCache.Where(entry => entry.IsCollection))
            {
                var keys = parameter.GetKeys(expression).Select(
                    k => state.CompressTypesforKey(k)).ToArray();
                parameter.SetKeys(expression, keys);
            }
        }

        /// <summary>
        /// Explicit implementation.
        /// </summary>
        /// <param name="root">The root expression.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        Expression IBaseSerializer.Deserialize(SerializableExpression root, SerializationState state) =>
            Deserialize((TSerializable)root, state);

        /// <summary>
        /// Compress the types on the expression.
        /// </summary>
        /// <param name="serializable">The <see cref="SerializableExpression"/>.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        void IBaseSerializer.CompressTypes(SerializableExpression serializable, SerializationState state) =>
            CompressTypes((TSerializable)serializable, state);

        /// <summary>
        /// Decompress the types on the expression.
        /// </summary>
        /// <param name="serializable">The <see cref="SerializableExpression"/>.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        void IBaseSerializer.DecompressTypes(SerializableExpression serializable, SerializationState state) =>
            DecompressTypes((TSerializable)serializable, state);

        /// <summary>
        /// Creates a template of the serializable type with keys decompressed.
        /// </summary>
        /// <param name="expression">The <see cref="SerializableExpression"/>.</param>
        /// <param name="state">The <see cref="SerializationState"/>.</param>
        /// <returns>The <see cref="SerializableExpression"/> instance.</returns>
        protected TSerializable DecompressTypes(
            TSerializable expression,
            SerializationState state)
        {
            // single props
            var parameters = KeyCache
                .Where(entry => !entry.IsCollection)
                .Select(
                    cache =>
                        (cache.GetKeys(expression)[0],
                        (Action<string>)(
                            s => cache.SetKeys(expression, new[] { s }))))
                .ToArray();

            state.DecompressTypesForKeys(parameters);

            // lists
            foreach (var parameter in KeyCache.Where(entry => entry.IsCollection))
            {
                var keys = parameter.GetKeys(expression).Select(
                    k => state.DecompressTypesForKey(k)).ToArray();
                parameter.SetKeys(expression, keys);
            }

            return expression;
        }

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
        /// <returns>The anonymous object.</returns>
        protected object ConvertAnonTypeToAnonymousType(
            AnonType anonType)
            => anonTypeAdapter.Value.ConvertFromAnonType(anonType);

        /// <summary>
        /// Entry for accessing properties to compress/decompress.
        /// </summary>
        internal struct KeyCacheEntry
        {
            public string PropName;
            public bool IsCollection;
            public Func<TSerializable, string[]> GetKeys;
            public Action<TSerializable, string[]> SetKeys;
        }
    }
}
