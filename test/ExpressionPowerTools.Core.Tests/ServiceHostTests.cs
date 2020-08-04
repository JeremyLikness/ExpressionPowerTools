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
                register.Register<IExpressionComparisonRuleProvider, DefaultComparisonRules>());
            Assert.IsType<DefaultComparisonRules>(ServiceHost.GetService<IExpressionComparisonRuleProvider>());
            ServiceHost.Reset();
            Assert.IsType<DefaultHighPerformanceRules>(ServiceHost.GetService<IExpressionComparisonRuleProvider>());
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

        [Fact]
        public void DefaultRulesProviderIsSingletonOfDefaultHighPerformanceRules()
        {
            ServiceHost.Reset();
            Assert.IsType<DefaultHighPerformanceRules>(
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
