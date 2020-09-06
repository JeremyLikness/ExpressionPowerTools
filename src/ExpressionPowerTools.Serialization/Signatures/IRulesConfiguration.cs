// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;
using ExpressionPowerTools.Serialization.Rules;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Interface for configuring rules.
    /// </summary>
    public interface IRulesConfiguration
    {
        /// <summary>
        /// Allow the rule.
        /// </summary>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration Allow();

        /// <summary>
        /// Deny the rule.
        /// </summary>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration Deny();

        /// <summary>
        /// Set rule for <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to opt in.</param>
        /// <returns>The chainable <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration RuleForType(Type type);

        /// <summary>
        /// Set rule for <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to opt-in.</typeparam>
        /// <returns>The chainable <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration RuleForType<T>();

        /// <summary>
        /// Rule for a <see cref="MethodInfo"/>.
        /// </summary>
        /// <param name="selector">The selector to resolve the method.</param>
        /// <returns>The chainable <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration RuleForMethod(Action<MemberSelector<MethodInfo>> selector);

        /// <summary>
        /// Rule for a <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="selector">The selector to resolve the property.</param>
        /// <returns>The chainable <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration RuleForProperty(Action<MemberSelector<PropertyInfo>> selector);

        /// <summary>
        /// Rule for a <see cref="FieldInfo"/>.
        /// </summary>
        /// <param name="selector">The selector to resolve the field.</param>
        /// <returns>The chainable <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration RuleForField(Action<MemberSelector<FieldInfo>> selector);

        /// <summary>
        /// Rule for a <see cref="ConstructorInfo"/>.
        /// </summary>
        /// <param name="selector">The selector to resolve the constructor.</param>
        /// <returns>The chainable <see cref="IRulesConfiguration"/>.</returns>
        IRulesConfiguration RuleForConstructor(Action<MemberSelector<ConstructorInfo>> selector);
    }
}
