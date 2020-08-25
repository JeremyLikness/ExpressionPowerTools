using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class InvocationSerializerTests
    {
        private readonly InvocationSerializer invocationSerializer =
            new InvocationSerializer(TestSerializer.ExpressionSerializer);

        private readonly Expression<Func<int, bool>> expr = i => true;

        // TODO: expr => i > 5;

        [Fact]
        public void InvocationExpressionShouldSerialize()
        {
            var invocation = Expression.Invoke(expr, expr.Parameters);
            var target = invocationSerializer.Serialize(invocation);
            Assert.Equal(target.Type, invocation.NodeType.ToString());
        }

        [Fact]
        public void InvocationExpressionShouldDeserialize()
        {
            var invocation = Expression.Invoke(expr, expr.Parameters);
            var serialized = TestSerializer.GetSerializedFragment<Invocation,
                InvocationExpression>(invocation);
            var deserialized = invocationSerializer.Deserialize(serialized);
            Assert.Equal(invocation.Type.FullName, deserialized.Type.FullName);
        }
    }
}
