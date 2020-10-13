// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.Http.Configuration;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Transport
{
    /// <summary>
    /// Handles remote requests.
    /// </summary>
    public class HttpRemoteQueryResolver : IRemoteQueryResolver
    {
        /// <summary>
        /// Delegate to retrieve the default options. Register your own to override.
        /// </summary>
        private readonly Lazy<Func<JsonSerializerOptions>> jsonOptions =
            ServiceHost.GetLazyService<Func<JsonSerializerOptions>>();

        /// <summary>
        /// The JSON serializer.
        /// </summary>
        private readonly Lazy<ISerializationWrapper<string, JsonSerializerOptions, JsonSerializerOptions>>
            jsonSerializer = ServiceHost.GetLazyService<ISerializationWrapper<string, JsonSerializerOptions, JsonSerializerOptions>>();

        /// <summary>
        /// Execute the remote query and materialize the results.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The base query to run.</param>
        /// <returns>The result.</returns>
        public async Task<IEnumerable<T>> AsEnumerableAsync<T>(IQueryable<T> query) =>
            (await ToArrayAsync(query)).AsEnumerable();

        /// <summary>
        /// Execute the remote query and materialize the single item.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The base query to run.</param>
        /// <returns>The result.</returns>
        public async Task<T> FirstOrSingleAsync<T>(IQueryable<T> query)
        {
            var contentJson = await GetRemoteContentAsync(query, PayloadType.Single);
            var options = GetJsonSerializerOptions();
            if (string.IsNullOrWhiteSpace(contentJson))
            {
                return default;
            }

            var responseContent = JsonSerializer.Deserialize<T>(contentJson, options);
            return responseContent;
        }

        /// <summary>
        /// Execute the remote query and materialize the count.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The base query to run.</param>
        /// <returns>The result.</returns>
        public async Task<int> CountAsync<T>(IQueryable<T> query)
        {
            var contentJson = await GetRemoteContentAsync(query, PayloadType.Count);
            var options = GetJsonSerializerOptions();
            if (string.IsNullOrWhiteSpace(contentJson))
            {
                return -1;
            }

            var responseContent = JsonSerializer.Deserialize<int>(contentJson, options);
            return responseContent;
        }

        /// <summary>
        /// Execute the remote query and materialize the results.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The base query to run.</param>
        /// <returns>The result.</returns>
        public async Task<T[]> ToArrayAsync<T>(IQueryable<T> query)
        {
            var contentJson = await GetRemoteContentAsync(query);
            var options = GetJsonSerializerOptions();
            if (string.IsNullOrWhiteSpace(contentJson))
            {
                return new T[0];
            }

            var responseContent = JsonSerializer.Deserialize<T[]>(contentJson, options);
            return responseContent;
        }

        /// <summary>
        /// Execute the remote query and materialize the results.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The base query to run.</param>
        /// <returns>The result.</returns>
        public async Task<HashSet<T>> ToHashSetAsync<T>(IQueryable<T> query) =>
            new HashSet<T>(await ToArrayAsync(query));

        /// <summary>
        /// Execute the remote query and materialize the results.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The base query to run.</param>
        /// <returns>The result.</returns>
        public async Task<List<T>> ToListAsync<T>(IQueryable<T> query) =>
            new List<T>(await ToArrayAsync(query));

        /// <summary>
        /// Main method to resolve remote content.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="type">The type of payload.</param>
        /// <returns>The remote content as Json.</returns>
        /// <exception cref="ArgumentNullException">Thrown when query is null.</exception>
        /// <exception cref="ArgumentException">Thrown when query is not <see cref="IRemoteQuery"/>.</exception>
        private async Task<string> GetRemoteContentAsync<T>(IQueryable<T> query, PayloadType type = PayloadType.Array)
        {
            Ensure.NotNull(() => query);

            if (!(query is IRemoteQuery remoteQuery))
            {
                throw new ArgumentException(
                    $"{query.GetType()} => {typeof(IRemoteQuery)}",
                    nameof(query));
            }

            var serializationRoot = QueryExprSerializer.Serialize(query);
            var options = GetJsonSerializerOptions();
            var json = jsonSerializer.Value.FromSerializationRoot(serializationRoot, options);
            var payload = new SerializationPayload(type)
            {
                Json = json,
            };

            var transportPayload = JsonSerializer.Serialize(payload, options);
            var requestContent = new StringContent(transportPayload);
            var path = PathTransformer(remoteQuery);
            var client = GetHttpClient();

            var contentJson = await client.FetchRemoteQueryAsync(path, requestContent);
            return contentJson;
        }

        /// <summary>
        /// Transforms the path using the template.
        /// </summary>
        /// <param name="query">The <see cref="IRemoteQuery"/>.</param>
        /// <returns>The transformed path.</returns>
        private string PathTransformer(IRemoteQuery query)
        {
            var context = query.CustomProvider.Context;
            var clientHttpConfiguration = ServiceHost.GetService<IClientHttpConfiguration>();
            var template = clientHttpConfiguration.PathTemplate;
            return template
                .Replace(ClientHttpConfiguration.ContextKey, context.Context.Name)
                .Replace(ClientHttpConfiguration.CollectionKey, context.Collection.Name);
        }

        /// <summary>
        /// Gets the <see cref="JsonSerializerOptions"/>.
        /// </summary>
        private JsonSerializerOptions GetJsonSerializerOptions() =>
            jsonOptions.Value();

        /// <summary>
        /// Gets the client instance.
        /// </summary>
        /// <returns>The <see cref="HttpClient"/>.</returns>
        private IRemoteQueryClient GetHttpClient() =>
            ServiceHost.GetService<IClientHttpConfiguration>()
            .ClientFactory();
    }
}
