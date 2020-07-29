using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class QuerySnapshotProviderTests
    {
        private IQueryable<IdType> Queryable =>
            new List<IdType>().AsQueryable();
        private IQuerySnapshotProvider<IdType> Provider =>
            new QuerySnapshotProvider<IdType>(Queryable);

        [Fact]
        public void CreateQueryProvidesSameQueryAsUnderlyingProvider()
        {
            var source = Provider.CreateQuery(Queryable.Expression);
            var target = Queryable.Provider.CreateQuery(Queryable.Expression);
            Assert.True(source.IsEquivalentTo(target));
        }

        [Fact]
        public void CreateQueryTypedProvidesSameQueryAsUnderlyingProvider()
        {
            var source = Provider.CreateQuery<IdType>(Queryable.Expression);
            var target = Queryable.Provider.CreateQuery<IdType>(Queryable.Expression);
            Assert.True(source.IsEquivalentTo(target));
        }

        [Fact]
        public void CreateQueryCreatesAQuerySnapshotHostWithSameProvider()
        {
            var provider = Provider;
            var source = provider.CreateQuery(Queryable.Expression);
            Assert.IsType<QuerySnapshotHost<IdType>>(source);
            Assert.Same(provider,
                ((QuerySnapshotHost<IdType>)source).SnapshotProvider);
        }

        [Fact]
        public void CreateQueryForTypeCreatesNewProviderForType()
        {
            var provider = Provider;
            var source = provider.CreateQuery<string>(Queryable.Expression);
            var sourceHost = source as QuerySnapshotHost<string>;
            Assert.IsType<QuerySnapshotProvider<string>>(sourceHost.SnapshotProvider);
        }

        [Fact]
        public void CreateQueryForTypeRegistersToPropagateEvents()
        {
            Expression expression = null;
            var provider = Provider;
            var queryExpression = new List<string>().AsQueryable().Expression;
            var source = provider.CreateQuery<string>(queryExpression);
            EventHandler<QuerySnapshotEventArgs> handler = (o, e) =>
                expression = e.Expression;
            provider.QueryExecuted += handler;
            var _ = ((QuerySnapshotHost<string>)source).GetEnumerator();
            provider.QueryExecuted -= handler;
            Assert.NotNull(expression);
        }

        [Fact]
        public void ExecuteEnumerableRaisesQueryExecuted()
        {
            var provider = Provider;
            var source = provider.CreateQuery(Queryable.Expression)
                as QuerySnapshotHost<IdType>;
            Assert.Raises<QuerySnapshotEventArgs>(
                handler => provider.QueryExecuted += handler,
                handler => provider.QueryExecuted -= handler,
                () => provider.ExecuteEnumerable(Queryable.Expression));
        }
    }
}
