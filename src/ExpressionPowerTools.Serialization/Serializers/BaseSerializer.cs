// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Base class for serializers.
    /// </summary>
    public abstract class BaseSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSerializer"/> class with a default serializer.
        /// </summary>
        /// <param name="serializer">The default serializer.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when serializer is null.</exception>
        public BaseSerializer(
            IExpressionSerializer<Expression, SerializableExpression> serializer)
        {
            Ensure.NotNull(() => serializer);
            Serializer = serializer;
         }

        /// <summary>
        /// Gets the anonymous type name.
        /// </summary>
        protected string AnonymousType => nameof(AnonymousType);

        /// <summary>
        /// Gets the default <see cref="IExpressionSerializer{T, TSerializable}"/>.
        /// </summary>
        protected IExpressionSerializer<Expression, SerializableExpression> Serializer { get; private set; }

        /// <summary>
        /// Gets the <see cref="ExpressionType"/> from the string representation.
        /// </summary>
        /// <param name="type">The string representation of the <see cref="ExpressionType"/>.</param>
        /// <returns>The <see cref="ExpressionType"/>.</returns>
        protected ExpressionType GetExpressionTypeFor(string type)
        {
            if (Enum.TryParse(type, out ExpressionType result))
            {
                return result;
            }

            return default;
        }
    }
}
