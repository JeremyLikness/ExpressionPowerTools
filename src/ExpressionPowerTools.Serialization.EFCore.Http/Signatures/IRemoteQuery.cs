// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Serialization.EFCore.Http.Signatures
{
    /// <summary>
    /// Remote query interface to capture the context.
    /// </summary>
    public interface IRemoteQuery
    {
        /// <summary>
        /// Gets the custom provider that tracks the context.
        /// </summary>
        IRemoteQueryProvider CustomProvider { get; }
    }
}
