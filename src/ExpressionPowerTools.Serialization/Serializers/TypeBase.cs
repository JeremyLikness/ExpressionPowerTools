// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Simple class to represent type information. Never serialized, but
    /// used for key calculation.
    /// </summary>
    public class TypeBase : MemberBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeBase"/> class initialized
        /// with a type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to intialize with.</param>
        public TypeBase(Type type)
        {
            DeclaringType = SerializeType(type);
        }

        /// <summary>
        /// Gets or sets the <see cref="MemberTypes"/> value.
        /// </summary>
        public override int MemberType
        {
            get => (int)MemberTypes.All;
            set { }
        }

        /// <summary>
        /// Calculates the unique key.
        /// </summary>
        /// <returns>The key.</returns>
        public override string CalculateKey() => DeclaringType.FullTypeName;
    }
}
