using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class NewArraySerializerTests
    {
        private readonly NewArraySerializer serializer =
            new NewArraySerializer(TestSerializer.ExpressionSerializer);

        [Fact]
        public void NewArrayExpressionShouldSerialize()
        {
            var newArray = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2));
            var target = serializer.Serialize(newArray);
            Assert.Equal(newArray.Type.GetElementType().FullName, target.ArrayType);
            Assert.True(target.Expressions.OfType<Constant>().Any());
        }

        [Fact]
        public void NewArrayExpressionShouldDeserialize()
        {
            var newArray = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2));

            var serialized = JsonDocument.Parse("{\"Expression\":{\"ArrayType\":\"System.Int32\",\"Expressions\":" +
                "[{\"ConstantType\":\"System.Int32\",\"ValueType\":\"System.Int32\",\"Value\":1,\"Type\":\"Constant\"}," +
                "{\"ConstantType\":\"System.Int32\",\"ValueType\":\"System.Int32\",\"Value\":2,\"Type\":\"Constant\"}]}}");

            var deserialized = serializer.Deserialize(serialized.RootElement.GetProperty("Expression"));

            Assert.Equal(newArray.Type, deserialized.Type);
            Assert.Equal(
                newArray.Expressions.OfType<ConstantExpression>().Select(ce => ce.Value),
                deserialized.Expressions.OfType<ConstantExpression>().Select(ce => ce.Value));
        }
    }
}
