using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class ExpressionPowerToolsEFCoreMiddlewareTests : TestServerBase
    {
        public ExpressionPowerToolsEFCoreMiddlewareTests(TestServerFactory factory)
            : base(factory)
        {
            next = async context =>
            await Task.Run(() => nextInvoked = true);
        }

        private readonly TemplateMatcher matcher = new TemplateMatcher(
            TemplateParser.Parse(MiddlewareExtensions.DefaultPattern),
            null);
        private readonly JsonWrapper jsonWrapper = new JsonWrapper();

        private bool nextInvoked = false;
        private readonly RequestDelegate next;
        private readonly string path = "/efcore";
        private void parseRoute(HttpContext context, string path)
        {
            var value = new RouteValueDictionary();
            try
            {
                matcher.TryMatch(path, value);
            }
            catch
            {

            }
            var feature = new RouteValuesFeature
            {
                RouteValues = value
            };
            context.Features.Set<IRouteValuesFeature>(feature);
        }

        private ExpressionPowerToolsEFCoreMiddleware NewMiddleware() =>
            new ExpressionPowerToolsEFCoreMiddleware(next, path, contextTypes);

        private readonly Type[] contextTypes = new[]
        {
            typeof(TestWidgetsContext),
            typeof(TestProductsContext)
        };

        private readonly IQueryable query = new List<TestWidget>().AsQueryable()
            .Take(5).OrderBy(w => w.Id);

        private string queryJson() => JsonSerializer.Serialize(
            new SerializationPayload
            {
                Json = jsonWrapper.FromSerializationRoot(QueryExprSerializer.Serialize(query))
            });

        [Fact]
        public void GivenNullNextDelegateWhenMiddlewareInstantiatedThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    new ExpressionPowerToolsEFCoreMiddleware(
                        null,
                        path,
                        contextTypes);
                });
        }

        [Fact]
        public void GivenNullPathWhenMiddlewareInstantiatedThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    new ExpressionPowerToolsEFCoreMiddleware(
                        next,
                        null,
                        contextTypes);
                });
        }

        [Fact]
        public void GivenNullContextTypesWhenMiddlewareInstantiatedThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    new ExpressionPowerToolsEFCoreMiddleware(
                        next,
                        path,
                        null);
                });
        }

        [Fact]
        public void GivenZeroLengthContextTypesWhenMiddlewareInstantiatedThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    new ExpressionPowerToolsEFCoreMiddleware(
                        next,
                        path,
                        new Type[0]);
                });
        }

        [Fact]
        public void GivenContextTypesNotDerivedFromDbContextWhenMiddlewareInstantiatedThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    new ExpressionPowerToolsEFCoreMiddleware(
                        next,
                        path,
                        new Type[] { typeof(string) });
                });
        }

        [Fact]
        public async Task GivenMethodNotPostWhenInvokeCalledThenShouldInvokeNextDelegate()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "GET",
                Path = path
            };
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, null);
            Assert.True(nextInvoked);
        }

        [Fact]
        public async Task GivenPathNotOfRootWhenInvokeCalledThenShouldInvokeNextDelegate()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/diff"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.True(nextInvoked);
        }

        [Fact]
        public async Task GivenPathNotWithContextWhenInvokeCalledThenShouldInvokeNextDelegate()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/efcore/"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.True(nextInvoked);
        }

        [Fact]
        public async Task GivenPathNotWithCollectionWhenInvokeCalledThenShouldInvokeNextDelegate()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/efcore/testwidgetscontext"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.True(nextInvoked);
        }

        [Fact]
        public async Task GivenPathWithInvalidContextWhenInvokeCalledThenShouldInvokeNextDelegate()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/efcore/badcontext/widgets"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.True(nextInvoked);
        }

        [Fact]
        public async Task GivenPathWithInvalidCollectionWhenInvokeCalledThenShouldInvokeNextDelegate()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/efcore/testwidgetscontext/decoy"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.True(nextInvoked);
        }

        [Fact]
        public async Task GivenDbContextNotRegisteredWithServiceProviderWhenInvokeCalledThenShouldSetBadRequestStatusCode()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/efcore/testproductscontext/products"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.Equal((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
        }

        [Fact]
        public async Task GivenInvalidBodyInvokeCalledThenShouldSetInternalServerErrorStatusCode()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var feature = new HttpRequestFeature
            {
                Method = "POST",
                Path = "/efcore/testwidgetscontext/widgets"
            };
            parseRoute(context, feature.Path);
            context.Features.Set<IHttpRequestFeature>(feature);
            await target.Invoke(context, GetServiceProvider());
            Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
        }

        [Fact]
        public async Task GivenValidBodyInvokeCalledThenShouldReturnResult()
        {
            nextInvoked = false;
            var target = NewMiddleware();
            var context = new DefaultHttpContext();

            var request = context.Features.Get<IHttpRequestFeature>();
            request.Method = HttpMethods.Post;
            request.Path = "/efcore/testwidgetscontext/widgets";

            parseRoute(context, request.Path);

            var bytes = Encoding.UTF8.GetBytes(queryJson());
            var requestStream = new MemoryStream(bytes);
            request.Body = requestStream;

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Length", requestStream.Length.ToString());

            var responseBody = new MemoryStream();
            var responseBodyFeature = new StreamResponseBodyFeature(responseBody);
            context.Features.Set<IHttpResponseBodyFeature>(responseBodyFeature);

            await target.Invoke(context, GetServiceProvider());

            Assert.Equal((int)HttpStatusCode.OK, context.Response.StatusCode);

            context.Response.Body.Flush();
            context.Response.Body.Position = 0;

            using var reader = new StreamReader(context.Response.Body);
            var json = reader.ReadToEnd();
            Assert.False(string.IsNullOrWhiteSpace(json));
            var result = JsonSerializer.Deserialize<TestWidget[]>(json);
            Assert.NotNull(result);
            Assert.Equal(5, result.Length);
        }
    }
}
