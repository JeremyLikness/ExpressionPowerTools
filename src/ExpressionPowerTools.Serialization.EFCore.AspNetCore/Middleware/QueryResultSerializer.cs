// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware
{
    /// <summary>
    /// Responsible for serializing the result to send back.
    /// </summary>
    public class QueryResultSerializer : IQueryResultSerializer
    {
        /// <summary>
        /// Count method.
        /// </summary>
        private readonly MethodInfo count = typeof(Queryable).GetMethods()
            .First(m => m.Name == nameof(Queryable.Count)
                && m.IsGenericMethodDefinition
                && m.GetParameters().Length == 1);

        /// <summary>
        /// ToArray() method.
        /// </summary>
        private readonly MethodInfo toArray = typeof(Enumerable).GetMethods()
            .First(m => m.Name == nameof(Enumerable.ToArray)
                && m.IsGenericMethodDefinition
                && m.GetParameters().Length == 1);

        /// <summary>
        /// Serializes the result of a query to the stream.
        /// </summary>
        /// <param name="response">The <see cref="Stream"/> for the response.</param>
        /// <param name="query">The <see cref="IQueryable"/> to resolve.</param>
        /// <param name="isCount">A value indicating whether the result should be a count.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SerializeAsync(
            Stream response,
            IQueryable query,
            bool isCount = false)
        {
            Ensure.NotNull(() => response);
            Ensure.NotNull(() => query);

            object result;
            var typeList = new[] { query.ElementType };
            var parameters = new object[] { query };

            if (isCount)
            {
                var countMethod = count.MakeGenericMethod(typeList);
                result = countMethod.Invoke(null, parameters);
            }
            else
            {
                var arrayMethod = toArray.MakeGenericMethod(typeList);
                result = arrayMethod.Invoke(null, parameters);
            }

            var json = JsonSerializer.Serialize(result);
            var bytes = Encoding.UTF8.GetBytes(json);
            return response.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
