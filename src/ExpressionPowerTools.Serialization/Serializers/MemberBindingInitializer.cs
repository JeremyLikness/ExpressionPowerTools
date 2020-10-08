// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of <see cref="ElementInit"/>.
    /// </summary>
    [Serializable]
    public class MemberBindingInitializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberBindingInitializer"/> class.
        /// </summary>
        public MemberBindingInitializer()
        {
        }

        /// <summary>
        /// Gets or sets the key to the member.
        /// </summary>
        public string AddMethodKey { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        public List<object> Arguments { get; set; }
            = new List<object>();
    }
}
