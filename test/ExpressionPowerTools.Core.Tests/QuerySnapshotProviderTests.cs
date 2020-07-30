using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public void GivenNullExpressionWhenCreateQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider.CreateQuery(null));
        }

        [Fact]
        public void CreateQueryTypedProvidesSameQueryAsUnderlyingProvider()
        {
            var source = Provider.CreateQuery<IdType>(Queryable.Expression);
            var target = Queryable.Provider.CreateQuery<IdType>(Queryable.Expression);
            Assert.True(source.IsEquivalentTo(target));
        }

        [Fact]
        public void GivenNullExpressionWhenCreateQueryTypedCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider.CreateQuery<IdType>(null));
        }

        [Fact]
        public void CreateQueryCreatesAQuerySnapshotHostWithSameProvider()
        {
            var provider = Provider;
            var source = provider.CreateQuery(Queryable.Expression);
            Assert.IsType<QuerySnapshotHost<IdType>>(source);
            Assert.Same(provider,
                ((QuerySnapshotHost<IdType>)source).CustomProvider);
        }

        [Fact]
        public void CreateQueryForTypeCreatesNewProviderForType()
        {
            var provider = Provider;
            var source = provider.CreateQuery<string>(Queryable.Expression);
            var sourceHost = source as QuerySnapshotHost<string>;
            Assert.IsType<QuerySnapshotProvider<string>>(sourceHost.CustomProvider);
        }

        [Fact]
        public void CreateQueryForTypeWithSameTypeUsesSameProvider()
        {
            var provider = Provider;
            var source = provider.CreateQuery<IdType>(Queryable.Expression);
            var sourceHost = source as QuerySnapshotHost<IdType>;
            Assert.Same(provider, sourceHost.CustomProvider);
        }

        [Fact]
        public void QueryWithProjectionTriggersSnapshot()
        {
            var triggered = false;
            var provider = Provider;
            var source = provider.CreateQuery<IdType>(Queryable.Expression);
            void handler(object o, QuerySnapshotEventArgs e) => 
                triggered = true;
            provider.QueryExecuted += handler;
            var _ = source.Select(i => new { Key = i.Id, Value = i.IdVal });
            var temp = _.AsEnumerableExpression();
            _.ToList();
            provider.QueryExecuted -= handler;
            Assert.True(triggered);
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
        public void GivenNullExpressionWhenExecuteEnumerableCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider.ExecuteEnumerable(null));
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
