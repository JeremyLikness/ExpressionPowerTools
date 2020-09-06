// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Serializers;
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
        /// Instance of the <see cref="ReflectionHelper"/>.
        /// </summary>
        private readonly Lazy<IReflectionHelper> reflectionHelper =
            new Lazy<IReflectionHelper>(() => ServiceHost.GetService<IReflectionHelper>());

        /// <summary>
        /// The collection of rules.
        /// </summary>
        private readonly HashSet<ISerializationRule> rules =
            new HashSet<ISerializationRule>();

        /// <summary>
        /// Represents the rules that are owned by a type.
        /// </summary>
        /// <remarks>
        /// When a derived type is found, we need this reference to copy the rules.
        /// Explicit types will override derived type defaults.
        /// </remarks>
        private readonly IDictionary<string, HashSet<ISerializationRule>> typeHierarchy =
            new Dictionary<string, HashSet<ISerializationRule>>();

        /// <summary>
        /// Synchronization.
        /// </summary>
        private readonly object objLock = new object();

        /// <summary>
        /// Compiled permissions.
        /// </summary>
        private readonly IDictionary<string, bool> permissions =
            new Dictionary<string, bool>();

        /// <summary>
        /// A value that indicates whether the rules have been compiled or not.
        /// </summary>
        private bool compiled;

        /// <summary>
        /// Adds a rule to the engine.
        /// </summary>
        /// <remarks>
        /// Will overwrite previous rules for the same type.
        /// </remarks>
        /// <param name="rule">The <see cref="ISerializationRule"/> to add.</param>
        public void AddRule(ISerializationRule rule)
        {
            lock (objLock)
            {
                rules.Add(rule);
                if (!(rule.Target is Type))
                {
                    var parentRuleType = rule.Target.DeclaringType;
                    var memberKey = new TypeBase(parentRuleType).CalculateKey();
                    HashSet<ISerializationRule> hierarchy;
                    if (typeHierarchy.ContainsKey(memberKey))
                    {
                        hierarchy = typeHierarchy[memberKey];
                    }
                    else
                    {
                        hierarchy = new HashSet<ISerializationRule>();
                        typeHierarchy.Add(memberKey, hierarchy);
                    }

                    hierarchy.Add(rule);
                }
                else
                {
                    if (!typeHierarchy.ContainsKey(rule.TargetKey))
                    {
                        typeHierarchy.Add(rule.TargetKey, new HashSet<ISerializationRule>());
                    }
                }

                compiled = false;
            }
        }

        /// <summary>
        /// Check if a member is allowed.
        /// </summary>
        /// <param name="member">The member to check.</param>
        /// <returns>A value indicating whether the member access is allowed.</returns>
        public bool MemberIsAllowed(MemberInfo member)
        {
            if (!compiled)
            {
                Compile();
            }

            // easiest check
            var memberKey = reflectionHelper.Value.TranslateMemberInfo(member);
            var key = memberKey.CalculateKey();
            if (permissions.ContainsKey(key))
            {
                return permissions[key];
            }

            // look to generic
            var type = member is Type typeDef ?
                typeDef : member.DeclaringType;
            var typeKey = new TypeBase(type).CalculateKey();

            if (type.IsGenericType && !type.IsGenericTypeDefinition)
            {
                var generic = type.GetGenericTypeDefinition();
                memberKey = reflectionHelper.Value.TranslateMemberInfo(generic);
                var genericKey = memberKey.CalculateKey();
                if (permissions.ContainsKey(genericKey))
                {
                    var rule = rules.Where(s => s.TargetKey == genericKey).FirstOrDefault();
                    if (rule != null)
                    {
                        var newRule = new SerializationRule(rule.Allow, type);
                        AddRule(newRule);
                    }
                }

                var genericVersion = reflectionHelper.Value.FindGenericVersion(member, generic);
                if (genericVersion != null)
                {
                    var genericVersionKey = reflectionHelper.Value.TranslateMemberInfo(genericVersion)
                        .CalculateKey();
                    if (permissions.ContainsKey(genericVersionKey))
                    {
                        // add the rule for better efficiency with future cals
                        AddRule(new SerializationRule(permissions[genericVersionKey], member));
                        permissions.Add(key, permissions[genericVersionKey]);
                        return permissions[key];
                    }
                }
            }

            // nothing explicit found - default for property and field is true
            if (member is PropertyInfo || member is FieldInfo)
            {
                permissions.Add(key, true);
                return true;
            }

            permissions.Add(key, false);
            return false;
        }

        /// <summary>
        /// Compiles the rules into a set of allowed keys.
        /// </summary>
        public void Compile()
        {
            if (compiled)
            {
                return;
            }

            if (memberInfo != null)
            {
                AddRules(true);
            }

            var compiledPermissions = new Dictionary<string, bool>();
            var allpublic = BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static;

            // types
            foreach (var rule in rules.Where(r =>
                r.MemberType == MemberTypes.TypeInfo ||
                r.MemberType == MemberTypes.NestedType))
            {
                var permission = rule.Allow;
                compiledPermissions.Add(rule.TargetKey, permission);

                var type = rule.Target as Type;

                // rule applies to all methods, properties, and types
                var children = type.GetMethods(allpublic).OfType<MemberInfo>()
                    .Union(type.GetProperties(allpublic))
                    .Union(type.GetFields(allpublic))
                    .Union(type.GetConstructors(allpublic))
                    .Select(m => reflectionHelper.Value.TranslateMemberInfo(m).CalculateKey());
                foreach (var child in children)
                {
                    compiledPermissions.Add(child, permission);
                }
            }

            // overrides
            foreach (var rule in rules.Where(r => r.MemberType != MemberTypes.All))
            {
                if (compiledPermissions.ContainsKey(rule.TargetKey))
                {
                    compiledPermissions[rule.TargetKey] = rule.Allow;
                }
                else
                {
                    compiledPermissions.Add(rule.TargetKey, rule.Allow);
                }
            }

            lock (objLock)
            {
                permissions.Clear();
                foreach (var entry in compiledPermissions)
                {
                    permissions.Add(entry.Key, entry.Value);
                }

                compiled = true;
            }
        }
    }
}
