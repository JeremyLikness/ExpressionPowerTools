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
    /// Client extensions for remote queries.
    /// </summary>
    /// <remarks>
    /// There are a few steps involved to run and resolve a remote query. See examples for more information.
    /// </remarks>
    /// <example>
    /// The first step is to register the client. The client uses <see cref="IHttpClientFactory"/> to register a
    /// typed instance of <see cref="IRemoteQueryClient"/> for processing. This requires a base address to make calls.
    /// <code lang="csharp"><![CDATA[
    /// builder.Services.AddExpressionPowerToolsEFCore(new Uri(builder.HostEnvironment.BaseAddress));
    /// ]]></code>
    /// This is typically done in the <c>Program.cs</c> for Blazor WebAssembly. It should be part of initialization as it
    /// configures the internal dependency injection service (<see cref="ServiceHost"/>). You must have a reference to the
    /// <c>DbContext</c> (it is used for the shape of the query and never run on the client). Use the <see cref="DbClientContext{TContext}"/>
    /// to start your query by referencing a root collection to use.
    /// <code lang="csharp"><![CDATA[
    /// var query = DbClientContext<ThingContext>.Query(context => context.Things)
    ///     .Where(t => t.IsActive == ActiveFlag &&
    ///         EF.Functions.Like(t.Name, $"%{nameFilter}%"))
    ///     .OrderBy(t => EF.Property<DateTime>(t, nameof(Thing.Created)));
    /// ]]></code>
    /// When you are ready to execute the query remotely, use the <c>ExecuteRemote</c> extension
    /// and specify the collection type, a single item, or count.
    /// <code lang="csharp"><![CDATA[
    /// var result = await query.ExecuteRemote().ToListAsync();
    /// ]]></code>
    /// </example>
    public static class ClientExtensions
    {
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
            return ServiceHost.GetService<IRemoteQueryResolver>().CountAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
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
            return ServiceHost.GetService<IRemoteQueryResolver>().FirstOrSingleAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
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
            return ServiceHost.GetService<IRemoteQueryResolver>().ToArrayAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
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
            return ServiceHost.GetService<IRemoteQueryResolver>().ToListAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
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
            return ServiceHost.GetService<IRemoteQueryResolver>().ToHashSetAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
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
            return ServiceHost.GetService<IRemoteQueryResolver>().AsEnumerableAsync(query as RemoteQuery<T, RemoteQueryProvider<T>>);
        }
    }
}
