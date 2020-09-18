// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Dynamic;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Wrapper for newing an anonymous expression.
    /// </summary>
    /// <remarks>
    /// This type exists so that an existing anonymous type initialization can be intercepted for serialization. On deserialization
    /// it is turned into an <see cref="ExpandoObject"/>.
    /// </remarks>
    public class AnonInitializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnonInitializer"/> class.
        /// </summary>
        public AnonInitializer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonInitializer"/> class.
        /// </summary>
        /// <param name="typeName">The anonymous type name.</param>
        /// <param name="propertyNames">The proprty names.</param>
        /// <param name="values">The values.</param>
        public AnonInitializer(string typeName, string[] propertyNames, AnonValue[] values)
        {
            AnonValue = new AnonType
            {
                AnonymousTypeName = typeName,
                PropertyNames = propertyNames,
                PropertyValues = values,
            };
        }

        /// <summary>
        /// Gets the anonymous type.
        /// </summary>
        public AnonType AnonValue { get; }
    }
}
