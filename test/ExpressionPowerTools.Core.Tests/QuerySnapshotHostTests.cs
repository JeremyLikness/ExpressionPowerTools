using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System.Collections.Generic;
using System.Linq;
using IEnumerableNonGeneric = System.Collections.IEnumerable;
using Xunit;
using ExpressionPowerTools.Core.Providers;
using System.Linq.Expressions;
using System;
using System.Reflection.Metadata.Ecma335;

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
        public void SnapshotHostCapturesExpression()
        {
            var expression = Expression.Constant(1);
            var target = new QuerySnapshotHost<IdType>(Query, expression);
            Assert.Same(target.Expression, expression);
        }

        [Fact]
        public void SnapshotHostCreatesInstanceOfSnapshotProvider()
        {
            var target = new QuerySnapshotHost<IdType>(Query);
            Assert.NotNull(target.CustomProvider);
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
            Assert.Same(target.Provider, target.CustomProvider);
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
            target.CustomProvider.QueryExecuted += handler;
            var _ = target.Skip(2).ToList();
            target.CustomProvider.QueryExecuted -= handler;
            Assert.NotNull(expression);
        }

        [Fact]
        public void GivenSnapshotHostProviderWhenQueryExecutedThenFiresQueryExecutedEventWithExpression()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            Expression target = null;
            void handler(object o, QuerySnapshotEventArgs e) => 
                target = e.Expression;
            query.CustomProvider.QueryExecuted += handler;
            var _ = query.Skip(2).Take(3).ToList();
            query.CustomProvider.QueryExecuted -= handler;
            Assert.NotNull(target);
            Assert.True(target.AsEnumerable()
                .MethodsWithNameForType(typeof(Queryable), nameof(Enumerable.Take))
                .Any());
        }

        [Fact]
        public void GivenNullWhenRegisterSnapshotCalledThenShouldThrowArgumentNull()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            Assert.Throws<System.ArgumentNullException>(
                () => query.RegisterSnap(null));
        }

        [Fact]
        public void GivenRegisterSnapshotCalledWhenQueryExecutedThenShouldCallbackOnce()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            Expression target = null;
            query.RegisterSnap(e => target = e);
            var _ = query.Skip(2).Take(3).ToList();
            Assert.NotNull(target);
            Assert.True(target.AsEnumerable()
                .MethodsWithNameForType(typeof(Queryable), nameof(Enumerable.Take))
                .Any());
        }

        [Fact]
        public void GivenRegisterSnapshotCalledWhenQueryExecutedWithProjectionThenShouldCallbackOnce()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            Expression target = null;
            void CaptureSnap(Expression e)
            {
                target = e;
            }
            query.RegisterSnap(CaptureSnap);
            var _ = query.Skip(2).Take(3).Select(i => new { i.Id, i.IdVal }).ToList();
            Assert.NotNull(target);
            Assert.True(target.AsEnumerable()
                .MethodsWithNameForType(typeof(Queryable), nameof(Enumerable.Take))
                .Any());
        }


        [Fact]
        public void GivenRegisterSnapshotCalledWhenQueryExecutedTwiceThenShouldCallbackTwice()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            int callCount = 0;
            query.RegisterSnap(e => callCount++);
            var _ = query.Skip(2).Take(3).ToList();
            var __ = query.Skip(3).Take(2).ToList();
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void GivenRegisterSnapshotCalledMultipleTimesWhenQueryExecutedThenShouldCallAllCallbacks()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            var firstCallback = false;
            var secondCallback = false;
            query.RegisterSnap(e => firstCallback = true);
            query.RegisterSnap(e => secondCallback = true);
            var _ = query.Skip(2).Take(3).ToList();
            Assert.True(firstCallback && secondCallback);
        }

        [Fact]
        public void GivenRegisterSnapshotCalledWhenUnregisterCalledThenShouldStopCallingBack()
        {
            var query = new QuerySnapshotHost<IdType>(Query);
            int callCount = 0;
            var key = query.RegisterSnap(e => callCount++);
            var _ = query.Skip(2).Take(3).ToList();
            query.UnregisterSnap(key);
            var __ = query.Skip(3).Take(2).ToList();
            Assert.Equal(1, callCount);
        }
    }
}
