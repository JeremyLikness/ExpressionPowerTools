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
using ExpressionPowerTools.Serialization.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class EndToEndTests : TestServerBase
    {
        public EndToEndTests(TestServerFactory factory) : base(factory)
        {
        }

        private readonly IQueryable query = new List<TestWidget>().AsQueryable()
            .Take(5).OrderBy(w => w.Id);

        private readonly IQueryable productsQuery = new List<TestProduct>().AsQueryable()
            .Take(1);

        private IQueryable altQuery = null;

        private string queryJson(
            bool isCount = false,
            bool useProduct = false,
            bool isSingle = false) => JsonSerializer.Serialize(
            new SerializationPayload(isCount ? PayloadType.Count : (isSingle ? PayloadType.Single : PayloadType.Array))
            {
                Json = Serializer.Serialize(altQuery ?? (useProduct ? productsQuery : query))
            });

        private void DefaultHttpContext(
            HttpContext context,
            MemoryStream memoryStream = null,
            bool isCount = false,
            bool useProduct = false,
            bool isSingle = false)
        {
            var request = context.Features.Get<IHttpRequestFeature>();
            request.Method = HttpMethods.Post;
            var contextName = useProduct ? nameof(TestProductsContext) :
                nameof(TestWidgetsContext);
            var collectionName = useProduct ? nameof(TestProductsContext.Products) :
                nameof(TestWidgetsContext.Widgets);
            request.Path = $"/efcore/{contextName}/{collectionName}";

            var bytes = Encoding.UTF8.GetBytes(queryJson(isCount, useProduct, isSingle));
            var requestStream = new MemoryStream(bytes);
            request.Body = requestStream;

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Length", requestStream.Length.ToString());

            var responseBody = memoryStream ?? new MemoryStream();
            var responseBodyFeature = new StreamResponseBodyFeature(responseBody);
            context.Features.Set<IHttpResponseBodyFeature>(responseBodyFeature);
        }

        private void BadPath(
            HttpContext context,
            MemoryStream memoryStream = null,
            bool isCount = false,
            bool useProduct = false)
        {
            DefaultHttpContext(context, memoryStream, isCount, useProduct);
            context.Request.Path = context.Request.Path.Value.Replace("efcore", "dapper");
        }

        private void AltPath(
            HttpContext context,
            MemoryStream memoryStream = null,
            bool isCount = false,
            bool useProduct = false)
        {
            DefaultHttpContext(context, memoryStream, isCount, useProduct);
            context.Request.Path = $"/alt/widgets/testwidgetscontext";
        }

        private void ComplexPath(
            HttpContext context,
            MemoryStream memoryStream = null,
            bool isCount = false,
            bool useProduct = false)
        {
            DefaultHttpContext(context, memoryStream, isCount, useProduct);
            context.Request.Path = $"/alt/testwidgetscontext/x/y/widgets/z";
        }

        private (int statusCode, T result) ProcessResult<T>(
            HttpContext context, MemoryStream stream)
        {
            var statusCode = context.Response.StatusCode;
            if (statusCode != (int)HttpStatusCode.OK)
            {
                return (statusCode, default);
            }

            stream.Flush();
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            Assert.False(string.IsNullOrWhiteSpace(json));
            var result = JsonSerializer.Deserialize<T>(json);
            return (statusCode, result); 
        }

        [Fact]
        public async Task SingleDbContextWorks()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>());
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream));
            var parsed = ProcessResult<TestWidget[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.NotNull(parsed.result);
            Assert.Equal(5, parsed.result.Length);
        }

        [Fact]
        public async Task MultipleDbContextsWork()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext, TestProductsContext>(), alsoProducts: true);
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream, useProduct: true));
            var parsed = ProcessResult<TestProduct[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.NotNull(parsed.result);
            Assert.Single(parsed.result);
        }

        [Fact]
        public async Task CountRequestWorks()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>());
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream, isCount: true));
            var parsed = ProcessResult<long>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.Equal(5, parsed.result);
        }

        [Fact]
        public async Task SingleRequestWorks()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>());
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream, isSingle: true));
            var parsed = ProcessResult<TestWidget>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.NotNull(parsed.result);

        }

        [Fact]
        public async Task NotInPathIgnored()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>());
            var result = await testServer.SendAsync(context => BadPath(context, stream));
            Assert.Equal((int)HttpStatusCode.NotFound, result.Response.StatusCode);
        }

        [Fact]
        public async Task AlternatePathWorks()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>("/alt/{collection}/{context}"));
            var result = await testServer.SendAsync(context => AltPath(context, stream));
            var parsed = ProcessResult<TestWidget[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.NotNull(parsed.result);
            Assert.Equal(5, parsed.result.Length);
        }

        [Fact]
        public async Task ComplexAlternatePathWorks()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>("/alt/{context}/x/y/{collection}/z"));
            var result = await testServer.SendAsync(context => ComplexPath(context, stream));
            var parsed = ProcessResult<TestWidget[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.NotNull(parsed.result);
            Assert.Equal(5, parsed.result.Length);
        }

        [Fact]
        public async Task JsonOptionsAreApplied()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>(
                    options: options => options.WithJsonSerializerOptions(
                        new JsonSerializerOptions
                        {
                            IgnoreNullValues = false
                        })));
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream));
            Assert.Equal((int)HttpStatusCode.OK, result.Response.StatusCode);
            stream.Flush();
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            Assert.Contains("null", json);
        }

        [Fact]
        public async Task DefaultCtorRestrictionHonored()
        {
            altQuery = new List<TestWidget>().AsQueryable()
            .Take(5).OrderBy(w => w.Id).Select(w => new TestWidget());
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>());
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream));
            var parsed = ProcessResult<TestWidget[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.Unauthorized, parsed.statusCode);            
        }

        [Fact]
        public async Task NoDefaultRulesHonored()
        {
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>(noDefaultRules: true));
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream));
            var parsed = ProcessResult<TestWidget[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.Unauthorized, parsed.statusCode);
            Serializer.ConfigureRules(); // reset to default
        }

        [Fact]
        public async void SpecificRulesApplied()
        {
            var ctor = typeof(TestWidget).GetConstructors().Single();
            altQuery = new List<TestWidget>().AsQueryable()
            .Take(5).OrderBy(w => w.Id).Select(w => new TestWidget());
            var stream = new MemoryStream();
            var testServer = CreateSimpleServer(
                config => config.MapPowerToolsEFCore<TestWidgetsContext>(
                    rules: rules => rules.RuleForConstructor(
                        selector => selector.ByMemberInfo(ctor))));
            var result = await testServer.SendAsync(context => DefaultHttpContext(context, stream));
            var parsed = ProcessResult<TestWidget[]>(result, stream);
            Assert.Equal((int)HttpStatusCode.OK, parsed.statusCode);
            Assert.NotNull(parsed.result);
            Assert.Equal(5, parsed.result.Length);
        }
    }
}
