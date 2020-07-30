using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class TestQueryableWrapper : IQueryable<IdType>
    {
        public Type ElementType => typeof(IdType);

        public Expression Expression { get; private set; }

        public IQueryProvider Provider => TestProvider;

        public TestQueryProvider TestProvider { get; private set; } =
            new TestQueryProvider();

        public IEnumerator<IdType> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
