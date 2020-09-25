using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers
{
    public class TestMessageHandler : HttpMessageHandler
    {
        private Func<HttpRequestMessage, HttpResponseMessage> response;

        public TestMessageHandler(
            Func<HttpRequestMessage, HttpResponseMessage> response)
        {
            this.response = response;
        }
        protected override Task<HttpResponseMessage>
            SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
        {
            return Task.FromResult(response(request));
        }
    }
}
