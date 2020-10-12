using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;
using System.Reflection;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Dependencies;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ConstantSerializerTests
    {
        private readonly ConstantSerializer serializer =
            new ConstantSerializer(TestSerializer.ExpressionSerializer);

        private readonly IExpressionEvaluator evaluator =
            ServiceHost.GetService<IExpressionEvaluator>();

        public static IEnumerable<object[]> GetConstantExpressions()
        {
            yield return new object[]
            {
                Expression.Constant(new { foo = "bar", bar = new { bar = "foo" } })
            };

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
            var target = serializer.Serialize(constant, TestSerializer.State);
            if (target.Value is Constant constantValue)
            {
                Assert.True(evaluator.ValuesAreEquivalent(
                    ((ConstantExpression)constant.Value).Value,
                    constantValue.Value));
            }
            else if (constant.Value is MemberInfo member)
            {
                Assert.Contains(member.Name, (string)target.Value);
            }
            else if (constant.Type.IsAnonymousType())
            {
                Assert.IsType<AnonType>(target.Value);
            }
            else
            {
                Assert.True(evaluator.ValuesAreEquivalent(constant.Value, target.Value));
            }
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void ConstantExpressionShouldDeserialize(ConstantExpression constant)
        {
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(constant);
            var deserialized = serializer.Deserialize(serialized, TestSerializer.State, ExpressionType.Constant);
            Assert.True(evaluator.ValuesAreEquivalent(constant.Value, deserialized.Value));
        }

        [Fact]
        public void GivenEnumerableQueryWhenQueryRootIsConstantExpressionThenShouldBeSet()
        {
            EnumerableQuery<int> query = new EnumerableQuery<int>(Expression.Constant(new int[0]));
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(Expression.Constant(query));
            var root = Expression.Constant(2);
            TestSerializer.State.QueryRoot = root;
            var deserialized = serializer.Deserialize(serialized, TestSerializer.State, ExpressionType.Constant);
            Assert.Same(deserialized, root);
        }

        [Fact]
        public void GivenEnumerableQueryWhenQueryRootIsNonConstantExpressionThenShouldBeSet()
        {
            EnumerableQuery<int> query = new EnumerableQuery<int>(Expression.Constant(new int[] { 1, 2 }));
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(Expression.Constant(query));
            Expression<Func<int[]>> one = () => new[] { 1 };
            var root = Expression.Invoke(one, one.Parameters);
            var state = TestSerializer.State;
            state.QueryRoot = root;
            var deserialized = serializer.Deserialize(serialized, state, ExpressionType.Constant);
            Assert.IsAssignableFrom<InvocationExpression>(deserialized.Value);
            Assert.Same(deserialized.Value, root);
        }

        [Fact]
        public void GivenEnumerableQueryWhenQueryRootIsNullThenShouldReturnNullConstant()
        {
            EnumerableQuery<int> query = new EnumerableQuery<int>(Expression.Constant(new int[2]));
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(Expression.Constant(query));
            var deserialized = serializer.Deserialize(serialized, TestSerializer.State, ExpressionType.Constant);
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
            var deserialized = serializer.Deserialize(serialized, TestSerializer.State, ExpressionType.Constant);
            Assert.NotNull(deserialized);
        }        
    }
}
