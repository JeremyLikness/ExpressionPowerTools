using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Providers;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    [Collection(nameof(ServiceHost))]
    public class ServiceHostTests
    {
        [Fact]
        public void CreatesADefaultInstanceOfServices()
        {
            ServiceHost.Reset();
            Assert.NotNull(ServiceHost.GetService<IServices>());
        }

        [Fact]
        public void InitializeIncludesDefaultServices()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(register =>
                register.Register<IdType, IdType>());
            Assert.NotNull(ServiceHost.GetService<IdType>());
            Assert.NotNull(ServiceHost.GetService<IExpressionComparisonRuleProvider>());
            ServiceHost.Reset();
        }

        [Fact]
        public void SecondCallToInitializeShouldThrowInvalidOperation()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(register => { });
            Assert.Throws<InvalidOperationException>(() =>
                ServiceHost.Initialize(register => { }));
            ServiceHost.Reset();
        }

        [Fact]
        public void ResetSetsToDefault()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(register =>
                register.Register<IExpressionComparisonRuleProvider, DefaultHighPerformanceRules>());
            Assert.IsType<DefaultHighPerformanceRules>(ServiceHost.GetService<IExpressionComparisonRuleProvider>());
            ServiceHost.Reset();
            Assert.IsType<DefaultComparisonRules>(ServiceHost.GetService<IExpressionComparisonRuleProvider>());
            ServiceHost.Reset();
        }

        [Fact]
        public void AdditionalInitializationAfterResetIsFine()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(register => { });
            ServiceHost.Reset();
            ServiceHost.Initialize(register => { });
        }

        public interface ILazyTest
        {
            int Prop { get; }
        }

        public class LazyService : ILazyTest
        {
            public int Prop => int.MaxValue;
        }

        [Fact]
        public void GetLazyDefersResolutionUntilValueAcccessed()
        {
            ServiceHost.Reset();
            var lazyTestProvider = ServiceHost.GetLazyService<ILazyTest>();
            ServiceHost.Initialize(
                registration => registration.Register<ILazyTest, LazyService>());
            var target = lazyTestProvider.Value;
            Assert.NotNull(target);
        }

        [Fact]
        public void DefaultRulesProviderIsSingletonOfDefaultComparisonRules()
        {
            ServiceHost.Reset();
            Assert.IsType<DefaultComparisonRules>(
                ServiceHost.GetService<IExpressionComparisonRuleProvider>());
            Assert.Same(
                ServiceHost.GetService<IExpressionComparisonRuleProvider>(),
                ServiceHost.GetService<IExpressionComparisonRuleProvider>());
            ServiceHost.Reset();
        }

        [Fact]
        public void DefaultEvaluatorIsSingletonOfExpressionEvaluator()
        {
            ServiceHost.Reset();
            Assert.IsType<ExpressionEvaluator>(
                ServiceHost.GetService<IExpressionEvaluator>());
            Assert.Same(
                ServiceHost.GetService<IExpressionEvaluator>(),
                ServiceHost.GetService<IExpressionEvaluator>());
            ServiceHost.Reset();
        }

        [Fact]
        public void DefaultExpressionEnumeratorIsExpressionEnumerator()
        {
            ServiceHost.Reset();
            Assert.IsType<ExpressionEnumerator>(
                ServiceHost.GetService<IExpressionEnumerator>(
                    Expression.Constant(true)));
            ServiceHost.Reset();
        }

        [Fact]
        public void DefaultQuerySnapshotHostIsQuerySnapshotHost()
        {
            ServiceHost.Reset();
            var query = new List<string>().AsQueryable();
            Assert.IsType<QuerySnapshotHost<string>>(
                ServiceHost.GetService<IQuerySnapshotHost<string>>(query));
            ServiceHost.Reset();
        }

        [Fact]
        public void DefaultQueryHostIsQueryHost()
        {
            ServiceHost.Reset();
            var query = new List<string>().AsQueryable();
            var provider = new QueryInterceptingProvider<string>(query);
            var target = ServiceHost.GetService<IQueryHost<string, ICustomQueryProvider<string>>>(
                    query.Expression, provider);
            Assert.NotNull(target);
            Assert.IsType<QueryHost<string, ICustomQueryProvider<string>>>(target);
            Assert.Same(query.Expression, target.Expression);
            Assert.Same(provider, target.CustomProvider);
            ServiceHost.Reset();
        }

        [Fact]
        public void DefaultQueryInterceptingProviderIsQueryInterceptingProvider()
        {
            ServiceHost.Reset();
            var query = new List<string>().AsQueryable();
            var target = ServiceHost.GetService<IQueryInterceptingProvider<string>>(
                query);
            Assert.NotNull(target);
            Assert.IsType<QueryInterceptingProvider<string>>(target);
            ServiceHost.Reset();
        }

        public interface IGenericService
        {
            string Id { get; }
        }

        public class GenericService : IGenericService
        {
            public string Id => nameof(GenericService);
        }

        public class OverriddenService : IGenericService
        {
            public string Id => nameof(OverriddenService);
        }

        public static bool AfterRegisterCalled = false;

        public class RegisterTestServices : IDependentServiceRegistration
        {
            public void AfterRegistered()
            {
                AfterRegisterCalled = true;
            }

            public void RegisterDefaultServices(IServiceRegistration registration)
            {
                registration.RegisterSingleton<IGenericService>(new GenericService());
            }
        }

        [Fact]
        public void GivenSatelliteImplementationOfIDependentServiceRegistrationWhenResetCalledThenShouldRegisterService()
        {
            ServiceHost.Reset();
            var service = ServiceHost.GetService<IGenericService>();
            Assert.NotNull(service);
            Assert.IsType<GenericService>(service);
        }

        [Fact]
        public void GivenRegisteredSatelliteServiceWhenInitializeCalledThenWillOverride()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(registration =>
                registration.RegisterSingleton<IGenericService>(new OverriddenService()));
            var service = ServiceHost.GetService<IGenericService>();
            Assert.NotNull(service);
            Assert.IsType<OverriddenService>(service);
        }

        [Fact]
        public void GivenRegisteredSatelliteServiceWhenInitializeCalledThenAfterRegisteredCalled()
        {
            ServiceHost.Reset();
            AfterRegisterCalled = false;
            ServiceHost.Initialize(registration =>
                registration.RegisterSingleton<IGenericService>(new OverriddenService()));
            Assert.True(AfterRegisterCalled);
        }

        [Fact]
        public void DefaultQuerySnapshotProviderIsQuerySnapshotProvider()
        {
            ServiceHost.Reset();
            var query = new List<string>().AsQueryable();
            var target = ServiceHost.GetService<IQuerySnapshotProvider<string>>(
                query);
            Assert.NotNull(target);
            Assert.IsType<QuerySnapshotProvider<string>>(target);
            ServiceHost.Reset();
        }


    }
}
