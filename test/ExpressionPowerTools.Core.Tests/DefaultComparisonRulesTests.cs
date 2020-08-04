using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Mail;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class DefaultComparisonRulesTests
    {
        protected virtual IExpressionComparisonRuleProvider Source { get; } =
            new DefaultComparisonRules();

        protected ConstantExpression One = Expression.Constant(1);
        protected ConstantExpression Two = Expression.Constant(2);
        protected ParameterExpression StringParam = Expression.Parameter(typeof(StringWrapper));
        protected ParameterExpression DerivedParam = Expression.Parameter(typeof(DerivedStringWrapper));

        [Fact]
        public void GivenRulesForTypeExistWhenGetRuleForEquivalencyCalledThenShouldReturnRuleset()
        {
            var target = Source.GetRuleForEquivalency<ConstantExpression>();
            Assert.NotNull(target);
        }

        [Fact]
        public void GivenRulesForTypeDoNotExistWhenGetRuleForEquivalencyCalledThenShouldReturnNull()
        {
            var target = Source.GetRuleForEquivalency<DebugInfoExpression>();
            Assert.Null(target);
        }

        [Fact]
        public void GivenEquivalentExpressionsThenNonGenericCheckEquivalencyShouldCompare()
        {
            var target = Source.CheckEquivalency((Expression)One, One);
            Assert.True(target);
        }

        [Fact]
        public void GivenNonSupportedExpressionThenTypedEquivalencyShouldReturnFalse()
        {
            var label = Expression.Label();
            var source = Expression.Goto(label);
            var target = Expression.Goto(label);
            Assert.False(Source.CheckEquivalency(source, target));
        }

        [Fact]
        public void GivenSupportedExpressionThenTypedEquivalencyShouldReturnTrue()
        {
            var expr = One as Expression;
            var target = Source.CheckEquivalency(One, expr);
            Assert.True(target);
        }

        [Fact]
        public void GivenRulesForTypeExistWhenGetRuleForSimilarityCalledThenShouldReturnRuleset()
        {
            var target = Source.GetRuleForSimilarity<ConstantExpression>();
            Assert.NotNull(target);
        }

        [Fact]
        public void GivenRulesForTypeDoNotExistWhenGetRuleForSimilarityCalledThenShouldReturnNull()
        {
            var target = Source.GetRuleForSimilarity<DebugInfoExpression>();
            Assert.Null(target);
        }

        [Fact]
        public void GivenSimilarExpressionsThenNonGenericCheckSimilarityShouldCompare()
        {
            var target = Source.CheckSimilarity((Expression)StringParam, DerivedParam);
            Assert.True(target);
        }

        [Fact]
        public void GivenNonSupportedExpressionThenTypedSimilarityShouldReturnFalse()
        {
            var label = Expression.Label();
            var source = Expression.Goto(label);
            var target = Expression.Goto(label);
            Assert.False(Source.CheckSimilarity(source, target));
        }

        [Fact]
        public void GivenSupportedExpressionThenTypedSimilarityShouldReturnTrue()
        {
            var expr = DerivedParam as Expression;
            var target = Source.CheckSimilarity(StringParam, expr);
            Assert.True(target);
        }

        [Fact]
        public void GivenNoRuleThenCheckEquivalencyShouldReturnFalse()
        {
            var source = Expression.ClearDebugInfo(Expression.SymbolDocument($"{nameof(DefaultComparisonRulesTests)}.cs"));
            var target = Expression.ClearDebugInfo(Expression.SymbolDocument($"{nameof(DefaultComparisonRulesTests)}.cs"));
            Assert.False(Source.CheckEquivalency(source, target));
        }

        [Fact]
        public void GivenNoRuleThenCheckSimilarityShouldReturnFalse()
        {
            var source = Expression.ClearDebugInfo(Expression.SymbolDocument($"{nameof(DefaultComparisonRulesTests)}.cs"));
            var target = Expression.ClearDebugInfo(Expression.SymbolDocument($"{nameof(DefaultComparisonRulesTests)}.cs"));
            Assert.False(Source.CheckSimilarity(source, target));
        }
    }
}
