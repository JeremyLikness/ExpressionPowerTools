// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Providers
{
    /// <summary>
    /// Provider that intercepts the <see cref="Expression"/> when run.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class QueryInterceptingProvider<T> :
        CustomQueryProvider<T>, IQueryInterceptingProvider<T>
    {
        private readonly Stack<IQueryInterceptor> interceptors =
            new Stack<IQueryInterceptor>();

        /// <summary>
        /// The transformatoin to apply.
        /// </summary>
        private ExpressionTransformer transformation = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInterceptingProvider{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">The query to snapshot.</param>
        public QueryInterceptingProvider(IQueryable sourceQuery)
            : base(sourceQuery)
        {
        }

        /// <summary>
        /// Creates a query host with this provider.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to use.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentNullException">Throw when expression is null.</exception>
        public override IQueryable CreateQuery(Expression expression)
        {
            Ensure.NotNull(() => expression);
            return ServiceHost.GetService<IQueryHost<T, IQueryInterceptingProvider<T>>>(expression, this);
        }

        /// <summary>
        /// Creates a query host with a different type.
        /// </summary>
        /// <typeparam name="TElement">The entity type.</typeparam>
        /// <param name="expression">The <see cref="Expression"/> to use.</param>
        /// <returns>The <see cref="IQueryable{TElement}"/>.</returns>
        /// <exception cref="ArgumentNullException">Throw when expression is null.</exception>
        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Ensure.NotNull(() => expression);
            if (typeof(TElement) == typeof(T))
            {
                return CreateQuery(expression) as IQueryable<TElement>;
            }

            var childProvider = ServiceHost.GetService<IQueryInterceptingProvider<TElement>>(Source);
            if (transformation != null)
            {
                childProvider.RegisterInterceptor(transformation);
            }
            else
            {
                interceptors.Push(childProvider);
            }

            return ServiceHost.GetService<IQueryHost<TElement, IQueryInterceptingProvider<TElement>>>(
                expression, childProvider);
        }

        /// <summary>
        /// Registers the transformation to apply.
        /// </summary>
        /// <param name="transformation">A method that transforms an <see cref="Expression"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when transformation is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when interceptor already registered.</exception>
        public void RegisterInterceptor(ExpressionTransformer transformation)
        {
            Ensure.NotNull(() => transformation);
            if (this.transformation != null)
            {
                throw new InvalidOperationException();
            }

            while (interceptors.Count > 0)
            {
                var child = interceptors.Pop();
                child.RegisterInterceptor(transformation);
            }

            this.transformation = transformation;
        }

        /// <summary>
        /// Execute with transformation.
        /// </summary>
        /// <param name="expression">The base <see cref="Expression"/>.</param>
        /// <returns>Result of executing the transformed expression.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        public override object Execute(Expression expression)
        {
            Ensure.NotNull(() => expression);
            return Source.Provider.Execute(TransformExpression(expression));
        }

        /// <summary>
        /// Execute the enumerable.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to execute.</param>
        /// <returns>The result of the transformed expression.</returns>
        public override IEnumerable<T> ExecuteEnumerable(Expression expression)
        {
            Ensure.NotNull(() => expression);
            return base.ExecuteEnumerable(TransformExpression(expression));
        }

        /// <summary>
        /// Perform the transformation.
        /// </summary>
        /// <param name="source">The original <see cref="Expression"/>.</param>
        /// <returns>The transformed <see cref="Expression"/>.</returns>
        private Expression TransformExpression(Expression source) =>
            transformation == null ? source :
            transformation(source);
    }
}
