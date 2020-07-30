// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Interface for provider that intercepts the <see cref="Expression"/> when run.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface IQueryInterceptingProvider<T> : IQueryInterceptor, ICustomQueryProvider<T>
    {
    }
}
