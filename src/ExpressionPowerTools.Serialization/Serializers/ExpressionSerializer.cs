﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Dependencies;
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
    /// The serializers should be accessed through the static <see cref="Serialization.QueryExprSerializer"/> class,
    /// which takes the serializable classes and serializes them to and from JSON.
    /// </remarks>
    public class ExpressionSerializer : IExpressionSerializer<Expression, SerializableExpression>
    {
        /// <summary>
        /// The constant serializer.
        /// </summary>
        private readonly IDictionary<ExpressionType, IBaseSerializer> serializers =
            new Dictionary<ExpressionType, IBaseSerializer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionSerializer"/> class.
        /// </summary>
        public ExpressionSerializer()
        {
            var types = ServiceHost.SafeGetTypes(
                t => t.Namespace == typeof(BaseSerializer<,>).Namespace
                    && t.GetCustomAttributes(false)
                    .Any(c => c is ExpressionSerializerAttribute))
                .SelectMany(t => t.GetCustomAttributes(false).OfType<ExpressionSerializerAttribute>()
                    .Select(c => new { serializer = t, type = c.Type }));

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
        /// <param name="root">The fragment to deserialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The deserialized <see cref="Expression"/>.</returns>
        public Expression Deserialize(
            SerializableExpression root,
            SerializationState state)
        {
            var type = (ExpressionType)root.Type;
            if (serializers.ContainsKey(type))
            {
                var serializer = serializers[type];
                serializer.DecompressTypes(root, state);
                var expression = serializer.Deserialize(root, state);
                state.LastExpression = expression;
                return expression;
            }

            throw new NotSupportedException(type.ToString());
        }

        /// <summary>
        /// Serialize an <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to serialize.</param>
        /// <param name="state">State for the serialization or deserialization.</param>
        /// <returns>The serialized <see cref="SerializableExpression"/>.</returns>
        public SerializableExpression Serialize(
            Expression expression,
            SerializationState state)
        {
            if (expression == null)
            {
                return null;
            }

            SerializableExpression result = null;

            var type = expression.NodeType;
            if (serializers.ContainsKey(type))
            {
                var serializer = serializers[type];
                result = serializer.Serialize(expression, state);
                serializer.CompressTypes(result, state);
            }

            return result ?? new SerializableExpression(expression);
        }
    }
}
