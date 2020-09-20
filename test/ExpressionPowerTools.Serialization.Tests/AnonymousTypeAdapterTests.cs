using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class AnonymousTypeAdapterTests
    {
        private readonly IAnonymousTypeAdapter adapter = new AnonymousTypeAdapter();

        [Fact]
        public void GivenNullWhenTransformAnonymousObjectCalledThenShouldReturnNull()
        {
            var actual = adapter.TransformAnonymousObject(null);
            Assert.Null(actual);
        }

        [Fact]
        public void GivenNonAnonymousTypeWhenTransformAnonymousObjectCalledThenShouldThrowInvalidOperation()
        {
            Assert.Throws<ArgumentException>(
                () => adapter.TransformAnonymousObject(this));
        }

        public static IEnumerable<object[]> GetAnonymousTypeMatrix()
        {
            yield return new object[]
            {
                new
                {
                    Id = 1,
                    name = nameof(GetAnonymousTypeMatrix)
                }
            };

            yield return new object[]
            {
                new
                {
                    Id = 1,
                    subType = new
                    {
                        Id = Guid.NewGuid(),
                        Name = nameof(Guid)
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetAnonymousTypeMatrix))]
        public void GivenAnonymousObjectWhenTransformAnonymousObjectCalledThenShouldReturnAnonType(object expected)
        {
            var anonType = adapter.TransformAnonymousObject(expected);
            Assert.NotNull(anonType);
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(expected, anonType.GetValue()));
        }

        [Fact]
        public void GivenNullConstantExpressionWhenTransformConstantCalledThenShouldReturnNull()
        {
            var actual = adapter.TransformConstant(null);
            Assert.Null(actual);
        }

        [Fact]
        public void GivenNonAnonymousConstantWhenTransformConstantCalledThenShouldReturnConstant()
        {
            var expected = Expression.Constant(1);
            var actual = adapter.TransformConstant(expected);
            Assert.Same(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetAnonymousTypeMatrix))]
        public void GivenAnonymousConstantWhenTransformConstantCalledThenShouldTransformConstant(object expected)
        {
            var constant = Expression.Constant(expected);
            var actual = adapter.TransformConstant(constant);
            Assert.NotSame(constant, actual);
            Assert.IsType<AnonType>(actual.Value);
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(
                constant.Value,
                ((AnonType)actual.Value).GetValue()));
        }

        [Theory]
        [MemberData(nameof(GetAnonymousTypeMatrix))]
        public void GivenAnonTypeConstantWhenTransformConstantCalledThenShouldTransformConstant(object expected)
        {
            var constant = Expression.Constant(expected);
            var actual = adapter.TransformConstant(constant);
            var actualTransformed = adapter.TransformConstant(actual);
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(
                constant.Value,
                actualTransformed.Value));
        }

        [Theory]
        [MemberData(nameof(GetAnonymousTypeMatrix))]
        public void GivenAnonInitializerConstantWhenTransformConstantCalledThenShouldTransformConstant(object expected)
        {
            var anonType = new AnonType(expected);
            var anonInitializer = new AnonInitializer(
                anonType.AnonymousTypeName,
                anonType.PropertyNames,
                anonType.PropertyValues);
            var constant = Expression.Constant(anonInitializer);
            var actual = adapter.TransformConstant(constant);
            var actualTransformed = adapter.TransformConstant(actual);
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(
                anonType.GetValue(),
                actualTransformed.Value));
        }

        [Fact]
        public void GivenNullExpressionWhenTransformNewCalledThenShouldReturnNull()
        {
            var actual = adapter.TransformNew(null);
            Assert.Null(actual);
        }

        [Fact]
        public void GivenNewExpressionNotForAnonymousTypeWhenTransformNewCalledThenShouldReturnExpression()
        {
            var expected = Expression.New(GetType().GetConstructors().First());
            var actual = adapter.TransformNew(expected);
            Assert.Same(expected, actual);
        }

        [Fact]
        public void GivenNewExpressionWithAnonymousTypeWhenTransformNewCalledThenShouldReturnTransformedExpression()
        {
            Expression<Func<object>> anonNew =
                () => new { Id = 1, Name = nameof(AnonymousTypeAdapter) };
            var exprNew = anonNew.AsEnumerable().OfType<NewExpression>().Single();
            var transformed = adapter.TransformNew(exprNew);
            Assert.Equal(typeof(AnonInitializer), transformed.Type);
            var originalNew = Expression.Lambda<Func<object>>(exprNew);
            var originalObj = originalNew.Compile()();
            var transformedNew = Expression.Lambda<Func<AnonInitializer>>(transformed);
            var transformedObj = transformedNew.Compile()().AnonValue.GetValue();
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(originalObj, transformedObj));
        }

        [Fact]
        public void GivenNewExpressionWithAnonymousTypeAndParametersWhenTransformNewCalledThenShouldReturnTransformedExpression()
        {
            var name = nameof(AnonymousTypeAdapter);
            Expression<Func<object>> anonNew =
                () => new { Id = 1, Name = name };
            var exprNew = anonNew.AsEnumerable().OfType<NewExpression>().Single();
            var transformed = adapter.TransformNew(exprNew);
            Assert.Equal(typeof(AnonInitializer), transformed.Type);
            var originalNew = Expression.Lambda<Func<object>>(exprNew);
            var originalObj = originalNew.Compile()();
            var transformedNew = Expression.Lambda<Func<AnonInitializer>>(transformed);
            var transformedObj = transformedNew.Compile()().AnonValue.GetValue();
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(originalObj, transformedObj));
        }

        [Fact]
        public void GivenNewExpressionWithAnonymousTypeAndReferenceWhenTransformNewCalledThenShouldReturnTransformedExpression()
        {
            var thing = new TestableThing();
            var query = new List<TestableThing>().AsQueryable();
            var projection = query.Select(t => new { t.Id });
            var exprNew = projection.Expression.AsEnumerable().OfType<NewExpression>().Single();
            var parameters = projection.Expression.AsEnumerable().OfType<LambdaExpression>()
                .Single().Parameters;
            var transformed = adapter.TransformNew(exprNew);
            Assert.Equal(typeof(AnonInitializer), transformed.Type);
            var originalNew = Expression.Lambda<Func<TestableThing, object>>(exprNew, parameters);
            var originalObj = originalNew.Compile()(thing);
            var transformedNew = Expression.Lambda<Func<TestableThing, AnonInitializer>>(transformed, parameters);
            var transformedObj = transformedNew.Compile()(thing).AnonValue.GetValue();
            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(originalObj, transformedObj));
        }


        [Fact]
        public void GivenNullLambdaExpressionWhenTransformLambdaCalledThenShouldReturnNull()
        {
            var actual = adapter.TransformLambda(null);
            Assert.Null(actual);
        }

        [Fact]
        public void GivenLambdaWithNonAnonymousReturnTypeWhenTransformCalledThenShouldReturnExpression()
        {
            Expression<Func<string>> lambda = () => string.Empty;
            var actual = adapter.TransformLambda(lambda);
            Assert.Same(actual, lambda);
        }

        public static IEnumerable<object[]> GetLambdaMatrix()
        {
            Expression<Func<object>> lambda = () => new { Id = 1 };
            var anon = new { Name = nameof(lambda) };
            Expression<Func<object>> anonLambda = () => anon;
            var query = new List<TestableThing>().AsQueryable();
            var projection = query.Select(t => new { t.Id });
            var expr = projection.Expression.AsEnumerable().OfType<LambdaExpression>().Single();
            
            yield return new object[]
            {
                lambda
            };

            yield return new object[]
            {
                anonLambda
            };

            yield return new object[]
            {
                expr
            };
        }

        [Theory]
        [MemberData(nameof(GetLambdaMatrix))]
        public void GivenLambdaWithAnonymousReturnTypeWhenTransformCalledThenShouldReturnExpression(LambdaExpression lambda)
        {
            var actual = adapter.TransformLambda(lambda);
            Assert.NotSame(lambda, actual);
            object source, target;
            if (lambda.Parameters.Any())
            {
                var thing = new TestableThing();
                target = actual.Compile().DynamicInvoke(thing);
                source = lambda.Compile().DynamicInvoke(thing);
            }
            else
            {
                target = actual.Compile().DynamicInvoke(null);
                source = lambda.Compile().DynamicInvoke(null);
            }

            object targetVal;
            if (lambda.AsEnumerable().OfType<NewExpression>().Any())
            {
                Assert.IsType<AnonInitializer>(target);
                targetVal = (target as AnonInitializer).AnonValue.GetValue();
            }
            else
            {
                targetVal = target;
            }

            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(source, targetVal));
        }

        [Theory]
        [MemberData(nameof(GetLambdaMatrix))]
        public void GivenConvertedLambdaWhenTransformCalledThenShouldReturnExpression(LambdaExpression lambda)
        {
            var transformed = adapter.TransformLambda(lambda);
            var actual = adapter.TransformLambda(transformed);
            object source, target;
            if (lambda.Parameters.Any())
            {
                var thing = new TestableThing();
                target = actual.Compile().DynamicInvoke(thing);
                source = lambda.Compile().DynamicInvoke(thing);
            }
            else
            {
                target = actual.Compile().DynamicInvoke(null);
                source = lambda.Compile().DynamicInvoke(null);
            }

            Assert.True(ExpressionEquivalency.ValuesAreEquivalent(source, target));
        }

        [Fact]
        public void GivenNullOrWhiteSpaceStringWhenMemberKeyTransformerCalledThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () => adapter.MemberKeyTransformer(string.Empty));
        }

        [Fact]
        public void TransformsAnonymousToExpando()
        {
            var source = "M:System.Linq.Queryable.Select``2(System.Linq.IQueryable{ExpressionPowerTools.Serialization.Tests.TestHelpers.TestableThing},System.Linq.Expressions.Expression{System.Func{ExpressionPowerTools.Serialization.Tests.TestHelpers.TestableThing,<>f__AnonymousType3{System.String}}})";
            var expected = "M:System.Linq.Queryable.Select``2(System.Linq.IQueryable{ExpressionPowerTools.Serialization.Tests.TestHelpers.TestableThing},System.Linq.Expressions.Expression{System.Func{ExpressionPowerTools.Serialization.Tests.TestHelpers.TestableThing,System.Dynamic.ExpandoObject}})";
            var actual = adapter.MemberKeyTransformer(source);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DoesNothingWithNonAnonymous()
        {
            var source = "T:System.Object";
            var actual = adapter.MemberKeyTransformer(source);
            Assert.Equal(source, actual);
        }
    }
}
