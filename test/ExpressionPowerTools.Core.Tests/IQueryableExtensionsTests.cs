﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class IQueryableExtensionsTests
    {
        [Fact]
        public void WhenNullThenAsEnumerableExpressionShouldThrowArgumentNull()
        {
            IQueryable query = null;
            Assert.Throws<ArgumentNullException>(
                () => query.AsEnumerableExpression());
        }

        [Fact]
        public void AsEnumerableShouldReturnIExpressionEnumeratorForQueryExpression()
        {
            var query = new List<IQueryableExtensionsTests>()
                .AsQueryable()
                .Where(t => t.GetHashCode() == int.MaxValue);
            var target = query.AsEnumerableExpression();
            Assert.NotNull(target);
            Assert.Contains(query.Expression, target);
        }

        [Fact]
        public void GivenEquivalentQueriesIsEquivalentToShouldReturnTrue()
        {
            var list = new List<IdType>();
            IQueryable source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            Assert.True(source.IsEquivalentTo(target));
        }

        [Fact]
        public void GivenNotEquivalentQueriesIsEquivalentToShouldReturnFalse()
        {
            var list = new List<IdType>();
            IQueryable source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "4");
            Assert.False(source.IsEquivalentTo(target));
        }

        [Fact]
        public void GivenNullIsEquivalentToShouldReturnFalse()
        {
            var list = new List<IdType>();
            IQueryable source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            Assert.False(source.IsEquivalentTo(null));
        }

        [Fact]
        public void GivenEquivalentTypedQueriesIsEquivalentToShouldReturnTrue()
        {
            var list = new List<IdType>();
            IQueryable<IdType> source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable<IdType> target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            Assert.True(source.IsEquivalentTo(target));
        }

        [Fact]
        public void GivenNotEquivalentTypedQueriesIsEquivalentToShouldReturnFalse()
        {
            var list = new List<IdType>();
            IQueryable<IdType> source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable<IdType> target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "4");
            Assert.False(source.IsEquivalentTo(target));
        }

        [Fact]
        public void GivenSimilarQueriesIsSimilarToShouldReturnTrue()
        {
            var list = new List<IdType>();
            IQueryable source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            Assert.True(source.IsSimilarTo(target));
        }

        [Fact]
        public void GivenNotSimilarQueriesIsSimilarToShouldReturnFalse()
        {
            var list = new List<IdType>();
            IQueryable source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "4");
            Assert.False(source.IsSimilarTo(target));
        }

        [Fact]
        public void GivenNullIsSimilarToShouldReturnFalse()
        {
            var list = new List<IdType>();
            IQueryable source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            Assert.False(source.IsSimilarTo(null));
        }

        [Fact]
        public void GivenSimilarTypedQueriesIsSimilarToShouldReturnTrue()
        {
            var list = new List<IdType>();
            IQueryable<IdType> source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable<IdType> target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            Assert.True(source.IsSimilarTo(target));
        }

        [Fact]
        public void GivenNotSimilarTypedQueriesIsSimilarToShouldReturnFalse()
        {
            var list = new List<IdType>();
            IQueryable<IdType> source = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "3");
            IQueryable<IdType> target = list
                .AsQueryable()
                .Where(t => t.Id == "1" && t.Echo("1", "2") == "4");
            Assert.False(source.IsSimilarTo(target));
        }

        [Fact]
        public void CreateQueryTemplateUsesEmptyList()
        {
            var target = IQueryableExtensions.CreateQueryTemplate<IdType>();
            Assert.False(target.Any());
        }

        [Fact]
        public void CreateQueryTemplateFromQueryUsesEmptyList()
        {
            var source = QueryHelper.QuerySkip2Take3;
            var target = source.CreateQueryTemplate();
            Assert.False(target.Any());
        }

        private IQueryable<QueryHelper> TestQuery() =>
            IQueryableExtensions.CreateQueryTemplate<QueryHelper>()
                .Where(q => q.Id == nameof(QueryHelper) &&
                    q.Created > DateTime.Now.AddDays(-1))
                .Skip(2)
                .Take(3)
                .OrderBy(q => q.Created);

        public static IEnumerable<object[]> FragmentNotInQueryMatrix()
        {
            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                    q => q.Where(qh => qh.Id == nameof(Queryable)))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                    q => q.Where(qh => qh.Created > DateTime.Now.AddDays(1)))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                    q => q.Skip(3))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                    q => q.Take(2))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                    q => q.OrderBy(q => q.Id))
            };
        }

        [Theory]
        [MemberData(nameof(FragmentNotInQueryMatrix))]
        public void GivenFragmentIsNotInQueryWhenHasFragmentCalledThenShouldReturnFalse(
            Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>> query)
        {
            var target = TestQuery();
            Assert.False(target.HasFragment(query));
        }

        public static IEnumerable<object[]> FragmentInQueryMatrix()
        {
            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                q => q.Where(qh => qh.Id == nameof(QueryHelper)))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                q => q.Where(qh => qh.Created > DateTime.Now.AddDays(-1)))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                q => q.Skip(2))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                q => q.Take(3))
            };

            yield return new object[]
            {
                (Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>>)(
                q => q.OrderBy(q => q.Created))
            };

        }

        [Theory]
        [MemberData(nameof(FragmentInQueryMatrix))]
        public void GivenFragmentIsInQueryWhenHasFragmentCalledThenShouldReturnTrue(
            Func<IQueryable<QueryHelper>, IQueryable<QueryHelper>> query)
        {
            var target = TestQuery();
            Assert.True(target.HasFragment(query));
        }

        [Fact]
        public void GivenQueryableWhenCreateSnapshotHostCalledThenShouldReturnSnapshotHost()
        {
            var target = TestQuery();
            var snapshot = target.CreateSnapshotQueryable(expression => { });
            Assert.NotNull(snapshot);
            Assert.IsType<QuerySnapshotHost<QueryHelper>>(snapshot);
        }

        [Fact]
        public void GivenQueryableWhenCreateSnapshotHostCalledThenShouldReturnSnapshotRegisteredForCallback()
        {
            var target = TestQuery();
            Expression expression = null;
            var snapshot = target.CreateSnapshotQueryable(e => expression = e);
            var _ = snapshot.Take(5).ToList();
            Assert.NotNull(expression);
            Assert.True(expression.AsEnumerable()
                .MethodsWithNameForType(
                    typeof(Queryable),
                    nameof(Queryable.Take)).Any());
        }

        private List<IdType> TestDb => new List<IdType>
        {
            new IdType(),
            new IdType(),
            new IdType(),
            new IdType(),
            new IdType()
        };

        [Fact]
        public void GivenQueryableWhenCreateInterceptedQueryCalledThenShouldApplyTransformation()
        {
            var list = TestDb;
            var query = list.AsQueryable().OrderBy(i => i.Id);
            var intercepted = query.CreateInterceptedQueryable(e =>
            {
                var newQuery = query.Provider.CreateQuery<IdType>(e)
                    .Take(2);
                return newQuery.Expression;
            });
            var result = intercepted.Skip(1).ToList();
            Assert.Equal(2, result.Count);
            var expected = list.OrderBy(i => i.Id).Skip(1).Take(2).ToList();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenQueryableWhenCreateInterceptedQueryCalledThenShouldReturnQueryHost()
        {
            var list = TestDb;
            bool transformationCalled = false;
            var query = list.AsQueryable().Skip(1).Take(2);
            var intercepted = query.CreateInterceptedQueryable(e => 
            {
                transformationCalled = true;
                return e;
            });
            var result = intercepted.ToList();
            Assert.True(transformationCalled);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(result[0].Id, list[1].Id);
            Assert.Equal(result[1].Id, list[2].Id);
        }

        [Fact]
        public void GivenQueryableWhenCreateInterceptedQueryCalledThenShouldRegisterTransformation()
        {
            var list = TestDb;
            var query = list.AsQueryable().Skip(1).Take(2);
            var altQuery = list.AsQueryable().Skip(2).Take(1);
            var intercepted = query.CreateInterceptedQueryable(e => altQuery.Expression);
            var result = intercepted.ToList();
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(result[0].Id, list[2].Id);
        }

    }
}
