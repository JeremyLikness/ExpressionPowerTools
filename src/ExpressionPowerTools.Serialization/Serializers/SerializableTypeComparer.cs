// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Type comparer for <see cref="SerializableType"/>.
    /// </summary>
    public class SerializableTypeComparer : IEqualityComparer<SerializableType>
    {
        /// <summary>
        /// Equality between types.
        /// </summary>
        /// <param name="x">The <see cref="SerializableType"/> to reference.</param>
        /// <param name="y">The <see cref="SerializableType"/> to compare.</param>
        /// <returns>A flag indicating whether the types are equal.</returns>
        public bool Equals(SerializableType x, SerializableType y)
        {
            if (!string.IsNullOrWhiteSpace(x.FullTypeName))
            {
                return x.FullTypeName == y.FullTypeName;
            }

            return x.ToString() == y.ToString();
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <param name="obj">The <see cref="SerializableType"/> to reference.</param>
        /// <returns>The hash code.</returns>
        public int GetHashCode(SerializableType obj) => obj.GetHashCode();
    }
}
