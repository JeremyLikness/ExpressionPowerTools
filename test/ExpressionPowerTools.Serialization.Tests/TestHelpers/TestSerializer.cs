using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Members;
using ExpressionPowerTools.Core.Signatures;
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

        public static SerializationState GetDefaultState()
        {
            State = ServiceHost.GetService<IDefaultConfiguration>().GetDefaultState();
            return State;
        }

        public static SerializationState State { get; private set; }

        public static object[] AsObjectArray(this object source) => new object[] { source };
    }
}
