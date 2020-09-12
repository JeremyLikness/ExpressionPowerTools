// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Text.Json.Serialization;

namespace ExpressionPowerTools.Serialization
{
    /// <summary>
    /// The payload type of the serialization request.
    /// </summary>
    public enum PayloadType
    {
        /// <summary>
        /// Result is an array.
        /// </summary>
        Array = 0,

        /// <summary>
        /// Result is a single item.
        /// </summary>
        Single = 1,

        /// <summary>
        /// Result is a count.
        /// </summary>
        Count = 2,
    }

    /// <summary>
    /// The serialization payload.
    /// </summary>
    [Serializable]
    public class SerializationPayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationPayload"/> class.
        /// </summary>
        public SerializationPayload()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationPayload"/> class.
        /// </summary>
        /// <param name="type">The type of the payload.</param>
        public SerializationPayload(PayloadType type)
        {
            QueryType = (int)type;
        }

        /// <summary>
        /// Gets or sets the Json payload.
        /// </summary>
        public string Json { get; set; }

        /// <summary>
        /// Gets or sets the query type.
        /// </summary>
        /// <remarks>
        /// Defaults to array.
        /// </remarks>
        public int QueryType { get; set; } = (int)PayloadType.Array;

        /// <summary>
        /// Gets the query type.
        /// </summary>
        /// <returns>The <see cref="PayloadType"/>.</returns>
        public PayloadType GetQueryType() => (PayloadType)QueryType;
    }
}
