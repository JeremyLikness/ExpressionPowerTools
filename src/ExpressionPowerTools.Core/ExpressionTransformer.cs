// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;

namespace ExpressionPowerTools.Core
{
    /// <summary>
    /// Transform one expression to another.
    /// </summary>
    /// <param name="source">The source <see cref="Expression"/>.</param>
    /// <returns>The transformed expression.</returns>
    public delegate Expression ExpressionTransformer(Expression source);
}
