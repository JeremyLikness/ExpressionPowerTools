// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Interface for a custom implementation of <see cref="IQueryProvider"/>.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface ICustomQueryProvider<T> : IQueryProvider
    {
        /// <summary>
        /// Execute enumeration from the <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to enumerate.</param>
        /// <returns>An instance of <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<T> ExecuteEnumerable(Expression expression);
    }
}
