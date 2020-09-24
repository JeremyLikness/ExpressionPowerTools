using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class RemoteClientTests
    {
        private const string Path = "/efcore/thingcontext/things";

        private const string LocalHost = "http://localhost:1234/";

        private readonly HttpContent strContent =
            new StringContent(nameof(RemoteClientTests));

        private IRemoteQueryClient GetClient() =>
            new RemoteQueryClient(new HttpClient
            {
                BaseAddress = new Uri(LocalHost)
            });

        private IRemoteQueryClient GetClient(
            Func<HttpRequestMessage, HttpResponseMessage> handler) =>
            new RemoteQueryClient(
                new HttpClient(
                    new TestMessageHandler(handler))
                {
                    BaseAddress = new Uri(LocalHost)
                });

        private HttpResponseMessage Response(
            HttpStatusCode code = HttpStatusCode.OK) =>
            new HttpResponseMessage(code)
            {
                Content = new StringContent(nameof(RemoteClientTests))
            };

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void GivenNullOrEmptyPathWhenFetchRemoteQueryAsyncCalledThenShouldThrowArgument(
            string path)
        {
            var client = GetClient();
            Assert.ThrowsAsync<ArgumentException>(
                async () => await client.FetchRemoteQueryAsync(path, strContent));
        }

        [Fact]
        public void GivenNullQueryContentWhenFetchRemoteQueryAsyncCalledThenShouldThrowArgumentNull()
        {
            var client = GetClient();
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await client.FetchRemoteQueryAsync(Path, null));
        }

        [Fact]
        public async Task GivenQueryWhenFetchRemoteQueryAsyncCalledThenShouldCallPostAsync()
        {
            bool calledPost = false;
            var client = GetClient(
                req =>
                {
                    calledPost = req.Method == HttpMethod.Post;
                    return Response();
                });
            await client.FetchRemoteQueryAsync(Path, strContent);
            Assert.True(calledPost);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.BadRequest)]
        public void GivenQueryWhenFetchRemoteQueryAsyncCalledThenShouldCheckForSuccessCode(
            HttpStatusCode code)
        {
            var client = GetClient(req => Response(code));
            if (code == HttpStatusCode.OK)
            {
                var result = client.FetchRemoteQueryAsync(Path, strContent);
            }
            else
            {
                Assert.ThrowsAsync<Exception>(
                    async () => await client.FetchRemoteQueryAsync(Path, strContent));
            }
        }

        [Fact]
        public async Task GivenQueryWhenFetchRemoteQueryAsyncCalledThenShouldReturnResult()
        {
            var client = GetClient(req => Response());
            var result = await client.FetchRemoteQueryAsync(Path, strContent);
            Assert.Equal(nameof(RemoteClientTests), result);
        }
    }
}
