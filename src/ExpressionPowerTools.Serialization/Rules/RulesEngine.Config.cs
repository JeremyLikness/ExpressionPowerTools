// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Rules
{
    /// <summary>
    /// Implementation of <see cref="IRulesConfiguration"/>.
    /// </summary>
    public partial class RulesEngine : IRulesConfiguration
    {
        /// <summary>
        /// The <see cref="MemberInfo"/> for the rule.
        /// </summary>
        private MemberInfo[] memberInfo = null;

        /// <summary>
        /// Allow the rule in queue.
        /// </summary>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when member info doesn't exist.</exception>
        public IRulesConfiguration Allow()
        {
            AddRules(true);
            return this;
        }

        /// <summary>
        /// Deny the rule in queue.
        /// </summary>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        /// <exception cref="InvalidOperationException">Throw when member info doesn't exist.</exception>
        public IRulesConfiguration Deny()
        {
            AddRules(false);
            return this;
        }

        /// <summary>
        /// Sets up a constructor rule.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        public IRulesConfiguration RuleForConstructor(Action<MemberSelector<ConstructorInfo>> selector)
        {
            CheckMemberInfo(shouldExist: false);
            var ctorSelector = new MemberSelector<ConstructorInfo>();
            selector(ctorSelector);
            memberInfo = ctorSelector.Member;
            return this;
        }

        /// <summary>
        /// Sets up a field rule.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        public IRulesConfiguration RuleForField(Action<MemberSelector<FieldInfo>> selector)
        {
            CheckMemberInfo(shouldExist: false);
            var fieldSelector = new MemberSelector<FieldInfo>();
            selector(fieldSelector);
            memberInfo = fieldSelector.Member;
            return this;
        }

        /// <summary>
        /// Sets up a method rule.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        public IRulesConfiguration RuleForMethod(Action<MemberSelector<MethodInfo>> selector)
        {
            CheckMemberInfo(shouldExist: false);
            var methodSelector = new MemberSelector<MethodInfo>();
            selector(methodSelector);
            memberInfo = methodSelector.Member;
            return this;
        }

        /// <summary>
        /// Sets up a property rule.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        public IRulesConfiguration RuleForProperty(Action<MemberSelector<PropertyInfo>> selector)
        {
            CheckMemberInfo(shouldExist: false);
            var propSelector = new MemberSelector<PropertyInfo>();
            selector(propSelector);
            memberInfo = propSelector.Member;
            return this;
        }

        /// <summary>
        /// Adds the rules for a type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to add.</param>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        public IRulesConfiguration RuleForType(Type type)
        {
            CheckMemberInfo(shouldExist: false);
            memberInfo = new[] { type };
            return this;
        }

        /// <summary>
        /// Adds the rules for a type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to add.</typeparam>
        /// <returns>The <see cref="IRulesConfiguration"/>.</returns>
        public IRulesConfiguration RuleForType<T>() => RuleForType(typeof(T));

        /// <summary>
        /// Check the state of <see cref="memberInfo"/>.
        /// </summary>
        /// <param name="shouldExist">A value indicating whether the <see cref="memberInfo"/> should exist.</param>
        private void CheckMemberInfo(bool shouldExist = false)
        {
            if (shouldExist == false)
            {
                if (memberInfo != null)
                {
                    AddRules(true);
                }

                return;
            }

            if (shouldExist == true && memberInfo == null)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Adds the rules for the queued members.
        /// </summary>
        /// <param name="allow">A value indicating whether the rule is to allow or deny.</param>
        private void AddRules(bool allow)
        {
            CheckMemberInfo(shouldExist: true);
            foreach (var member in memberInfo)
            {
                AddRule(new SerializationRule(allow, member));
            }

            memberInfo = null;
        }
    }
}
