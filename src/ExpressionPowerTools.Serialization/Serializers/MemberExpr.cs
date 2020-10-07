// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Helper to serialize a <see cref="MemberExpression"/>.
    /// </summary>
    [Serializable]
    public class MemberExpr : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberExpr"/> class.
        /// </summary>
        public MemberExpr()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberExpr"/> class
        /// initialized with a <see cref="MemberExpression"/>.
        /// </summary>
        /// <param name="member">The <see cref="MemberExpression"/> to
        /// serialize.</param>
        public MemberExpr(MemberExpression member)
            : base(member)
        {
            MemberTypeKey = GetKeyForMember(member.Member);
        }

        /// <summary>
        /// Gets or sets the indexer property.
        /// </summary>
        public string Indexer { get; set; }

        /// <summary>
        /// Gets or sets the indexer type key.
        /// </summary>
        public string IndexerTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the member type key.
        /// </summary>
        public string MemberTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the method's object.
        /// </summary>
        public object Expression { get; set; }
    }
}
