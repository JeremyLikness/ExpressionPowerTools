using System;
using Microsoft.Extensions.DependencyInjection;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using Xunit;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using System.Net.Http;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class ClientExtensionsTests
    {
        private readonly IServiceCollection Collection = new
            ServiceCollection();

        private const string Path = "/custom/{context}/{collection}";

        private readonly Uri BaseUri = new Uri("https://localhost:1234/");

        private readonly Uri ServiceUri = new Uri("https://localhost:4321/");

        [Fact]
        public void ConfigurePathSetsPath()
        {
            Collection.AddExpressionPowerToolsEFCore(
                BaseUri,
                configure => configure.SetPathTemplate(Path));
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            Assert.Equal(Path, config.PathTemplate);
        }

        [Fact]
        public void ConfigureClientCapturesClient()
        {
            var myClient = new RemoteQueryClient(new HttpClient { BaseAddress = ServiceUri }); 
            Collection.AddExpressionPowerToolsEFCore(
                BaseUri,
                configure => configure.SetClientFactory(
                    () => myClient));
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            var client = config.ClientFactory();
            Assert.NotNull(client);
            Assert.Same(myClient, client);
        }

        [Fact]
        public void ChainingWorks()
        {
            var myClient = new RemoteQueryClient(new HttpClient { BaseAddress = ServiceUri });
            Collection.AddExpressionPowerToolsEFCore(
                BaseUri,
                configure => configure.SetClientFactory(
                    () => myClient)
                .SetPathTemplate(Path));
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            Assert.Equal(Path, config.PathTemplate);
            var client = config.ClientFactory();
            Assert.NotNull(client);
            Assert.Same(myClient, client);
        }

        [Fact]
        public void DefaultsToUseServiceProvider()
        {
            Collection.AddExpressionPowerToolsEFCore(BaseUri);
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            var client = config.ClientFactory();
            Assert.NotNull(client);            
        }
    }
}
