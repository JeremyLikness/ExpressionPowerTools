// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Extensions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// State info passed recurisvely through the serialization process.
    /// </summary>
    public class SerializationState
    {
        /// <summary>
        /// List of parameters to preserve across stack.
        /// </summary>
        private HashSet<ParameterExpression> parameters;

        /// <summary>
        /// Gets or sets the query root to build the query from.
        /// </summary>
        public Expression QueryRoot { get; set; }

        /// <summary>
        /// Gets or sets the last <see cref="Expression"/> serialized.
        /// </summary>
        public Expression LastExpression { get; set; }

        /// <summary>
        /// Gets or sets the optional <see cref="JsonSerializerOptions"/>.
        /// </summary>
        public JsonSerializerOptions Options { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not types are compressed. Default is <c>true</c>.
        /// </summary>
        /// <remarks>
        /// When this flag is set, instead of serializing long types, each type is indexed in a master
        /// "type index" the first time it is encountered. Subsequent references will use <c>^x</c>
        /// where <c>x</c> is the index of the type. Set this to <c>false</c> if you need to debug the
        /// serialization payload. This flag is ignored during deserialization as compressed types are
        /// automatically detected and decompressed when present.
        /// </remarks>
        public bool CompressTypes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the expression should be
        /// compressed. This will take anything not parameterized and invoke it
        /// for transport over the wire.
        /// </summary>
        public bool CompressExpression { get; set; } = true;

        /// <summary>
        /// Gets or sets the index of types.
        /// </summary>
        /// <remarks>
        /// This table is used to build a master index of types. For example, if <see cref="string"/> is
        /// referenced multiple times, the intial entry may be <c>System.String</c> and subsequent entries
        /// will reference <c>^0</c>.
        /// </remarks>
        public List<string> TypeIndex { get; set; } = new List<string>();

        /// <summary>
        /// Gets the expression tree that was deserialized.
        /// </summary>
        /// <remarks>
        /// Used mainly for troubleshooting.
        /// </remarks>
        /// <returns>The expression tree.</returns>
        public string GetExpressionTree()
        {
            if (LastExpression == null)
            {
                return string.Empty;
            }

            var result = LastExpression.AsEnumerable().ToString();
            LastExpression = null;
            return result;
        }

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

        /// <summary>
        /// Gets the parameters that were built.
        /// </summary>
        /// <returns>The parameter list.</returns>
        public ParameterExpression[] GetParameters()
        {
            return parameters.ToArray();
        }
    }
}
