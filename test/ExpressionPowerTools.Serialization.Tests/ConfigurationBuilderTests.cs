using System;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Configuration;
using ExpressionPowerTools.Serialization.Signatures;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ConfigurationBuilderTests
    {
        [Fact]
        public void GivenConfigurationBuilderWhenConfigureCalledThenShouldSetDefaultOptions()
        {
            var state = new ConfigurationBuilder().Configure();
            Assert.True(state.CompressTypes);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenConfigurationBuilderWhenCompressTypesCalledThenShouldSetFlag(bool setting)
        {
            var state = new ConfigurationBuilder().CompressTypes(setting).Configure();
            Assert.Equal(setting, state.CompressTypes);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenConfigurationBuilderThenOptionsCanBeChainedConfigurable(bool setting)
        {
            var state = new ConfigurationBuilder()
                .CompressTypes(setting)
                .CompressExpressionTree(false)
                .Configure();

            Assert.False(state.CompressExpression);
            Assert.Equal(setting, state.CompressTypes);
        }

        [Fact]
        public void GivenConfigureCalledWhenConfiguringThenShouldThrowInvalidOperation()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            var state = builder.Configure();
            Assert.Throws<InvalidOperationException>(
                () => builder.CompressTypes(true));
        }
    }
}
