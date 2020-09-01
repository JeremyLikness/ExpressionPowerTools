using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class MemberSerializerTests
    {
        private readonly MemberSerializer memberSerializer =
        new MemberSerializer(TestSerializer.ExpressionSerializer);

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "xUnit1013:Public method should be marked as test",
            Justification = "Used by the test.")]
        
        public int InstanceProperty { get; set; } 
        public static int StaticProperty { get; set; } 
        public string ReadOnlyProperty { get => InstanceProperty.ToString(); }
        public int instanceField;
        public static int staticField;

        public static IEnumerable<object[]> GetMemberMatrix()
        {
            var type = typeof(MemberSerializerTests);
            var flags = BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static;
            var instance = Expression.Constant(
                new MemberSerializerTests());
            var instanceProp = type.GetProperty(nameof(InstanceProperty));
            var readonlyProp = type.GetProperty(nameof(ReadOnlyProperty));
            var instanceFieldInfo = type.GetField(nameof(instanceField));
            var staticFieldInfo = type.GetField(nameof(staticField), flags);
            var staticProp = type.GetProperty(
                nameof(StaticProperty), flags);

            yield return new object[]
            {
                Expression.MakeMemberAccess(instance, instanceProp)
            };

            yield return new object[]
            {
                Expression.MakeMemberAccess(instance, readonlyProp)
            };

            yield return new object[]
            {
                Expression.MakeMemberAccess(null, staticProp)
            };

            yield return new object[]
            {
                Expression.MakeMemberAccess(instance, instanceFieldInfo)
            };

            yield return new object[]
            {
                Expression.MakeMemberAccess(null, staticFieldInfo)
            };
        }

        [Theory]
        [MemberData(nameof(GetMemberMatrix))]
        public void MemberExpressionShouldSerialize(MemberExpression member)
        {
            var target = memberSerializer.Serialize(member, null);
            Assert.Equal((ExpressionType)target.Type, member.NodeType);
        }

        [Theory]
        [MemberData(nameof(GetMemberMatrix))]
        public void MemberExpressionShouldDeserialize(MemberExpression member)
        {
            var serialized = TestSerializer
                .GetSerializedFragment<MemberExpr, MemberExpression>(member);
            var deserialized = memberSerializer.Deserialize(serialized, new SerializationState());
            Assert.Equal(member.Type.FullName, deserialized.Type.FullName);
            Assert.True(deserialized.IsEquivalentTo(deserialized));
        }

        public override bool Equals(object obj) =>
            obj is MemberSerializerTests;

        public override int GetHashCode() => 5;
    }
}
