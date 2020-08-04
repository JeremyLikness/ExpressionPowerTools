using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class ServicesTests
    {
        [Fact]
        public void GivenNotConfiguredWhenGetServiceCalledThenShouldThrowInvalidOperation()
        {
            var source = new Services();
            Assert.Throws<InvalidOperationException>(
                () => source.GetService<IdType>());
        }

        [Fact]
        public void GivenConfiguredWhenGetServiceCalledWithNonRegisteredServiceThenShouldThrowInvalidOperation()
        {
            var source = new Services();
            source.RegisterServices(registration => { });
            Assert.Throws<InvalidOperationException>(
                () => source.GetService<IdType>());
        }

        [Fact]
        public void GivenConfiguredWhenGetServiceCalledWithRegisteredServiceThenShouldReturnInstance()
        {
            var source = new Services();
            source.RegisterServices(
                registration => registration.Register<IdType,IdType>());
            var target = source.GetService<IdType>();
            Assert.NotNull(target);
        }

        [Fact]
        public void GivenConfiguredWhenGetServiceCalledWithNonArgumentWithResolveSetThenShouldReturnWithArgument()
        {
            var source = new Services();
            var param = new IdType();
            source.RegisterServices(registration =>
                source.Register<StringWrapper, StringWrapper>());
            var target = source.GetService<StringWrapper>(param);
            Assert.NotNull(target);
            Assert.Equal(target.Id, param.Id);
        }

        [Fact]
        public void GivenConfiguredWhenRegisterServiceCalledThenShouldThrowInvalidOperation()
        {
            var source = new Services();
            source.RegisterServices(registration => { });
            Assert.Throws<InvalidOperationException>(
                () => source.Register<string, string>());
        }

        [Fact]
        public void GivenGenericRegistrationWhenGetServiceCalledThenShouldImplementType()
        {
            var source = new Services();
            source.RegisterServices(registration =>
                registration.RegisterGeneric(typeof(IQueryHost<,>), typeof(QueryHost<,>)));
            var query = new List<IdType>().AsQueryable();
            var provider = new QueryInterceptingProvider<IdType>(query);
            var target = source.GetService<IQueryHost<IdType, ICustomQueryProvider<IdType>>>(
                query.Expression, provider);
            Assert.NotNull(target);
            Assert.Same(query.Expression, target.Expression);
            Assert.Same(target.CustomProvider, provider);
        }

        [Fact]
        public void GivenGenericRegistrationWhenSignatureIsNotAssignableFromImplementationThenShouldThrowInvalidOperation()
        {
            var source = new Services();
            Assert.Throws<InvalidOperationException>(
                () => source.RegisterGeneric(typeof(ICustomQueryProvider<>), typeof(IQueryHost<,>)));
        }

        [Fact]
        public void GivenNullInstanceWhenRegisterSingletonCalledThenShouldThrowArgumentNull()
        {
            var source = new Services();
            Assert.Throws<ArgumentNullException>(
                () => source.RegisterSingleton<IdType>(null));
        }

        [Fact]
        public void GivenRegisteredSingletonWhenGetServiceCalledThenShouldReturnSingleton()
        {
            var source = new Services();
            var id = new IdType();
            source.RegisterServices(registration =>
                registration.RegisterSingleton(id));
            Assert.Same(id, source.GetService<IdType>());
        }

        [Fact]
        public void GivenRegisteredTypeWhenSingletonRegisteredThenShouldReplaceType()
        {
            var source = new Services();
            var id = new IdType();
            source.Register<IdType, IdType>();
            source.RegisterServices(
                registration => registration.RegisterSingleton(id));
            Assert.Same(id, source.GetService<IdType>());
        }

        [Fact]
        public void GivenRegisteredSingletonWhenTypeRegisteredThenShouldReplaceSingleton()
        {
            var source = new Services();
            var id = new IdType();
            source.RegisterSingleton(id);
            source.RegisterServices(
                registration => registration.Register<IdType, IdType>());
            Assert.NotSame(id, source.GetService<IdType>());
        }
    }
}
