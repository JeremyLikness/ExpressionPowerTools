using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class LambdaSerializerTests
    {
        private readonly LambdaSerializer lambdaSerializer =
            new LambdaSerializer(TestSerializer.ExpressionSerializer);

        private readonly IRulesConfiguration rulesConfig;

        public LambdaSerializerTests()
        {
            rulesConfig = ServiceHost.GetService<IRulesConfiguration>();
            rulesConfig.RuleForType<LambdaSerializerTests>();
        }

        public static IEnumerable<object[]> GetLambdaExpressions()
        {
            Expression<Func<int>> expr = () => 1;
            Expression<Func<string, string, bool>> strExpr = (target, pattern) =>
                  target.Contains(pattern);

            yield return new object[]
            {
                Expression.Lambda(expr.Body, expr.Parameters)
            };

            yield return new object[]
            {
                Expression.Lambda<Func<string,string,bool>>(strExpr.Body, strExpr.Parameters)
            };
        }

        [Theory]
        [MemberData(nameof(GetLambdaExpressions))]
        public void LambdaExpressionShouldSerialize(LambdaExpression lambda)
        {
            var target = lambdaSerializer.Serialize(lambda, TestSerializer.State);
            Assert.Equal((ExpressionType)target.Type, lambda.NodeType);
        }

        [Theory]
        [MemberData(nameof(GetLambdaExpressions))]
        public void LambdaExpressionShouldDeserialize(LambdaExpression lambda)
        {
            var serialized = TestSerializer.GetSerializedFragment<Lambda, LambdaExpression>(lambda);
            var deserialized = lambdaSerializer.Deserialize(serialized, TestSerializer.State);
            Assert.Equal(lambda.Type.FullName, deserialized.Type.FullName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "xUnit1013:Public method should be marked as test",
            Justification = "Used by test.")]
        public void DoNothing()
        {
        }

        [Fact]
        public void GivenNullOptionsWhenLambdaSerializedThenShouldDeserialize()
        {
            Expression<Action> empty = () => DoNothing();
            var lambda = Expression.Lambda(empty.Body, empty.Parameters);
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };
            var serialized = TestSerializer.GetSerializedFragment<Lambda, LambdaExpression>(lambda, options);
            var deserialized = lambdaSerializer.Deserialize(serialized, TestSerializer.State);
            Assert.NotNull(deserialized);
        }

        [Fact]
        public void GivenObjectWhenLambdaExpressionThatReferencesPropertyIsDeserializedThenShouldResolveProperty()
        {
            var things = TestableThing.MakeQuery(2).ToList();
            Expression<Func<List<TestableThing>, string>> firstId =
                list => list.First().Id;
            var serialized = TestSerializer.GetSerializedFragment<Lambda, LambdaExpression>(firstId);
            var deserialized = lambdaSerializer.Deserialize(serialized, TestSerializer.State);
            var expected = firstId.Compile()(things);
            var actual = deserialized.Compile().DynamicInvoke(things);
            Assert.Equal(expected, actual);
        }
    }
}
