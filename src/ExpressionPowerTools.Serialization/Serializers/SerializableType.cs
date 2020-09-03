// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Text.Json.Serialization;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializable type. Handles recursive generic arguments.
    /// </summary>
    [Serializable]
    public struct SerializableType
    {
        /// <summary>
        /// Gets or sets the full type name.
        /// </summary>
        [JsonIgnore]
        public string FullTypeName { get; set; }

        /// <summary>
        /// Gets or sets the full name of the type.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the type parameter name.
        /// </summary>
        public string TypeParamName { get; set; }

        /// <summary>
        /// Gets or sets the list of generic type arguments for the type.
        /// </summary>
        public SerializableType[] GenericTypeArguments { get; set; }

        /// <summary>
        /// Overload to show type.
        /// </summary>
        /// <returns>The first usable string it finds.</returns>
        public override string ToString() => FullTypeName ?? TypeName ?? TypeParamName ?? string.Empty;

        /// <summary>
        /// Gets the hash code for the type.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <summary>
        /// Gets equality for serializable type.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>A value indicating whether the serializable types are equal.</returns>
        public override bool Equals(object obj) =>
            obj is SerializableType otherType &&
            GetHashCode() == otherType.GetHashCode();
    }
}
