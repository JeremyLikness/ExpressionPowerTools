// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Top-level serializer that passes work off to specific types.
    /// </summary>
    /// <remarks>
    /// The constructor for this class scans the assembly for serializers tagged with
    /// <see cref="ExpressionSerializerAttribute"/>. These are loaded based on the
    /// <see cref="ExpressionType"/> they represent and stored as <see cref="IBaseSerializer"/>.
    /// The serializers should be accessed through the static <see cref="Serializer"/> class,
    /// which takes the serializable classes and serializes them to and from JSON.
    /// </remarks>
    public class ExpressionSerializer : IExpressionSerializer<Expression, SerializableExpression>
    {
        /// <summary>
        /// The constant serializer.
        /// </summary>
        private readonly IDictionary<string, IBaseSerializer> serializers =
            new Dictionary<string, IBaseSerializer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionSerializer"/> class.
        /// </summary>
        public ExpressionSerializer()
        {
            var types = GetType().Assembly.GetTypes()
                .Where(t => t.Namespace == typeof(BaseSerializer).Namespace
                    && t.GetCustomAttributes(false)
                    .Any(c => c is ExpressionSerializerAttribute))
                .SelectMany(t => t.GetCustomAttributes(false).OfType<ExpressionSerializerAttribute>()
                    .Select(c => new { serializer = t, type = c.Type.ToString() }));

            var activated = new Dictionary<Type, IBaseSerializer>();

            foreach (var type in types)
            {
                if (!activated.ContainsKey(type.serializer))
                {
                    activated[type.serializer] = (IBaseSerializer)Activator.CreateInstance(type.serializer, this);
                }

                serializers.Add(type.type, activated[type.serializer]);
            }
        }

        /// <summary>
        /// Deserialize an <see cref="Expression"/>.
        /// </summary>
        /// <param name="json">The fragment to deserialize.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public Expression Deserialize(JsonElement json)
        {
            var type = json.GetProperty(nameof(Type)).GetString();
            if (serializers.ContainsKey(type))
            {
                return serializers[type].Deserialize(json);
            }

            return null;
        }

        /// <summary>
        /// Serialize an <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <returns>The serialized <see cref="SerializableExpression"/>.</returns>
        public SerializableExpression Serialize(Expression expression)
        {
            if (expression == null)
            {
                return null;
            }

            var type = expression.NodeType.ToString();
            if (serializers.ContainsKey(type))
            {
                return serializers[type].Serialize(expression);
            }

            return new SerializableExpression(expression);
        }
    }
}
