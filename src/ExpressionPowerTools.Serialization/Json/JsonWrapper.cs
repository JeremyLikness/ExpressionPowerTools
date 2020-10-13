// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Json
{
    /// <summary>
    /// Wrapper for serializing/deserializing to Json using <see cref="JsonSerializer"/>.
    /// </summary>
    public class JsonWrapper : ISerializationWrapper<string, JsonSerializerOptions, JsonSerializerOptions>
    {
        /// <summary>
        /// Serialize the <see cref="SerializationRoot"/>.
        /// </summary>
        /// <param name="root">The <see cref="SerializationRoot"/>.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The serialized json in text.</returns>
        public string FromSerializationRoot(SerializationRoot root, JsonSerializerOptions options = null)
            => JsonSerializer.Serialize(root, PrepareOptions(options));

        /// <summary>
        /// Deserialize to a <see cref="SerializationRoot"/>.
        /// </summary>
        /// <param name="serialized">The serialized json.</param>
        /// <param name="options">The deserialization options.</param>
        /// <returns>The <see cref="SerializationRoot"/>.</returns>
        public SerializationRoot ToSerializationRoot(string serialized, JsonSerializerOptions options = null)
        {
            var root = JsonSerializer.Deserialize<SerializationRoot>(serialized, PrepareOptions(options));
            return root;
        }

        /// <summary>
        /// Prepares the options with the converter.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The options with the converter added.</returns>
        private JsonSerializerOptions PrepareOptions(JsonSerializerOptions options)
        {
            options = options ?? new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
            };

            var expressionConverter = new SerializableExpressionConverter();
            var anonTypeConverter = new AnonTypeConverter();
            var rootConverter = new SerializationRootConverter(expressionConverter, anonTypeConverter);
            options.Converters.Add(expressionConverter);
            options.Converters.Add(rootConverter);
            options.Converters.Add(new MemberBindingExprConverter());
            options.Converters.Add(anonTypeConverter);

            return options;
        }
    }
}
