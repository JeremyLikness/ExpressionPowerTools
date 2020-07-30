using ExpressionPowerTools.Core.Providers;
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
    public class CustomQueryProviderTests
    {
        private IQueryable<IdType> Query => new List<IdType>().AsQueryable();

        private TestQueryableWrapper TestWrapper => new TestQueryableWrapper();

        private Expression NewExpression => Expression.Constant(new IdType());

        [Fact]
        public void GivenNullQueryableWhenCustomQueryProviderCreatedThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new TestDerivedCustomProvider(null));
        }

        [Fact]
        public void GivenNullExpressionWhenExecuteCalledThenShouldThrowArgumentNull()
        {
            var target = new TestDerivedCustomProvider(Query);
            Assert.Throws<ArgumentNullException>(
                () => target.Execute(null));
        }

        [Fact]
        public void GivenExpressionWhenExecuteCalledThenShouldCallSourceProviderExecute()
        {
            var wrapper = TestWrapper;
            var target = new TestDerivedCustomProvider(wrapper);
            target.Execute(NewExpression);
            Assert.True(wrapper.TestProvider.ExecuteCalled);
        }

        [Fact]
        public void GivenNullExpressionWhenExecuteTypeCalledThenShouldThrowArgumentNull()
        {
            var target = new TestDerivedCustomProvider(Query);
            Assert.Throws<ArgumentNullException>(
                () => target.Execute<IdType>(null));
        }

        [Fact]
        public void GivenExpressionWhenExecuteTypeCalledThenShouldCallSourceProviderExecute()
        {
            var wrapper = TestWrapper;
            var target = new TestDerivedCustomProvider(wrapper);
            target.Execute<IdType>(NewExpression);
            Assert.True(wrapper.TestProvider.ExecuteCalled);
        }

        [Fact]
        public void GivenNullExpressionWhenExecuteEnumerableCalledThenShouldThrowArgumentNull()
        {
            var target = new TestDerivedCustomProvider(Query);
            Assert.Throws<ArgumentNullException>(
                () => target.ExecuteEnumerable(null));
        }

        [Fact]
        public void GivenExpressionWhenExecuteEnumerableCalledThenShouldCallSourceProviderCreateQuery()
        {
            var wrapper = TestWrapper;
            var target = new TestDerivedCustomProvider(wrapper);
            target.ExecuteEnumerable(NewExpression);
            Assert.True(wrapper.TestProvider.CreateQueryCalled);
        }
    }
}
