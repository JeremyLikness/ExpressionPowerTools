// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Adapter to serialize and deserialize anonymous types.
    /// </summary>
    public interface IAnonymousTypeAdapter
    {
        /// <summary>
        /// Encapsulates an anonymous type for serialization.
        /// </summary>
        /// <param name="anonymousInstance">The instance to convert.</param>
        /// <returns>The <see cref="AnonType"/>.</returns>
        AnonType ConvertToAnonType(object anonymousInstance);

        /// <summary>
        /// Reconstructs an anonymous type from <see cref="AnonType"/>.
        /// </summary>
        /// <param name="anonType">The <see cref="AnonType"/>.</param>
        /// <returns>The anonymous type instance.</returns>
        object ConvertFromAnonType(AnonType anonType);
    }
}
