// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using Microsoft.Extensions.Logging;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware
{
    /// <summary>
    /// Resonsible for deserializing the query to run.
    /// </summary>
    public class QueryDeserializer : IQueryDeserializer
    {
        /// <summary>
        /// Deserializes the query.
        /// </summary>
        /// <param name="template">The <see cref="IQueryable"/> to run.</param>
        /// <param name="json">The stream with json info.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>The <see cref="IQueryable"/> result.</returns>
        public async Task<QueryResult> DeserializeAsync(
            IQueryable template,
            Stream json,
            ILogger logger = null)
        {
            Ensure.NotNull(() => template);
            Ensure.NotNull(() => json);
            var request = await JsonSerializer.DeserializeAsync<SerializationPayload>(json);
            Ensure.VariableNotNull(() => request);
            Ensure.NotNullOrWhitespace(() => request.Json);
            if (logger != null)
            {
                logger.LogInformation($"Query payload: {request.Json}");
            }

            var query = Serializer.DeserializeQuery(template, request.Json);
            if (logger != null)
            {
                logger.LogInformation($"Deserialized query: {query.Expression}");
            }

            return new QueryResult
            {
                Query = query,
                QueryType = request.GetQueryType(),
            };
        }
    }
}
