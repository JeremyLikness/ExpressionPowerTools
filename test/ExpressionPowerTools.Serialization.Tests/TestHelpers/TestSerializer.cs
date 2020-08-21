using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestSerializer : IExpressionSerializer<Expression, SerializableExpression>
    {
        public bool DeserializeCalled { get; private set; }
        public bool SerializeCalled { get; private set; }
        public Expression ReturnExpression { get; set; } = Expression.Constant(42);
        public SerializableExpression ReturnSerializableExpression { get; set; } =
            new SerializableExpression(Expression.Constant(42));

        public Expression Deserialize(JsonElement json) => ReturnExpression;

        public SerializableExpression Serialize(Expression expression) => ReturnSerializableExpression;

        public static TSerializer GetSerializer<TSerializer, TExpression>(TExpression expression)
            where TExpression : Expression
            where TSerializer : SerializableExpression
        {
            if (expression is ConstantExpression constant)
            {
                return new Constant(constant) as TSerializer;
            }

            if (expression is ParameterExpression parameter)
            {
                return new Parameter(parameter) as TSerializer;
            }

            if (expression is NewArrayExpression newArray)
            {
                var returnVal = new NewArray(newArray);
                var testSerializer = new TestSerializer();
                foreach (var child in newArray.Expressions)
                {
                    returnVal.Expressions.Add(testSerializer.Serialize(child));
                }
            }

            return new SerializableExpression(expression) as TSerializer;
        }

        public static JsonElement GetSerializedFragment<TSerializer, TExpression>(TExpression expression)
            where TExpression : Expression
            where TSerializer : SerializableExpression =>
            JsonDocument.Parse(
            JsonSerializer.Serialize(GetSerializer<TSerializer, TExpression>(expression))).RootElement;
    }
}
