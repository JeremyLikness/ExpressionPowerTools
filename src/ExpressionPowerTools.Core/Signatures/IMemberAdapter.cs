// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Adapter to convert members to text and vice versa. Uses the XML comments algorithm.
    /// </summary>
    public interface IMemberAdapter
    {
        /// <summary>
        /// Primarily for testing. Clears the cache.
        /// </summary>
        void Reset();

        /// <summary>
        /// Makes an anonymous type.
        /// </summary>
        /// <param name="types">The type list to use.</param>
        /// <returns>The anonymous type.</returns>
        Type MakeAnonymousType((string prop, Type propType)[] types);

        /// <summary>
        /// Gets a unique string that identifies the member.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> to parse.</param>
        /// <returns>the unique string.</returns>
        string GetKeyForMember(MemberInfo member);

        /// <summary>
        /// Uses the key to build the proper <see cref="MemberInfo"/> reference.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The <see cref="MemberInfo"/>.</returns>
        MemberInfo GetMemberForKey(string key);

        /// <summary>
        /// Translate key to specific type.
        /// </summary>
        /// <typeparam name="TMemberInfo">The type of <see cref="MemberInfo"/> to build.</typeparam>
        /// <param name="key">The key to use.</param>
        /// <returns>The <see cref="MemberInfo"/>.</returns>
        TMemberInfo GetMemberForKey<TMemberInfo>(string key)
            where TMemberInfo : MemberInfo;

        /// <summary>
        /// Counts closed generics to provide a good type name.
        /// </summary>
        /// <param name="key">The key to parse.</param>
        /// <returns>The generics count.</returns>
        int ClosedGenericsCount(string key);
    }
}
