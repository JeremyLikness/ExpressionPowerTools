using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity;
using Xunit;
using System.Reflection.Metadata;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionSimilarityTests
    {
        private static ConstantExpression Five =>
            Expression.Constant(5);

        private static ConstantExpression Six =>
            Expression.Constant(6);

        private static ConstantExpression StrFive =>
            Expression.Constant(5.ToString());

        private static ConstantExpression StrNull =>
            Expression.Constant(null, typeof(string));

        private static ConstantExpression OfFive =>
            Expression.Constant(Five);

        private static ConstantExpression OfOfFive =>
            Expression.Constant(OfFive);

        private static ParameterExpression IntParameter =>
            Expression.Parameter(typeof(int));

        private static ParameterExpression StringParameter =>
            Expression.Parameter(typeof(string));

        private static ParameterExpression IntNamedParameter =>
            Expression.Parameter(
                typeof(int),
                nameof(IntNamedParameter));

        private static ParameterExpression IntByRefParameter =>
            Expression.Parameter(typeof(int).MakeByRefType());

        public static IEnumerable<object[]> GetBinaryExpressionMatrix()
        {

            // left Similar, right not Similar (false)
            yield return new object[]
            {
                Expression.Add(Five, Six),
                Expression.Add(Five, Five),
                false
            };

            // left not Similar, right Similar (false)
            yield return new object[]
            {
                Expression.Add(Five, Six),
                Expression.Add(Six, Six),
                false
            };

            // left Similar, right Similar (true)
            yield return new object[]
            {
                Expression.Add(Five, Six),
                Expression.Add(Five, Six),
                true
            };
        }

        public static IEnumerable<object[]> GetNullMatrix()
        {
            yield return new object[] { null, null };
            yield return new object[]
            {
                Expression.Constant(5), null
            };
            yield return new object[]
            {
                null, Expression.Constant(5)
            };
        }

        public static IEnumerable<object[]> GetConstantExpressionMatrix()
        {
            yield return new object[]
            {
                Five, OfFive, false
            };
            yield return new object[]
            {
                OfFive, OfOfFive, false
            };
            yield return new object[]
            {
                OfFive, OfFive, true
            };
            yield return new object[]
            {
                OfOfFive, OfOfFive, true
            };
        }

        public static IEnumerable<object[]> GetUnaryExpressionMatrix()
        {
            Expression<Func<string, bool>> isNullOrWhiteSpace = str =>
                string.IsNullOrWhiteSpace(str);

            Expression<Func<string, bool>> isNullOrWhiteSpaceWrapper = str =>
                StringWrapper.IsNullOrWhitespace(str);

            Expression<Func<string, bool>> isNullOrEmpty = str =>
                string.IsNullOrEmpty(str);

            var method = (isNullOrWhiteSpace.Body as MethodCallExpression)
                .Method;

            var methodWrapper = (isNullOrWhiteSpaceWrapper.Body as MethodCallExpression)
                .Method;

            var methodAlt = (isNullOrEmpty.Body as MethodCallExpression)
                .Method;

            // everything is the same, should be true
            yield return new object[]
            {
                Expression.IsTrue("1".AsConstantExpression(), method),
                Expression.IsTrue("1".AsConstantExpression(), method),
                true
            };

            // different types = false
            yield return new object[]
            {
                Expression.IsTrue("1".AsConstantExpression(), method),
                Expression.IsTrue("1".AsConstantExpression(), methodWrapper),
                false
            };

            // different method names = false
            yield return new object[]
            {
                Expression.IsTrue("1".AsConstantExpression(), method),
                Expression.IsTrue("1".AsConstantExpression(), methodAlt),
                false
            };

            // null and null = true
            yield return new object[]
            {
                Expression.IsTrue(true.AsConstantExpression()),
                Expression.IsTrue(true.AsConstantExpression()),
                true
            };

            // null and not null = false
            yield return new object[]
            {
                Expression.IsTrue(true.AsConstantExpression()),
                Expression.IsTrue("1".AsConstantExpression(), method),
                false
            };

            // not null and null = false
            yield return new object[]
            {
                Expression.IsTrue("1".AsConstantExpression(), method),
                Expression.IsTrue(true.AsConstantExpression()),
                false
            };
        }

        [Theory]
        [MemberData(nameof(GetNullMatrix))]
        public void GivenEitherExpressionNullThenAreSimilarShouldReturnFalse(
            Expression left,
            Expression right)
        {
            Assert.False(eq.AreSimilar(left, right));
        }

        [Fact]
        public void GivenConstantsWithDifferentTypeThenAreSimilarShouldReturnFalse()
        {
            Assert.False(eq.AreSimilar(Five, StrFive));
        }

        [Fact]
        public void GivenConstantsWithDifferentValuesThenAreSimilarShouldReturnFalse()
        {
            Assert.False(eq.AreSimilar(Five, Six));
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressionMatrix))]
        public void GivenConstantWithExpressionThenAreSimilarShouldRecursivelyCompare(
            Expression left,
            Expression right,
            bool Similar)
        {
            if (Similar)
            {
                Assert.True(eq.AreSimilar(left, right));
            }
            else
            {
                Assert.False(eq.AreSimilar(left, right));
            }
        }

        [Fact]
        public void GivenConstantsOfSameTypeBothNullThenAreSimilarShouldReturnTrue()
        {
            Assert.True(eq.AreSimilar(StrNull, StrNull));
        }

        [Fact]
        public void GivenConstantsOfSameTypeWithOneNullThenAreSimilarShouldReturnFalse()
        {
            Assert.False(eq.AreSimilar(StrNull, StrFive));
        }

        [Fact]
        public void GivenConstantWithSameReferenceThenAreSimilarShouldReturnTrue()
        {
            Assert.True(eq.AreSimilar(
                Expression.Constant(this),
                Expression.Constant(this)));
        }

        [Fact]
        public void GivenConstantWithDifferentReferenceThenAreSimilarShouldReturnFalse()
        {
            var other = new ExpressionEquivalencyTests();
            Assert.False(eq.AreSimilar(
                Expression.Constant(this),
                Expression.Constant(other)));
        }

        [Fact]
        public void GivenConstantWithObjectTypeThenAreSimilarShouldReturnFalse()
        {
            Assert.False(eq.AreSimilar(
                new object().AsConstantExpression(),
                new object().AsConstantExpression()));
        }

        [Fact]
        public void GivenConstantWithObjectTypeAndOtherTypeThenAreSimilarShouldReturnFalse()
        {
            Assert.False(eq.AreSimilar(
                new object().AsConstantExpression(),
                new IdType().AsConstantExpression()));
        }

        [Fact]
        public void GivenEnumerableConstantWithSameTypeThenAreSimilarShouldReturnTrue()
        {
            var source = new List<int?> { 1, null, 3 }.AsConstantExpression();
            var target = new List<int?> { 1, null, 3 }.AsConstantExpression();
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenEnumerableConstantWithDifferentTypeThenAreSimilarShouldReturnFalse()
        {
            var source = new List<int?> { 1, 2, 3 }.AsConstantExpression();
            var target = new List<int> { 1, 2, 4 }.AsConstantExpression();
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenEnumerableOfShorterLengthThenAreSimilarShouldReturnTrue()
        {
            var source = new[] { 1, 2, 3 }.AsConstantExpression();
            var target = new[] { 1, 2 }.AsConstantExpression();
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenEnumerableOfLongerLengthThenAreSimilarShouldReturnTrue()
        {
            var source = new[] { 1, 2, 3 }.AsConstantExpression();
            var target = new[] { 1, 2, 3, 4 }.AsConstantExpression();
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenEnumerableWithComplexTypesInDifferentOrderThenAreSimilarShouldReturnTrue()
        {
            var source = new[] { Five, Six };
            var target = new[] { Six, Five };
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenEnumerableTargetWithComplexTypesHasFewerExpressionsThenAreSimilarShouldReturnTrue()
        {
            var source = new[] { Five, Six };
            var target = new[] { Five };
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenEnumerableTargetWithComplexTypesHasMoreExpressionsThenAreSimilarShouldReturnTrue()
        {
            var source = new[] { Five };
            var target = new[] { Five, Six };
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenListOfDifferentTypeThenAreSimilarShouldReturnFalse()
        {
            var source = new List<int> { 1, 2 }.AsConstantExpression();
            var target = new List<long> { 1, 2 }.AsConstantExpression();
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenListOfSameTypeThenAreSimilarShouldReturnTrue()
        {
            var source = new List<int> { 1, 2 }.AsConstantExpression();
            var target = new List<int> { 3, 4 }.AsConstantExpression();
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenParameterWithDifferentTypeThenAreSimilarShouldReturnFalse()
        {
            Assert.False(eq.AreSimilar(
                IntParameter, StringParameter));
        }

        [Fact]
        public void GivenParameterWithDerivedTypeThenAreSimilarShouldReturnTrue()
        {
            var source = typeof(StringWrapper).AsParameterExpression();
            var target = typeof(DerivedStringWrapper).AsParameterExpression();
            Assert.True(eq.AreSimilar(source, target));
            Assert.True(eq.AreSimilar(target, source));
        }

        [Fact]
        public void GivenParameterWithDifferentNameThenAreSimilarShouldReturnTrue()
        {
            Assert.True(eq.AreSimilar(
                IntParameter, IntNamedParameter));
        }

        [Fact]
        public void GivenParameterWithDifferentByRefThenAreSimilarShouldReturnTrue()
        {
            Assert.True(eq.AreSimilar(
                IntParameter, IntByRefParameter));
        }

        [Fact]
        public void GivenParameterWithSameTypeAndNameThenAreSimilarShouldReturnTrue()
        {
            Assert.True(eq.AreSimilar(
                IntParameter, IntParameter));
        }

        [Fact]
        public void GivenExpressionNotSupportedThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.Goto(Expression.Label());
            var target = Expression.Goto(Expression.Label());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenBinaryExpressionsWhenNodeTypesAreDifferentThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.Add(1.AsConstantExpression(), 2.AsConstantExpression());
            var target = Expression.Subtract(1.AsConstantExpression(), 2.AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Theory]
        [MemberData(nameof(GetBinaryExpressionMatrix))]
        public void GivenBinaryExpressionsWithSameNodeTypeWhenAreSimilarCalledThenShouldEvaluateLeftAndRightOnEquivalency(
            BinaryExpression source, BinaryExpression target, bool areSimilar)
        {
            if (areSimilar)
            {
                Assert.True(eq.AreSimilar(source, target));
            }
            else
            {
                Assert.False(eq.AreSimilar(source, target));
            }
        }

        [Fact]
        public void GivenUnaryExpressionsWithSameNodeTypeMethodAndOperandsThenAreSimilarShouldReturnTrue()
        {
            var source = Expression.IsTrue(true.AsConstantExpression());
            var target = Expression.IsTrue(true.AsConstantExpression());
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenUnaryExpressionWhenNodeTypesAreDifferentThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.IsTrue(true.AsConstantExpression());
            var target = Expression.IsFalse(true.AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenUnaryExpressionWhenOperandsAreDifferentThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.IsTrue(true.AsConstantExpression());
            var target = Expression.IsTrue(false.AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Theory]
        [MemberData(nameof(GetUnaryExpressionMatrix))]
        public void GivenUnaryExpressionWhenTypesAndOperandsAreSameThenAreSimilarShouldEvaluateBasedOnMethods(
            Expression source, Expression target, bool areSimilar)
        {
            if (areSimilar)
            {
                Assert.True(eq.AreSimilar(source, target));
            }
            else
            {
                Assert.False(eq.AreSimilar(source, target));
            }
        }

        [Fact]
        public void GivenMemberExpressionWhenTypesDifferThenAreSimilarShouldReturnFalse()
        {
            var type = typeof(StringWrapper).AsParameterExpression();
            var sourceProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var targetProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.IdVal));
            var source = Expression.Property(type, sourceProperty);
            var target = Expression.Property(type, targetProperty);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenDeclaringTypesDifferThenAreSimilarShouldReturnFalse()
        {
            var sourceType = typeof(StringWrapper).AsParameterExpression();
            var targetType = typeof(IdType).AsParameterExpression();
            var sourceProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var targetProperty = typeof(IdType).GetProperty(nameof(IdType.Id));
            var source = Expression.Property(sourceType, sourceProperty);
            var target = Expression.Property(targetType, targetProperty);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenMemberNamesDifferThenAreSimilarShouldReturnFalse()
        {
            var type = typeof(StringWrapper).AsParameterExpression();
            var sourceProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var targetProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.OtherId));
            var source = Expression.Property(type, sourceProperty);
            var target = Expression.Property(type, targetProperty);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenExpressionsDifferThenAreSimilarShouldReturnTrue()
        {
            var sourceType = typeof(StringWrapper).AsParameterExpression();
            var targetType = typeof(DerivedStringWrapper).AsParameterExpression();
            var property = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var source = Expression.Property(sourceType, property);
            var target = Expression.Property(targetType, property);
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenTypeDeclaringTypeMemberNameAndExpressionsMatchThenAreSimilarShouldReturnTrue()
        {
            var type = typeof(StringWrapper).AsParameterExpression();
            var property = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var source = Expression.Property(type, property);
            var target = Expression.Property(type, property);
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentReturnTypeWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithName(nameof(IdType.GetId));
            var targetMethod = typeof(IdType).MethodWithName(nameof(IdType.GetIdVal));
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(expr, sourceMethod);
            var target = Expression.Call(expr, targetMethod);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentDeclaringTypesWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithName(nameof(IdType.GetId));
            var targetMethod = typeof(DerivedStringWrapper).MethodWithName(nameof(DerivedStringWrapper.GetId));
            var sourceExpr = new IdType().AsParameterExpression();
            var targetExpr = new DerivedStringWrapper().AsParameterExpression();
            var source = Expression.Call(sourceExpr, sourceMethod);
            var target = Expression.Call(targetExpr, targetMethod);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentNamesWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(
                nameof(IdType.Echo), 1);
            var targetMethod = typeof(IdType).MethodWithName(nameof(IdType.EchoStr));
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(expr, sourceMethod, "1".AsConstantExpression());
            var target = Expression.Call(expr, targetMethod, "1".AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }


        [Fact]
        public void GivenMethodCallExpressionWithDifferentExpressionWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var method = typeof(IdType).MethodWithName(nameof(IdType.GetId));
            var sourceExpr = new IdType().AsParameterExpression();
            var targetExpr = new IdType().AsConstantExpression();
            var source = Expression.Call(sourceExpr, method);
            var target = Expression.Call(targetExpr, method);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithStaticMethodWhenAreSimilarCalledThenShouldReturnTrue()
        {
            var method = typeof(Enumerable).MethodWithName(nameof(Enumerable.Take), isStatic: true);
            var methodWithType = method.MakeGenericMethod(typeof(IdType));
            var extensionParameter = new List<IdType>().AsConstantExpression();
            var takeParameter = 5.AsConstantExpression();
            var source = Expression.Call(methodWithType, extensionParameter, takeParameter);
            var target = Expression.Call(methodWithType, extensionParameter, takeParameter);
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentArgumentCountWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(nameof(IdType.LongParameterList), 8);
            var targetMethod = typeof(IdType).MethodWithNameAndParameterCount(nameof(IdType.LongParameterList), 9);
            var paramList8 = new ConstantExpression[8];
            Array.Fill(paramList8, "1".AsConstantExpression());
            var paramList9 = new ConstantExpression[9];
            Array.Fill(paramList9, "1".AsConstantExpression());
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(
                expr, sourceMethod, paramList8);
            var target = Expression.Call(
                expr, targetMethod, paramList9);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentArgumentsWhenAreSimilarCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(
                nameof(IdType.Echo), 1);
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(
                expr, sourceMethod, "1".AsConstantExpression());
            var target = Expression.Call(
                expr, sourceMethod, "2".AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithMatchingExpressionAndArgumentsWhenAreSimilarCalledThenShouldReturnTrue()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(
                nameof(IdType.Echo), 1);
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(
                expr, sourceMethod, "1".AsConstantExpression());
            var target = Expression.Call(
                expr, sourceMethod, "1".AsConstantExpression());
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenTypeIsDifferentThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            Expression<Func<object>> strExpr = () => "1";
            var source = Expression.Lambda(intExpr);
            var target = Expression.Lambda(strExpr);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenNameIsDifferentThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            var source = Expression.Lambda(intExpr, "test", new ParameterExpression[0]);
            var target = Expression.Lambda(intExpr, nameof(intExpr), new ParameterExpression[0]);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenTailCallIsDifferentThenAreSimilarShouldReturnTrue()
        {
            Expression<Func<object>> intExpr = () => 1;
            var source = Expression.Lambda(intExpr, nameof(intExpr), false, new ParameterExpression[0]);
            var target = Expression.Lambda(intExpr, nameof(intExpr), true, new ParameterExpression[0]);
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenParameterCountDiffersThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            Expression<Func<int, object>> intParamExpr = val => 1;
            var source = Expression.Lambda(intExpr);
            var target = Expression.Lambda(intParamExpr);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenSingaturesMatchThenAreSimilarShouldReturnTrue()
        {
            Expression<Func<long, object>> longParamExpr = val => 1;
            Expression<Func<long, object>> longParamExpr1 = val1 => 1;
            var source = Expression.Lambda(longParamExpr);
            var target = Expression.Lambda(longParamExpr1);
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenParametersAreDifferentTypesThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<long, object>> longParamExpr = val => 1;
            Expression<Func<int, object>> intParamExpr = val => 1;
            var source = Expression.Lambda(longParamExpr);
            var target = Expression.Lambda(intParamExpr);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenBodiesAreNotSimilarAreSimilarThenShouldReturnFalse()
        {
            var source = Expression.Lambda(Expression.Equal(0.AsConstantExpression(), 1.AsConstantExpression()));
            var target = Expression.Lambda(Expression.Equal(1.AsConstantExpression(), 2.AsConstantExpression()));
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenSimilarThenAreSimilarShouldReturnTrue()
        {
            var source = Expression.Lambda(Expression.Equal(0.AsConstantExpression(), 1.AsConstantExpression()));
            var target = Expression.Lambda(Expression.Equal(0.AsConstantExpression(), 1.AsConstantExpression()));
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenInvocationExpressionWhenTypeIsDifferentThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<int>> intExpr = () => 1;
            Expression<Func<string>> strExpr = () => "1";
            var source = Expression.Invoke(intExpr, intExpr.Parameters);
            var target = Expression.Invoke(strExpr, strExpr.Parameters);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenInvocationExpressionWhenParameterCountDiffersThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            Expression<Func<int, object>> intParamExpr = val => 1;
            var source = Expression.Invoke(intExpr, intExpr.Parameters);
            var target = Expression.Invoke(intParamExpr, intParamExpr.Parameters);
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenInvocationExpressionWhenSignaturesMatchThenAreSimilarShouldReturnTrue()
        {
            Expression<Func<long, object>> longParamExpr = val => 1;
            Expression<Func<long, object>> longParamExpr1 = val1 => 1;
            var source = Expression.Invoke(longParamExpr, longParamExpr.Parameters);
            var target = Expression.Invoke(longParamExpr1, longParamExpr1.Parameters);
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenInvocationExpressionWhenParametersAreDifferentTypesThenAreSimilarShouldReturnFalse()
        {
            Expression<Func<long, object>> longParamExpr = val => 1;
            Expression<Func<int, object>> intParamExpr = val => 1;
            var source = Expression.Invoke(longParamExpr, longParamExpr.Parameters);
            var target = Expression.Invoke(intParamExpr, intParamExpr.Parameters);
            Assert.False(eq.AreSimilar(source, target));
        }

        public interface ITemp
        {
            string Id { get; set; }
        }

        public class Temp : ITemp
        {
            public string Id { get; set; }
        }

        [Fact]
        public void GivenInvocationExpressionWhenSimilarThenAreSimilarShouldReturnTrue()
        {
            Expression<Func<Temp, Temp>> expr = i => i;
            Expression<Func<ITemp, ITemp>> expr1 = i => i;
            Assert.True(
                eq.AreSimilar(
                    Expression.Invoke(expr, expr.Parameters),
                    Expression.Invoke(expr1, expr1.Parameters)));
        }



        [Fact]
        public void GivenTwoQueriesWhenSimilarThenAreSimilarShouldReturnTrue()
        {
            var source = QueryHelper.QuerySkip2Take3.Expression;
            Assert.True(eq.AreSimilar(source, source));
        }

        [Fact]
        public void GivenTwoQueriesWhenNotSimilarThenAreSimilarShouldReturnFalse()
        {
            var source = QueryHelper.QuerySkip2Take3.Expression;
            var target = QueryHelper.QuerySkip2Take4.Expression;
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTargetNullWhenIsPartOfCalledThenShouldReturnFalse()
        {
            var source = IQueryableExtensions.CreateQueryTemplate<IdType>()
                .Take(5);
            Assert.False(eq.IsPartOf(source.Expression, null));
        }

        [Fact]
        public void GivenTargetWithoutQueryPartsWhenIsPartOfCalledThenShouldReturnFalse()
        {
            var source = IQueryableExtensions.CreateQueryTemplate<IdType>()
                .Take(5);
            var target = IQueryableExtensions.CreateQueryTemplate<IdType>();
            Assert.False(eq.IsPartOf(source.Expression, target.Expression));
        }

        [Fact]
        public void GivenTargetWithQueryPartsNotSimiliarWhenIsPartOfCalledThenShouldReturnFalse()
        {
            var target = QueryHelper.QuerySkip2Take3;
            var source = target.CreateQueryTemplate().Take(4);
            Assert.False(eq.IsPartOf(source.Expression, target.Expression));
        }

        [Fact]
        public void GivenTargetWithSimilarQueryPartsWhenIsPartOfCalledThenShouldReturnTrue()
        {
            var target = QueryHelper.QuerySkip2Take3;
            var source = target.CreateQueryTemplate().Take(3);
            Assert.True(eq.IsPartOf(source.Expression, target.Expression));
        }

        [Fact]
        public void GivenTwoArrayInitializationsWithDifferentTypesThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            var target = Expression.NewArrayInit(typeof(long), Expression.Constant((long)1));
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTwoArrayInitializationsWithSameTypeAndDifferentContentsThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            var target = Expression.NewArrayInit(typeof(int), Expression.Constant(2));
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTwoArrayInitializationsWithSameTypeAndContentsThenAreSimilarShouldReturnTrue()
        {
            var source = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            var target = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            Assert.True(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenTypesAreDifferentThenAreSimilarShouldReturnFalse()
        {
            var source = Expression.New(typeof(IdType));
            var target = Expression.New(typeof(StringWrapper));
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenConstructorsAreDifferentThenAreSimilarShouldReturnFalse()
        {
            var constructors = typeof(StringWrapper).GetConstructors();
            var source = Expression.New(constructors.Where(c => c.GetParameters().Length == 1).Skip(1).First(),
                new IdType().AsConstantExpression());
            var target = Expression.New(constructors.First(c => c.GetParameters().Length == 1),
                true.AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenArgumentsAreDifferentThenAreSimilarShouldReturnFalse()
        {
            var constructor = typeof(StringWrapper)
                .GetConstructor(new[] { typeof(bool) });
            var source = Expression.New(constructor, true.AsConstantExpression());
            var target = Expression.New(constructor, false.AsConstantExpression());
            Assert.False(eq.AreSimilar(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenArgumentsAreSameThenAreSimilarShouldReturnTrue()
        {
            var source = Expression.New(typeof(IdType));
            var target = Expression.New(typeof(IdType));
            Assert.True(eq.AreSimilar(source, target));
        }

    }
}
