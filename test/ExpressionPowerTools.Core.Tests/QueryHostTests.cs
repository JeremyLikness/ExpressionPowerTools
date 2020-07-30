using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class QueryHostTests
    {
        private TestQueryProvider Provider => new TestQueryProvider();

        private Expression Expression => Expression.Constant(1);

        private QueryHost<IdType, TestQueryProvider> QueryHost(
            Expression expression = null, TestQueryProvider provider = null) =>
            new QueryHost<IdType, TestQueryProvider>(
                expression ?? Expression, provider ?? Provider);

        [Fact]
        public void GivenNullExpressionThenThrowsArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new QueryHost<IdType, TestQueryProvider>(null, Provider));
        }

        [Fact]
        public void GivenNullProviderThenThrowsArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new QueryHost<IdType, TestQueryProvider>(Expression, null));
        }

        [Fact]
        public void GivenQueryHostOfTypeThenElementTypeShouldReturnType()
        {
            var target = QueryHost();
            Assert.Equal(typeof(IdType), target.ElementType);
        }

        [Fact]
        public void GivenQueryHostCreatedWithExpressionThenReturnsSameExpression()
        {
            var expression = Expression;
            var target = QueryHost(expression: expression);
            Assert.Same(expression, target.Expression);
        }

        [Fact]
        public void GivenQueryHostCreatedWithProviderThenReturnsSameProvider()
        {
            var provider = Provider;
            var target = QueryHost(provider: provider);
            Assert.Same(provider, target.Provider);
        }

        [Fact]
        public void GivenQueryHostProviderAndCustomProviderShouldBeSame()
        {
            var target = QueryHost();
            Assert.Same(target.Provider, target.CustomProvider);
        }

        [Fact]
        public void GivenQueryHostWhenGetEnumeratorCalledThenShouldCallExecuteEnumerableOnProvider()
        {
            var provider = Provider;
            var target = QueryHost(provider: provider);
            target.GetEnumerator();
            Assert.True(provider.ExecuteEnumerableCalled);
        }
    }
}
