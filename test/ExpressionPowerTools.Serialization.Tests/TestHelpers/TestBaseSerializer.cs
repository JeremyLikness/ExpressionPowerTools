using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestBaseSerializer : BaseSerializer<MethodCallExpression, SerializableExpression>
    {
        public TestBaseSerializer() : base(TestSerializer.ExpressionSerializer)
        {
        }

        public override MethodCallExpression Deserialize(
            JsonElement json,
            SerializationState state,
            SerializableExpression template,
            ExpressionType expressionType)
        {
            throw new System.NotImplementedException();
        }

        public override SerializableExpression Serialize(MethodCallExpression expression, SerializationState state)
        {
            throw new System.NotImplementedException();
        }
    }
}
