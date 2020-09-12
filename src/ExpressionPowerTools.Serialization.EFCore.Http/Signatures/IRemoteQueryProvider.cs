// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Signatures
{
    /// <summary>
    /// Custom provider for tracking context.
    /// </summary>
    public interface IRemoteQueryProvider
    {
        /// <summary>
        /// Gets the <see cref="RemoteContext"/>.
        /// </summary>
        RemoteContext Context { get; }
    }
}
