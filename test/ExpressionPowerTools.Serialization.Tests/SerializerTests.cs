using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializerTests
    {
        [Fact]
        public void GivenSerializeWhenCalledWithNullThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                Serializer.Serialize(null));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenDeserializeWhenCalledWithNullOrEmptyStringThenShouldThrowArgument(string json)
        {
            Assert.Throws<ArgumentException>(() =>
                Serializer.Deserialize(json));
        }

        [Fact]
        public void GivenAConstantPrimitiveWhenSerializedThenShouldDeserialize()
        {
            var five = Expression.Constant(5);
            var json = Serializer.Serialize(five);
            var target = Serializer.Deserialize<ConstantExpression>(json);
            Assert.Equal(five.Type, target.Type);
            Assert.Equal(five.Value, target.Value);
        }

        [Fact]
        public void GivenAConstantWithAnExpressionAsTheValueWhenSerializedThenShouldDeserialize()
        {
            var five = Expression.Constant(5);
            var expr = Expression.Constant(five);
            var json = Serializer.Serialize(expr);
            var target = Serializer.Deserialize<ConstantExpression>(json);
            Assert.IsType<ConstantExpression>(target.Value);
            Assert.Equal(5, (target.Value as ConstantExpression).Value);
        }

        [Fact]
        public void GivenAnArrayWithExpressionsWhenSerializedThenShouldDeserialize()
        {
            var array = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2),
                Expression.Constant(3));
            var json = Serializer.Serialize(array);
            var target = Serializer.Deserialize<NewArrayExpression>(json);
            Assert.NotNull(target);
            Assert.Equal(typeof(int[]), target.Type);
            Assert.Equal(
                array.Expressions.OfType<ConstantExpression>().Select(c => c.Value),
                target.Expressions.OfType<ConstantExpression>().Select(c => c.Value));
        }

        public static IEnumerable<object[]> GetParameterExpressions() =>
            ParameterSerializerTests.GetParameterExpressions();

        [Theory]
        [MemberData(nameof(GetParameterExpressions))]
        public void GivenParameterExpressionWhenSerializedThenShouldDeserialize(ParameterExpression parameter)
        {
            var json = Serializer.Serialize(parameter);
            var target = Serializer.Deserialize<ParameterExpression>(json);
            Assert.Equal(parameter.Type, target.Type);
            Assert.Equal(parameter.Name, target.Name);
        }
    }
}
