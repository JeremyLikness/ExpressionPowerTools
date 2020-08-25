using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionExtensionsTests
    {
        public string Id { get; set; }

        [Fact]
        public void GivenExpressionsAreEquivalentWhenIsEquivalentToCalledThenShouldReturnTrue()
        {
            Assert.True(1.AsConstantExpression().IsEquivalentTo(1.AsConstantExpression()));
        }

        [Fact]
        public void GivenExpressionsAreNotEquivalentWhenIsEquivalentToCalledThenShouldReturnFalse()
        {
            Assert.False(1.AsConstantExpression().IsEquivalentTo(0.AsConstantExpression()));
        }

        [Fact]
        public void GivenExpressionsAreSimilarWhenIsSimilarToCalledThenShouldReturnTrue()
        {
            Assert.True(1.AsConstantExpression().IsSimilarTo(1.AsConstantExpression()));
        }

        [Fact]
        public void GivenExpressionsAreNotSimilarWhenIsSimilarToCalledThenShouldReturnFalse()
        {
            Assert.False(1.AsConstantExpression().IsSimilarTo(0.AsConstantExpression()));
        }

        [Fact]
        public void GivenExpressionWhenMemberNameExtensionCalledThenShouldReturnName()
        {
            var foo = string.Empty;
            Expression<Func<string>> expr = () => foo;
            Assert.Equal(nameof(foo), expr.MemberName());
        }

        [Fact]
        public void WhenNullThenAsEnumerableShouldThrowArgumentNull()
        {
            Expression expr = null;
            Assert.Throws<ArgumentNullException>(
                () => expr.AsEnumerable());
        }

        [Fact]
        public void AsEnumerableShouldReturnIExpressionEnumerator()
        {
            var expr = Expression.Constant(this);
            var target = expr.AsEnumerable();
            Assert.NotNull(target);
            Assert.IsType<ExpressionEnumerator>(target);
        }

        [Fact]
        public void WhenNullThenAsConstantExpressionShouldThrowArgumentNull()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(
                () => obj.AsConstantExpression());
        }

        [Fact]
        public void AsConstantExpressionShouldReturnConstantExpressionWithValue()
        {
            var target = this.AsConstantExpression();
            Assert.NotNull(target);
            Assert.Equal(GetType(), target.Type);
            Assert.Same(this, target.Value);
        }

        [Fact]
        public void WhenNullThenAsParameterExpressionForObjectShouldThrowNullArgument()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(
                () => obj.AsParameterExpression());
        }

        [Fact]
        public void AsParameterExpressionForObjectShouldReturnParameterExpressionOfObjectType()
        {
            var target = this.AsParameterExpression();
            Assert.NotNull(target);
            Assert.Equal(GetType(), target.Type);
            Assert.False(target.IsByRef);
        }

        [Fact]
        public void AsParameterExpressionForObjectWithNameShouldReturnParameterExpressionOfObjectTypeWithName()
        {
            ParameterExpression target = this.AsParameterExpression(nameof(target));
            Assert.NotNull(target);
            Assert.Equal(GetType(), target.Type);
            Assert.Equal(nameof(target), target.Name);
            Assert.False(target.IsByRef);
        }

        [Fact]
        public void AsParameterExpressionForObjectByRefShouldReturnParameterExpressionOfObjectTypeByRef()
        {
            ParameterExpression target = this.AsParameterExpression(byRef: true);
            Assert.NotNull(target);
            Assert.Equal(GetType(), target.Type);
            Assert.True(target.IsByRef);
        }

        [Fact]
        public void WhenNullThenAsParameterExpresionForTypeShouldThrowArgumentNull()
        {
            Type type = null;
            Assert.Throws<ArgumentNullException>(
                () => type.AsParameterExpression());
        }

        [Fact]
        public void AsParameterExpressionForTypeShouldReturnParameterExpressionForType()
        {
            var target = GetType().AsParameterExpression();
            Assert.Equal(GetType(), target.Type);
            Assert.False(target.IsByRef);
        }

        [Fact]
        public void AsParameterExpressionForTypeWithNameShouldReturnParameterExpressionForTypeWithName()
        {
            ParameterExpression target = GetType().AsParameterExpression(nameof(target));
            Assert.Equal(GetType(), target.Type);
            Assert.Equal(nameof(target), target.Name);
            Assert.False(target.IsByRef);
        }

        [Fact]
        public void AsParameterExpressionForTypeByRefShouldReturnParameterExpressionForTypeByRef()
        {
            var target = GetType().AsParameterExpression(byRef: true);
            Assert.Equal(GetType(), target.Type);
            Assert.True(target.IsByRef);
        }

        [Fact]
        public void WhenNullThenCreateParameterExpressionShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => ExpressionExtensions.CreateParameterExpression
                <string, string>(null));
        }

        [Fact]
        public void CreateParameterExpressionShouldCreateParameterWithParentType()
        {
            var target = ExpressionExtensions
                .CreateParameterExpression<ExpressionExtensionsTests, string>
                (test => test.Id);
            Assert.NotNull(target);
            Assert.Equal(typeof(string), target.Type);
        }

        [Fact]
        public void CreateParameterExpressionShouldCreateParameterWithName()
        {
            var target = ExpressionExtensions
                .CreateParameterExpression<ExpressionExtensionsTests, string>
                (test => test.Id);
            Assert.NotNull(target);
            Assert.Equal(nameof(Id), target.Name);
        }

        [Fact]
        public void AsInvocationExpressionWithNoParametersShouldReturnInvocation()
        {
            Expression<Func<bool>> lambda = () => true;
            var invocation = lambda.AsInvocationExpression();
            Assert.NotNull(invocation);
            Assert.Same(invocation.Expression, lambda);            
        }

        public static IEnumerable<object[]> GetInvocationMatrix()
        {
            Expression<Func<int, bool>> intbool = i => i > 2;
            Expression<Func<int, int, long>> multiply = (a, b) => a * b;

            yield return new object[]
            {
                intbool
            };

            yield return new object[]
            {
                multiply
            };
        }

        [Theory]
        [MemberData(nameof(GetInvocationMatrix))]
        public void AsInvocationExpressionWithParametersShouldReturnInvocation(LambdaExpression expr)
        {
            var invocation = expr.AsInvocationExpression();
            Assert.NotNull(invocation);
            Assert.Same(invocation.Expression, expr);
            Assert.Equal(invocation.Arguments, expr.Parameters);
        }

        [Fact]
        public void GivenExpressionNotPartOfTargetWhenIsPartOfCalledThenShouldReturnFalse()
        {
            var target = Expression.Add(1.AsConstantExpression(), 2.AsConstantExpression());
            var source = 3.AsConstantExpression();
            Assert.False(source.IsPartOf(target));
        }

        [Fact]
        public void GivenExpressionPartOfTargetWhenIsPartOfCalledThenShouldReturnTrue()
        {
            var target = Expression.Add(1.AsConstantExpression(), 2.AsConstantExpression());
            var source = 2.AsConstantExpression();
            Assert.True(source.IsPartOf(target));
        }
    }
}
