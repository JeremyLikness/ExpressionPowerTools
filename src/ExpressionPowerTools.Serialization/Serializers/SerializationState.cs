// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Xml.Linq;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// State info passed recurisvely through the serialization process.
    /// </summary>
    public class SerializationState
    {
        private HashSet<ParameterExpression> parameters;

        /// <summary>
        /// Gets or sets the query root to build the query from.
        /// </summary>
        public Expression QueryRoot { get; set; }

        /// <summary>
        /// Gets or sets the optional <see cref="JsonSerializerOptions"/>.
        /// </summary>
        public JsonSerializerOptions Options { get; set; }

        /// <summary>
        /// Retrieves a <see cref="ParameterExpression"/> of the same type
        /// and name from cache, or inserts the new <see cref="ParameterExpression"/>.
        /// </summary>
        /// <param name="expr">The <see cref="ParameterExpression"/> to parse.</param>
        /// <returns>The <see cref="ParameterExpression"/> or its cached version.</returns>
        public ParameterExpression GetOrCacheParameter(ParameterExpression expr)
        {
            parameters = parameters ?? new HashSet<ParameterExpression>();
            var cachedExpression = parameters
                .SingleOrDefault(
                p => p.Name == expr.Name &&
                p.Type == expr.Type);
            if (cachedExpression != null)
            {
                return cachedExpression;
            }

            parameters.Add(expr);
            return expr;
        }
    }
}
