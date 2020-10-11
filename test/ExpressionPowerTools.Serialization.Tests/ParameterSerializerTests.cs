using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ParameterSerializerTests
    {
        private readonly ParameterSerializer serializer =
            new ParameterSerializer(TestSerializer.ExpressionSerializer);

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
            var serializable = serializer.Serialize(parameter, new SerializationState());
            Assert.Equal(parameter.Type, TestSerializer.MemberAdapter.GetMemberForKey<Type>(serializable.ParameterTypeKey));
            if (!string.IsNullOrWhiteSpace(parameter.Name))
            {
                Assert.Equal(parameter.Name, serializable.Name);
            }
        }

        [Theory]
        [MemberData(nameof(GetParameterExpressions))]
        public void ParameterExpressionShouldDeserialize(ParameterExpression parameter)
        {
            var serialized = TestSerializer.GetSerializedFragment<Parameter, ParameterExpression>(parameter);
            var deserialized = serializer.Deserialize(serialized, TestSerializer.State);
            Assert.Equal(parameter.Type, deserialized.Type);
            if (!string.IsNullOrWhiteSpace(parameter.Name))
            {
                Assert.Equal(parameter.Name, deserialized.Name);
            }
        }

        [Fact]
        public void GivenOptionsIgnoreNullWhenParameterSerializedThenShouldDeserialize()
        {
            var parameter = Expression.Parameter(typeof(long));
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };

            var serialized = TestSerializer.GetSerializedFragment<Parameter, ParameterExpression>(parameter, options);
            var deserialized = serializer.Deserialize(serialized, TestSerializer.State);
            Assert.Equal(parameter.Type, deserialized.Type);
        }
    }
}
