using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GivenNotConfiguredWhenGetServiceCalledForGenericTypeThenShouldThrowInvalidOperation()
        {
            var source = new Services();
            Assert.Throws<InvalidOperationException>(
                () => source.GetService<IQuerySnapshotProvider<string>>());
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
        public void GivenGenericRegistrationWhenSignatureIsAssignableFromImplementationThenShouldNotThrowInvalidOperation()
        {
            var source = new Services();
            source.RegisterGeneric(typeof(QueryHost<,>), typeof(QueryHost<,>));
        }

        [Fact]
        public void GivenGenericRegistrationWhenSignatureBaseClassOfImplementationThenShouldNotThrowInvalidOperation()
        {
            var source = new Services();
            source.RegisterGeneric(typeof(QueryHost<,>), typeof(DerivedQueryHost<,>));
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
        public void GivenRegisteredTypeWhenSameTypeRegisteredThenShouldReplaceType()
        {
            var source = new Services();
            source.RegisterServices(register =>
                register.Register<StringWrapper, StringWrapper>()
                .Register<StringWrapper, DerivedStringWrapper>());
            Assert.IsType<DerivedStringWrapper>(source.GetService<StringWrapper>());
        }

        [Fact]
        public void GivenRegisteredSingletonWhenSameTypeRegisteredWithSingletonThenShouldReplaceInstance()
        {
            var source = new Services();
            var id1 = new IdType();
            var id2 = new IdType();
            source.RegisterServices(register =>
                register.RegisterSingleton(id1)
                    .RegisterSingleton(id2));
            Assert.NotSame(id1, source.GetService<IdType>());
            Assert.Same(id2, source.GetService<IdType>());
        }

        [Fact]
        public void GivenRegisteredGenericTypeWhenSameGenericTypeRegisteredWithThenShouldReplaceImplementation()
        {
            var source = new Services();
            source.RegisterServices(register =>
                register.RegisterGeneric(typeof(IQueryHost<,>), typeof(QueryHost<,>))
                    .RegisterGeneric(typeof(IQueryHost<,>), typeof(DerivedQueryHost<,>)));
            var sourceQuery = new List<string>().AsQueryable();
            var provider = new QueryInterceptingProvider<string>(sourceQuery);
            Assert.NotNull(source.GetService<IQueryHost<string, ICustomQueryProvider<string>>>(
                sourceQuery.Expression, provider) as DerivedQueryHost<string, ICustomQueryProvider<string>>);
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
