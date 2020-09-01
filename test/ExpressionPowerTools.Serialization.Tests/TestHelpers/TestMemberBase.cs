using System;
using System.Reflection;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestMemberBase : MemberBase
    {
        public override int MemberType
        {
            get => (int)MemberTypes.Constructor;
            set => throw new NotImplementedException();
        }

        public override string CalculateKey() => Guid.NewGuid().ToString();
    }
}
