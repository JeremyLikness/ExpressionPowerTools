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

        public static IEnumerable<object[]> GetConstantExpressions =
            ConstantSerializerTests.GetConstantExpressions();

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void GivenExpressionWhenSerializedThenShouldDeserialize(ConstantExpression constant)
        {
            var json = Serializer.Serialize(constant);
            var target = Serializer.Deserialize<ConstantExpression>(json);

            if (constant.Type.FullName.Contains("AnonymousType"))
            {
                Assert.Equal(
                    constant.Type.GetProperties().Where(p => p.CanRead).Select(p => p.Name),
                    ((IDictionary<string, object>)target.Value).Keys);
            }
            else
            {
                Assert.Equal(constant.Type, target.Type);
                Assert.Equal(constant.Value, target.Value);
            }
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

        public static IEnumerable<object[]> GetUnaryExpressions() =>
            UnarySerializerTests.GetUnaryExpressions();

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void GivenUnaryExpressionWhenSerializedThenShouldDeserialize(UnaryExpression unary)
        {
            var json = Serializer.Serialize(unary);
            var target = Serializer.Deserialize<UnaryExpression>(json);
            Assert.Equal(unary.Type, target.Type);
            Assert.Equal(unary.Operand?.NodeType, target.Operand?.NodeType);

            if (unary.Method != null)
            {
                Assert.Equal(unary.Method, target.Method);
            }
        }
    }
}
