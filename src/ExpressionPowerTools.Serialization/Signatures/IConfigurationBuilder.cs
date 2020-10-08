// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
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
        /// <param name="options">The default <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The chainable <see cref="IConfigurationBuilder"/>.</returns>
        IConfigurationBuilder WithJsonSerializerOptions(
            Action<JsonSerializerOptions> options);

        /// <summary>
        /// Sets the flag to indicate whether types should be compressed.
        /// </summary>
        /// <param name="compressTypes">The flag indicating whether types should be compressed.</param>
        /// <returns>The chainable <see cref="IConfigurationBuilder"/>.</returns>
        IConfigurationBuilder CompressTypes(bool compressTypes);

        /// <summary>
        /// Sets the flag to indicate whether expression trees should be partially
        /// evaluated so that local variable references aren't serialized.
        /// </summary>
        /// <param name="compressExpressionTree">The flag indicating whether the tree
        /// should be compressed.</param>
        /// <returns>The chainable <see cref="IConfigurationBuilder"/>.</returns>
        IConfigurationBuilder CompressExpressionTree(bool compressExpressionTree);

        /// <summary>
        /// Takes the configuration and returns the serialization state.
        /// </summary>
        /// <returns>The built-up <see cref="SerializationState"/>.</returns>
        SerializationState Configure();
    }
}
