// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable <see cref="MemberAssignment"/>.
    /// </summary>
    [Serializable]
    public class MemberBindingAssignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberBindingAssignment"/> class.
        /// </summary>
        public MemberBindingAssignment()
        {
        }

        /// <summary>
        /// Gets or sets the initialization expression.
        /// </summary>
        public object Expression { get; set; }

        /// <summary>
        /// Gets or sets the binding type.
        /// </summary>
        public int BindingType
        {
            get;

            [ExcludeFromCodeCoverage]
            set;
        }

            = (int)MemberBindingType.Assignment;

        /// <summary>
        /// Gets or sets the key of the member.
        /// </summary>
        public string MemberInfoKey { get; set; }
    }
}
