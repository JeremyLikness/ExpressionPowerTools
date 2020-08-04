using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Signatures;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class DefaultHighPerformanceRulesTests : DefaultComparisonRulesTests
    {
        protected override IExpressionComparisonRuleProvider Source { get; }
            = new DefaultHighPerformanceRules();
    }
}
