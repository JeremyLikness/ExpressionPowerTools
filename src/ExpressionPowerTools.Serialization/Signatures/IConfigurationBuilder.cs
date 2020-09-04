// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Configuration builder for <see cref="SerializationState"/>.
    /// </summary>
    public interface IConfigurationBuilder
    {
        /// <summary>
        /// Adds the <see cref="JsonSerializerOptions"/> to the options.
        /// </summary>
        /// <param name="options">The <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The chainable <see cref="IConfigurationBuilder"/>.</returns>
        IConfigurationBuilder WithJsonSerializerOptions(JsonSerializerOptions options);

        /// <summary>
        /// Sets the flag to indicate whether types should be compressed.
        /// </summary>
        /// <param name="compressTypes">The flag indicating whether types should be compressed.</param>
        /// <returns>The chainable <see cref="IConfigurationBuilder"/>.</returns>
        IConfigurationBuilder CompressTypes(bool compressTypes);

        /// <summary>
        /// Takes the configuration and returns the serialization state.
        /// </summary>
        /// <returns>The built-up <see cref="SerializationState"/>.</returns>
        SerializationState Configure();
    }
}
