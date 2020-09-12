// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Queryable
{
    /// <summary>
    /// Custom provider for remote queries.
    /// </summary>
    /// <remarks>
    /// The main purpose is to provide a query to build the filters and sorts, and capture
    /// the original context for extension overloads that will fetch the remote results.
    /// </remarks>
    /// <typeparam name="T">The type of the query.</typeparam>
    public class RemoteQueryProvider<T> : CustomQueryProvider<T>, IRemoteQueryProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteQueryProvider{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">The source query.</param>
        /// <param name="remoteContext">The <see cref="RemoteContext"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when remote context is null.</exception>
        public RemoteQueryProvider(
            IQueryable sourceQuery,
            RemoteContext remoteContext)
            : base(sourceQuery)
        {
            Ensure.NotNull(() => remoteContext);
            Context = remoteContext;
        }

        /// <summary>
        /// Gets the <see cref="RemoteContext"/>.
        /// </summary>
        public RemoteContext Context { get; }

        /// <summary>
        /// Create a query.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to parse.</param>
        /// <returns>The new <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public override IQueryable CreateQuery(Expression expression)
        {
            Ensure.NotNull(() => expression);
            return new RemoteQuery<T, RemoteQueryProvider<T>>(expression, this);
        }

        /// <summary>
        /// Create a typed query.
        /// </summary>
        /// <typeparam name="TElement">The query <see cref="Type"/>.</typeparam>
        /// <param name="expression">The query <see cref="Expression"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Ensure.NotNull(() => expression);
            if (typeof(TElement) == typeof(T))
            {
                return CreateQuery(expression) as IQueryable<TElement>;
            }

            var childProvider = new RemoteQueryProvider<TElement>(Source, Context);
            return new RemoteQuery<TElement, RemoteQueryProvider<TElement>>(expression, childProvider);
        }
    }
}
