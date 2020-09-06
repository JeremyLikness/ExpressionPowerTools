// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Reflection;

namespace ExpressionPowerTools.Serialization.Rules
{
    /// <summary>
    /// Helps with selection of a <see cref="MemberInfo"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="MemberInfo"/>.</typeparam>
    public class MemberSelector<T>
        where T : MemberInfo
    {
        /// <summary>
        /// Gets or sets the <see cref="MemberInfo"/>.
        /// </summary>
        public T[] Member { get; set; }
    }
}
