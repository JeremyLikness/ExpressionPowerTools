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
    public class QueryInterceptingProviderTests
    {
        private IQueryable<IdType> Query =>
            new List<IdType>().AsQueryable();

        private QueryInterceptingProvider<IdType> Provider(
            IQueryable query = null) =>
                new QueryInterceptingProvider<IdType>(query ?? Query);

        [Fact]
        public void GivenNullExpressionWhenCreateQueryCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider().CreateQuery(null));
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryCalledThenShouldReturnNewQuerySnapshotHost()
        {
            var target = Provider().CreateQuery(Query.Expression);
            Assert.IsAssignableFrom<IQueryHost<IdType, 
                IQueryInterceptingProvider<IdType>>>(target);
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryCalledThenShouldReturnQueryWithSelfAsProvider()
        {
            var provider = Provider();
            var target = provider.CreateQuery(Query.Expression)
                as IQueryHost<IdType,
                IQueryInterceptingProvider<IdType>>;
            Assert.Same(provider, target.CustomProvider);
        }

        [Fact]
        public void GivenNullExpressionWhenCreateQueryTypedCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider().CreateQuery<string>(null));
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryTypedCalledThenShouldReturnNewQueryHost()
        {
            var target = Provider().CreateQuery<string>(Query.Expression);
            Assert.IsAssignableFrom<IQueryHost<string,
                IQueryInterceptingProvider<string>>>(target);
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryTypedCalledWithSameTypeThenShouldReturnQueryWithSelfAsProvider()
        {
            var provider = Provider();
            var target = provider.CreateQuery<IdType>(Query.Expression);
            Assert.Same(provider, target.Provider);
        }

        [Fact]
        public void GivenExpressionWhenCreateQueryTypedCalledWithDifferentTypeThenShouldReturnQueryWithNewProvider()
        {
            var provider = Provider();
            var target = provider.CreateQuery<string>(Query.Expression);
            Assert.NotSame(provider, target.Provider);
        }

        [Fact]
        public void GivenNullExpressionWhenExecuteCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => Provider().Execute(null));
        }

        [Fact]
        public void GivenExpressionWhenExecuteCalledThenShouldTransformExpressionAndCallSourceProvider()
        {
            var query = new TestQueryableWrapper();
            var provider = new QueryInterceptingProvider<IdType>(query);
            provider.RegisterInterceptor(e => Expression.Constant(1));
            var target = provider.Execute(Expression.Constant(2));
            Assert.IsType<ConstantExpression>(target);
            Assert.Equal(1, (target as ConstantExpression).Value);
        }

        [Fact]
        public void GivenNoRegistrationThenTheTransformationShouldReturnOriginalExpression()
        {
            var query = new TestQueryableWrapper();
            var provider = new QueryInterceptingProvider<IdType>(query);
            var target = provider.Execute(Expression.Constant(2));
            Assert.IsType<ConstantExpression>(target);
            Assert.Equal(2, (target as ConstantExpression).Value);
        }

        [Fact]
        public void GivenRegistrationWhenRegistrationCalledAgainThenShouldThrowInvalidOperation()
        {
            var provider = Provider();
            provider.RegisterInterceptor(e => e);
            Assert.Throws<InvalidOperationException>(
                () => provider.RegisterInterceptor(e => e));
        }

        [Fact]
        public void GivenRegistrationWhenChildProviderCreatedThenRegistrationShouldBePassedToChild()
        {
            var list = new List<IdType> { new IdType(), new IdType(), new IdType() };
            var query = list.AsQueryable().Take(1);
            var swapQuery = list.AsQueryable().Skip(1).Take(1)
                .Select(i => Tuple.Create(i.Id, i.IdVal));
            var provider = new QueryInterceptingProvider<IdType>(query);
            var host = new QueryHost<IdType, QueryInterceptingProvider<IdType>>(
                query.Expression, provider);
            
            // register now
            provider.RegisterInterceptor(e => swapQuery.Expression);
            
            // force resolution of a different type, generates new provider, should be intercepted
            var intercepted = host.Select(i => Tuple.Create(i.Id, i.IdVal)).ToList();
            Assert.Single(intercepted);
            Assert.Equal(list[1].Id, intercepted[0].Item1);
        }

        [Fact]
        public void GivenRegistrationWhenChildProvidersExistThenRegistrationShouldBePassedToChildren()
        {
            var list = new List<IdType> { new IdType(), new IdType(), new IdType() };
            var query = list.AsQueryable().Take(1);
            var swapQuery = list.AsQueryable().Skip(1).Take(1).Select(i => Tuple.Create(i.Id, i.IdVal));
            var provider = new QueryInterceptingProvider<IdType>(query);
            var host = new QueryHost<IdType, QueryInterceptingProvider<IdType>>(query.Expression, provider);
            // force resolution of a different type
            var notIntercepted = host.Select(i => Tuple.Create(i.Id, i.IdVal)).ToList();
            // now register
            provider.RegisterInterceptor(e => swapQuery.Expression);
            var intercepted = host.Select(i => Tuple.Create(i.Id, i.IdVal)).ToList();
            Assert.Single(intercepted);
            Assert.Equal(list[1].Id, intercepted[0].Item1);
        }

    }
}
