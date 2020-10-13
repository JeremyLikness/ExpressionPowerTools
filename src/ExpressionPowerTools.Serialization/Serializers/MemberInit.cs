// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable representation of <see cref="MemberInitExpression"/>.
    /// </summary>
    [Serializable]
    public class MemberInit : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberInit"/> class.
        /// </summary>
        public MemberInit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberInit"/> class with
        /// the related <see cref="MemberInitExpression"/>.
        /// </summary>
        /// <param name="memberInit">The <see cref="MemberInitExpression"/>.</param>
        public MemberInit(MemberInitExpression memberInit)
            : base(memberInit)
        {
        }

        /// <summary>
        /// Gets or sets the expression to initialize.
        /// </summary>
        public CtorExpr NewExpression { get; set; }

        /// <summary>
        /// Gets or sets the list of bindings.
        /// </summary>
        public List<MemberBindingExpr> Bindings { get; set; } =
            new List<MemberBindingExpr>();
    }
}
