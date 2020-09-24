using ExpressionPowerTools.Core.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    /// <summary>
    /// Included to show how rule execution time compares with coded logic.
    /// </summary>
    /// <remarks>
    /// Code coverage doesn't recognize the derived type so excluded here.
    /// </remarks>
    public class ExpressionEquivalencyTestsWithoutRules : ExpressionEquivalencyTests, IClassFixture<PerformanceRulesFixture>
    {
    }
}
