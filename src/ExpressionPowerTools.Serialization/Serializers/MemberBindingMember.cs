// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of the <see cref="MemberMemberBinding"/> class.
    /// </summary>
    [Serializable]
    public class MemberBindingMember : MemberBindingExpr
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberBindingMember"/> class.
        /// </summary>
        public MemberBindingMember()
        {
        }

        /// <summary>
        /// Gets or sets the key for the member.
        /// </summary>
        public string MemberKey { get; set; }

        /// <summary>
        /// Gets or sets the binding type.
        /// </summary>
        public override int BindingType
        {
            get;

            [ExcludeFromCodeCoverage]
            set;
        }

            = (int)MemberBindingType.MemberBinding;

        /// <summary>
        /// Gets or sets the bindings for the member.
        /// </summary>
        public List<MemberBindingExpr> Bindings
        {
            get;

            [ExcludeFromCodeCoverage]
            set;
        }

            = new List<MemberBindingExpr>();
    }
}
