// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Handles compression/decompression of types.
    /// </summary>
    public interface ITypesCompressor
    {
        /// <summary>
        /// Compress the types in a list.
        /// </summary>
        /// <param name="typeIndex">The index of existing types.</param>
        /// <param name="keys">The keys to compress.</param>
        void CompressTypes(
            List<string> typeIndex,
            params (string key, Action<string> transformedKey)[] keys);

        /// <summary>
        /// Recursively compresses types in the type index.
        /// </summary>
        /// <param name="typeIndex">The type index to compress.</param>
        void CompressTypeIndex(List<string> typeIndex);

        /// <summary>
        /// Decompress the types in a list.
        /// </summary>
        /// <param name="typeIndex">The index of existing types.</param>
        /// <param name="keys">The keys to decompress.</param>
        void DecompressTypes(
            List<string> typeIndex,
            params (string key, Action<string> transformedKey)[] keys);
    }
}
