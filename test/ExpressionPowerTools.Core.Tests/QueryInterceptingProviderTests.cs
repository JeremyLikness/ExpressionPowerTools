using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class QueryInterceptingProviderTests
    {
        private IQueryable<IdType> Query =>
            new List<IdType>().AsQueryable();

        private QueryInterceptingProvider<IdType> Provider(
            IQueryable query = null) =>
                new QueryInterceptingProvider<IdType>(query ?? Query);

        [Fact]
        public void GivenNullExpressionWhenCreateQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider().CreateQuery(null));
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryCalledThenShouldReturnNewQuerySnapshotHost()
        {
            var target = Provider().CreateQuery(Query.Expression);
            Assert.IsType<QueryHost<IdType, 
                QueryInterceptingProvider<IdType>>>(target);
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryCalledThenShouldReturnQueryWithSelfAsProvider()
        {
            var provider = Provider();
            var target = provider.CreateQuery(Query.Expression)
                as QueryHost<IdType,
                QueryInterceptingProvider<IdType>>;
            Assert.Same(provider, target.CustomProvider);
        }

        [Fact]
        public void GivenNullExpressionWhenCreateQueryTypedCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider().CreateQuery<string>(null));
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryTypedCalledThenShouldReturnNewQuerySnapshotHost()
        {
            var target = Provider().CreateQuery<string>(Query.Expression);
            Assert.IsType<QueryHost<string,
                QueryInterceptingProvider<string>>>(target);
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryTypedCalledWithSameTypeThenShouldReturnQueryWithSelfAsProvider()
        {
            var provider = Provider();
            var target = provider.CreateQuery<IdType>(Query.Expression);
            Assert.Same(provider, target.Provider);
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryTypedCalledWithDifferentTypeThenShouldReturnQueryWithNewProvider()
        {
            var provider = Provider();
            var target = provider.CreateQuery<string>(Query.Expression);
            Assert.NotSame(provider, target.Provider);
        }

    }
}
