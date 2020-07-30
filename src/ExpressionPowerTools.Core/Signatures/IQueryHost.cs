// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Interface for custom query host.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    /// <typeparam name="TProvider">The <see cref="ICustomQueryProvider{T}"/> to handle logic.</typeparam>
    public interface IQueryHost<T, TProvider> : IOrderedQueryable<T>, IOrderedQueryable
        where TProvider : ICustomQueryProvider<T>
    {
        /// <summary>
        /// Gets the <see cref="ICustomQueryProvider{T}"/> that handles the custom logic.
        /// </summary>
        TProvider CustomProvider { get; }
    }
}
