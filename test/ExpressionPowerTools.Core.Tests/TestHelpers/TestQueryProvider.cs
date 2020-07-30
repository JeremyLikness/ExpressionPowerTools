using ExpressionPowerTools.Core.Signatures;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class TestQueryProvider : ICustomQueryProvider<IdType>
    {
        public bool ExecuteEnumerableCalled;
        public bool ExecuteCalled;
        public bool CreateQueryCalled;

        public IQueryable CreateQuery(Expression expression)
        {
            CreateQueryCalled = true;
            return new List<IdType>().AsQueryable();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            CreateQueryCalled = true;
            return new List<TElement>().AsQueryable();
        }

        public object Execute(Expression expression)
        {
            ExecuteCalled = true;
            return null;
        }

        public TResult Execute<TResult>(Expression expression)
        {
            ExecuteCalled = true;
            return default;
        }

        public IEnumerable<IdType> ExecuteEnumerable(Expression expression)
        {
            ExecuteEnumerableCalled = true;
            return new List<IdType>();
        }
    }
}
