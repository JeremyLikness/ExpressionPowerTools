using System;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestSerializableExpression : SerializableExpression
    {
        public Type GetType(string type, bool useTyped) =>
            useTyped ?
            GetMemberFromKey<Type>(type) :
            GetMemberFromKey(type) as Type;
    }
}
