using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ConstantSerializerTests
    {
        [Fact]
        public void ConstantExpressionShouldSerialize()
        {
            var constant = Expression.Constant(42);
            var serializer = new ConstantSerializer(new TestSerializer());
            var target = serializer.Serialize(constant);
            Assert.Equal(constant.Type.FullName, target.ConstantType);
            Assert.Equal(constant.Value, target.Value);            
        }

        [Fact]
        public void ConstantExpressionShouldDeserialize()
        {
            var constant = Expression.Constant(42);
            var serializer = new ConstantSerializer(new TestSerializer());
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(constant);
            var deserialized = serializer.Deserialize(serialized);
            Assert.Equal(constant.Type, deserialized.Type);
            Assert.Equal(constant.Value, deserialized.Value);            
        }
    }
}
