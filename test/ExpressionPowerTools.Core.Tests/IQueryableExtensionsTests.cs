using System;
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
        public void AsEnumerableShouldReturnIExpresionEnumeratorForQueryExpression()
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
        
        [Fact]
        public void GivenFragmentIsNotInQueryWhenHasFragmentCalledThenShouldReturnFalse()
        {
            var target = TestQuery();
            Assert.False(target.HasFragment(
                q => q.Where(qh => qh.Id == nameof(Queryable))));
            Assert.False(target.HasFragment(
                q => q.Where(qh => qh.Created > DateTime.Now.AddDays(1))));
            Assert.False(target.HasFragment(q => q.Skip(3)));
            Assert.False(target.HasFragment(q => q.Take(2)));
            Assert.False(target.HasFragment(q => q.OrderBy(q => q.Id)));
        }

        [Fact]
        public void GivenFragmentIsInQueryWhenHasFragmentCalledThenShouldReturnTrue()
        {
            var target = TestQuery();
            Assert.True(target.HasFragment(
                q => q.Where(qh => qh.Id == nameof(QueryHelper))));
            Assert.True(target.HasFragment(
                q => q.Where(qh => qh.Created > DateTime.Now.AddDays(-1))));
            Assert.True(target.HasFragment(q => q.Skip(2)));
            Assert.True(target.HasFragment(q => q.Take(3)));
            Assert.True(target.HasFragment(q => q.OrderBy(q => q.Created)));
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

    }
}







