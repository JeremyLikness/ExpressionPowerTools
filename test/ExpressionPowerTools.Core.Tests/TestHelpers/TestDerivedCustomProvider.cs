using ExpressionPowerTools.Core.Providers;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class TestDerivedCustomProvider : CustomQueryProvider<IdType>
    {
        public TestDerivedCustomProvider(IQueryable source):
            base(source)
        {

        }

        public override IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
