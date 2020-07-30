// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Provider to intercept query execution for inspection.
    /// </summary>
    /// <typeparam name="T">The type of snapshot to provide for.</typeparam>
    public interface IQuerySnapshotProvider<T> : ICustomQueryProvider<T>, IQuerySnapshot
    {
    }
}
