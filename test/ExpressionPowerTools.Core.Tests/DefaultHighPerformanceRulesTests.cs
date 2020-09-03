using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Tests
{
    public class DefaultHighPerformanceRulesTests : DefaultComparisonRulesTests
    {
        protected override IExpressionComparisonRuleProvider Source { get; }
            = new DefaultHighPerformanceRules();
    }
}
