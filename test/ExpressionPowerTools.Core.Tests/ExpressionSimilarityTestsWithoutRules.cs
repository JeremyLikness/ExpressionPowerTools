using ExpressionPowerTools.Core.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    /// <summary>
    /// Included to show how rule execution time compares with coded logic.
    /// </summary>
    public class ExpressionSimilarityTestsWithoutRules : ExpressionSimilarityTests, IClassFixture<PerformanceRulesFixture>
    {
    }
}
