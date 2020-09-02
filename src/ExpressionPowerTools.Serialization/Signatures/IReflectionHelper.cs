// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;
using System.Text;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Helper class to cache <see cref="Type"/> and <see cref="MemberInfo"/> information.
    /// </summary>
    public interface IReflectionHelper
    {
        /// <summary>
        /// Deserializes a <see cref="Type"/>.
        /// </summary>
        /// <param name="serializedType">The serialized <see cref="Type"/>.</param>
        /// <returns>The deserialized <see cref="Type"/>.</returns>
        Type DeserializeType(SerializableType serializedType);

        /// <summary>
        /// Gets the full type name of the serialized type.
        /// </summary>
        /// <param name="serializedType">The <see cref="SerializableType"/>.</param>
        /// <param name="builder">A <see cref="StringBuilder"/>.</param>
        /// <param name="level">The recurision level.</param>
        /// <returns>The full type name.</returns>
        string GetFullTypeName(SerializableType serializedType, StringBuilder builder = null, int level = 0);

        /// <summary>
        /// Gets the specified member. Will add to cache if not found.
        /// </summary>
        /// <typeparam name="TMemberInfo">The type of the item to retrieve.</typeparam>
        /// <typeparam name="TMemberBase">The type of the member base.</typeparam>
        /// <param name="member">The key for the item.</param>
        /// <returns>The cached item.</returns>
        TMemberInfo GetMemberFromCache<TMemberInfo, TMemberBase>(TMemberBase member)
            where TMemberInfo : MemberInfo
            where TMemberBase : MemberBase;

        /// <summary>
        /// Get a <see cref="Type"/> based on full name.
        /// </summary>
        /// <remarks>
        /// This will check the cache first, then try to create the type, and
        /// finally will scan all assemblies for the type.
        /// </remarks>
        /// <param name="name">The full name of the <see cref="Type"/>.</param>
        /// <returns>The <see cref="Type"/> or <c>null</c>.</returns>
        Type GetTypeFromCache(string name);

        /// <summary>
        /// Pre-register types to the cache to improve discoverability.
        /// </summary>
        /// <param name="typeList">The <see cref="Type"/> list to register.</param>
        void RegisterTypes(params Type[] typeList);

        /// <summary>
        /// Creates a serializable type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to serialize.</param>
        /// <returns>The <see cref="SerializableType"/>.</returns>
        SerializableType SerializeType(Type type);
    }
}
