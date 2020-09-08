using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ExpressionPowerTools.Serialization.Rules;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializationRuleTests
    {
        public SerializationRule target;
        public ConstructorInfo ctor = typeof(SerializationRuleTests)
            .GetConstructors()
            .First();

        public SerializationRuleTests()
        {
            target = new SerializationRule(true, ctor);
        }

        [Fact]
        public void GivenNewSerializationRuleThenShouldInitializeProperties()
        {
            Assert.True(target.Allow);
            Assert.Equal(MemberTypes.Constructor, target.MemberType);
            Assert.Same(ctor, target.Target);
            var checkKey = new Ctor(ctor).CalculateKey();
            Assert.Equal(checkKey, target.TargetKey);
        }

        [Fact]
        public void GivenSerializationRuleWhenToStringCalledThenShouldIncludePermissionAndMemberKey()
        {
            var str = target.ToString();
            Assert.Contains(target.Allow.ToString(), str);
            Assert.Contains(target.TargetKey, str);
        }
    }
}
