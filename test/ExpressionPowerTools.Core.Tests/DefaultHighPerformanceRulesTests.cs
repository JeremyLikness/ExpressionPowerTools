using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Signatures;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class DefaultHighPerformanceRulesTests
    {
        private IExpressionComparisonRuleProvider source =
         new DefaultHighPerformanceRules();

        [Fact]
        public void GivenRulesForTypeExistWhenGetRuleForEquivalencyCalledThenShouldReturnRuleset()
        {
            var target = source.GetRuleForEquivalency<ConstantExpression>();
            Assert.NotNull(target);
        }

        [Fact]
        public void GivenRulesForTypeDoNotExistWhenGetRuleForEquivalencyCalledThenShouldReturnNull()
        {
            var target = source.GetRuleForEquivalency<GotoExpression>();
            Assert.Null(target);
        }
    }
}
