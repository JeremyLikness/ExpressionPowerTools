using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class CtorSerializerTests
    {
        private readonly CtorSerializer ctorSerializer =
        new CtorSerializer(TestSerializer.ExpressionSerializer);

        private readonly IRulesConfiguration rulesConfig = ServiceHost.GetService<IRulesConfiguration>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "xUnit1013:Public method should be marked as test",
            Justification = "Used by the test.")]

        public class TestClass<T, T1>
        {
            public TestClass()
            {
            }

            public TestClass(int prop)
            {
                Prop = prop;
            }

            public TestClass(int prop, string field)
                : this(prop)
            {
                this.field = field;
            }

            public TestClass(T thing)
            {
                Thing = thing;
            }

            public TestClass(T thing, T1 _)
                : this(thing)
            {
            }

            public T Thing { get; set; }
            public IComparable<T1> Comparer { get; set; }
            public int Prop { get; set; }
            public string field;
        }

        public static IEnumerable<object[]> GetCtorMatrix()
        {
            var type = typeof(TestClass<CtorSerializerTests, string>);
            var prop = type.GetProperty(nameof(TestClass<int, int>.Prop));
            var thing = type.GetProperty(nameof(TestClass<int, int>.Thing));
            var field = type.GetField(nameof(TestClass<int, int>.field));

            ConstructorInfo noArgs = null,
                intProp = null,
                intPropField = null,
                tThing = null,
                tThingT1 = null;

            foreach(var ctor in type.GetConstructors())
            {
                if (ctor.GetParameters().Length == 0)
                {
                    noArgs = ctor;
                    continue;
                }

                if (ctor.GetParameters().Length == 2)
                {
                    if (ctor.GetParameters()[0].ParameterType == typeof(int))
                    {
                        intPropField = ctor;
                    }
                    else
                    {
                        tThingT1 = ctor;                   
                    }
                    continue;
                }

                if (ctor.GetParameters()[0].ParameterType == typeof(int))
                {
                    intProp = ctor;
                    continue;
                }
                tThing = ctor;
            }

            yield return new object[]
            {
                noArgs, null, null
            };

            yield return new object[]
            {
                intProp, new[] { 1.AsConstantExpression() }, null
            };

            yield return new object[]
            {
                intProp, new[] { 1.AsConstantExpression() }, new[] { prop }
            };

            yield return new object[]
            {
                tThing, new[] { new CtorSerializerTests().AsConstantExpression() }, null
            };

            yield return new object[]
            {
                tThing, new[] { new CtorSerializerTests().AsConstantExpression() }, new[] { thing }
            };

            yield return new object[]
            {
                tThingT1,
                new []
                {
                    new CtorSerializerTests().AsConstantExpression(),
                    nameof(CtorSerializerTests).AsConstantExpression()
                },
                null
            };

            yield return new object[]
            {
                intPropField,
                new []
                {
                    1.AsConstantExpression(),
                    nameof(intPropField).AsConstantExpression()
                },
                null
            };

            yield return new object[]
            {
                intPropField,
                new []
                {
                    1.AsConstantExpression(),
                    nameof(intPropField).AsConstantExpression()
                },
                new MemberInfo[] { prop, field }
            };

            var anon = new { Id = 2 };
            var anonCtor = anon.GetType().GetConstructors()[0];
            yield return new object[]
            {
                anonCtor,
                new [] { 2.AsConstantExpression() },
                null
            };
        }

        public static NewExpression MakeNew(ConstructorInfo info, Expression[] args, MemberInfo[] members)
        {
            if (args?.Length == 0)
            {
                return Expression.New(info);
            }

            if (members == null)
            {
                return Expression.New(info, args);
            }

            return Expression.New(info, args, members);
        }

        [Theory]
        [MemberData(nameof(GetCtorMatrix))]
        public void NewExpressionShouldSerialize(
            ConstructorInfo info,
            Expression[] args,
            MemberInfo[] members)
        {
            var expr = MakeNew(info, args, members);
            var target = ctorSerializer.Serialize(expr, new SerializationState());
            Assert.Equal((ExpressionType)target.Type, expr.NodeType);
        }

        [Theory]
        [MemberData(nameof(GetCtorMatrix))]
        public void NewExpressionShouldDeserialize(
            ConstructorInfo info,
            Expression[] args,
            MemberInfo[] members)
        {
            var expr = MakeNew(info, args, members);
            rulesConfig.RuleForConstructor(selector => selector.ByMemberInfo(info));
            var serialized = TestSerializer
                .GetSerializedFragment<CtorExpr, NewExpression>(expr);
            var deserialized = ctorSerializer.Deserialize(serialized, new SerializationState());
            Assert.True(deserialized.IsEquivalentTo(deserialized));
        }

        [Fact]
        public void GivenCtorAllowedWhenDeserializeCalledThenShouldDeserialize()
        {
            var noArgs = typeof(TestClass<int, IComparable<int>>).GetConstructors().First(
                c => c.GetParameters().Length == 0);
            rulesConfig.RuleForConstructor(selector => selector.ByMemberInfo(noArgs));
            var expr = MakeNew(noArgs, null, null);
            var serialized = TestSerializer
                .GetSerializedFragment<CtorExpr, NewExpression>(expr);
            var deserialized = ctorSerializer.Deserialize(serialized, new SerializationState());
            Assert.NotNull(deserialized);
        }

        [Fact]
        public void GivenCtorNotAllowedWhenDeserializeCalledThenShouldThrowUnauthorizedAccess()
        {
            var noArgs = typeof(TestClass<int,IComparable<int>>).GetConstructors().First(
            c => c.GetParameters().Length == 0);
            rulesConfig.RuleForConstructor(selector => selector.ByMemberInfo(noArgs)).Deny();
            var expr = MakeNew(noArgs, null, null);
            var serialized = TestSerializer
                .GetSerializedFragment<CtorExpr, NewExpression>(expr);
            Assert.Throws<UnauthorizedAccessException>(() =>
                ctorSerializer.Deserialize(serialized, new SerializationState()));
        }

        public override bool Equals(object obj) => obj is CtorSerializerTests;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
