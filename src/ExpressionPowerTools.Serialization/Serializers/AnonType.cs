// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Adapter for anonymous types.
    /// </summary>
    [Serializable]
    public class AnonType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnonType"/> class.
        /// </summary>
        public AnonType()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonType"/> class
        /// with an anonymous type.
        /// </summary>
        /// <param name="anonymous">The anonymous type.</param>
        /// <param name="getKey">Function to get key for type.</param>
        public AnonType(
            object anonymous,
            Func<Type, string> getKey)
        {
            Ensure.NotNull(() => anonymous);
            AnonymousTypeKey = getKey(anonymous.GetType());
            foreach (var prop in anonymous.GetType().GetProperties())
            {
                var type = prop.PropertyType;
                var value = prop.GetValue(anonymous);
                var name = prop.Name;

                if (prop.PropertyType.IsAnonymousType())
                {
                    type = typeof(AnonType);
                    value = new AnonType(
                        value,
                        getKey);
                }

                var anonTypeKey = getKey(type);
                Types.Add(anonTypeKey);
                Names.Add(name);
                Values.Add(value);
            }
        }

        /// <summary>
        /// Gets or sets the anonymous type key.
        /// </summary>
        public string AnonymousTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        public List<string> Types { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the property names.
        /// </summary>
        public List<string> Names { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        public List<object> Values { get; set; } = new List<object>();
    }
}
