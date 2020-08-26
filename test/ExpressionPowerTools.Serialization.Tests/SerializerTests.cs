using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializerTests
    {
        [Fact]
        public void GivenSerializeWhenCalledWithNullThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                Serializer.Serialize(null));
        }

        public static IEnumerable<object[]> GetSerializers()
        {
            foreach (var type in typeof(IBaseSerializer).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface &&
                    typeof(IBaseSerializer).IsAssignableFrom(t)))
            {
                yield return new object[]
                {
                    Activator
                    .CreateInstance(
                        type,
                        new[] { (object)TestSerializer.ExpressionSerializer })
                    as IBaseSerializer
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetSerializers))]
        public void GivenSerializerWhenSerializeCalledWithNullThenShouldReturnNull(IBaseSerializer serializer)
        {
            Assert.Null(serializer.Serialize(null));
        }

        [Fact]
        public void WhenDeserializeCalledWithEmptyJsonThenShouldReturnNull()
        {
            Assert.Null(Serializer.Deserialize("{}"));
        }

        [Fact]
        public void WhenGetExpressionTypeForCalledWithInvalidStringThenShouldReturnDefault()
        {
            Assert.Equal(default, new TestBaseSerializer().GetExpressionType("fake"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenDeserializeWhenCalledWithNullOrEmptyStringThenShouldThrowArgument(string json)
        {
            Assert.Throws<ArgumentException>(() =>
                Serializer.Deserialize(json));
        }

        public static IEnumerable<object[]> GetConstantExpressions =
            ConstantSerializerTests.GetConstantExpressions();

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void GivenExpressionWhenSerializedThenShouldDeserialize(ConstantExpression constant)
        {
            var json = Serializer.Serialize(constant);
            var target = Serializer.Deserialize<ConstantExpression>(json);

            if (constant.Type.FullName.Contains("AnonymousType"))
            {
                Assert.Equal(
                    constant.Type.GetProperties().Where(p => p.CanRead).Select(p => p.Name),
                    ((IDictionary<string, object>)target.Value).Keys);
            }
            else
            {
                Assert.Equal(constant.Type, target.Type);
                if (constant.Value is ConstantExpression ce)
                {
                    Assert.Equal(ce.Value, (target.Value as ConstantExpression).Value);
                }
                else
                { 
                    Assert.Equal(constant.Value, target.Value);
                }
                Assert.True(constant.IsEquivalentTo(target));
            }
        }

        [Fact]
        public void GivenAnArrayWithExpressionsWhenSerializedThenShouldDeserialize()
        {
            var array = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2),
                Expression.Constant(3));
            var json = Serializer.Serialize(array);
            var target = Serializer.Deserialize<NewArrayExpression>(json);
            Assert.NotNull(target);
            Assert.Equal(typeof(int[]), target.Type);
            Assert.Equal(
                array.Expressions.OfType<ConstantExpression>().Select(c => c.Value),
                target.Expressions.OfType<ConstantExpression>().Select(c => c.Value));
            Assert.True(array.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetParameterExpressions() =>
            ParameterSerializerTests.GetParameterExpressions();

        [Theory]
        [MemberData(nameof(GetParameterExpressions))]
        public void GivenParameterExpressionWhenSerializedThenShouldDeserialize(ParameterExpression parameter)
        {
            var json = Serializer.Serialize(parameter);
            var target = Serializer.Deserialize<ParameterExpression>(json);
            Assert.Equal(parameter.Type, target.Type);
            Assert.Equal(parameter.Name, target.Name);
        }

        public static IEnumerable<object[]> GetUnaryExpressions() =>
            UnarySerializerTests.GetUnaryExpressions();

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void GivenUnaryExpressionWhenSerializedThenShouldDeserialize(UnaryExpression unary)
        {
            var json = Serializer.Serialize(unary);
            var target = Serializer.Deserialize<UnaryExpression>(json);
            Assert.Equal(unary.Type, target.Type);
            Assert.Equal(unary.Operand?.NodeType, target.Operand?.NodeType);

            if (unary.Method != null)
            {
                Assert.Equal(unary.Method, target.Method);
            }

            Assert.True(unary.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetLambdaExpressions() =>
            LambdaSerializerTests.GetLambdaExpressions();

        [Theory]
        [MemberData(nameof(GetLambdaExpressions))]
        public void GivenLambdaExpressionWhenSerializedThenShouldDeserialize(LambdaExpression lambda)
        {
            var json = Serializer.Serialize(lambda);
            var target = Serializer.Deserialize<LambdaExpression>(json);
            Assert.Equal(lambda.Type, target.Type);
            Assert.Equal(lambda.Body?.NodeType, target.Body?.NodeType);
            Assert.Equal(lambda.Parameters, target.Parameters);
            Assert.True(lambda.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetInvocationExpressions() =>
            InvocationSerializerTests.GetInvocationExpressionMatrix();

        [Theory]
        [MemberData(nameof(GetInvocationExpressions))]
        public void GivenInvocationExpressionWhenSerializedThenShouldDeserialize(InvocationExpression invocation)
        {
            var json = Serializer.Serialize(invocation);
            var target = Serializer.Deserialize<InvocationExpression>(json);
            Assert.Equal(invocation.Type, target.Type);
            Assert.True(invocation.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetMethodCallExpressions() =>
            MethodSerializerTests.GetMethodCallMatrix();

        [Theory]
        [MemberData(nameof(GetMethodCallExpressions))]
        public void GivenMethodCallExpressionWhenSerializedThenShouldDeserialize(
            MethodCallExpression method)
        {
            var json = Serializer.Serialize(method);
            var target = Serializer.Deserialize<MethodCallExpression>(json);
            Assert.True(method.IsEquivalentTo(target));
        }
    }
}
