using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Extensions;
using System;
using System.Linq.Expressions;
using Xunit;
using rules = ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionRulesExtensionsTests
    {
        private ConstantExpression Two => Expression.Constant(2);
        private ConstantExpression TwoStr => Expression.Constant("2");
        private ConstantExpression Three => Expression.Constant(3);

        [Fact]
        public void GivenTrueThenShouldEvaluateToTrue()
        {
            var rule = rules.True<ConstantExpression>().Compile();
            Assert.True(rule(Two, Three));
        }

        [Fact]
        public void GivenFalseThenShouldEvaluateToFalse()
        {
            var rule = rules.False<ConstantExpression>().Compile();
            Assert.False(rule(Two, Three));
        }

        [Fact]
        public void GivenSameTypesThenTypesMustMatchShouldEvaluateToTrue()
        {
            var rule = rules.TypesMustMatch<ConstantExpression>()
                .Compile();
            Assert.True(rule(Two, Three));
        }

        [Fact]
        public void GivenDifferentTypesThenMustBeSameTypeShouldEvaluateToFalse()
        {
            var rule = rules.TypesMustMatch<ConstantExpression>()
                .Compile();
            Assert.False(rule(Two, TwoStr));
        }

        [Fact]
        public void GivenSameValuesThenMembersMustMatchShouldEvaluateToTrue()
        {
            var rule = rules.MembersMustMatch<ConstantExpression>(
                e => e.Value)
                .Compile();
            Assert.True(rule(Two, Two));
        }

        [Fact]
        public void GivenDifferentValuesThenMustBeSameTypeShouldEvaluateToFalse()
        {
            var rule = rules.MembersMustMatch<ConstantExpression>(
                e => e.Value)
                .Compile();
            Assert.False(rule(Two, Three));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenRuleThenReturnsResultOfRule(bool result)
        {
            var rule = rules.Rule<ConstantExpression>(
                (s, t) => result).Compile();
            Assert.Equal(result, rule(Two, Three));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void GivenStartWithAndThenResultIsLogicalAndOfExpressions(bool left, bool right)
        {
            var leftCondition = rules.Rule<ConstantExpression>(
                (s, t) => left);
            var rightCondition = rules.Rule<ConstantExpression>(
                (s, t) => right);
            var rule = rules.And(
                leftCondition, 
                rightCondition).Compile();
            Assert.Equal(left && right, rule(Two, Three));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void GivenAndThenResultShouldBeLogicalAndOfExpressions(bool left, bool right)
        {
            var leftCondition = rules.Rule<ConstantExpression>(
                (s, t) => left);
            var rightCondition = rules.Rule<ConstantExpression>(
                (s, t) => right);
            var rule = leftCondition.And(rightCondition).Compile();
            Assert.Equal(left && right, rule(Two, Three));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void GivenStartWithOrThenResultShouldBeLogicalOrOfExpressions(bool left, bool right)
        {
            var leftCondition = rules.Rule<ConstantExpression>(
                (s, t) => left);
            var rightCondition = rules.Rule<ConstantExpression>(
                (s, t) => right);
            var rule = rules.Or(
                leftCondition,
                rightCondition).Compile();
            Assert.Equal(left || right, rule(Two, Three));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void GivenOrThenResultShouldBeLogicalOrOfExpressions(bool left, bool right)
        {
            var leftCondition = rules.Rule<ConstantExpression>(
                (s, t) => left);
            var rightCondition = rules.Rule<ConstantExpression>(
                (s, t) => right);
            var rule = leftCondition.Or(rightCondition).Compile();
            Assert.Equal(left || right, rule(Two, Three));
        }

        [Theory]
        [InlineData(true, true, true, true)] // if (true) then (true)
        [InlineData(true, true, null, true)] // if (true) then (true)
        [InlineData(true, true, false, true)] // if (true) then (true)
        [InlineData(true, false, true, false)] // if (true) then (false)
        [InlineData(true, false, null, false)]  // if (true) then (false)
        [InlineData(true, false, false, false)] // if (true) then (false)
        [InlineData(false, true, true, true)] // if (false) else (true)
        [InlineData(false, true, null, true)] // if (false) else (*true)
        [InlineData(false, true, false, false)] // if (false) else (false)
        [InlineData(false, false, true, true)] // if (false) else (true)
        [InlineData(false, false, null, true)] // if (false) else (*true)
        [InlineData(false, false, false, false)] // if (false) else (false)
        public void GivenIfThenResultShouldBeBasedOnEvaluationOfIfThenElse(
            bool ifCondition, bool thenCondition, bool? elseCondition, bool expected)
        {
            var ifRule = rules.Rule<ConstantExpression>(
                (s, t) => ifCondition);
            var thenRule = rules.Rule<ConstantExpression>(
                (s, t) => thenCondition);
            var elseRule = elseCondition.HasValue ?
                rules.Rule<ConstantExpression>(
                (s, t) => elseCondition.Value) : null;
            var rule = rules.If(
                ifRule, thenRule, elseRule).Compile();
            Assert.Equal(expected, rule(Two, Three));
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        [InlineData(2, 1, false)]
        public void GivenToRuleOfTypeThenShouldCreateRuleForConvertedTypes(
            int sourceVal,
            int targetVal,
            bool expected)
        {
            var source = Expression.Equal(
                Expression.Constant(sourceVal),
                Expression.Constant(2));
            var target = Expression.Equal(
                Expression.Constant(targetVal),
                Expression.Constant(3));
            var rule = rules.IfWithCast<BinaryExpression, ConstantExpression>(
                condition: (s, t) => s.Left is ConstantExpression,
                conversion: e => e.Left as ConstantExpression,
                ifTrue: (s, t) => ExpressionEquivalency.AreEquivalent(s, t),
                ifFalse: rules.False<ConstantExpression>()).Compile();
            Assert.Equal(expected, rule(source, target));
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public void GivenGlobalRuleThenShouldEvaluateBasedOnExpressionType(
            int sourceValue,
            bool expected)
        {
            var source = Expression.Equal(
                Expression.Constant(sourceValue),
                Expression.Constant(2));
            var target = Expression.Equal(
                Expression.Constant(1),
                Expression.Constant(3));
            var rule = rules.IfWithCast<BinaryExpression, ConstantExpression>(
                condition: (s, t) => s.Left is ConstantExpression,
                conversion: e => e.Left as ConstantExpression,
                ifTrue: (s, t) => ExpressionEquivalency.AreEquivalent(s, t),
                ifFalse: rules.False<ConstantExpression>());
            var globalRule = rules.IfWithCast<Expression, BinaryExpression>(
                condition: (s, t) => s is BinaryExpression,
                conversion: e => e as BinaryExpression,
                ifTrue: rule,
                ifFalse: rules.False<BinaryExpression>());
            var global = globalRule.Compile();
            Assert.Equal(expected, global(source, target));
        }
    }
}
