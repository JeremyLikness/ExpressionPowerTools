// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Signatures
{
    /// <summary>
    /// Interface to retain generic type for extensions.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the remote query.</typeparam>
    public interface IRemoteQueryable<T> : IRemoteQuery
    {
    }
}
