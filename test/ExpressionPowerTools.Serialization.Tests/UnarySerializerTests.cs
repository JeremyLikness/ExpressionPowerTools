using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class UnarySerializerTests
    {
        private readonly UnarySerializer unarySerializer =
            new UnarySerializer(TestSerializer.ExpressionSerializer);

        public static string ToString(int x) => x.ToString();

        public static int Increment(int x) => x++;

        public static int Decrement(int x) => x--;

        public static int Negate(int x) => -1 * x;

        public static bool Not(bool flag) => !flag;

        public static IEnumerable<object[]> GetUnaryExpressions()
        {

            yield return new object[]
            {
                Expression.ArrayLength(Expression.Constant(new int[0]))
            };

            yield return new object[]
            {
                Expression.Convert(Expression.Constant(5), typeof(long))
            };

            var method = typeof(UnarySerializerTests).GetMethod(nameof(ToString),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            yield return new object[]
            {
                Expression.Convert(Expression.Constant(5), typeof(string), method)
            };

            yield return new object[]
            {
                Expression.ConvertChecked(Expression.Constant(5), typeof(long))
            };

            yield return new object[]
            {
                Expression.ConvertChecked(Expression.Constant(5), typeof(string), method)
            };

            yield return new object[]
            {
                Expression.Decrement(Expression.Constant(5))
            };

            var methodDecrement = typeof(UnarySerializerTests).GetMethod(nameof(Decrement),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            yield return new object[]
            {
                Expression.Decrement(Expression.Constant(5), methodDecrement)
            };

            yield return new object[]
            {
                Expression.Increment(Expression.Constant(5))
            };

            var methodIncrement = typeof(UnarySerializerTests).GetMethod(nameof(Increment),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            yield return new object[]
            {
                Expression.Increment(Expression.Constant(5), methodIncrement)
            };

            yield return new object[]
            {
                Expression.Negate(Expression.Constant(5))
            };

            var methodNegate = typeof(UnarySerializerTests).GetMethod(nameof(Negate),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            yield return new object[]
            {
                Expression.Negate(Expression.Constant(5), methodNegate)
            };

            yield return new object[]
            {
                Expression.NegateChecked(Expression.Constant(5))
            };

            yield return new object[]
            {
                Expression.NegateChecked(Expression.Constant(5), methodNegate)
            };

            yield return new object[]
            {
                Expression.Not(Expression.Constant(true))
            };

            var methodNot = typeof(UnarySerializerTests).GetMethod(nameof(Not),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            yield return new object[]
            {
                Expression.Not(Expression.Constant(true), methodNot)
            };

            ParameterExpression value = Expression.Parameter(typeof(int), nameof(value));

            yield return new object[]
            {
                Expression.PostDecrementAssign(value)
            };

            yield return new object[]
            {
                Expression.PostDecrementAssign(value, methodDecrement)
            };


            yield return new object[]
            {
                Expression.PostIncrementAssign(value)
            };

            yield return new object[]
            {
                Expression.PostIncrementAssign(value, methodDecrement)
            };

            yield return new object[]
            {
                Expression.PreDecrementAssign(value)
            };

            yield return new object[]
            {
                Expression.PreDecrementAssign(value, methodDecrement)
            };


            yield return new object[]
            {
                Expression.PreIncrementAssign(value)
            };

            yield return new object[]
            {
                Expression.PreIncrementAssign(value, methodDecrement)
            };

            Expression<Func<bool>> truth = () => true;
            var expr = Expression.Lambda<Func<bool>>(Expression.Invoke(truth));

            yield return new object[]
            {
                Expression.Quote(expr)
            };

            yield return new object[]
            {
                Expression.Rethrow()
            };

            yield return new object[]
            {
                Expression.Rethrow(typeof(InvalidCastException))
            };

            yield return new object[]
            {
                Expression.Throw(Expression.Constant(new ArgumentNullException()))
            };

            yield return new object[]
            {
                Expression.Throw(Expression.Constant(new InvalidCastException()), typeof(InvalidCastException))
            };

            yield return new object[]
            {
                Expression.TypeAs(Expression.Constant(5), typeof(object))
            };

            yield return new object[]
            {
                Expression.UnaryPlus(Expression.Constant(5))
            };

            yield return new object[]
            {
                Expression.UnaryPlus(Expression.Constant(5), methodIncrement)
            };

            IComparable five = 5;

            yield return new object[]
            {
                Expression.Unbox(Expression.Constant(five, typeof(IComparable)), typeof(int))
            };
        }

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void UnaryExpressionShouldSerialize(UnaryExpression unary)
        {
            var target = unarySerializer.Serialize(unary, TestSerializer.State);
            Assert.Equal((ExpressionType)target.Type, unary.NodeType);
        }

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void UnaryExpressionShouldDeserialize(UnaryExpression unary)
        {
            var serialized = TestSerializer.GetSerializedFragment<Unary, UnaryExpression>(unary);
            var deserialized = unarySerializer.Deserialize(serialized, TestSerializer.State);
            Assert.Equal(unary.Type.FullName, deserialized.Type.FullName);
        }

        [Fact]
        public void GivenOptionsIgnoreNullWhenUnarySerializedThenShouldDeserialize()
        {
            var unary = Expression.Throw(Expression.Constant(null));
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };

            var serialized = TestSerializer.GetSerializedFragment<Unary, UnaryExpression>(unary, options);
            var deserialized = unarySerializer.Deserialize(serialized, TestSerializer.State);
            Assert.Equal(unary.Type.FullName, deserialized.Type.FullName);
        }
    }
}
