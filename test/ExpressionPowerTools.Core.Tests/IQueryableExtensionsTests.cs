using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionPowerTools.Core.Extensions;
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


    }
}
