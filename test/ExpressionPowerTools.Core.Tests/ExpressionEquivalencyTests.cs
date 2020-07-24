using System.Collections.Generic;
using System.Linq.Expressions;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionEquivalencyTests
    {
        private static ConstantExpression Five =>
            Expression.Constant(5);

        private static ConstantExpression Six =>
            Expression.Constant(6);

        private static ConstantExpression StrFive =>
            Expression.Constant(5.ToString());

        private static ConstantExpression Obj =>
            Expression.Constant(new
            {
                foo = 1,
                bar = "2"
            });

        private static ConstantExpression OfFive =>
            Expression.Constant(Five);

        private static ConstantExpression OfOfFive =>
            Expression.Constant(OfFive);

        private static ParameterExpression IntParameter =>
            Expression.Parameter(typeof(int));

        private static ParameterExpression StringParameter =>
            Expression.Parameter(typeof(string));

        private static ParameterExpression IntNamedParameter =>
            Expression.Parameter(
                typeof(int),
                nameof(IntNamedParameter));

        private static ParameterExpression IntByRefParameter =>
            Expression.Parameter(typeof(int).MakeByRefType());

        public static IEnumerable<object[]> GetNullMatrix()
        {
            yield return new object[] { null, null };
            yield return new object[]
            {
                Expression.Constant(5), null
            };
            yield return new object[]
            {
                null, Expression.Constant(5)
            };
        }

        public static IEnumerable<object[]> GetConstantExpressionMatrix()
        {
            yield return new object[]
            {
                Five, OfFive, false
            };
            yield return new object[]
            {
                OfFive, OfOfFive, false
            };
            yield return new object[]
            {
                OfFive, OfFive, true
            };
            yield return new object[]
            {
                OfOfFive, OfOfFive, true
            };
        }

        [Theory]
        [MemberData(nameof(GetNullMatrix))]
        public void GivenEitherExpressionNullThenAreEquivalentShouldReturnFalse(
            Expression left,
            Expression right)
        {
            Assert.False(eq.AreEquivalent(left, right));
        }

        [Fact]
        public void GivenConstantsWithDifferentTypeThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(Five, StrFive));
        }

        [Fact]
        public void GivenConstantsWithDifferentValuesThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(Five, Six));
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressionMatrix))]
        public void GivenConstantWithExpressionThenAreEquivalentShouldRecursivelyCompare(
            Expression left,
            Expression right,
            bool equivalent)
        {
            if (equivalent)
            {
                Assert.True(eq.AreEquivalent(left, right));
            }
            else
            {
                Assert.False(eq.AreEquivalent(left, right));
            }
        }

        [Fact]
        public void GivenConstantWithSameValueThenAreEquivalentShouldReturnTrue()
        {
            Assert.True(eq.AreEquivalent(
                Expression.Constant(this),
                Expression.Constant(this)));
        }

        [Fact]
        public void GivenEnumerableWithItemsInDifferentOrderThenAreEquivalentShouldReturnFalse()
        {
            var source = new [] { Five, Six };
            var target = new [] { Six, Five };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTargetIsHasFewerExpressionsThenAreEquivalentShouldReturnFalse()
        {
            var source = new [] { Five, Six };
            var target = new [] { Five };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTargetHasMoreExpressionsThenAreEquivalentShouldReturnFalse()
        {
            var source = new [] { Five };
            var target = new [] { Five, Six };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableWithDifferentValuesThenAreEquivalentShouldReturnFalse()
        {
            var source = new [] { Five, Five };
            var target = new[] { Six, Six };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableWithSameValuesInSameOrderThenAreEquivalentShouldReturnTrue()
        {
            var source = new[] { Five, Six, OfFive, OfOfFive };
            var target = new[] { Five, Six, OfFive, OfOfFive };
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenParameterWithDifferentTypeThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(
                IntParameter, StringParameter));
        }

        [Fact]
        public void GivenParameterWithDifferentNameThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(
                IntParameter, IntNamedParameter));
        }

        [Fact]
        public void GivenParameterWithDifferentByRefThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(
                IntParameter, IntByRefParameter));
        }

        [Fact]
        public void GivenParameterWithSameTypeAndNameThenAreEquivalentShouldReturnTrue()
        {
            Assert.True(eq.AreEquivalent(
                IntParameter, IntParameter));
        }
    }
}
