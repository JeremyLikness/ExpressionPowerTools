// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Rules
{
    /// <summary>
    /// A rule for serialization.
    /// </summary>
    public class SerializationRule : ISerializationRule
    {
        private string targetKey = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationRule"/> class
        /// with the options to allow and the match.
        /// </summary>
        /// <param name="allow">A value indicating whether the rule is allowed.</param>
        /// <param name="info">The <see cref="MemberInfo"/> the rule applies to.</param>
        /// <exception cref="ArgumentException">Thrown when the type of member is not <see cref="Type"/>,
        /// <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/> or <see cref="FieldInfo"/>.</exception>
        public SerializationRule(bool allow, MemberInfo info)
        {
            Allow = allow;
            Target = info;
            MemberType = info.MemberType;
        }

        /// <summary>
        /// Gets a value indicating whether the target is allowed.
        /// </summary>
        public bool Allow { get; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        public MemberInfo Target { get; }

        /// <summary>
        /// Gets the <see cref="MemberTypes"/> for the rule.
        /// </summary>
        public MemberTypes MemberType { get; }

        /// <summary>
        /// Gets the target key.
        /// </summary>
        public string TargetKey
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(targetKey))
                {
                    return targetKey;
                }

                var reflectionHelper = ServiceHost.GetService<IReflectionHelper>();
                var member = reflectionHelper.TranslateMemberInfo(Target);
                targetKey = member.CalculateKey();
                return targetKey;
            }
        }

        /// <summary>
        /// Gets the hash code of the key.
        /// </summary>
        /// <returns>The key hash code.</returns>
        public override int GetHashCode() => TargetKey.GetHashCode();

        /// <summary>
        /// Gets the member signature.
        /// </summary>
        /// <returns>The text showing allowed or not and the key.</returns>
        public override string ToString() => $"{Allow}: {TargetKey}";
    }
}
