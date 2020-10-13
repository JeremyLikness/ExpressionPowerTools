using System;
using System.Collections.Generic;
using System.Text;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.Signatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class MiddlewareExtensionsTests : TestServerBase
    {
        private static readonly RoutePattern routePattern =
            RoutePatternFactory.Parse(MiddlewareExtensions.DefaultPattern);
        private static readonly Type[] defaultTypes = new[] { typeof(TestWidgetsContext) };

        public MiddlewareExtensionsTests(TestServerFactory factory) : base(factory)
        {
        }

        public static IEnumerable<object[]> GetNullParameterMatrix()
        {
            yield return new object[]
            {
                false,
                routePattern,
                defaultTypes
            };

            yield return new object[]
            {
                true,
                null,
                defaultTypes
            };

            yield return new object[]
            {
                true,
                routePattern,
                null
            };
        }

        [Theory]
        [MemberData(nameof(GetNullParameterMatrix))]
        public void GivenNullInputsWhenMapPowerToolsEFCoreBaseCalledThenShouldThrowArgumentNull(
            bool useEndPointRouteBuilder,
            RoutePattern pattern,
            Type[] contextTypes)
        {
            IEndpointRouteBuilder builder = null;
            if (useEndPointRouteBuilder)
            {
                CreateSimpleServer(config => builder = config);
            }

            Assert.Throws<ArgumentNullException>(
                () => MiddlewareExtensions.MapPowerToolsEFCore(
                    builder,
                    pattern,
                    contextTypes));
        }

        [Theory]
        [InlineData("/efcore")]
        [InlineData("/efcore/{decoy}/{otherdecoy}")]
        [InlineData("/efcore/{context}")]
        [InlineData("/efcore/{collection}")]
        [InlineData("/efcore/{context}/{decoy}")]
        [InlineData("/efcore/{collection}/{decoy}")]
        public void GivenBadPatternWhenMapPowerToolsEFCoreBasedCalledThenShouldThrowArgument(
            string pattern)
        {
            IEndpointRouteBuilder builder = null;
            CreateSimpleServer(config => builder = config);
            Assert.Throws<ArgumentException>(
                () => MiddlewareExtensions.MapPowerToolsEFCore(
                    builder,
                    RoutePatternFactory.Parse(pattern),
                    defaultTypes));
        }

        public static IEnumerable<object[]> GetBadTypeMatrix()
        {
            yield return new object[] { new Type[0] };
            yield return new object[] { new[] { typeof(string) } };
        }

        [Theory]
        [MemberData(nameof(GetBadTypeMatrix))]
        public void GivenBadDbContextTypesWhenMapPowerToolsEFCoreBaseCalledThenShouldThrowArgument(
            Type[] dbContextTypes)
        {
            IEndpointRouteBuilder builder = null;
            CreateSimpleServer(config => builder = config);
            
            Assert.Throws<ArgumentException>(
                () => MiddlewareExtensions.MapPowerToolsEFCore(
                    builder,
                    routePattern,
                    dbContextTypes));
        }

        [Fact]
        public void GivenConfigPassedWhenMapPowerToolsEFCoreBaseCalledThenShouldConfigureDefaults()
        {
            IEndpointRouteBuilder builder = null;
            CreateSimpleServer(config => builder = config);

            builder.MapPowerToolsEFCore(
                routePattern,
                defaultTypes,
                options: options => options.CompressExpressionTree(false));

            var defaultConfig = ServiceHost.GetService<IDefaultConfiguration>();
            var state = defaultConfig.GetDefaultState();
            Assert.True(state.CompressTypes);
            Assert.False(state.CompressExpression);
        }

        [Fact]
        public void GivenRulesPassedWhenMapPowerToolsEFCoreBaseCalledThenShouldConfigureRules()
        {
            IEndpointRouteBuilder builder = null;
            CreateSimpleServer(config => builder = config);

            builder.MapPowerToolsEFCore(
                routePattern,
                defaultTypes,
                rules => rules.RuleForType<MiddlewareExtensionsTests>());

            var engine = ServiceHost.GetService<IRulesEngine>();
            Assert.True(engine.MemberIsAllowed(typeof(MiddlewareExtensionsTests)));

            // reset rules
            QueryExprSerializer.ConfigureRules();
        }
    }
}
