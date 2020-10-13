using System;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ExpressionSerializerTests
    {
        private readonly Serializers.ExpressionSerializer target = new Serializers.ExpressionSerializer();

        [Fact]
        public void GivenExpressionHasSerializerWhenSerializeCalledThenShouldSerialize()
        {
            var serialized = target.Serialize(Expression.Constant(5), new SerializationState());
            Assert.NotNull(serialized);
            Assert.Equal(ExpressionType.Constant, (ExpressionType)serialized.Type);
        }

        [Fact]
        public void GivenExpressionHasSerializerWhenDeserializeCalledThenShouldDeserialize()
        {
            var serialized = TestSerializer.ExpressionSerializer.Serialize(
                Expression.Constant(5), TestSerializer.GetDefaultState());
            var deserialized = target.Deserialize(serialized, TestSerializer.State);
            Assert.IsType<ConstantExpression>(deserialized);
            Assert.Equal(5, ((ConstantExpression)deserialized).Value);
        }

        [Fact]
        public void GivenExpressionHasNoSerializerWhenSerializeCalledThenShouldReturnSerializableExpression()
        {
            var serialized = target.Serialize(Expression.Goto(Expression.Label()), null);
            Assert.IsType<SerializableExpression>(serialized);
            Assert.Equal(ExpressionType.Goto, (ExpressionType)serialized.Type);
        }
    }
}
