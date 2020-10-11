// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Configuration
{
    /// <summary>
    /// The default configuration used when none is explicitly provided.
    /// </summary>
    public class DefaultConfiguration : IDefaultConfiguration
    {
        /// <summary>
        /// Synchronization.
        /// </summary>
        private readonly object lockObj = new object();

        /// <summary>
        /// Holds the default state.
        /// </summary>
        private SerializationState defaultState;

        /// <summary>
        /// Gets a new <see cref="SerializationState"/> with default options.
        /// </summary>
        /// <remarks>
        /// The default configuration is transferred to a new instance of <see cref="SerializationState"/>
        /// to prevent side effects (i.e. manipulation of the state affecting the default).
        /// </remarks>
        /// <returns>The <see cref="SerializationState"/>.</returns>
        public SerializationState GetDefaultState()
        {
            if (defaultState == null)
            {
                lock (lockObj)
                {
                    if (defaultState == null)
                    {
                        defaultState = ServiceHost.GetService<IConfigurationBuilder>().Configure();
                    }
                }
            }

            SerializationState state;

            lock (lockObj)
            {
                state = new SerializationState
                {
                    CompressTypes = defaultState.CompressTypes,
                    CompressExpression = defaultState.CompressExpression,
                    Options = defaultState.Options,
                };
            }

            return state;
        }

        /// <summary>
        /// Uses the configuration builder to configure the default state.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        public void SetDefaultState(Action<IConfigurationBuilder> builder)
        {
            var config = ServiceHost.GetService<IConfigurationBuilder>();
            builder(config);
            lock (lockObj)
            {
                defaultState = config.Configure();
            }
        }
    }
}
