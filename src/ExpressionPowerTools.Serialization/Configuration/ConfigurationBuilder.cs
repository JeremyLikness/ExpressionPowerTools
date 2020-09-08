// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Configuration
{
    /// <summary>
    /// Configuration builder for wiring up configuration fluently.
    /// </summary>
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        /// <summary>
        /// The <see cref="SerializationState"/> to build up.
        /// </summary>
        private readonly SerializationState state = new SerializationState
        {
            Options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
            },
            CompressTypes = true,
        };

        /// <summary>
        /// Once <see cref="Configure"/> is called, this instance is done.
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// Configure the type compression.
        /// </summary>
        /// <param name="compressTypes">The flag indicating whether or not to compress types.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public IConfigurationBuilder CompressTypes(bool compressTypes)
        {
            CheckValidity();
            state.CompressTypes = compressTypes;
            return this;
        }

        /// <summary>
        /// Configuration complete. Return the <see cref="SerializationState"/>.
        /// </summary>
        /// <returns>The <see cref="SerializationState"/>.</returns>
        public SerializationState Configure()
        {
            isValid = false;
            return state;
        }

        /// <summary>
        /// Sets the <see cref="JsonSerializerOptions"/>.
        /// </summary>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public IConfigurationBuilder WithJsonSerializerOptions(JsonSerializerOptions options)
        {
            state.Options = options;
            return this;
        }

        /// <summary>
        /// Checks whether configuration is still valid.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when already configured.</exception>
        private void CheckValidity()
        {
            if (!isValid)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
