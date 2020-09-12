// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Extensions
{
    /// <summary>
    /// Helper extensions for remote query capabilities.
    /// </summary>
    public static class ClientExtensions
    {
        /// <summary>
        /// Service to fetch the query.
        /// </summary>
        private static Lazy<IRemoteQueryResolver> resolver =
            ServiceHost.GetLazyService<IRemoteQueryResolver>();

        /// <summary>
        /// Takes an enumerable and builds a host for remote processing.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="source">The source to parse.</param>
        /// <param name="context">The context of the query.</param>
        /// <returns>The <see cref="RemoteQuery{T, TProvider}"/>.</returns>
        public static IQueryable<T> AsRemoteQueryable<T>(this IEnumerable<T> source, RemoteContext context)
        {
            var query = source.AsQueryable();
            var provider = new RemoteQueryProvider<T>(source.AsQueryable(), context);
            return new RemoteQuery<T, RemoteQueryProvider<T>>(query.Expression, provider);
        }

        /// <summary>
        /// Adds the client and provides the opportunity to configure it.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/> to extend.</param>
        /// <param name="baseAddress">The base address of the client. This should only incude the scheme, domain, and ports. Use
        /// the "configure" option to modify the path to the server middleware.</param>
        /// <param name="configure">The optional configuration.</param>
        public static void AddExpressionPowerToolsEFCore(
            this IServiceCollection collection,
            Uri baseAddress,
            Action<IClientHttpConfiguration> configure = null)
        {
            ServiceHost.Reset();
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            collection.AddHttpClient<IRemoteQueryClient, RemoteQueryClient>(
                client => client.BaseAddress = baseAddress);
            IServiceProvider BuildSp() => collection.BuildServiceProvider();
            config.SetClientFactory(() => BuildSp().GetService<IRemoteQueryClient>());
            configure?.Invoke(config);
        }

        /// <summary>
        /// Use this to indicate you are about to run a remote query.
        /// </summary>
        /// <param name="query">The query to run remotely.</param>
        /// <returns>The remote query.</returns>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when query is null.</exception>
        /// <exception cref="NullReferenceException">Thrown when query is not a remote query.</exception>
        public static IRemoteQueryable<T> ExecuteRemote<T>(this IQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            var result = query as RemoteQuery<T, RemoteQueryProvider<T>>;
            Ensure.VariableNotNull(() => result);
            return result;
        }

        /// <summary>
        /// Provides a count of the query.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result.</returns>
        public static Task<int> CountAsync<T>(this IRemoteQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            return resolver.Value.CountAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }

        /// <summary>
        /// Grabs the first item, or the single item, from the result.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result.</returns>
        public static Task<T> FirstOrSingleAsync<T>(this IRemoteQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            return resolver.Value.FirstOrSingleAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }

        /// <summary>
        /// Grabs the array.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result.</returns>
        public static Task<T[]> ToArrayAsync<T>(this IRemoteQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            return resolver.Value.ToArrayAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }

        /// <summary>
        /// Grabs the list.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result.</returns>
        public static Task<IList<T>> ToListAsync<T>(this IRemoteQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            return resolver.Value.ToListAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }

        /// <summary>
        /// Grabs the hash set.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result.</returns>
        public static Task<HashSet<T>> ToHashSetAsync<T>(this IRemoteQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            return resolver.Value.ToHashSetAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }

        /// <summary>
        /// Grabs the enumerable.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result.</returns>
        public static Task<IEnumerable<T>> AsEnumerableAsync<T>(this IRemoteQueryable<T> query)
        {
            Ensure.NotNull(() => query);
            return resolver.Value.AsEnumerableAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }
    }
}
