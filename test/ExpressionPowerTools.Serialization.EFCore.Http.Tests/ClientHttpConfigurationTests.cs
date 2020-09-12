using System;
using System.Net.Http;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.Http.Configuration;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class ClientHttpConfigurationTests
    {
        [Fact]
        public void IsRegistered()
        {
            var target = ServiceHost.GetService<IClientHttpConfiguration>();
            Assert.NotNull(target);
            Assert.IsType<ClientHttpConfiguration>(target);
        }

        [Fact]
        public void SetsAppropriateDefaults()
        {
            var target = new ClientHttpConfiguration();
            Assert.Equal("/efcore/{context}/{collection}", target.PathTemplate);
            Assert.NotNull(target.ClientFactory);
            Assert.Throws<InvalidOperationException>(
                () =>target.ClientFactory());
        }

        [Fact]
        public void GivenNullFactoryWhenSetClientFactoryCalledThenShouldThrowArgumentNull()
        {
            var target = new ClientHttpConfiguration();
            Assert.Throws<ArgumentNullException>(
                () => target.SetClientFactory(null));
        }

        [Fact]
        public void GivenFactoryWhenSetClientFactoryCalledThenShouldSetFactory()
        {
            var target = new ClientHttpConfiguration();
            var client = new RemoteQueryClient(new HttpClient());
            target.SetClientFactory(() => client);
            var actual = target.ClientFactory();
            Assert.Same(client, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("/{context}")]
        [InlineData("{collection}")]
        [InlineData("/{context}{collection}")]
        [InlineData("{context}/{decoy}")]
        [InlineData("/{context}/{context}")]
        [InlineData("{context}/{collection}/{collection}")]
        [InlineData("efcore/{context}")]
        [InlineData("efcore/{collection}")]
        [InlineData("/efcore/{context}{collection}")]
        [InlineData("efcore/{context}/{decoy}")]
        [InlineData("/efcore/{context}/{context}")]
        [InlineData("efcore/{context}/{collection}/{collection}")]
        public void GivenInvalidPathTemplateWhenSetPathTemplateCalledThenShouldThrowArgument(
            string path)
        {
            var target = new ClientHttpConfiguration();
            Assert.Throws<ArgumentException>(
                () => target.SetPathTemplate(path));
        }

        [Theory]
        [InlineData("{context}/{collection}")]
        [InlineData("{collection}/{context}")]
        [InlineData("/{context}/{collection}")]
        [InlineData("/{collection}/{context}")]
        [InlineData("efcore/{context}/{collection}")]
        [InlineData("efcore/{collection}/{context}")]
        [InlineData("{context}/{collection}/")]
        [InlineData("{collection}/{context}/")]
        [InlineData("/{context}/{collection}/")]
        [InlineData("/{collection}/{context}/")]
        [InlineData("efcore/{context}/{collection}/")]
        [InlineData("efcore/{collection}/{context}/")]
        [InlineData("a/b/{context}/c/d/{collection}")]
        public void GivenValidPathTemplateWhenSetPathTemplateCalledThenShouldSetPathTemplate(
            string path)
        {
            var target = new ClientHttpConfiguration();
            target.SetPathTemplate(path);
            Assert.Equal(path, target.PathTemplate);
        }
    }
}
