// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Holds the default configuration for serializatoin.
    /// </summary>
    public interface IDefaultConfiguration
    {
        /// <summary>
        /// Sets the default state.
        /// </summary>
        void SetDefaultState(Func<IConfigurationBuilder, SerializationState> builder);

        /// <summary>
        /// Gets the default state.
        /// </summary>
        SerializationState GetDefaultState();
    }
}
