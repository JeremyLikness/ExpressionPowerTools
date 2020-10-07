// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of the <see cref="MemberListBinding"/> class.
    /// </summary>
    [Serializable]
    public class MemberBindingList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberBindingList"/> class.
        /// </summary>
        public MemberBindingList()
        {
        }

        /// <summary>
        /// Gets or sets the key to the member.
        /// </summary>
        public string MemberKey { get; set; }

        /// <summary>
        /// Gets or sets the binding type.
        /// </summary>
        public int BindingType
        {
            get;
            [ExcludeFromCodeCoverage]
            set;
        }

            = (int)MemberBindingType.ListBinding;

        /// <summary>
        /// Gets or sets the list of initializers.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<MemberBindingInitializer> Initializers
        {
            get;

            [ExcludeFromCodeCoverage]
            set;
        }

            = new List<MemberBindingInitializer>();
    }
}
