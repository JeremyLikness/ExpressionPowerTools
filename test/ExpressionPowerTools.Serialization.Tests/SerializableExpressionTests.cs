using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializableExpressionTests
    {
        [Fact]
        public void GivenNullExpressionWhenConstructorCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SerializableExpression(null));
        }

        [Fact]
        public void GivenNonNullExpressionWhenConstructorCalledThenShouldSetType()
        {
            var target = new SerializableExpression(Expression.Constant(5));
            Assert.Equal(ExpressionType.Constant.ToString(), target.Type);
        }
    }
}
