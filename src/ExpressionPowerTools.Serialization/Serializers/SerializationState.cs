// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// State info passed recurisvely through the serialization process.
    /// </summary>
    public class SerializationState
    {
        /// <summary>
        /// Designator for a compressed type.
        /// </summary>
        private const string CompressedType = "^";

        /// <summary>
        /// The comparer to use for types.
        /// </summary>
        private readonly IEqualityComparer<SerializableType> typeComparer =
            new SerializableTypeComparer();

        /// <summary>
        /// The <see cref="IReflectionHelper"/> instance.
        /// </summary>
        private readonly IReflectionHelper reflectionHelper =
            ServiceHost.GetService<IReflectionHelper>();

        /// <summary>
        /// List of parameters to preserve across stack.
        /// </summary>
        private HashSet<ParameterExpression> parameters;

        /// <summary>
        /// A value that indicates whether the type index has been recursively decompressed.
        /// </summary>
        private bool decompressedTypes;

        /// <summary>
        /// A value that indicates whether the type index is being decompressed.
        /// </summary>
        private bool decompressingTypes;

        /// <summary>
        /// Gets or sets the query root to build the query from.
        /// </summary>
        public Expression QueryRoot { get; set; }

        /// <summary>
        /// Gets or sets the optional <see cref="JsonSerializerOptions"/>.
        /// </summary>
        public JsonSerializerOptions Options { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not types are compressed. Default is <c>true</c>.
        /// </summary>
        /// <remarks>
        /// When this flag is set, instead of serializing long types, each type is indexed in a master
        /// "type index" the first time it is encountered. Subsequent references will use <c>^x</c>
        /// where <c>x</c> is the index of the type. Set this to <c>false</c> if you need to debug the
        /// serialization payload. This flag is ignored during deserialization as compressed types are
        /// automatically detected and decompressed when present.
        /// </remarks>
        public bool CompressTypes { get; set; }

        /// <summary>
        /// Gets or sets the index of types.
        /// </summary>
        /// <remarks>
        /// This table is used to build a master index of types. For example, if <see cref="string"/> is
        /// referenced multiple times, the intial entry may be <c>System.String</c> and subsequent entries
        /// will reference <c>^0</c>.
        /// </remarks>
        public List<SerializableType> TypeIndex { get; set; } = new List<SerializableType>();

        /// <summary>
        /// Decompress the types on a <see cref="MemberBase"/>.
        /// </summary>
        /// <param name="member">The <see cref="MemberBase"/> to decompress.</param>
        public void DecompressMemberTypes(MemberBase member)
        {
            member.DeclaringType = DecompressType(member.DeclaringType);
            member.MemberValueType = DecompressType(member.MemberValueType);
            member.ReflectedType = DecompressType(member.ReflectedType);
        }

        /// <summary>
        /// Decompresses a type.
        /// </summary>
        /// <param name="type">The <see cref="SerializableType"/> to inspect.</param>
        /// <returns>The decompressed type.</returns>
        public SerializableType DecompressType(SerializableType type)
        {
            if (!decompressedTypes)
            {
                decompressedTypes = true;
                decompressingTypes = true;
                var typeIdx = TypeIndex.ToArray();
                var newIdx = new List<SerializableType>();
                foreach (var idxType in typeIdx)
                {
                    var args = new SerializableType[0];
                    if (idxType.GenericTypeArguments?.Length > 0)
                    {
                        args = idxType.GenericTypeArguments.Select(
                            t => DecompressType(t)).ToArray();
                    }

                    var newType = default(SerializableType);
                    newType.FullTypeName = idxType.FullTypeName;
                    newType.TypeName = idxType.TypeName;
                    newType.TypeParamName = idxType.TypeParamName;
                    newType.GenericTypeArguments = args;
                    newIdx.Add(newType);
                }

                TypeIndex.Clear();
                TypeIndex.AddRange(newIdx);
                decompressingTypes = false;
            }

            if (!string.IsNullOrWhiteSpace(type.TypeName) &&
                type.TypeName.StartsWith(CompressedType))
            {
                type = TypeIndex[int.Parse(type.TypeName.Substring(1))];

                if (decompressingTypes && type.GenericTypeArguments?.Length > 0)
                {
                    var args = type.GenericTypeArguments.Select(arg => DecompressType(arg))
                        .ToArray();
                    type.GenericTypeArguments = args;
                }
            }

            return type;
        }

        /// <summary>
        /// Gets a type from the cache.
        /// </summary>
        /// <param name="type">The <see cref="SerializableType"/> to cache or retrieve.</param>
        /// <returns>The full type for an indexed type, or an indexed type for a full type.</returns>
        public Type GetType(SerializableType type) =>
            reflectionHelper.DeserializeType(
                DecompressType(type));

        /// <summary>
        /// Compresses a type to avoid repetition in the serialization payload.
        /// </summary>
        /// <param name="type">The <see cref="SerializableType"/>.</param>
        /// <returns>The indexed <see cref="SerializableType"/>.</returns>
        public SerializableType CompressType(SerializableType type)
        {
            if (!CompressTypes)
            {
                return type;
            }

            if (string.IsNullOrWhiteSpace(type.FullTypeName))
            {
                type.FullTypeName = reflectionHelper.GetFullTypeName(type);
            }

            if (!TypeIndex.Contains(type, typeComparer))
            {
                TypeIndex.Add(type);
                var idx = TypeIndex.IndexOfType(type);

                // compress sub-types
                if (type.GenericTypeArguments?.Length > 0)
                {
                    type.GenericTypeArguments = type.GenericTypeArguments
                        .Select(t => CompressType(t)).ToArray();
                }

                TypeIndex[idx] = type;
            }

            return GetIndexedType(type);
        }

        /// <summary>
        /// Compresses a type to avoid repetition in the serialization payload.
        /// </summary>
        /// <param name="type">The <see cref="Type"/>.</param>
        /// <returns>The indexed <see cref="SerializableType"/>.</returns>
        public SerializableType CompressType(Type type)
        {
            return CompressType(reflectionHelper.SerializeType(type));
        }

        /// <summary>
        /// Compresses the types on a <see cref="MemberBase"/>.
        /// </summary>
        /// <param name="member">The <see cref="MemberBase"/>.</param>
        public void CompressMemberTypes(MemberBase member)
        {
            member.DeclaringType = CompressType(member.DeclaringType);
            member.MemberValueType = CompressType(member.MemberValueType);
            member.ReflectedType = CompressType(member.ReflectedType);
        }

        /// <summary>
        /// Retrieves a <see cref="ParameterExpression"/> of the same type
        /// and name from cache, or inserts the new <see cref="ParameterExpression"/>.
        /// </summary>
        /// <param name="expr">The <see cref="ParameterExpression"/> to parse.</param>
        /// <returns>The <see cref="ParameterExpression"/> or its cached version.</returns>
        public ParameterExpression GetOrCacheParameter(ParameterExpression expr)
        {
            parameters = parameters ?? new HashSet<ParameterExpression>();
            var cachedExpression = parameters
                .SingleOrDefault(
                p => p.Name == expr.Name &&
                p.Type == expr.Type);
            if (cachedExpression != null)
            {
                return cachedExpression;
            }

            parameters.Add(expr);
            return expr;
        }

        /// <summary>
        /// Gets the indexed type.
        /// </summary>
        /// <param name="type">The <see cref="SerializableType"/> to reference.</param>
        /// <returns>The indexed type.</returns>
        private SerializableType GetIndexedType(SerializableType type) =>
            new SerializableType
            {
                TypeName = $"{CompressedType}{TypeIndex.IndexOfType(type)}",
            };
    }
}
