// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using System.Reflection;

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
            if (member.Member is PropertyInfo property)
            {
                PropertyInfo = new Property(property);
                MemberType = PropertyInfo.MemberType;
            }
            else if (member.Member is FieldInfo field)
            {
                FieldInfo = new Field(field);
                MemberType = FieldInfo.MemberType;
            }
        }

        /// <summary>
        /// Gets or sets the member type.
        /// </summary>
        public int MemberType { get; set; }

        /// <summary>
        /// Gets or sets the serializable <see cref="PropertyInfo"/>.
        /// </summary>
        public Property PropertyInfo { get; set; }

        /// <summary>
        /// Gets or sets the serializable <see cref="FieldInfo"/>.
        /// </summary>
        public Field FieldInfo { get; set; }

        /// <summary>
        /// Gets or sets the method's object.
        /// </summary>
        public object Expression { get; set; }
    }
}
