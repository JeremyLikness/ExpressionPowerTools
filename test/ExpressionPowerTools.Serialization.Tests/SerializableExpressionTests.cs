using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializableExpressionTests
    {
        [Fact]
        public void GivenNullExpressionWhenConstructorCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SerializableExpression(null));
        }

        [Fact]
        public void GivenNonNullExpressionWhenConstructorCalledThenShouldSetType()
        {
            var target = new SerializableExpression(Expression.Constant(5));
            Assert.Equal(ExpressionType.Constant.ToString(), target.Type);
        }

        [Fact]
        public void GivenConstantExpressionWhenConstantCreatedThenShouldSetConstantTypeAndValueAndValueType()
        {
            var expr = Expression.Constant(5);
            var target = new Constant(expr);
            Assert.Equal(expr.Type.FullName, target.ConstantType);
            Assert.Equal(expr.Value, target.Value);
            Assert.Equal(expr.Value.GetType().FullName, target.ValueType);
        }

        public static IEnumerable<object[]> GetMethods()
        {
            yield return new object[]
            {
                typeof(string).GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .FirstOrDefault(m => m.Name == nameof(string.Intern) && m.IsStatic)
            };

            yield return new object[]
            {
                typeof(SerializableExpressionTests)
                .GetMethod(nameof(GivenMethodInfoWhenMethodCreatedThenShouldPopulateMethodProperties))
            };
        }

        [Theory]
        [MemberData(nameof(GetMethods))]
        public void GivenMethodInfoWhenMethodCreatedThenShouldPopulateMethodProperties(MethodInfo method)
        {
            var serializerMethod = new Method(method);
            Assert.Equal(method.IsStatic, serializerMethod.IsStatic);
            Assert.Equal(method.Name, serializerMethod.Name);
            Assert.Equal(method.DeclaringType.FullName, serializerMethod.DeclaringType);
            Assert.Equal(method.ReturnType.FullName, serializerMethod.ReturnType);
            Assert.Equal(method.GetParameters().Select(p => new KeyValuePair<string, string>(p.Name, p.ParameterType.FullName)),
                serializerMethod.Parameters);
        }

        [Fact]
        public void GivenMultipleMethodInfosWhenMethodCreatedThenShouldHaveUniqueHashCodes()
        {
            var listMayHaveDuplicates =
                typeof(Expression).GetMethods().Union(
                    typeof(Expression).GetMethods(
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                .Select(m => new Method(m).GetHashCode()).ToList();
            var noDuplicates = new HashSet<int>(listMayHaveDuplicates);
            Assert.Equal(listMayHaveDuplicates.Count, noDuplicates.Count);
        }

        [Fact]
        public void GivenNewArrayExpressionWhenNewArrayCreatedThenShouldSetArrayType()
        {
            var expr = Expression.NewArrayInit(typeof(int), Expression.Constant(1), Expression.Constant(2));
            var target = new NewArray(expr);
            Assert.Equal(expr.Type.GetElementType().FullName, target.ArrayType);
        }

        [Fact]
        public void GivenNewArrayExpressionWhenNewArrayCreatedThenShouldInitializeExpressionsList()
        {
            var expr = Expression.NewArrayInit(typeof(int), Expression.Constant(1), Expression.Constant(2));
            var target = new NewArray(expr);
            Assert.NotNull(target.Expressions);
        }

        [Fact]
        public void GivenParameterExpressionWhenParameterCreatedThenShouldSetNameAndParameterType()
        {
            var expr = Expression.Parameter(typeof(int), nameof(GivenParameterExpressionWhenParameterCreatedThenShouldSetNameAndParameterType));
            var target = new Parameter(expr);
            Assert.Equal(expr.Type.FullName, target.ParameterType);
            Assert.Equal(expr.Name, target.Name);
        }

        public static string ToString(int i) => i.ToString();

        public static IEnumerable<object[]> GetUnaryExpressions()
        {
            yield return new object[]
            {
                Expression.ArrayLength(Expression.Constant(new int[0]))
            };

            yield return new object[]
            {
                Expression.Convert(
                    Expression.Constant(5),
                    typeof(string),
                    typeof(SerializableExpressionTests).GetMethod(
                        nameof(ToString),
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            };
        }

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void GivenUnaryExpressionWhenUnaryCreatedThenShouldSetUnaryTypeAndMethod(UnaryExpression unary)
        {
            var target = new Unary(unary);
            if (unary.Method != null)
            {
                Assert.Equal(unary.Method.Name, target.UnaryMethod.Name);
            }
            Assert.Equal(unary.Type.FullName, target.UnaryType);
        }

        [Fact]
        public void GivenLambdaExpressionWhenLambdaCreatedThenShouldSetLambdaProperties()
        {
            Expression<Func<int, bool>> expr = i => i > 5;
            var parameter = Expression.Parameter(typeof(int), "i");
            var lambda = Expression.Lambda(expr, parameter);
            var target = new Lambda(lambda);
            Assert.NotNull(target.Parameters);
            Assert.Equal(lambda.Name, target.Name);
            Assert.Equal(lambda.Type.FullName, target.LambdaType);
            Assert.Equal(lambda.ReturnType.FullName, target.ReturnType);
        }

    }
}
