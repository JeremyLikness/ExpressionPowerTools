using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionPowerTools.Core.Extensions;
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
    }
}
