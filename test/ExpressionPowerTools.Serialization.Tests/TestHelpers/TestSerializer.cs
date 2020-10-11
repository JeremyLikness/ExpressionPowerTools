using System.ComponentModel;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Members;
using ExpressionPowerTools.Core.Signatures;
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

        public static IMemberAdapter MemberAdapter { get; private set; } =
            new MemberAdapter();

        public static SerializationState State { get; private set; }

        public static JsonElement GetSerializedFragment<TSerializer, TExpression>(
            TExpression expression,
            JsonSerializerOptions options = null)
            where TExpression : Expression
            where TSerializer : SerializableExpression
        {
            var state = ServiceHost.GetService<IDefaultConfiguration>()
                .GetDefaultState();
            if (options != null)
            {
                state.Options = options;
            }

            var json = JsonSerializer.Serialize(
                ExpressionSerializer.Serialize(expression, state) as TSerializer,
                options);
            State = state;
            return JsonDocument.Parse(json).RootElement;
        }

        public static object[] AsObjectArray(this object source) => new object[] { source };
    }
}
