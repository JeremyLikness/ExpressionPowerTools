using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
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

        private static readonly Expression<Func<bool>> FuncBool = () => true;

        private static readonly Expression<Func<string>> FuncString = () => nameof(FuncString);

        private static readonly Expression<Func<int, bool>> FuncIntBool = i => i > 2;

        private static readonly Expression<Func<int, bool>> FuncIntBoolAlt = j => j > 2;

        private static readonly Expression<Func<long, bool>> FuncLongBool = i => i > 2;

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
        public void GivenIEquatableImplementedAndFalseThenAreEquivalentShouldReturnFalse()
        {
            var source = new IdType().AsConstantExpression();
            var target = new IdType().AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenIEquatableImplementedAndTrueThenAreEquivalentShouldReturnTrue()
        {
            var source = new IdType().AsConstantExpression();
            var target = new IdType
            {
                Id = ((IdType)source.Value).Id,
                IdVal = ((IdType)source.Value).IdVal
            }.AsConstantExpression();
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenIComparableImplementedAndNotZeroThenAreEquivalentShouldReturnFalse()
        {
            var source = new StringWrapper(true).AsConstantExpression();
            var target = new StringWrapper(true).AsConstantExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenIComparableImplementedAndZeroThenAreEquivalentShouldReturnTrue()
        {
            var source = new StringWrapper(true).AsConstantExpression();
            var target = new StringWrapper
            {
                Id = ((StringWrapper)source.Value).Id,
                IdVal = ((StringWrapper)source.Value).IdVal
            }.AsConstantExpression();
            Assert.True(eq.AreEquivalent(source, target));
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
        public void GivenConstantWithDifferentReferenceThenAreEquivalentShouldReturnFalse()
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
        public void GivenEnumerableWithTargetNullThenAreEquivalentShouldReturnFalse()
        {
            IEnumerable<ConstantExpression> source = new[] { Five, Six };
            var target = default(IEnumerable<ConstantExpression>);
            Assert.False(eq.AreEquivalent(source, target));
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
        public void GivenAnonymousParameterWithSameSigantureThenAreEquivalentShouldReturnTrue()
        {
            var source = new { Id = 1, Name = nameof(IdType) }.GetType().AsParameterExpression();
            var target = new { Id = 1, Name = nameof(IdType) }.GetType().AsParameterExpression();
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenAnonymousParameterWithDifferentSignatureThenAreEquivalentShouldReturnFalse()
        {
            var source = new { Id = 1, Name = nameof(IdType) }.GetType().AsParameterExpression();
            var target = new { Id = (long)1, Name = nameof(IdType) }.GetType().AsParameterExpression();
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenSameExpressionThenAreEquivalentShouldReturnTrue()
        {
            var source = Expression.Goto(Expression.Label());
            Assert.True(eq.AreEquivalent(source, source));
        }

        [Fact]
        public void GivenExpressionNotSupportedThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.Goto(Expression.Label("1"));
            var target = Expression.Goto(Expression.Label("1"));
            Assert.False(eq.AreEquivalent(source, target));
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

        // TODO: IsLifted and IsLiftedToNull

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
        public void GivenMethodCallExpressionWithStaticMethodWhenAreEquivalentCalledThenShouldReturnTrue()
        {
            var method = typeof(Enumerable).MethodWithName(nameof(Enumerable.Take), isStatic: true);
            var methodWithType = method.MakeGenericMethod(typeof(IdType));
            var extensionParameter = new List<IdType>().AsConstantExpression();
            var takeParameter = 5.AsConstantExpression();
            var source = Expression.Call(methodWithType, extensionParameter, takeParameter);
            var target = Expression.Call(methodWithType, extensionParameter, takeParameter);
            Assert.True(eq.AreEquivalent(source, target));
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
            var source = QueryHelper.QuerySkip2Take3.Expression;
            Assert.True(eq.AreEquivalent(source, source));
        }

        [Fact]
        public void GivenTwoQueriesWhenNotEquivalentThenAreEquivalentShouldReturnFalse()
        {
            var source = QueryHelper.QuerySkip2Take3.Expression;
            var target = QueryHelper.QuerySkip2Take4.Expression;
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoArrayInitializationsWithDifferentTypesThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            var target = Expression.NewArrayInit(typeof(long), Expression.Constant((long)1));
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoArrayInitializationsWithSameTypeAndDifferentContentsThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            var target = Expression.NewArrayInit(typeof(int), Expression.Constant(2));
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoArrayInitializationsWithSameTypeAndContentsThenAreEquivalentShouldReturnTrue()
        {
            var source = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            var target = Expression.NewArrayInit(typeof(int), Expression.Constant(1));
            Assert.True(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenTypesAreDifferentThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.New(typeof(IdType));
            var target = Expression.New(typeof(StringWrapper));
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenConstructorsAreDifferentThenAreEquivalentShouldReturnFalse()
        {
            var constructors = typeof(StringWrapper).GetConstructors();
            var source = Expression.New(constructors.Single(c => c.GetParameters().Length == 0));
            var target = Expression.New(constructors.First(c => c.GetParameters().Length == 1),
                true.AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenArgumentsAreDifferentThenAreEquivalentShouldReturnFalse()
        {
            var constructor = typeof(StringWrapper)
                .GetConstructor(new[] { typeof(bool) });
            var source = Expression.New(constructor, true.AsConstantExpression());
            var target = Expression.New(constructor, false.AsConstantExpression());
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoInitsWhenArgumentsAreSameThenAreEquivalentShouldReturnTrue()
        {
            var source = Expression.New(typeof(IdType));
            var target = Expression.New(typeof(IdType));
            Assert.True(eq.AreEquivalent(source, target));
        }

        public static IEnumerable<object[]> GetInvocationExpressionMatrix()
        {

            // left equivalent, right not equivalent (false)
            yield return new object[]
            {
                Expression.Invoke(FuncBool, FuncBool.Parameters)
            };

            yield return new object[]
            {
                Expression.Invoke(FuncString, FuncString.Parameters)
            };

            yield return new object[]
            {
                Expression.Invoke(FuncIntBool, FuncIntBool.Parameters)
            };
        }

        [Theory]
        [MemberData(nameof(GetInvocationExpressionMatrix))]
        public void GivenTwoInvocationsWhenSameThenAreEquivalentShouldReturnTrue(InvocationExpression invocation)
        {
            Assert.True(eq.AreEquivalent(
                invocation,
                invocation.Update(invocation.Expression, invocation.Arguments)));
        }

        [Fact]
        public void GivenTwoInvocationsWhenDifferentThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.Invoke(FuncIntBool, FuncIntBool.Parameters);
            var target = Expression.Invoke(FuncBool, FuncBool.Parameters);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoInvocationsWhenDifferentTypesThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.Invoke(FuncBool, FuncBool.Parameters);
            var target = Expression.Invoke(FuncString, FuncString.Parameters);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void GivenTwoInvocationsWhenDifferentArgsThenAreEquivalentShouldReturnFalse()
        {
            var source = Expression.Invoke(FuncIntBool, FuncIntBool.Parameters);
            var target = Expression.Invoke(FuncIntBool, FuncIntBoolAlt.Parameters);
            Assert.False(eq.AreEquivalent(source, target));
        }

        [Fact]
        public void AreEquivalentWithNullTargetShouldReturnFalse()
        {
            Assert.False(eq.AreEquivalent(Expression.Constant(null, typeof(IdType)), null));
        }

        [Fact]
        public void AreEquivalentNonGenericEnumerableWithNullTargetShouldReturnFalse()
        {
            IEnumerable nonGenericEnumerable = new int[] { 1, 2 };
            Assert.False(eq.NonGenericEnumerablesAreEquivalent(nonGenericEnumerable, null));
        }

        private static IDictionary dictionary => new Dictionary<string, object>
        {
            {"one", 1},
            {"two", 2}
        };

        private static IDictionary dictionaryAltKey => new Dictionary<string, object>
        {
            {"one", 1},
            {"three", 2}
        };

        private static IDictionary dictionaryAltValue => new Dictionary<string, object>
        {
            {"one", 1},
            {"two", 3}
        };

        public static IEnumerable<object[]> GetDictionaryMatrix()
        {
            yield return new object[]
            {
                dictionary, dictionary, true
            };

            yield return new object[]
            {
                dictionary, null, false
            };

            yield return new object[]
            {
                dictionary, dictionaryAltKey, false
            };

            yield return new object[]
            {
                dictionary, dictionaryAltValue, false
            };
        }

        [Theory]
        [MemberData(nameof(GetDictionaryMatrix))]
        public void GivenTwoIDictionaryWhenDictionariesAreEquivalentCalledThenShouldReturnResult(
            IDictionary source,
            IDictionary target,
            bool areEqual)
        {
            Assert.Equal(areEqual, eq.DictionariesAreEquivalent(source, target));
        }

        [Theory]
        [MemberData(nameof(GetDictionaryMatrix))]
        public void GivenTwoIDictionaryWhenValuesAreEquivalentCalledThenShouldReturnResult(
            IDictionary source,
            IDictionary target,
            bool areEqual)
        {
            Assert.Equal(areEqual, eq.ValuesAreEquivalent(source, target));
        }

        [Fact]
        public void GivenExceptionOfDifferentTypeWhenValuesAreEquivalentCalledThenShouldReturnFalse()
        {
            var source = new ArgumentException();
            var target = new ArgumentNullException();
            Assert.False(eq.ValuesAreEquivalent(source, target));
        }

        [Fact]
        public void GivenExceptionOfSameTypeAndDifferentMessageWhenValuesAreEquivalentCalledThenShouldReturnFalse()
        {
            var source = new ArgumentException(nameof(ArgumentException));
            var target = new ArgumentException(nameof(ArgumentNullException));
            Assert.False(eq.ValuesAreEquivalent(source, target));
        }

        [Fact]
        public void GivenExceptionOfSameTypeAndMessageWhenValuesAreEquivalentCalledThenShouldReturnTrue()
        {
            var source = new ArgumentException(nameof(ArgumentException));
            var target = new ArgumentException(nameof(ArgumentException));
            Assert.True(eq.ValuesAreEquivalent(source, target));
        }

        public static IEnumerable<object[]> SpecialTypesMatrix()
        {
            var anonymousType = new { Foo = 1 }.GetType();

            yield return new object[]
            {
                anonymousType, typeof(object), false
            };

            yield return new object[]
            {
                anonymousType, anonymousType, true
            };

            yield return new object[]
            {
                anonymousType, typeof(IDictionary), true
            };

            yield return new object[]
            {
                anonymousType, typeof(IDictionary<string, object>), true
            };

            yield return new object[]
            {
                anonymousType, typeof(Dictionary<int, Type>), true
            };
        }

        [Theory]
        [MemberData(nameof(SpecialTypesMatrix))]
        public void GivenTwoTypesWhenTypesAreEquivalentThenShouldReturnResult(
            Type source,
            Type target,
            bool areEquivalent)
        {
            Assert.Equal(areEquivalent, eq.TypesAreEquivalent(source, target));
        }

        [Fact]
        public void GivenEnumerableQueryWhenTargetIsNotEnumerableQueryThenValuesAreEquivalentShouldBeFalse()
        {
            var enumerableQuery = new EnumerableQuery<string>(Expression.Constant("this"));
            var notEnumerableQuery = new List<int>();
            Assert.False(eq.ValuesAreEquivalent(enumerableQuery, notEnumerableQuery));
        }

        [Fact]
        public void GivenEnumerableQueryWhenOfSameTypeThenAreEquivalentShouldBeTrue()
        {
            var enumerableQuery = new EnumerableQuery<string>(Expression.Constant("this"));
            var enumerableQuerySame = new EnumerableQuery<string>(Expression.Constant("that"));
            Assert.True(eq.AreEquivalent(
                Expression.Constant(enumerableQuery),
                Expression.Constant(enumerableQuerySame)));
        }

        [Fact]
        public void GivenEnumerableQueryWhenOfDifferentTypeThenAreEquivalentShouldBeFalse()
        {
            var enumerableQuery = new EnumerableQuery<string>(Expression.Constant("this"));
            var enumerableQueryDifferent = new EnumerableQuery<int>(Expression.Constant(5));
            Assert.False(eq.AreEquivalent(
                Expression.Constant(enumerableQuery),
                Expression.Constant(enumerableQueryDifferent)));
        }

        public static IEnumerable<object[]> GetEnumerableValuesMatrix()
        {
            var matrix = nameof(GetEnumerableValuesMatrix);
            var matrixSame = nameof(GetEnumerableValuesMatrix);
            var matrixDifferent = nameof(matrix);
            var enumerable = new string[] { "one", "two" };
            var enumerableSame = new string[] { "one", "two" };
            var enumerableMatrix = matrix.AsEnumerable().ToArray();
            var enumerableMatrixSame = matrixSame.AsEnumerable().ToArray();

            yield return new object[]
            {
                matrix, matrixSame, true
            };

            yield return new object[]
            {
                matrix, matrixDifferent, false
            };

            yield return new object[]
            {
                matrix, enumerableMatrix, false
            };

            yield return new object[]
            {
                enumerable, enumerableSame, true
            };

            yield return new object[]
            {
                enumerable, enumerableMatrix, false
            };

            yield return new object[]
            {
                enumerableMatrix, enumerableMatrixSame, true
            };
        }

        [Theory]
        [MemberData(nameof(GetEnumerableValuesMatrix))]
        public void GivenTwoEnumerablesWhenValuesAreEquivalentCalledThenShouldResolveWithoutEnumeratingString(
            object source,
            object target,
            bool areEquivalent)
        {
            Assert.Equal(areEquivalent, eq.ValuesAreEquivalent(source, target));
        }

        public static IEnumerable<object[]> GetAnonymousTypesMatrix()
        {
            var anonymousType = new { Foo = 1, Bar = "hello" };
            var otherType = new { Foo = 1, Bar = "hello" };
            var differentType = new { Foo = 1, Bar = "goodbye" };
            Dictionary<string, object> anonymousDictionary = new Dictionary<string, object>
            {
                { nameof(anonymousType.Foo), anonymousType.Foo },
                { nameof(anonymousType.Bar), anonymousType.Bar }
            };
            IDictionary anonymousNonGenericDictionary = anonymousDictionary;
            ExpandoObject anonymousExpando = new ExpandoObject();
            ((IDictionary<string, object>)anonymousExpando).Add(
                nameof(anonymousType.Foo), anonymousType.Foo);
            ((IDictionary<string, object>)anonymousExpando).Add(
                nameof(anonymousType.Bar), anonymousType.Bar);

            yield return new object[]
            {
                anonymousType, anonymousType, true
            };

            yield return new object[]
            {
                anonymousType, otherType, true
            };

            yield return new object[]
            {
                anonymousType, differentType, false
            };

            yield return new object[]
            {
                anonymousType, anonymousDictionary, true
            };

            yield return new object[]
            {
                differentType, anonymousDictionary, false
            };

            yield return new object[]
            {
                anonymousType, anonymousNonGenericDictionary, true
            };

            yield return new object[]
            {
                differentType, anonymousNonGenericDictionary, false
            };

            yield return new object[]
            {
                anonymousType, anonymousExpando, true
            };

            yield return new object[]
            {
                differentType, anonymousExpando, false
            };
        }

        [Theory]
        [MemberData(nameof(GetAnonymousTypesMatrix))]
        public void GivenAnonymousTypeWhenComparedToDictionaryThenValuesAreEquivalentShouldReturnResult(
            object source, object target, bool areEquivalent)
        {
            Assert.Equal(areEquivalent, eq.ValuesAreEquivalent(source, target));
        }

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

        public static Expression<Func<ExpressionEquivalencyTests>> memberAssignmentExpr =
                () => new ExpressionEquivalencyTests { TestProp = new TestData() };
        public static Expression<Func<TestData>> memberAssignmentExprDifferentType =
                () => new TestData { Name = "Hello" };
        public static Expression<Func<TestData>> memberAssignmentExprDifferentTypeCtor =
                () => new TestData("Hello") { Name = "GoodBye" };
        public static Expression<Func<ExpressionEquivalencyTests>> memberAssignmentDup =
                () => new ExpressionEquivalencyTests { TestProp = new TestData() };
        public static Expression<Func<ExpressionEquivalencyTests>> memberAssignmentExprAlt =
            () => new ExpressionEquivalencyTests { TestProp = null };
        public static Expression<Func<ExpressionEquivalencyTests>> memberMemberBindingExpr =
            () => new ExpressionEquivalencyTests { TestProp = { Name = nameof(ExpressionEquivalencyTests) } };
        public static Expression<Func<ExpressionEquivalencyTests>> memberListBindingExpr =
            () => new ExpressionEquivalencyTests { TestProps = { new TestData(), new TestData() } };
        public static Expression<Func<ExpressionEquivalencyTests>> memberListBindingExprAlt =
            () => new ExpressionEquivalencyTests { TestProps = { new TestData(), null } };

        public static IEnumerable<object[]> GetMemberInitAndBindingMatrix(bool bindings = false)
        {
            static object Resolve(LambdaExpression expr, bool bindings)
            {
                var init = expr.Body as MemberInitExpression;
                return bindings ? (object)init.Bindings.First() : init;
            }

            yield return new object[]
            {
                Resolve(memberAssignmentExpr, bindings),
                Resolve(memberAssignmentExpr, bindings),
                true
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExpr, bindings),
                null,
                false
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExpr, bindings),
                Resolve(memberAssignmentExprDifferentType, bindings),
                false
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExprDifferentType, bindings),
                Resolve(memberAssignmentExprDifferentTypeCtor, bindings),
                false
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExpr, bindings),
                Resolve(memberAssignmentDup, bindings),
                true
            };

            yield return new object[]
            {
                Resolve(memberAssignmentExpr, bindings),
                Resolve(memberAssignmentExprAlt, bindings),
                false
            };

            yield return new object[]
            {
                Resolve(memberMemberBindingExpr, bindings),
                Resolve(memberMemberBindingExpr, bindings),
                true
            };

            yield return new object[]
            {
                Resolve(memberListBindingExpr, bindings),
                Resolve(memberListBindingExpr, bindings),
                true
            };

            yield return new object[]
            {
                Resolve(memberListBindingExpr, bindings),
                Resolve(memberListBindingExprAlt, bindings),
                false
            };

            yield return new object[]
            {
                Resolve(memberMemberBindingExpr, bindings),
                Resolve(memberListBindingExpr, bindings),
                false
            };
        }

        public static IEnumerable<object[]> GetMemberBindingMatrix()
        {
            foreach(var result in GetMemberInitAndBindingMatrix(true))
            {
                yield return result;
            }
        }

        [Theory]
        [MemberData(nameof(GetMemberBindingMatrix))]
        public void GivenMemberBindingsWhenComparedThenMemberBindingsAreEquivalentShouldReturnResult(
            MemberBinding source,
            MemberBinding target,
            bool areEquivalent)
        {
            Assert.Equal(areEquivalent, eq.MemberBindingsAreEquivalent(source, target));
        }

        public static IEnumerable<object[]> GetMemberInitMatrix()
        {
            foreach (var result in GetMemberInitAndBindingMatrix(false))
            {
                yield return result;
            }
        }

        [Theory]
        [MemberData(nameof(GetMemberInitMatrix))]
        public void GivenMemberInitsWhenComparedThenAreEquivalentShouldReturnResult(
            MemberInitExpression source,
            MemberInitExpression target,
            bool areEquivalent)
        {
            Assert.Equal(areEquivalent, eq.AreEquivalent(source, target));
        }
    }
}
