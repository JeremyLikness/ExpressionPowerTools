using System;
using System.Collections.Generic;
using System.Reflection;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class CollectionHandleTests
    {
        private static readonly Type dbType = typeof(TestProductsContext);
        private static readonly PropertyInfo products = typeof(TestProductsContext).GetProperty(nameof(TestProductsContext.Products));
        private static readonly PropertyInfo widgets = typeof(TestWidgetsContext).GetProperty(nameof(TestWidgetsContext.Widgets));
        private static readonly PropertyInfo decoy = typeof(TestWidgetsContext).GetProperty(nameof(TestWidgetsContext.Decoy));

        public static IEnumerable<object[]> GetInitMatrix()
        {
            yield return new object[] { dbType, null };
            yield return new object[] { null, products };
            yield return new object[] { null, null };
        }

        [Theory]
        [MemberData(nameof(GetInitMatrix))]
        public void GivenNullTypeOrNullCollectionWhenCollectionHandleInstantiatedThenShouldThrowArgumentNull(
            Type dbContext, PropertyInfo collection)
        {
            Assert.Throws<ArgumentNullException>(() => new CollectionHandle(dbContext, collection));
        }

        [Fact]
        public void GivenTypeNotDerivedFromDbContextWhenCollectionHandleInstantiatedThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(() => new CollectionHandle(typeof(string), products));
        }

        [Fact]
        public void GivenCollectionNotAPropertyOnDbContextTypeWhenCollectionHandleInstantiatedThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () => new CollectionHandle(dbType, widgets));
        }

        [Fact]
        public void GivenCollectionNotADbSetWhenCollectionHandleInstantiatedThenShouldThrowArgument()
        {
            Assert.Throws<ArgumentException>(
                () => new CollectionHandle(typeof(TestWidgetsContext), decoy));
        }

        [Fact]
        public void GivenProperTypeAndCollectionWhenCollectionHandleInstantiatedThenShouldSetProperties()
        {
            var target = new CollectionHandle(dbType, products);
            Assert.Same(dbType, target.DbContextType);
            Assert.Same(products, target.Collection);
        }
    }
}
