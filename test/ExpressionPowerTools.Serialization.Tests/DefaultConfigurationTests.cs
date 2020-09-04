using System;
using System.Collections.Generic;
using System.Text;
using ExpressionPowerTools.Serialization.Configuration;
using ExpressionPowerTools.Serialization.Signatures;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class DefaultConfigurationTests
    {
        [Fact]
        public void GivenNoConfigurationWhenDefaultConfigurationRequestedThenShouldUseSystemDefaults()
        {
            IDefaultConfiguration target = new DefaultConfiguration();
            var state = target.GetDefaultState();
            Assert.True(state.CompressTypes);
            Assert.NotNull(state.Options);
            Assert.True(state.Options.IgnoreNullValues);
            Assert.True(state.Options.IgnoreReadOnlyProperties);
        }

        [Fact]
        public void GivenDefaultConfigurationWhenStateRequestedThenShouldReturnNewInstance()
        {
            IDefaultConfiguration config = new DefaultConfiguration();
            var source = config.GetDefaultState();
            var target = config.GetDefaultState();
            Assert.NotSame(source, target);
        }

        [Fact]
        public void GivenDefaultConfigurationWhenConfigureRequestedThenShouldReturnConfigurationBuilder()
        {
            IDefaultConfiguration config = new DefaultConfiguration();
            config.SetDefaultState(builder => builder.CompressTypes(false).Configure());
            var target = config.GetDefaultState();
            Assert.False(target.CompressTypes);
        }
    }
}
