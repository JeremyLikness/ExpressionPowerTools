// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Reflection;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// The rules engine.
    /// </summary>
    public interface IRulesEngine
    {
        /// <summary>
        /// Add a rule to the engine.
        /// </summary>
        /// <param name="rule">The <see cref="ISerializationRule"/> to add.</param>
        void AddRule(ISerializationRule rule);

        /// <summary>
        /// Checks if a member is allowed.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> to check.</param>
        /// <returns>A value indicating whether or not the member access is allowed.</returns>
        bool MemberIsAllowed(MemberInfo member);

        /// <summary>
        /// Compiles the rules for efficiency.
        /// </summary>
        void Compile();
    }
}
