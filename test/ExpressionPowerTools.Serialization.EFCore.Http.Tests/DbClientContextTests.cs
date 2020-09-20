using System;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class DbClientContextTests
    {
        [Fact]
        public void GivenEmptyExpressionWhenQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => DbClientContext<TestThingContext>.Query<TestThingContext>(null));
        }

        [Fact]
        public void GivenExpressionOnDifferentContextWhenQueryCalledThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () => DbClientContext<TestThingContext>.Query(q => new AltContext().AltThings));
        }

        [Fact]
        public void GivenExpressionOfCorrectTypeThenShouldBuildQueryWithContext()
        {
            var query = DbClientContext<TestThingContext>.Query(t => t.Things);
            Assert.NotNull(query);
            var remote = query as IRemoteQuery;
            var context = remote.CustomProvider.Context;
            Assert.Same(typeof(TestThingContext), context.Context);
            var prop = typeof(TestThingContext).GetProperty(nameof(TestThingContext.Things));
            Assert.Same(prop, context.Collection);
        }
    }
}
