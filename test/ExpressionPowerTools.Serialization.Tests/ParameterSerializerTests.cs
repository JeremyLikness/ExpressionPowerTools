using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ParameterSerializerTests
    {
        public static IEnumerable<object[]> GetParameterExpressions()
        {

            yield return new object[]
            {
                Expression.Parameter(typeof(int))
            };

            yield return new object[]
            {
                Expression.Parameter(typeof(string), nameof(GetParameterExpressions))
            };
        }

        [Theory]
        [MemberData(nameof(GetParameterExpressions))]
        public void ParameterExpressionShouldSerialize(ParameterExpression parameter)
        {
            var serializer = new ParameterSerializer(new TestSerializer());
            var serializable = serializer.Serialize(parameter);
            Assert.Equal(parameter.Type.FullName, serializable.ParameterType);
            if (!string.IsNullOrWhiteSpace(parameter.Name))
            {
                Assert.Equal(parameter.Name, serializable.Name);
            }
        }

        [Theory]
        [MemberData(nameof(GetParameterExpressions))]
        public void ParameterExpressionShouldDeserialize(ParameterExpression parameter)
        {
            var serializer = new ParameterSerializer(new TestSerializer());
            var serialized = TestSerializer.GetSerializedFragment<Parameter, ParameterExpression>(parameter);
            var deserialized = serializer.Deserialize(serialized);
            Assert.Equal(parameter.Type, deserialized.Type);
            if (!string.IsNullOrWhiteSpace(parameter.Name))
            {
                Assert.Equal(parameter.Name, deserialized.Name);
            }
        }
    }
}
