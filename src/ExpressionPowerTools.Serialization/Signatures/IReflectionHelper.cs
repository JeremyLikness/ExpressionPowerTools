// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Helper class to cache <see cref="Type"/> and <see cref="MemberInfo"/> information.
    /// </summary>
    public interface IReflectionHelper
    {
        /// <summary>
        /// Gets the <see cref="BindingFlags"/> for public instance or static.
        /// </summary>
        BindingFlags AllPublic { get; }

        /// <summary>
        /// Finds the generic counterpart of a <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> to check.</param>
        /// <param name="genericType">The generic <see cref="Type"/>.</param>
        /// <returns>The correleated member.</returns>
        MemberInfo FindGenericVersion(MemberInfo member, Type genericType = null);
    }
}
