using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionEquivalencyTests
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

            // left equivalent, right not equivalent (false)
            yield return new object[]
            {
                Expression.Add(Five, Six),
                Expression.Add(Five, Five),
                false
            };

            // left not equivalent, right equivalent (false)
            yield return new object[]
            {
                Expression.Add(Five, Six),
                Expression.Add(Six, Six),
                false
            };

            // left equivalent, right equivalent (true)
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
        public void GivenEitherExpressionNullThenAreEquivalentShouldReturnFalse(
            Expression left,
            Expression right)
        {
            Assert.False(eq.AreEquivalent(left, right));
        }

        [Fact]
        public void GivenConstantsWithDifferentTypeThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(Five, StrFive));
        }

        [Fact]
        public void GivenConstantsWithDifferentValuesThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(Five, Six));
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressionMatrix))]
        public void GivenConstantWithExpressionThenAreEquivalentShouldRecursivelyCompare(
            Expression left,
            Expression right,
            bool equivalent)
        {
            if (equivalent)
            {
                Assert.True(eq.AreEquivalent(left, right));
            }
            else
            {
                Assert.False(eq.AreEquivalent(left, right));
            }
        }

        [Fact]
        public void GivenConstantsOfSameTypeBothNullThenAreEquivalentShouldReturnTrue()
        {
            Assert.True(eq.AreEquivalent(StrNull, StrNull));
        }

        [Fact]
        public void GivenConstantsOfSameTypeWithOneNullThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(StrNull, StrFive));
        }

        [Fact]
        public void GivenConstantWithSameReferenceThenAreEquivalentShouldReturnTrue()
        {
            Assert.True(eq.AreEquivalent(
                Expression.Constant(this),
                Expression.Constant(this)));
        }

        [Fact]
        public void GivenConstantWithDifferentReferenceThenAreEquivalentShouldReturnTrue()
        {
            var other = new ExpressionEquivalencyTests();
            Assert.False(eq.AreEquivalent(
                Expression.Constant(this),
                Expression.Constant(other)));
        }

        [Fact]
        public void GivenEnumerableConstantWithSameMembersThenAreEquivalentShouldReturnTrue()
        {
            var source = new int?[] { 1, null, 3 }.AsConstantExpression();
            var target = new int?[] { 1, null, 3 }.AsConstantExpression();
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableConstantWithDifferentMembersThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { 1, 2, 3 }.AsConstantExpression();
            var target = new[] { 1, 2, 4 }.AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableConstantWithSourceNullThenAreEquivalentShouldReturnFalse()
        {
            var source = new int?[] { 1, null, 3 }.AsConstantExpression();
            var target = new int?[] { 1, 2, 3 }.AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableConstantWithTargetNullThenAreEquivalentShouldReturnFalse()
        {
            var source = new int?[] { 1, 2, 3 }.AsConstantExpression();
            var target = new int?[] { 1, null, 3 }.AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableOfShorterLengthThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { 1, 2, 3 }.AsConstantExpression();
            var target = new[] { 1, 2 }.AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableOfLongerLengthThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { 1, 2, 3 }.AsConstantExpression();
            var target = new[] { 1, 2, 3, 4 }.AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableWithItemsInDifferentOrderThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { Five, Six };
            var target = new[] { Six, Five };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableTargetHasFewerExpressionsThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { Five, Six };
            var target = new[] { Five };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableTargetHasMoreExpressionsThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { Five };
            var target = new[] { Five, Six };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableWithDifferentValuesThenAreEquivalentShouldReturnFalse()
        {
            var source = new[] { Five, Five };
            var target = new[] { Six, Six };
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableWithSameValuesInSameOrderThenAreEquivalentShouldReturnTrue()
        {
            var source = new[] { Five, Six, OfFive, OfOfFive };
            var target = new[] { Five, Six, OfFive, OfOfFive };
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenParameterWithDifferentTypeThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(
                IntParameter, StringParameter));
        }

        [Fact]
        public void GivenParameterWithDifferentNameThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(
                IntParameter, IntNamedParameter));
        }

        [Fact]
        public void GivenParameterWithDifferentByRefThenAreEquivalentShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(
                IntParameter, IntByRefParameter));
        }

        [Fact]
        public void GivenParameterWithSameTypeAndNameThenAreEquivalentShouldReturnTrue()
        {
            Assert.True(eq.AreEquivalent(
                IntParameter, IntParameter));
        }

        [Fact]
        public void GivenExpressionNotSupportedThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.Goto(Expression.Label());
            Assert.False(eq.AreEquivalent(source, source));
        }

        [Fact]
        public void GivenBinaryExpressionsWhenNodeTypesAreDifferentThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.Add(1.AsConstantExpression(), 2.AsConstantExpression());
            var target = Expression.Subtract(1.AsConstantExpression(), 2.AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Theory]
        [MemberData(nameof(GetBinaryExpressionMatrix))]
        public void GivenBinaryExpressionsWithSameNodeTypeWhenAreEquivalentCalledThenShouldEvaluateLeftAndRightOnEquivalency(
            BinaryExpression source, BinaryExpression target, bool areEquivalent)
        {
            if (areEquivalent)
            {
                Assert.True(eq.AreEquivalent(source, target));
            }
            else
            {
                Assert.False(eq.AreEquivalent(source, target));
            }
        }

        [Fact]
        public void GivenUnaryExpressionsWithSameNodeTypeMethodAndOperandsThenAreEquivalentShouldReturnTrue()
        {
            var source = Expression.IsTrue(true.AsConstantExpression());
            var target = Expression.IsTrue(true.AsConstantExpression());
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenUnaryExpressionWhenNodeTypesAreDifferentThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.IsTrue(true.AsConstantExpression());
            var target = Expression.IsFalse(true.AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenUnaryExpressionWhenOperandsAreDifferentThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.IsTrue(true.AsConstantExpression());
            var target = Expression.IsTrue(false.AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Theory]
        [MemberData(nameof(GetUnaryExpressionMatrix))]
        public void GivenUnaryExpressionWhenTypesAndOperandsAreSameThenAreEquivalentShouldEvaluateBasedOnMethods(
            Expression source, Expression target, bool areEquivalent)
        {
            if (areEquivalent)
            {
                Assert.True(eq.AreEquivalent(source, target));
            }
            else
            {
                Assert.False(eq.AreEquivalent(source, target));
            }
        }

        public void GivenUnaryExpressionWhenOneIsLiftedAndOneIsNotLiftedThenAreEquivalentShouldReturnFalse()
        {
            // any example?
        }

        public void GivenUnaryExpressionWhenOneIsLiftedToNullAndOneIsNotLiftedToNullThenAreEquivalentShouldReturnFalse()
        {
            // need some help
        }

        [Fact]
        public void GivenMemberExpressionWhenTypesDifferThenAreEquivalentShouldReturnFalse()
        {
            var type = typeof(StringWrapper).AsParameterExpression();
            var sourceProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var targetProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.IdVal));
            var source = Expression.Property(type, sourceProperty);
            var target = Expression.Property(type, targetProperty);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenDeclaringTypesDifferThenAreEquivalentShouldReturnFalse()
        {
            var sourceType = typeof(StringWrapper).AsParameterExpression();
            var targetType = typeof(IdType).AsParameterExpression();
            var sourceProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var targetProperty = typeof(IdType).GetProperty(nameof(IdType.Id));
            var source = Expression.Property(sourceType, sourceProperty);
            var target = Expression.Property(targetType, targetProperty);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenMemberNamesDifferThenAreEquivalentShouldReturnFalse()
        {
            var type = typeof(StringWrapper).AsParameterExpression();
            var sourceProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var targetProperty = typeof(StringWrapper).GetProperty(nameof(StringWrapper.OtherId));
            var source = Expression.Property(type, sourceProperty);
            var target = Expression.Property(type, targetProperty);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenExpressionsDifferThenAreEquivalentShouldReturnFalse()
        {
            var sourceType = typeof(StringWrapper).AsParameterExpression();
            var targetType = typeof(DerivedStringWrapper).AsParameterExpression();
            var property = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var source = Expression.Property(sourceType, property);
            var target = Expression.Property(targetType, property);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMemberExpressionWhenTypeDeclaringTypeMemberNameAndExpressionsMatchThenAreEquivalentShouldReturnTrue()
        {
            var type = typeof(StringWrapper).AsParameterExpression();
            var property = typeof(StringWrapper).GetProperty(nameof(StringWrapper.Id));
            var source = Expression.Property(type, property);
            var target = Expression.Property(type, property);
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentReturnTypeWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithName(nameof(IdType.GetId));
            var targetMethod = typeof(IdType).MethodWithName(nameof(IdType.GetIdVal));
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(expr, sourceMethod);
            var target = Expression.Call(expr, targetMethod);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentDeclaringTypesWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithName(nameof(IdType.GetId));
            var targetMethod = typeof(DerivedStringWrapper).MethodWithName(nameof(DerivedStringWrapper.GetId));
            var sourceExpr = new IdType().AsParameterExpression();
            var targetExpr = new DerivedStringWrapper().AsParameterExpression();
            var source = Expression.Call(sourceExpr, sourceMethod);
            var target = Expression.Call(targetExpr, targetMethod);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentNamesWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(
                nameof(IdType.Echo), 1);
            var targetMethod = typeof(IdType).MethodWithName(nameof(IdType.EchoStr));
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(expr, sourceMethod, "1".AsConstantExpression());
            var target = Expression.Call(expr, targetMethod, "1".AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }


        [Fact]
        public void GivenMethodCallExpressionWithDifferentExpressionWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var method = typeof(IdType).MethodWithName(nameof(IdType.GetId));
            var sourceExpr = new IdType().AsParameterExpression();
            var targetExpr = new IdType().AsConstantExpression();
            var source = Expression.Call(sourceExpr, method);
            var target = Expression.Call(targetExpr, method);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentArgumentCountWhenAreEquivalentCalledThenShouldReturnFalse()
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
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithDifferentArgumentsWhenAreEquivalentCalledThenShouldReturnFalse()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(
                nameof(IdType.Echo), 1);
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(
                expr, sourceMethod, "1".AsConstantExpression());
            var target = Expression.Call(
                expr, sourceMethod, "2".AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenMethodCallExpressionWithMatchingExpressionAndArgumentsWhenAreEquivalentCalledThenShouldReturnTrue()
        {
            var sourceMethod = typeof(IdType).MethodWithNameAndParameterCount(
                nameof(IdType.Echo), 1);
            var expr = new IdType().AsParameterExpression();
            var source = Expression.Call(
                expr, sourceMethod, "1".AsConstantExpression());
            var target = Expression.Call(
                expr, sourceMethod, "1".AsConstantExpression());
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenTypeIsDifferentThenAreEquivalentShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            Expression<Func<object>> strExpr = () => "1";
            var source = Expression.Lambda(intExpr);
            var target = Expression.Lambda(strExpr);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenNameIsDifferentThenAreEquivalentShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            var source = Expression.Lambda(intExpr, "test", new ParameterExpression[0]);
            var target = Expression.Lambda(intExpr, nameof(intExpr), new ParameterExpression[0]);
            Assert.False(eq.AreEquivalent(source, target));
        }
        
        [Fact]
        public void GivenLambdaExpressionWhenTailCallIsDifferentThenAreEquivalentShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            var source = Expression.Lambda(intExpr, nameof(intExpr), false, new ParameterExpression[0]);
            var target = Expression.Lambda(intExpr, nameof(intExpr), true, new ParameterExpression[0]);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenParameterCountDiffersThenAreEquivalentShouldReturnFalse()
        {
            Expression<Func<object>> intExpr = () => 1;
            Expression<Func<int, object>> intParamExpr = val => 1;
            var source = Expression.Lambda(intExpr);
            var target = Expression.Lambda(intParamExpr);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenParametersAreNotEquivalentThenAreEquivalentShouldReturnFalse()
        {
            Expression<Func<long, object>> longParamExpr = val => 1;
            Expression<Func<int, object>> intParamExpr = val => 1;
            var source = Expression.Lambda(longParamExpr);
            var target = Expression.Lambda(intParamExpr);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenBodiesAreNotEquivalentAreEquivalentThenShouldReturnFalse()
        {
            var source = Expression.Lambda(Expression.Equal(0.AsConstantExpression(), 1.AsConstantExpression()));
            var target = Expression.Lambda(Expression.Equal(1.AsConstantExpression(), 2.AsConstantExpression()));
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenLambdaExpressionWhenEquivalentThenAreEquivalentShouldReturnTrue()
        {
            var source = Expression.Lambda(Expression.Equal(0.AsConstantExpression(), 1.AsConstantExpression()));
            var target = Expression.Lambda(Expression.Equal(0.AsConstantExpression(), 1.AsConstantExpression()));
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoQueriesWhenEquivalentThenAreEquivalentShouldReturnTrue()
        {
            var source = QueryHelper.Query.Expression;
            Assert.True(eq.AreEquivalent(source, source));
        }

        [Fact]
        public void GivenTwoQueriesWhenNotEquivalentThenAreEquivalentShouldReturnFalse()
        {
            var source = QueryHelper.Query.Expression;
            var target = QueryHelper.QueryAlt.Expression;
            Assert.False(eq.AreEquivalent(source, target));
        }
    }
}
