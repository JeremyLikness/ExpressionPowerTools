using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class MemberInitSerializerTests
    {
        private readonly MemberInitSerializer memberInitSerializer =
            new MemberInitSerializer(TestSerializer.ExpressionSerializer);

        public class TestData
        {
            public TestData() { }

            public TestData(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }

        public TestData TestProp { get; set; } = new TestData();
        public List<TestData> TestProps { get; set; } = new List<TestData>();

        public static Expression<Func<MemberInitSerializerTests>> memberAssignmentExpr =
                () => new MemberInitSerializerTests { TestProp = new TestData() };
        public static Expression<Func<TestData>> memberAssignmentExprDifferentType =
                () => new TestData { Name = "Hello" };
        public static Expression<Func<TestData>> memberAssignmentExprDifferentTypeCtor =
                () => new TestData("Hello") { Name = "GoodBye" };
        public static Expression<Func<MemberInitSerializerTests>> memberAssignmentDup =
                () => new MemberInitSerializerTests { TestProp = new TestData() };
        public static Expression<Func<MemberInitSerializerTests>> memberAssignmentExprAlt =
            () => new MemberInitSerializerTests { TestProp = null };
        public static Expression<Func<MemberInitSerializerTests>> memberMemberBindingExpr =
            () => new MemberInitSerializerTests { TestProp = { Name = nameof(MemberInitSerializerTests) } };
        public static Expression<Func<MemberInitSerializerTests>> memberListBindingExpr =
            () => new MemberInitSerializerTests { TestProps = { new TestData(), new TestData() } };
        public static Expression<Func<MemberInitSerializerTests>> memberListBindingExprAlt =
            () => new MemberInitSerializerTests { TestProps = { new TestData(), null } };

        public static IEnumerable<object[]> GetMemberInitMatrix()
        {
            static MemberInitExpression Resolve(LambdaExpression expr)
                => expr.Body as MemberInitExpression;

            yield return new object[]
            {
                Resolve(memberListBindingExpr),
            };

            yield return new object[]
            {
                Resolve(memberListBindingExprAlt),
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExprAlt),
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExpr),
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExprDifferentType),                
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExprDifferentType),
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExprDifferentTypeCtor),
            };

            yield return new object[]
            {
                Resolve(memberAssignmentDup),
            };

            yield return new object[]
            {
                Resolve(memberMemberBindingExpr),
            };
        }

        [Theory]
        [MemberData(nameof(GetMemberInitMatrix))]
        public void GivenMemberInitExpressionThenShouldSerialize(MemberInitExpression expression)
        {
            var target = memberInitSerializer.Serialize(expression, new SerializationState());
            Assert.Equal((ExpressionType)target.Type, expression.NodeType);
        }

        [Theory]
        [MemberData(nameof(GetMemberInitMatrix))]
        public void GivenMemberInitExpressionThenShouldDeserialize(MemberInitExpression expression)
        {
            var serialized = TestSerializer
                .GetSerializedFragment<MemberInit, MemberInitExpression>(expression);
            ServiceHost.GetService<IRulesConfiguration>().RuleForType<TestData>()
                .RuleForType<MemberInitSerializerTests>()
                .RuleForType(typeof(List<>));
            var deserialized = memberInitSerializer.Deserialize(serialized, new SerializationState());
            Assert.Equal(expression.Type.FullName, deserialized.Type.FullName);
            Assert.True(expression.IsEquivalentTo(deserialized));
        }
    }
}
