// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Serialization
{
    /// <summary>
    /// The serialization payload.
    /// </summary>
    [Serializable]
    public class SerializationPayload
    {
        /// <summary>
        /// Gets or sets the Json payload.
        /// </summary>
        public string Json { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the query is intended
        /// to be a count.
        /// </summary>
        public bool IsCount { get; set; }
    }
}
