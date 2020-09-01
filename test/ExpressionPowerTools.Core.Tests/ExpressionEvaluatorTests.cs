using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionEvaluatorTests
    {
        public static IEnumerable<object[]> GetNullQueryMatrix()
        {
            yield return new object[] { null, QueryHelper.QuerySkip2Take3 };
            yield return new object[] { QueryHelper.QuerySkip2Take3, null };
        }

        private readonly IExpressionEvaluator evaluator = new ExpressionEvaluator();

        private Expression Add1And2 => 
            Expression.Add(1.AsConstantExpression(), 2.AsConstantExpression());
            
        private Expression Add2And1 =>
            Expression.Add(2.AsConstantExpression(), 1.AsConstantExpression());

        private IEnumerable<Expression> Add1And2Enumerable => Add1And2.AsEnumerable();

        private IEnumerable<Expression> Add2And1Enumerable => Add2And1.AsEnumerable();

        [Fact]
        public void GivenEquivalentExpressionsWhenAreEquivalentCalledThenShouldReturnTrue()
        {
            var source = Add1And2;
            var target = Add1And2;
            Assert.True(evaluator.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenNonEquivalentExpressionsWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var source = Add1And2;
            var target = Add2And1;
            Assert.False(evaluator.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEquivalentEnumerableWhenAreEquivalentCalledThenShouldReturnTrue()
        {
            var source = Add1And2Enumerable;
            var target = Add1And2Enumerable;
            Assert.True(evaluator.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenNonEquivalentEnumerableWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var source = Add1And2Enumerable;
            var target = Add2And1Enumerable;
            Assert.False(evaluator.AreEquivalent(source, target));
        }

        [Theory]
        [MemberData(nameof(GetNullQueryMatrix))]
        public void GivenNullAndNotNullQueryWhenAreEquivalentCalledThenShouldReturnFalse(
            IQueryable<QueryHelper> source, IQueryable<QueryHelper> target)
        {
            Assert.False(evaluator.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEquivalentQueryableWhenAreEquivalentCalledThenShouldReturnTrue()
        {
            var source = QueryHelper.QuerySkip2Take3;
            var target = QueryHelper.QuerySkip2Take3;
            Assert.True(evaluator.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenNonEquivalentQueryableWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var source = QueryHelper.QuerySkip2Take3;
            var target = QueryHelper.QuerySkip2Take4;
            Assert.False(evaluator.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenSimilarExpressionsWhenAreSimilarCalledThenShouldReturnTrue()
        {
            var source = Add1And2;
            var target = Add1And2;
            Assert.True(evaluator.AreSimilar(source, target));
        }

        [Fact]
        public void GivenNonSimilarExpressionsWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var source = Add1And2;
            var target = Add2And1;
            Assert.False(evaluator.AreSimilar(source, target));
        }

        [Fact]
        public void GivenSimilarEnumerableWhenAreSimilarCalledThenShouldReturnTrue()
        {
            var source = Add1And2Enumerable;
            var target = Add1And2Enumerable;
            Assert.True(evaluator.AreSimilar(source, target));
        }

        [Fact]
        public void GivenNonSimilarEnumerableWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var source = Add1And2Enumerable;
            var target = Add2And1Enumerable;
            Assert.False(evaluator.AreSimilar(source, target));
        }

        [Theory]
        [MemberData(nameof(GetNullQueryMatrix))]
        public void GivenNullAndNotNullQueryWhenAreSimilarCalledThenShouldReturnFalse(
            IQueryable<QueryHelper> source, IQueryable<QueryHelper> target)
        {
            Assert.False(evaluator.AreSimilar(source, target));
        }


        [Fact]
        public void GivenSimilarQueryableWhenAreSimilarCalledThenShouldReturnTrue()
        {
            var source = QueryHelper.QuerySkip2Take3;
            var target = QueryHelper.QuerySkip2Take3;
            Assert.True(evaluator.AreSimilar(source, target));
        }

        [Fact]
        public void GivenNonSimilarQueryableWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var source = QueryHelper.QuerySkip2Take3;
            var target = QueryHelper.QuerySkip2Take4;
            Assert.False(evaluator.AreSimilar(source, target));
        }

        [Fact]
        public void GivenExpressionThatIsPartOfOtherExpressionWhenIsPartOfCalledThenShouldReturnTrue()
        {
            var source = 1.AsConstantExpression();
            var target = Add1And2;
            Assert.True(evaluator.IsPartOf(source, target));
        }

        [Fact]
        public void GivenExpressionThatIsNotPartOfOtherExpressionWhenIsPartOfCalledThenShouldReturnFalse()
        {
            var source = 3.AsConstantExpression();
            var target = Add1And2;
            Assert.False(evaluator.IsPartOf(source, target));
        }

        [Theory]
        [MemberData(nameof(GetNullQueryMatrix))]
        public void GivenNullAndNotNullQueryWhenIsPartOfCalledThenShouldReturnFalse(
            IQueryable<QueryHelper> source, IQueryable<QueryHelper> target)
        {
            Assert.False(evaluator.IsPartOf(source, target));
        }


        [Fact]
        public void GivenQueryThatIsPartOfOtherQueryWhenIsPartOfCalledThenShouldReturnTrue()
        {
            var source = new List<QueryHelper>().AsQueryable().Take(3);
            var target = QueryHelper.QuerySkip2Take3;
            Assert.True(evaluator.IsPartOf(source, target));
        }

        [Fact]
        public void GivenQueryThatIsNotPartOfOtherQueryWhenIsPartOfCalledThenShouldReturnFalse()
        {
            var source = new List<QueryHelper>().AsQueryable().Take(4);
            var target = QueryHelper.QuerySkip2Take3;
            Assert.False(evaluator.IsPartOf(source, target));
        }
    }
}
