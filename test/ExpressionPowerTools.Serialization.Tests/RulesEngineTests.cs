using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Rules;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class RulesEngineTests
    {
        private RulesEngine target;

        public RulesEngineTests()
        {
            target = new RulesEngine();
        }

        public class RuleClass<T>
        {
            public RuleClass()
            {
            }

            public int field;

            public string OtherProp { get; set; }

            public string AltProp { get; set; }

            public RuleClass(T init)
            {
                Thing = init;
            }

            public T Thing { get; set; }

            public void SetOtherProp(string otherProp)
            {
                OtherProp = otherProp;
            }

            public void SetAltProp(string otherProp)
            {
                AltProp = otherProp;
            }

            public static void SetThing(RuleClass<T> rc, T thing) =>
                rc.Thing = thing;

            public T GetThing() => Thing;
        }

        public static Type GenericType = typeof(RuleClass<>);
        public static MethodInfo GenericSetOtherProp =
            GenericType.GetMethod(nameof(RuleClass<int>.SetOtherProp));
        public static PropertyInfo GenericThing =
            GenericType.GetProperty(nameof(RuleClass<int>.Thing));
        public static FieldInfo GenericField =
            GenericType.GetField(nameof(RuleClass<int>.field));
        public static ConstructorInfo GenericCtor =
            GenericType.GetConstructors().First(ctor => ctor.GetParameters().Length > 0);

        public static Type ClosedType = typeof(RuleClass<RulesEngineTests>);
        public static MethodInfo ClosedSetOtherProp =
            ClosedType.GetMethod(nameof(RuleClass<int>.SetOtherProp));
        public static PropertyInfo ClosedThing =
            ClosedType.GetProperty(nameof(RuleClass<int>.Thing));
        public static FieldInfo ClosedField =
            ClosedType.GetField(nameof(RuleClass<int>.field));
        public static ConstructorInfo ClosedCtor =
            ClosedType.GetConstructors().First(ctor => ctor.GetParameters().Length > 0);

        public static IEnumerable<object[]> GetBasicMembers()
        {
            yield return new object[] { GenericType, false };
            yield return new object[] { GenericSetOtherProp, false };
            yield return new object[] { GenericThing, true };
            yield return new object[] { GenericField, true };
            yield return new object[] { ClosedType, false };
            yield return new object[] { ClosedSetOtherProp, false };
            yield return new object[] { ClosedThing, true };
            yield return new object[] { ClosedField, true };
            yield return new object[] { GenericCtor, false };
            yield return new object[] { ClosedCtor, false };
        }

        [Theory]
        [MemberData(nameof(GetBasicMembers))]
        public void GivenNoConfigWhenMemberIsAllowedThenShouldReturnDefault(
            MemberInfo memberInfo,
            bool allowed)
        {
            Assert.Equal(allowed, target.MemberIsAllowed(memberInfo));
        }

        [Fact]
        public void GivenGenericTypeAllowedWhenMemberIsAllowedForClosedTypeThenShouldReturnTrue()
        {
            target.RuleForType(GenericType);
            Assert.True(target.MemberIsAllowed(ClosedType));
        }

        [Fact]
        public void GivenClosedTypeAllowedWhenMemberIsAllowedThenShouldReturnReturn()
        {
            target.RuleForType<RuleClass<RulesEngineTests>>();
            Assert.True(target.MemberIsAllowed(ClosedSetOtherProp));
        }

        [Fact]
        public void GivenConfigCallingCompileMultipleTimesYieldsSameResults()
        {
            target.RuleForProperty(selector => selector.ByMemberInfo(GenericThing))
                .Deny();
            Assert.False(target.MemberIsAllowed(GenericThing));
            target.Compile();
            Assert.False(target.MemberIsAllowed(GenericThing));
        }

        [Fact]
        public void GivenPropertyDeniedWhenMemberIsAllowedThenShouldReturnFalse()
        {
            target.RuleForProperty(selector => selector.ByMemberInfo(GenericThing))
                .Deny();
            Assert.False(target.MemberIsAllowed(GenericThing));
        }

        [Fact]
        public void GivenFieldDeniedWhenMemberRequestedThenShouldReturnFalse()
        {
            target.RuleForField(selector => selector.ByMemberInfo(GenericField))
                .Deny();
            Assert.False(target.MemberIsAllowed(GenericField));
        }

        [Fact]
        public void GivenMethodAllowedWhenMemberRequestedThenShouldReturnTrue()
        {
            target.RuleForMethod(selector => selector.ByMemberInfo(ClosedSetOtherProp));
            Assert.True(target.MemberIsAllowed(ClosedSetOtherProp));
        }

        [Fact]
        public void GivenTypeAllowedWhenMethodRequestedThenShouldReturnTrue()
        {
            target.RuleForType(GenericType);
            Assert.True(target.MemberIsAllowed(GenericSetOtherProp));
        }

        [Fact]
        public void GivenTypeDeniedWhenPropertyOrFieldRequestedThenShouldReturnFalse()
        {
            target.RuleForType(GenericType).Deny();
            Assert.False(target.MemberIsAllowed(GenericThing));
        }

        [Fact]
        public void GivenTypeAllowedAndMemberDeniedWhenMemberIsAllowedThenShouldReturnFalse()
        {
            target.RuleForType(GenericType)
                .RuleForMethod(selector => selector.ByMemberInfo(GenericSetOtherProp)).Deny();
            Assert.False(target.MemberIsAllowed(GenericSetOtherProp));
        }

        [Fact]
        public void GivenTypeDeniedAndMemberAllowedWhenMemberIsAllowedCalledThenShouldReturnTrue()
        {
            target.RuleForType(GenericType).Deny()
                .RuleForMethod(selector => selector.ByMemberInfo(GenericSetOtherProp)).Allow();
            Assert.True(target.MemberIsAllowed(GenericSetOtherProp));
        }

        [Fact]
        public void GivenGenericRulesWhenClosedAccessRequestedThenShouldDefaultToGenericReturnResult()
        {
            target.RuleForMethod(selector => selector.ByMemberInfo(GenericSetOtherProp)).Allow();
            Assert.True(target.MemberIsAllowed(ClosedSetOtherProp));
        }

        [Fact]
        public void GivenGenericRulesWhenRuleSetForClosedTypeThenShouldOverride()
        {
            target.RuleForType(GenericType).Allow()
                  .RuleForMethod(selector => selector.ByMemberInfo(ClosedSetOtherProp)).Deny();
            Assert.True(target.MemberIsAllowed(GenericSetOtherProp));
            Assert.False(target.MemberIsAllowed(ClosedSetOtherProp));
        }

        [Fact]
        public void GivenTypeAllowedAndCtorDeniedWhenMemberIsAllowedThenShouldReturnFalse()
        {
            target.RuleForType(GenericType)
                .RuleForConstructor(selector => selector.ByMemberInfo(GenericCtor)).Deny();
            Assert.False(target.MemberIsAllowed(GenericCtor));
        }

        [Fact]
        public void GivenTypeDeniedAndCtorAllowedWhenMemberIsAllowedCalledThenShouldReturnTrue()
        {
            target.RuleForType(GenericType).Deny()
                .RuleForConstructor(selector => selector.ByMemberInfo(GenericCtor)).Allow();
            Assert.True(target.MemberIsAllowed(GenericCtor));           
        }

        [Fact]
        public void GivenRuleForCtorAllowedWhenMemberIsAllowedCalledThenShouldReturnTrue()
        {
            target.RuleForConstructor(selector => selector.ByResolver<ConstructorInfo, RuleClass<RulesEngineTests>>(
                rc => new RuleClass<RulesEngineTests>(this)));
            Assert.True(target.MemberIsAllowed(ClosedCtor));
        }

        [Fact]
        public void GivenGenericRulesWhenClosedAccessRequestedForCtorThenShouldDefaultToGenericReturnResult()
        {
            target.RuleForConstructor(selector => selector.ByMemberInfo(GenericCtor)).Allow();
            Assert.True(target.MemberIsAllowed(ClosedCtor));
        }

        [Fact]
        public void GivenGenericRulesWhenRuleSetForClosedTypeCtorThenShouldOverride()
        {
            target.RuleForType(GenericType).Allow()
                  .RuleForConstructor(selector => selector.ByMemberInfo(ClosedCtor)).Deny();
            Assert.True(target.MemberIsAllowed(GenericCtor));
            Assert.False(target.MemberIsAllowed(ClosedCtor));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenNoRuleWhenAllowOrDenyCalledThenShouldThrowInvalidOperation(bool allow)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                if (allow)
                {
                    target.Allow();
                }
                else
                {
                    target.Deny();
                }
            });
        }
    }
}
