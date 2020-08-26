using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestBaseSerializer : BaseSerializer<Expression, SerializableExpression>
    {
        public TestBaseSerializer() : base(TestSerializer.ExpressionSerializer)
        {
        }

        public override Expression Deserialize(JsonElement json)
        {
            throw new System.NotImplementedException();
        }

        public ExpressionType GetExpressionType(string type)
            => GetExpressionTypeFor(type);

        public override SerializableExpression Serialize(Expression expression)
        {
            throw new System.NotImplementedException();
        }
    }
}
