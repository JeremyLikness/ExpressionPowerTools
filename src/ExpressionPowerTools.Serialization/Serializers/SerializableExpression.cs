// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Class for serialization expressions.
    /// </summary>
    [Serializable]
    public class SerializableExpression
    {
        /// <summary>
        /// Member adapter.
        /// </summary>
        private readonly Lazy<IMemberAdapter> memberAdapter =
            ServiceHost.GetLazyService<IMemberAdapter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableExpression"/> class.
        /// </summary>
        public SerializableExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableExpression"/> class and captures
        /// the <see cref="ExpressionType"/> of the <see cref="Expression"/> passed in.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public SerializableExpression(Expression expression)
        {
            Ensure.NotNull(() => expression);
            Type = (int)expression.NodeType;
        }

        /// <summary>
        /// Gets or sets the type of the expression.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Gets the unique key for a member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The unique key.</returns>
        protected string GetKeyForMember(MemberInfo member) =>
            memberAdapter.Value.GetKeyForMember(member);

        /// <summary>
        /// Gets the member from a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The member info.</returns>
        protected MemberInfo GetMemberFromKey(string key) =>
            memberAdapter.Value.GetMemberForKey(key);

        /// <summary>
        /// Typed version of get member from a key.
        /// </summary>
        /// <typeparam name="TMemberInfo">The type of the member.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The member.</returns>
        protected TMemberInfo GetMemberFromKey<TMemberInfo>(string key)
            where TMemberInfo : MemberInfo =>
            GetMemberFromKey(key) as TMemberInfo;
    }
}
