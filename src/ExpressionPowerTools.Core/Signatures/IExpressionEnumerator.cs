// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Enables recursing over an expression tree.
    /// </summary>
    public interface IExpressionEnumerator : IEnumerable<Expression>
    {
    }
}
