// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// State info passed recurisvely through the serialization process.
    /// </summary>
    public class SerializationState
    {
        /// <summary>
        /// The compressor.
        /// </summary>
        private ITypesCompressor compressor;

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
        /// Gets the compressor.
        /// </summary>
        private ITypesCompressor Compressor
        {
            get
            {
                if (compressor == null)
                {
                    compressor = ServiceHost.GetService<ITypesCompressor>();
                }

                return compressor;
            }
        }

        /// <summary>
        /// Called at the end of serialization.
        /// </summary>
        public void Done()
        {
            if (CompressTypes)
            {
                Compressor.CompressTypeIndex(TypeIndex);
            }
        }

        /// <summary>
        /// Method to compress types for the key.
        /// </summary>
        /// <param name="keys">The list of keys and callbacks.</param>
        public void CompressTypesForKeys(params (string key, Action<string> keyFn)[] keys)
        {
            if (CompressTypes)
            {
                Compressor.CompressTypes(TypeIndex, keys);
            }
        }

        /// <summary>
        /// Compress a single key.
        /// </summary>
        /// <param name="keyToCompress">The key to compress.</param>
        /// <returns>The compressed key.</returns>
        public string CompressTypesforKey(string keyToCompress)
        {
            var result = keyToCompress;
            if (CompressTypes)
            {
                Compressor.CompressTypes(TypeIndex, (keyToCompress, key => result = key));
            }

            return result;
        }

        /// <summary>
        /// Method to decompress types for the key.
        /// </summary>
        /// <param name="keys">The list of keys and callbacks.</param>
        public void DecompressTypesForKeys(params (string key, Action<string> keyFn)[] keys)
        {
            if (CompressTypes)
            {
                Compressor.DecompressTypes(TypeIndex, keys);
            }
        }

        /// <summary>
        /// Decompress a single key.
        /// </summary>
        /// <param name="keyToDecompress">The key to decompress.</param>
        /// <returns>The decompressed key.</returns>
        public string DecompressTypesForKey(string keyToDecompress)
        {
            var result = keyToDecompress;
            if (CompressTypes)
            {
                Compressor.DecompressTypes(TypeIndex, (keyToDecompress, key => result = key));
            }

            return result;
        }

        /// <summary>
        /// Gets the expression tree that was deserialized.
        /// </summary>
        /// <remarks>
        /// Used mainly for troubleshooting.
        /// </remarks>
        /// <param name="preventReset">A value indicating whether the expression should be reset or ont.</param>
        /// <returns>The expression tree.</returns>
        public string GetExpressionTree(bool preventReset = false)
        {
            if (LastExpression == null)
            {
                return string.Empty;
            }

            var result = LastExpression.AsEnumerable().ToString();

            if (!preventReset)
            {
                LastExpression = null;
            }

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
