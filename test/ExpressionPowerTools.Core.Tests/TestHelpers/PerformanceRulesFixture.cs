using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using System;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    /// <summary>
    /// Force to run on non-rules based engine.
    /// </summary>
    public class PerformanceRulesFixture : IDisposable
    {
        public PerformanceRulesFixture()
        {
            ServiceHost.Reset();
            var defaultRules = new DefaultHighPerformanceRules();
            ServiceHost.Initialize(register => register.RegisterSingleton<IExpressionComparisonRuleProvider>(defaultRules));
        }

        public void Dispose()
        {
            ServiceHost.Reset();
        }
    }

}
