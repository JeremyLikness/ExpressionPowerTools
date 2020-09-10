// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore
{
    /// <summary>
    /// Middleware for managing requests for Entity Framework Core queries.
    /// </summary>
    public class ExpressionPowerToolsEFCoreMiddleware
    {
        /// <summary>
        /// Tracks the next step in the pipeline.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// The registered <c>DbContext</c> types.
        /// </summary>
        private readonly Type[] contextTypes;

        /// <summary>
        /// The root path for the routing endpoint.
        /// </summary>
        private readonly string endpointPath;

        /// <summary>
        /// The path processing service.
        /// </summary>
        private readonly Lazy<IRouteProcessor> routeProcessor =
            ServiceHost.GetLazyService<IRouteProcessor>();

        /// <summary>
        /// The adapter to map to the <see cref="DbContext"/>.
        /// </summary>
        private readonly Lazy<IDbContextAdapter> adapter =
            ServiceHost.GetLazyService<IDbContextAdapter>();

        /// <summary>
        /// The process to deserialize the query to run.
        /// </summary>
        private readonly Lazy<IQueryDeserializer> deserializer =
            ServiceHost.GetLazyService<IQueryDeserializer>();

        /// <summary>
        /// The process to serialize the query results.
        /// </summary>
        private readonly Lazy<IQueryResultSerializer> serializer =
            ServiceHost.GetLazyService<IQueryResultSerializer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionPowerToolsEFCoreMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the processing pipeline.</param>
        /// <param name="path">The path configured for the endpoint.</param>
        /// <param name="dbContextTypes">The list of eligible context types.</param>
        public ExpressionPowerToolsEFCoreMiddleware(
            RequestDelegate next,
            string path,
            Type[] dbContextTypes)
        {
            Ensure.NotNull(() => next);
            Ensure.NotNullOrWhitespace(() => path);
            Ensure.NotNull(() => dbContextTypes);
            if (dbContextTypes.Length < 1 ||
                dbContextTypes.Any(t => !typeof(DbContext).IsAssignableFrom(t)))
            {
                throw new ArgumentException($"{dbContextTypes}", nameof(dbContextTypes));
            }

            this.next = next;
            endpointPath = path;
            contextTypes = dbContextTypes;
        }

        /// <summary>
        /// The main invocation of the middleware component.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> in the pipeline.</param>
        /// <param name="provider">The <see cref="IServiceProvider"/>.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Invoke(HttpContext httpContext, IServiceProvider provider)
        {
            int errorCode = default;
            string errorMessage = string.Empty;
            Exception capturedException = null;
            try
            {
                var processed = await FilterPipelineAsync(httpContext, provider);
                if (!processed)
                {
                    await next.Invoke(httpContext);
                    return;
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                capturedException = uae;
                errorCode = (int)HttpStatusCode.Unauthorized;
                errorMessage = uae.Message;
            }
            catch (NullReferenceException nre)
            {
                capturedException = nre;
                errorCode = (int)HttpStatusCode.BadRequest;
                errorMessage = nre.Message;
            }
            catch (Exception ex)
            {
                capturedException = ex;
                errorCode = (int)HttpStatusCode.InternalServerError;
                errorMessage = "Processing failed for unknown reason. Please check the logs for more information.";
            }
            finally
            {
                if (capturedException != null)
                {
                    var logger = provider.GetService(typeof(ILogger<ExpressionPowerToolsEFCoreMiddleware>))
                        as ILogger<ExpressionPowerToolsEFCoreMiddleware>;
                    logger.LogError(capturedException, errorMessage);
                    httpContext.Response.StatusCode = errorCode;
                    var bytes = Encoding.UTF8.GetBytes(errorMessage);
                    await httpContext.Response.Body.WriteAsync(bytes);
                }
            }
        }

        /// <summary>
        /// Pipeline to filter properly structured requests.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/>.</param>
        /// <param name="provider">The <see cref="IServiceProvider"/>.</param>
        /// <returns>A value indicating whether or not the pipeline was processed.</returns>
        private async Task<bool> FilterPipelineAsync(HttpContext httpContext, IServiceProvider provider)
        {
            if (httpContext.Request.Method != HttpMethods.Post)
            {
                return false;
            }

            var path = httpContext.Request.RouteValues;

            var logger = provider.GetService(typeof(ILogger<ExpressionPowerToolsEFCoreMiddleware>))
                as ILogger<ExpressionPowerToolsEFCoreMiddleware>;
            logger.LogInformation($"{nameof(ExpressionPowerToolsEFCoreMiddleware)} processing path {httpContext.Request.Path}.");

            var (context, collection) = routeProcessor.Value.ParseRoute(httpContext.Request.RouteValues);

            if (string.IsNullOrWhiteSpace(context) ||
                string.IsNullOrWhiteSpace(collection))
            {
                logger.LogWarning($"No context or collection found in path {path}.");
                return false;
            }

            if (!adapter.Value.TryGetContext(
                contextTypes,
                context,
                out Type dbContextType))
            {
                logger.LogWarning($"{context} is not an registered DbContext.");
                return false;
            }

            if (!adapter.Value.TryGetDbSet(
                dbContextType,
                collection,
                out PropertyInfo dbSet))
            {
                logger.LogWarning($"{collection} DbSet on DbContext {context} not found.");
                return false;
            }

            var handle = new CollectionHandle(dbContextType, dbSet);
            await ProcessQueryAsync(httpContext, handle, provider);

            return true;
        }

        /// <summary>
        /// Task to process the query.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/>.</param>
        /// <param name="handle">The handle to the set to process.</param>
        /// <param name="provider">The service provider.</param>
        /// <returns>A <see cref="Task"/> for asynchronous processing.</returns>
        private async Task ProcessQueryAsync(
            HttpContext httpContext,
            CollectionHandle handle,
            IServiceProvider provider)
        {
            var dbContext = provider.GetService(handle.DbContextType) as DbContext;
            Ensure.VariableNotNull(() => dbContext);
            var rootQuery = adapter.Value.CreateQuery(dbContext, handle.Collection);
            var result = await deserializer.Value.DeserializeAsync(
                rootQuery, httpContext.Request.Body);
            Ensure.VariableNotNull(() => result);
            await serializer.Value.SerializeAsync(
                httpContext.Response.Body,
                result.Query,
                result.IsCount);
        }
    }
}
