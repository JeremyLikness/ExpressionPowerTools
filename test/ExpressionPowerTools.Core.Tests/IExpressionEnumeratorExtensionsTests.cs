using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionPowerTools.Core.Extensions;
using Xunit;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Tests
{
    public class IExpressionEnumeratorExtensionsTests
    {
        [Fact]
        public void WhenNullConstantsOfTypeShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => QueryHelper
                .NullEnumerator.ConstantsOfType<string>());
        }

        [Fact]
        public void ConstantsOfTypeShouldReturnConstantsOfGivenType()
        {
            var target = QueryHelper.QueryEnumerator
                .ConstantsOfType<int>()
                .ToList();
            Assert.NotEmpty(target);
            Assert.True(target.All(
                item => item.Type == typeof(int)));
        }

        [Fact]
        public void WhenNullMethodsWithNameForTypeShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => QueryHelper.NullEnumerator
                .MethodsWithNameForType<IEnumerable<int>>(
                    nameof(Enumerable.Take)));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        public void WhenNameIsNullOrWhiteSpaceThenMethodsWithNameForTypeShouldThrowArgument(
            string methodName)
        {
            Assert.Throws<ArgumentException>(
                () => QueryHelper.QueryEnumerator
                .MethodsWithNameForType<IEnumerable<int>>(methodName));
        }

        [Fact]
        public void MethodsWithNameForTypeShouldReturnMethodCallExpressions()
        {
            var target = QueryHelper.QueryEnumerator
                .MethodsWithNameForType<DateTime>(
                nameof(DateTime.AddDays)).ToList();
            Assert.Single(target);
            Assert.Equal(typeof(DateTime), target[0].Method.DeclaringType);
            Assert.Equal(nameof(DateTime.AddDays), target[0].Method.Name);
        }

        [Fact]
        public void MethodsWithNameForTypeNonGenericShouldReturnMethodCallExpressions()
        {
            var target = QueryHelper.QueryEnumerator
                .MethodsWithNameForType(
                typeof(Queryable),
                nameof(Queryable.Take)).ToList();
            Assert.Single(target);
            Assert.Equal(typeof(Queryable), target[0].Method.DeclaringType);
            Assert.Equal(nameof(Queryable.Take), target[0].Method.Name);
        }

        [Fact]
        public void GivenNullWhenMethodsFromTemplateCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => QueryHelper.QueryEnumerator
                .MethodsFromTemplate<DateTime>(null));
        }

        [Fact]
        public void GivenNonMemberExpressionWhenMethodsFromTemplateCalledThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () => QueryHelper.QueryEnumerator
                .MethodsFromTemplate<DateTime>(dt => new string(" ")));
        }

        [Fact]
        public void GivenDifferentDeclaringTypeWhenMethodsFromTemplateCalledThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () => QueryHelper.QueryEnumerator
                .MethodsFromTemplate<DateTime>(dt => Math.Max(1, 2)));
        }

        [Fact]
        public void MethodsFromTemplateShouldReturnMatchingMethodCallExpressions()
        {
            var target = QueryHelper.QueryEnumerator
                .MethodsFromTemplate<DateTime>(dt => dt.AddDays(1))
                .Single();
            Assert.NotNull(target);
            Assert.Equal(typeof(DateTime), target.Method.DeclaringType);
            Assert.Equal(nameof(DateTime.AddDays), target.Method.Name);
        }

        [Fact]
        public void WhenNullMethodsWithNameShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => IExpressionEnumeratorExtensions
                    .MethodsWithName(null, nameof(Queryable.Take)));
        }

        [Theory]
        [InlineData("    ")]
        [InlineData(null)]
        public void GiveMethodNameWithNullOrWhitespaceWhenMethodsWithNameCalledThenShouldThrowArgument(
            string methodName)
        {
            Assert.Throws<ArgumentException>(
                () => QueryHelper.QueryEnumerator
                .MethodsWithName(methodName));
        }

        [Fact]
        public void GivenMethodNameWhenMethodsWithNameCalledThenShouldReturnMatchingMethodCallExpressions()
        {
            var target = QueryHelper.QueryEnumerator
                .MethodsWithName(nameof(Enumerable.Take))
                .Single();
            Assert.NotNull(target);
            Assert.Equal(
                nameof(Enumerable.Take),
                target.Method.Name);
        }

        [Fact]
        public void WhenNullOfExpressionTypeShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => IExpressionEnumeratorExtensions
                    .OfExpressionType(
                    null,
                    ExpressionType.Add));
        }

        [Theory]
        [InlineData(ExpressionType.Constant)]
        [InlineData(ExpressionType.Call)]
        [InlineData(ExpressionType.Parameter)]
        [InlineData(ExpressionType.Lambda)]
        public void GivenExpressionTypeWhenOfExpressionTypeCalledThenShouldReturnExpressionWithMatchingType(
            ExpressionType type)
        {
            var target = QueryHelper.QueryEnumerator
                .OfExpressionType(type).ToList();
            Assert.NotEmpty(target);
            Assert.True(target.All(t => t.NodeType == type));
        }
    }
}
