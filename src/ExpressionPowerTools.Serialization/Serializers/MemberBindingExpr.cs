// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Base for a member binding expression.
    /// </summary>
    [Serializable]
    public abstract class MemberBindingExpr
    {
        /// <summary>
        /// Gets or sets the type of the binding.
        /// </summary>
        public abstract int BindingType { get; set; }
    }
}
