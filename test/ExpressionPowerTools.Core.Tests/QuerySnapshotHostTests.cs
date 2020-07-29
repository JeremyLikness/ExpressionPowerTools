using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using IEnumerableNonGeneric = System.Collections.IEnumerable;
using Xunit;
using ExpressionPowerTools.Core.Providers;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Tests
{
    public class QuerySnapshotHostTests
    {
        private IQueryable<IdType> Query => new List<IdType>().AsQueryable();

        [Fact]
        public void SnapshotHostCapturesQueryExpression()
        {
            var query = Query;
            var target = new QuerySnapshotHost<IdType>(query);
            Assert.Same(query.Expression, target.Expression);
        }

        [Fact]
        public void SnapshotHostCreatesInstanceOfIQuerySnapshotProvider()
        {
            var target = new QuerySnapshotHost<IdType>(Query);
            Assert.NotNull(target.SnapshotProvider);
        }
        
        [Fact]
        public void SnapshotHostElementTypeReturnsTypeOfQuery()
        {
            var target = new QuerySnapshotHost<IdType>(Query);
            Assert.Equal(typeof(IdType), target.ElementType);
        }
        
        [Fact]
        public void SnapshotHostProviderIsTheSnapshotProviderInstance()
        {
            var target = new QuerySnapshotHost<IdType>(Query);
            Assert.Same(target.Provider, target.SnapshotProvider);
        }
        
        [Fact]
        public void GivenSnapshotHostProviderWhenGetEnumeratorCalledThenShouldReturnEnumerator()
        {
            var target = new QuerySnapshotHost<IdType>(Query);
            var enumerator = target.GetEnumerator();
            Assert.NotNull(enumerator);
        }

        [Fact]
        public void GivenSnapshotHostProviderWhenIEnumerableInterfaceUsedThenShouldReturnEnumerator()
        {
            IEnumerableNonGeneric target = 
                new QuerySnapshotHost<IdType>(Query);
            var enumerator = target.GetEnumerator();
            Assert.NotNull(enumerator);
        }        

        [Fact]
        public void GivenSnapshotHostProviderWhenQueryExecutedThenFiresQueryExecutedEvent()
        {
            var target = new QuerySnapshotHost<IdType>(Query);
            Expression expression = null;
            void handler(object o, QuerySnapshotEventArgs e)
            {
                expression = e.Expression;
            }
            target.SnapshotProvider.QueryExecuted += handler;
            var _ = target.Skip(2).ToList();
            target.SnapshotProvider.QueryExecuted -= handler;
            Assert.NotNull(expression);
        }

        [Fact]
        public void GivenSnapshotHostProviderWhenQueryExecutedThenFiresQueryExecutedEventWithExpression()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            Expression target = null;
            void handler(object o, QuerySnapshotEventArgs e) => 
                target = e.Expression;
            query.SnapshotProvider.QueryExecuted += handler;
            var _ = query.Skip(2).Take(3).ToList();
            query.SnapshotProvider.QueryExecuted -= handler;
            Assert.NotNull(target);
            Assert.True(target.AsEnumerable()
                .MethodsWithNameForType(typeof(Queryable), nameof(Enumerable.Take))
                .Any());
        }
    }
}
