using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers
{
    public class TestServerBase : IClassFixture<TestServerFactory>
    {
        public TestServerBase(TestServerFactory factory)
        {
            Factory = factory;
        }

        protected virtual IServiceProvider GetServiceProvider()
        {
            return CreateSimpleServer().Services;
        }

        protected TestServerFactory Factory { get; private set; }

        protected TestServer CreateSimpleServer(
            Action<IEndpointRouteBuilder> config = null,
            bool alsoProducts = false) =>
            Factory.CreateTestServer(
                services =>
                {
                    services
                        .AddRouting();
                    if (alsoProducts)
                    {
                        services.AddTransient(sp => Factory.GetDbContext<TestProductsContext>());
                    }                    
                },
                app => app
                    .UseRouting()
                    .UseEndpoints(config ?? (e => {})));
    }
}
