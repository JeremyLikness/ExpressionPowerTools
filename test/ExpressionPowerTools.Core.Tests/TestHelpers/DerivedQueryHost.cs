using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Signatures;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class DerivedQueryHost<T, TProvider> : QueryHost<T, TProvider>
        where TProvider : ICustomQueryProvider<T>
    {
        public DerivedQueryHost(Expression expression, TProvider provider) : base(expression, provider)
        {
        }
    }
}
