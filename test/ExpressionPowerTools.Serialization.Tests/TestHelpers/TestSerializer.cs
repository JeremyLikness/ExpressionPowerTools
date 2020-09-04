using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public static class TestSerializer 
    {
        public static ExpressionSerializer ExpressionSerializer { get; } =
            new ExpressionSerializer();

        public static IReflectionHelper ReflectionHelper { get; private set; } =
            new ReflectionHelper();
        
        public static JsonElement GetSerializedFragment<TSerializer, TExpression>(
            TExpression expression,
            JsonSerializerOptions options = null)
            where TExpression : Expression
            where TSerializer : SerializableExpression
        {
            var state = options == null ?
                new SerializationState() : options.ToSerializationState();
            var json = JsonSerializer.Serialize(
                ExpressionSerializer.Serialize(expression, state) as TSerializer,
                options);
            return JsonDocument.Parse(json).RootElement;
        }

        public static object[] AsObjectArray(this object source) => new object[] { source };
    }
}
