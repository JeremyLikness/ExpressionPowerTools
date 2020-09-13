using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class DbContextAdapterTests
    {
        private readonly DbContextOptions<TestWidgetsContext> options =
            new DbContextOptionsBuilder<TestWidgetsContext>()
            .UseInMemoryDatabase(nameof(DbContextAdapterTests)).Options;
        private readonly TestWidgetsContext context;
        private readonly PropertyInfo widgets = typeof(TestWidgetsContext)
            .GetProperty(nameof(TestWidgetsContext.Widgets));
        private readonly PropertyInfo decoy = typeof(TestWidgetsContext)
            .GetProperty(nameof(TestWidgetsContext.Decoy));
        private readonly PropertyInfo products = typeof(TestProductsContext)
            .GetProperty(nameof(TestProductsContext.Products));
        private readonly IDbContextAdapter target = new DbContextAdapter();

        public DbContextAdapterTests()
        {
            context = new TestWidgetsContext(options);
        }

        [Fact]
        public void GivenNullDbContextWhenCreateQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => target.CreateQuery(null, widgets));
        }

        [Fact]
        public void GivenNullCollectionWhenCreateQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => target.CreateQuery(context, null));
        }

        [Fact]
        public void GivenCollectionNotOnDbContextWhenCreateQueryCalledThenShouldThrowTarget()
        {
            Assert.Throws<TargetException>(
                () => target.CreateQuery(context, products));
        }

        [Fact]
        public void GivenCollectionDoesNotReferenceDbSetWhenCreateQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentException>(
                () => target.CreateQuery(context, decoy));
        }

        [Fact]
        public void GivenParametersAreValidWhenCreateQueryCalledThenShouldReturnQuery()
        {
            var query = target.CreateQuery(context, widgets);
            Assert.NotNull(query);
            Assert.Equal(typeof(TestWidget), query.ElementType);
        }

        public static IEnumerable<object[]> GetTryGetContextMatrix()
        {
            yield return new object[]
            {
                null,
                null
            };

            yield return new object[]
            {
                new Type[0],
                typeof(TestWidgetsContext).Name
            };

            yield return new object[]
            {
                null,
                typeof(TestWidgetsContext).Name
            };

            yield return new object[]
            {
                new Type[0],
                null
            };

            yield return new object[]
            {
                new Type[] { typeof(TestWidgetsContext) },
                typeof(TestProductsContext).Name
            };

            yield return new object[]
            {
                new Type[] { typeof(DbContextAdapterTests) },
                typeof(DbContextAdapterTests).Name
            };
        }

        [Theory]
        [MemberData(nameof(GetTryGetContextMatrix))]
        public void GivenNoMatchBetweenContextAndTypesWhenTryGetContextCalledThenShouldReturnFalse(
            Type[] typeList,
            string context)
        {
            Assert.False(target.TryGetContext(typeList, context, out _));
        }

        [Fact]
        public void GivenMatchBetweenContextAndTypesWhenTryGetContextCalledThenShouldReturnContextTypeAndTrue()
        {
            Assert.True(target.TryGetContext(
                new Type[] { typeof(TestWidgetsContext) },
                typeof(TestWidgetsContext).Name,
                out Type dbContextType));
            Assert.Equal(typeof(TestWidgetsContext), dbContextType);
        }

        public static IEnumerable<object[]> GetTryGetDbSetMatrix()
        {
            yield return new object[] { null, null };

            yield return new object[]
                {
                    typeof(TestWidgetsContext),
                    string.Empty
                };

            yield return new object[]
            {
                null,
                nameof(TestWidgetsContext.Widgets)
            };

            yield return new object[]
            {
                typeof(TestWidgetsContext),
                nameof(TestWidgetsContext.Decoy)
            };

            yield return new object[]
            {
                typeof(string),
                nameof(string.Length)
            };
        }

        [Theory]
        [MemberData(nameof(GetTryGetDbSetMatrix))]
        public void GivenNoMatchBetweenCollectionAndDbSetWhenTryGetDbSetCalledThenShouldReturnFalse(
            Type dbContextType,
            string collection)
        {
            Assert.False(target.TryGetDbSet(
                dbContextType,
                collection,
                out PropertyInfo _));
        }

        [Fact]
        public void GivenValidParametersWhenTryGetDbSetCalledThenShouldReturnPropertyInfoAndTrue()
        {
            Assert.True(target.TryGetDbSet(
                typeof(TestWidgetsContext),
                nameof(TestWidgetsContext.Widgets),
                out PropertyInfo info));
            Assert.Same(widgets, info);
        }
    }
}
