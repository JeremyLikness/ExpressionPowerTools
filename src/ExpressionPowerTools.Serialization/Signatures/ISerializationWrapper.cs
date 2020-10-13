// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// The type of serialization.
    /// </summary>
    public enum SerializationType
    {
        /// <summary>
        /// Base serialization returns a <see cref="SerializableExpression"/>.
        /// </summary>
        Base,

        /// <summary>
        /// Uses <see cref="JsonSerializer"/>.
        /// </summary>
        SystemTextJson,
    }

    /// <summary>
    /// Wrapper for serialization of a specific type.
    /// </summary>
    /// <typeparam name="T">The type that the serializer deals with.</typeparam>
    /// <typeparam name="TSerializeOptions">Any options needed for the serializer.</typeparam>
    /// <typeparam name="TDeserializeOptions">Any options needed for the deserializer.</typeparam>
    public interface ISerializationWrapper<T, TSerializeOptions, TDeserializeOptions>
        where TSerializeOptions : class
        where TDeserializeOptions : class
    {
        /// <summary>
        /// Serialize the root.
        /// </summary>
        /// <param name="root">The <see cref="SerializationRoot"/>.</param>
        /// <param name="options">The options.</param>
        /// <returns>The target type for the serializer.</returns>
        T FromSerializationRoot(SerializationRoot root, TSerializeOptions options = null);

        /// <summary>
        /// Deserialize the root.
        /// </summary>
        /// <param name="serialized">The serialized expression.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="SerializationRoot"/>.</returns>
        SerializationRoot ToSerializationRoot(T serialized, TDeserializeOptions options = null);
    }
}
