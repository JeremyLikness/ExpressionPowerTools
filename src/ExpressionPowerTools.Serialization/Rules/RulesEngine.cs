// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Rules
{
    /// <summary>
    /// The rules engine.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The rules engine is an opt-in engine for execution. By default, properties and fields are allowed.
    /// Methods and constructors are not allowed. The rules engine operates on a few principles.
    /// </para>
    /// <para>Allowing or denying a type will allow or deny all children of that type. For example,
    /// although methods are denied by defeault, allowing a type will also allow access to methods.
    /// More specific rules override general. You can allow a type and then deny a method, for example.
    /// Rules defined on generic types are inherited by closed types by default. You can choose to specify
    /// a rule for the closed type. For example, you might allow <see cref="IQueryable{T}"/> as a generic
    /// type but deny `IQueryable&lt;int>`.</para>
    /// <para>Use the chainable <see cref="IRulesConfiguration"/> interface to build the rules. By default
    /// they are "allow." You can use the explicit <see cref="Allow"/> to reinforce this, or turn it into
    /// a <see cref="Deny"/>.</para>
    /// </remarks>
    public partial class RulesEngine : IRulesEngine
    {
        /// <summary>
        /// Provider for <see cref="IReflectionHelper"/>.
        /// </summary>
        private readonly Lazy<IReflectionHelper> reflectionProvider =
            ServiceHost.GetLazyService<IReflectionHelper>();

        /// <summary>
        /// Member adapter.
        /// </summary>
        private readonly Lazy<IMemberAdapter> memberAdapter =
            ServiceHost.GetLazyService<IMemberAdapter>();

        /// <summary>
        /// Permissions.
        /// </summary>
        /// <remarks>
        /// Explicit types will override derived type defaults.
        /// </remarks>
        private readonly ConcurrentDictionary<string, bool> rules
            = new ConcurrentDictionary<string, bool>();

        /// <summary>
        /// The list of custom rules registered.
        /// </summary>
        private readonly ConcurrentDictionary<bool, List<Predicate<MemberInfo>>> customRules
            = new ConcurrentDictionary<bool, List<Predicate<MemberInfo>>>(
            new KeyValuePair<bool, List<Predicate<MemberInfo>>>[]
            {
                new KeyValuePair<bool, List<Predicate<MemberInfo>>>(false, new List<Predicate<MemberInfo>>()),
                new KeyValuePair<bool, List<Predicate<MemberInfo>>>(true, new List<Predicate<MemberInfo>>()),
            });

        /// <summary>
        /// Default permissions.
        /// </summary>
        /// <remarks>
        /// Explicit types will override derived type defaults.
        /// </remarks>
        private readonly ConcurrentDictionary<string, bool> defaultRules
            = new ConcurrentDictionary<string, bool>();

        /// <summary>
        /// Synchronization.
        /// </summary>
        private readonly object objLock = new object();

        /// <summary>
        /// A rule is waiting to be queued using the fluent interface.
        /// </summary>
        private bool rulePending = false;

        /// <summary>
        /// Gets a value indicating whether anonymous types are allowed.
        /// </summary>
        public bool AllowAnonymousTypes { get; private set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether defaults are being loaded.
        /// </summary>
        public bool LoadingDefaults { get; set; } = false;

        /// <summary>
        /// Gets an instance of the <see cref="ReflectionHelper"/>.
        /// </summary>
        private IReflectionHelper ReflectionHelper => reflectionProvider.Value;

        /// <summary>
        /// Adds a rule to the engine.
        /// </summary>
        /// <remarks>
        /// Will overwrite previous rules for the same type.
        /// </remarks>
        /// <param name="rule">The <see cref="ISerializationRule"/> to add.</param>
        public void AddRule(ISerializationRule rule)
        {
            rules.AddOrUpdate(rule.TargetKey, rule.Allow, (_, __) => rule.Allow);

            if (LoadingDefaults)
            {
                defaultRules.AddOrUpdate(
                    rule.TargetKey,
                    rule.Allow,
                    (_, __) => rule.Allow);
            }
        }

        /// <summary>
        /// Add a custom rule to the engine.
        /// </summary>
        /// <param name="rule">The rule to execute.</param>
        /// <param name="isOverride">A value indicating whether this rule overrides other rules.</param>
        public void AddCustomRule(Predicate<MemberInfo> rule, bool isOverride)
        {
            customRules[isOverride].Add(rule);
        }

        /// <summary>
        /// Reset to default rules.
        /// </summary>
        public void ResetToDefaults()
        {
            Reset();
            foreach (var rule in defaultRules)
            {
                rules.AddOrUpdate(
                    rule.Key,
                    rule.Value,
                    (_, __) => rule.Value);
            }
        }

        /// <summary>
        /// Check if a member is allowed.
        /// </summary>
        /// <param name="member">The member to check.</param>
        /// <returns>A value indicating whether the member access is allowed.</returns>
        public bool MemberIsAllowed(MemberInfo member)
        {
            if (rulePending)
            {
                AddRules(true);
            }

            LoadingDefaults = false;

            if (member == null)
            {
                return true;
            }

            // Overriding custom rules short circuit other rules
            if (customRules[true].Count > 0)
            {
                return customRules[true].All(r => r.Invoke(member) == true);
            }

            // Ordinary custom rules only short circuit when false
            if (customRules[false].Count > 0 &&
                customRules[false].Any(r => r.Invoke(member) == false))
            {
                return false;
            }

            if ((member is Type typeInfo && typeInfo.IsAnonymousType())
                || (member.DeclaringType != null && member.DeclaringType.IsAnonymousType()))
            {
                return AllowAnonymousTypes;
            }

            var key = memberAdapter.Value.GetKeyForMember(member);

            if (rules.ContainsKey(key))
            {
                return rules[key];
            }

            // look to type
            var type = member is Type typeDef ?
                typeDef : member.DeclaringType;
            var typeKey = memberAdapter.Value.GetKeyForMember(type);

            // is the type allowed or denied? This will inherit.
            if (rules.ContainsKey(typeKey))
            {
                var permission = rules[typeKey];
                rules.TryAdd(key, permission);
                return permission;
            }

            var genericPermission = false;
            var found = false;

            if (type.IsGenericType && !type.IsGenericTypeDefinition)
            {
                var generic = type.GetGenericTypeDefinition();

                var genericKey = memberAdapter.Value.GetKeyForMember(generic);
                if (rules.ContainsKey(genericKey))
                {
                    genericPermission = rules[genericKey];
                    rules.TryAdd(typeKey, genericPermission);
                    found = true;
                }

                var genericVersion = ReflectionHelper.FindGenericVersion(member, generic);
                if (genericVersion != null)
                {
                    var genericVersionKey = memberAdapter.Value.GetKeyForMember(genericVersion);

                    if (rules.ContainsKey(genericVersionKey))
                    {
                        // add the rule for better efficiency with future cals
                        genericPermission = rules[genericVersionKey];
                        rules.TryAdd(key, genericPermission);
                        found = true;
                    }
                }

                if (found)
                {
                    return genericPermission;
                }
            }

            // nothing explicit found - default for property and field is true
            if (member is PropertyInfo || member is FieldInfo)
            {
                rules.TryAdd(key, true);
                return true;
            }

            rules.TryAdd(key, false);
            return false;
        }

        /// <summary>
        /// Clears the ruleset. Although this returns the existing rules for
        /// restoration, it does not provide a way to restore custom rules.
        /// </summary>
        /// <returns>The rule set for restoration.</returns>
        public IList<(string rule, bool authorized)> Reset()
        {
            Monitor.Enter(objLock);

            if (rulePending && LoadingDefaults)
            {
                AddRules(true);
            }

            LoadingDefaults = false;
            rulePending = false;
            memberInfo = null;
            try
            {
                var result = rules.Select(r => (r.Key, r.Value)).ToList();
                rules.Clear();
                customRules.Clear();
                var customRuleSet = new List<Predicate<MemberInfo>>();
                var overridingRuleSet = new List<Predicate<MemberInfo>>();
                customRules.AddOrUpdate(false, customRuleSet, (_, __) => customRuleSet);
                customRules.AddOrUpdate(true, overridingRuleSet, (_, __) => overridingRuleSet);
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                Monitor.Exit(objLock);
            }
        }

        /// <summary>
        /// Restores a rule set (used mainly for testing).
        /// </summary>
        /// <param name="ruleSet">The rule set.</param>
        public void Restore(IList<(string rule, bool authorized)> ruleSet)
        {
            Monitor.Enter(objLock);
            try
            {
                var result = rules.Select(r => (r.Key, r.Value)).ToList();
                rules.Clear();
                foreach (var rule in ruleSet)
                {
                    rules.AddOrUpdate(
                        rule.rule,
                        rule.authorized,
                        (_, __) => rule.authorized);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Monitor.Exit(objLock);
            }
        }
    }
}
