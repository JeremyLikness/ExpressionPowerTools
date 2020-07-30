// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Exposes a method to register a transformation.
    /// </summary>
    public interface IQueryInterceptor
    {
        /// <summary>
        /// Register the transformation to intercept.
        /// </summary>
        /// <param name="transformation">The method to inspect and/or transform.</param>
        void RegisterInterceptor(ExpressionTransformer transformation);
    }
}
