using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.Extensions;
using Xunit;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ConstantSerializerTests
    {
        private readonly ConstantSerializer serializer =
            new ConstantSerializer(TestSerializer.ExpressionSerializer);

        public static IEnumerable<object[]> GetConstantExpressions()
        {
            yield return new object[]
            {
                Expression.Constant(typeof(IComparable<>))
            };

            yield return new object[]
            {
                Expression.Constant(5)
            };

            yield return new object[]
            {
                Expression.Constant(null, typeof(object))
            };

            yield return new object[]
            {
                Expression.Constant(new { foo = "bar", id = 42 })
            };

            yield return new object[]
            {
                Expression.Constant(new { foo = "bar", bar = default(object) })
            };

            yield return new object[]
            {
                Expression.Constant(new int[0])
            };

            yield return new object[]
            {
                Expression.Constant(new int[] { 1, 2 })
            };

            yield return new object[]
            {
                Expression.Constant(5, typeof(IComparable))
            };

            yield return new object[]
            {
                Expression.Constant(Expression.Constant(5))
            };
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void ConstantExpressionShouldSerialize(ConstantExpression constant)
        {
            var target = serializer.Serialize(constant, new SerializationState());
            if (target.Value is AnonType anon)
            {
                Assert.True(ExpressionEquivalency.ValuesAreEquivalent(
                    constant.Value, anon.GetValue()));
            }
            else if (target.Value is Constant constantValue)
            {
                Assert.True(ExpressionEquivalency.ValuesAreEquivalent(
                    ((ConstantExpression)constant.Value).Value,
                    constantValue.Value));
            }
            else if (constant.Value is MemberInfo member)
            {
                Assert.Contains(member.Name, (string)target.Value);
            }
            else
            {
                Assert.True(ExpressionEquivalency.ValuesAreEquivalent(constant.Value, target.Value));
            }
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void ConstantExpressionShouldDeserialize(ConstantExpression constant)
        {
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(constant);
            var deserialized = serializer.Deserialize(serialized, new SerializationState());
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(constant.Value, deserialized.Value));
        }

        [Fact]
        public void GivenEnumerableQueryWhenQueryRootIsConstantExpressionThenShouldBeSet()
        {
            EnumerableQuery<int> query = new EnumerableQuery<int>(Expression.Constant(new int[0]));
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(Expression.Constant(query));
            var root = Expression.Constant(2);
            var deserialized = serializer.Deserialize(serialized, root.ToSerializationState());
            Assert.Same(deserialized, root);
        }

        [Fact]
        public void GivenEnumerableQueryWhenQueryRootIsNonConstantExpressionThenShouldBeSet()
        {
            EnumerableQuery<int> query = new EnumerableQuery<int>(Expression.Constant(new int[] { 1, 2 }));
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(Expression.Constant(query));
            Expression<Func<int[]>> one = () => new[] { 1 };
            var root = Expression.Invoke(one, one.Parameters);
            var deserialized = serializer.Deserialize(serialized, root.ToSerializationState());
            Assert.IsAssignableFrom<InvocationExpression>(deserialized.Value);
            Assert.Same(deserialized.Value, root);
        }

        [Fact]
        public void GivenEnumerableQueryWhenQueryRootIsNullThenShouldReturnNullConstant()
        {
            EnumerableQuery<int> query = new EnumerableQuery<int>(Expression.Constant(new int[2]));
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(Expression.Constant(query));
            var deserialized = serializer.Deserialize(serialized, new SerializationState());
            Assert.Null(deserialized.Value);
        }

        [Fact]
        public void GivenOptionIgnoreNullValuesWhenConstantExpressionSerializedThenShouldDeserialize()
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(
                Expression.Constant(null), options);
            var deserialized = serializer.Deserialize(serialized, new SerializationState());
            Assert.NotNull(deserialized);
        }

        [Fact]
        public void GivenNoParameterValuesWhenGetValueCalledThenShouldReturnNull()
        {
            var target = new AnonType
            {
                AnonymousTypeName = "test"
            };
            Assert.Null(target.GetValue());
        }

        [Fact]
        public void GivenAnonTypeWhenGetValueCalledMultipleTimesThenShouldReturnSameInstance()
        {
            var target = new AnonType(new { Foo = 1, Bar = "two" });
            Assert.Same(target.GetValue(), target.GetValue());
        }
    }
}
