// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializable <see cref="NewExpression"/>.
    /// </summary>
    [Serializable]
    public class CtorExpr : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtorExpr"/> class.
        /// </summary>
        public CtorExpr()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtorExpr"/> class
        /// initialized with a <see cref="NewExpression"/>.
        /// </summary>
        /// <param name="ctor">The <see cref="NewExpression"/> to
        /// serialize.</param>
        public CtorExpr(NewExpression ctor)
            : base(ctor)
        {
            CtorInfo = GetKeyForMember(ctor.Constructor);

            if (ctor.Members != null)
            {
                MemberKeys = ctor.Members.Select(
                    m => GetKeyForMember(m))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets or sets the serializable <see cref="ConstructorInfo"/>.
        /// </summary>
        public string CtorInfo { get; set; }

        /// <summary>
        /// Gets or sets the method's object.
        /// </summary>
        public List<object> Arguments { get; set; } = new List<object>();

        /// <summary>
        /// Gets or sets the keys of members.
        /// </summary>
        public List<string> MemberKeys { get; set; } = new List<string>();
    }
}
