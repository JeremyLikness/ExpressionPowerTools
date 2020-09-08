// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Represents a rule to allow or disallow a serialization.
    /// </summary>
    /// <remarks>
    /// The default for all methods is to not allow. The default configuration
    /// adds a set of rules for basic query functionality including
    /// <see cref="Enumerable"/> and <see cref="Queryable"/>. An allow allows the
    /// full hierarchy of types. A disallow prohibits the full hierarchy. These
    /// can then be overridden.
    /// </remarks>
    public interface ISerializationRule
    {
        /// <summary>
        /// Gets a value indicating whether the rule is an allow.
        /// </summary>
        bool Allow { get; }

        /// <summary>
        /// Gets the target for the rule.
        /// </summary>
        MemberInfo Target { get; }

        /// <summary>
        /// Gets the member type for the rule.
        /// </summary>
        MemberTypes MemberType { get; }

        /// <summary>
        /// Gets the unique key for the rule.
        /// </summary>
        string TargetKey { get; }
    }
}
