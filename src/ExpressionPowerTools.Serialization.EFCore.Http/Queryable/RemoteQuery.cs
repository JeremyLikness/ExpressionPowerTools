// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Queryable
{
    /// <summary>
    /// Encapsulates query capabilities to build the template for remote submission.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
    /// <typeparam name="TProvider">The <see cref="ICustomQueryProvider{T}"/>.</typeparam>
    public class RemoteQuery<T, TProvider> : QueryHost<T, TProvider>, IRemoteQueryable<T>
        where TProvider : ICustomQueryProvider<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteQuery{T, TProvider}"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to parse.</param>
        /// <param name="provider">The <see cref="ICustomQueryProvider{T}"/>.</param>
        public RemoteQuery(Expression expression, TProvider provider)
            : base(expression, provider)
        {
        }

        /// <summary>
        /// Gets the explicit implementation that exposes the interface for the custom provider.
        /// </summary>
        IRemoteQueryProvider IRemoteQuery.CustomProvider => CustomProvider as IRemoteQueryProvider;

        /// <summary>
        /// Gets the enumerator of the result. Overridden to prevent issues trying to execute
        /// a database query directly.
        /// </summary>
        /// <returns>An empty enumerator.</returns>
        public override IEnumerator<T> GetEnumerator() => Enumerable.Empty<T>().GetEnumerator();
    }
}
