using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class LambdaSerializerTests
    {
        private readonly LambdaSerializer lambdaSerializer =
            new LambdaSerializer(TestSerializer.ExpressionSerializer);

        public static IEnumerable<object[]> GetLambdaExpressions()
        {
            Expression<Func<int>> expr = () => 1;

            yield return new object[]
            {
                Expression.Lambda(expr.Body, expr.Parameters)
            };
        }

        [Theory]
        [MemberData(nameof(GetLambdaExpressions))]
        public void LambdaExpressionShouldSerialize(LambdaExpression lambda)
        {
            var target = lambdaSerializer.Serialize(lambda, null);
            Assert.Equal(target.Type, lambda.NodeType.ToString());
        }

        [Theory]
        [MemberData(nameof(GetLambdaExpressions))]
        public void LambdaExpressionShouldDeserialize(LambdaExpression lambda)
        {
            var serialized = TestSerializer.GetSerializedFragment<Lambda, LambdaExpression>(lambda);
            var deserialized = lambdaSerializer.Deserialize(serialized, null, null);
            Assert.Equal(lambda.Type.FullName, deserialized.Type.FullName);
        }
    }
}
