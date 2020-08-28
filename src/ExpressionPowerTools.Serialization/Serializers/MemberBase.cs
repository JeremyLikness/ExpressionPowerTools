// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Base class to serialize a member.
    /// </summary>
    public abstract class MemberBase
    {
        /// <summary>
        /// Gets or sets the type of the member. See <see cref="MemberTypes"/> for options.
        /// </summary>
        public abstract string MemberType { get; set; }

        /// <summary>
        /// Gets or sets the declaring type.
        /// </summary>
        public SerializableType DeclaringType { get; set; }

        /// <summary>
        /// Gets or sets the return type.
        /// </summary>
        public SerializableType MemberValueType { get; set; }

        /// <summary>
        /// Gets or sets the hash of the reflected type.
        /// </summary>
        public SerializableType ReflectedType { get; set; }

        /// <summary>
        /// Gets or sets the unique key.
        /// </summary>
        private string Key { get; set; }

        /// <summary>
        /// Calculate the unique key.
        /// </summary>
        /// <returns>A unique key for the member.</returns>
        public abstract string CalculateKey();

        /// <summary>
        /// Gets the unique key for the member.
        /// </summary>
        /// <returns>The unique key.</returns>
        public string GetKey()
        {
            if (!string.IsNullOrWhiteSpace(Key))
            {
                return Key;
            }

            Key = CalculateKey();
            return Key;
        }

        /// <summary>
        /// Helper to serialize a type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to serialize.</param>
        /// <returns>The <see cref="SerializableType"/>.</returns>
        protected SerializableType SerializeType(Type type) =>
            ReflectionHelper.Instance.SerializeType(type);

        /// <summary>
        /// Helper to get the full name of a type.
        /// </summary>
        /// <param name="serializableType">The <see cref="SerializableType"/> to get the name for.</param>
        /// <returns>The full name of the type.</returns>
        protected string GetFullNameOfType(SerializableType serializableType) =>
            ReflectionHelper.Instance.GetFullTypeName(serializableType);
    }
}
