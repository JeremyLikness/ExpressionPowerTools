// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Hosts
{
    /// <summary>
    /// Base class for custom query host.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TProvider">The <see cref="ICustomQueryProvider{T}"/> to use.</typeparam>
    public class QueryHost<T, TProvider> : IQueryHost<T, TProvider>
        where TProvider : ICustomQueryProvider<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHost{T, TProvider}"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/>.</param>
        /// <param name="provider">The <see cref="ICustomQueryProvider{T}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when expression or provider are null.</exception>
        public QueryHost(
            Expression expression,
            TProvider provider)
        {
            Ensure.NotNull(() => expression);
            Ensure.NotNull(() => provider);
            Expression = expression;
            CustomProvider = provider;
        }

        /// <summary>
        /// Gets the type of element.
        /// </summary>
        public virtual Type ElementType => typeof(T);

        /// <summary>
        /// Gets the <see cref="Expression"/> for the query.
        /// </summary>
        public virtual Expression Expression { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IQueryProvider"/>.
        /// </summary>
        public IQueryProvider Provider => CustomProvider;

        /// <summary>
        /// Gets or sets the instance of the <see cref="ICustomQueryProvider{T}"/>.
        /// </summary>
        public TProvider CustomProvider { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> for the query results.
        /// </summary>
        /// <returns>The <see cref="IEnumerator{T}"/>.</returns>
        public virtual IEnumerator<T> GetEnumerator() =>
            CustomProvider.ExecuteEnumerable(Expression).GetEnumerator();

        /// <summary>
        /// Gets the non-typed <see cref="IEnumerator"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
