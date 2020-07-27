using System;
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
    }
}
