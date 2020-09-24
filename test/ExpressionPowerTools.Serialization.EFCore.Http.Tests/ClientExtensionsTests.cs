using System;
using Microsoft.Extensions.DependencyInjection;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using Xunit;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using System.Net.Http;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static ExpressionPowerTools.Serialization.EFCore.Http.Tests.HttpRemoteQueryResolverTests;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class ClientExtensionsTests
    {
        private readonly IServiceCollection Collection = new
            ServiceCollection();

        private const string Path = "/custom/{context}/{collection}";

        private readonly Uri BaseUri = new Uri("https://localhost:1234/");

        private readonly Uri ServiceUri = new Uri("https://localhost:4321/");

        [Fact]
        public void ConfigurePathSetsPath()
        {
            Collection.AddExpressionPowerToolsEFCore(
                BaseUri,
                configure => configure.SetPathTemplate(Path));
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            Assert.Equal(Path, config.PathTemplate);
        }

        [Fact]
        public void ConfigureClientCapturesClient()
        {
            var myClient = new RemoteQueryClient(new HttpClient { BaseAddress = ServiceUri }); 
            Collection.AddExpressionPowerToolsEFCore(
                BaseUri,
                configure => configure.SetClientFactory(
                    () => myClient));
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            var client = config.ClientFactory();
            Assert.NotNull(client);
            Assert.Same(myClient, client);
        }

        [Fact]
        public void ChainingWorks()
        {
            var myClient = new RemoteQueryClient(new HttpClient { BaseAddress = ServiceUri });
            Collection.AddExpressionPowerToolsEFCore(
                BaseUri,
                configure => configure.SetClientFactory(
                    () => myClient)
                .SetPathTemplate(Path));
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            Assert.Equal(Path, config.PathTemplate);
            var client = config.ClientFactory();
            Assert.NotNull(client);
            Assert.Same(myClient, client);
        }

        [Fact]
        public void DefaultsToUseServiceProvider()
        {
            Collection.AddExpressionPowerToolsEFCore(BaseUri);
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            var client = config.ClientFactory();
            Assert.NotNull(client);            
        }

        [Fact]
        public void GivenNullQueryWhenExecuteRemoteAsyncThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => ClientExtensions.ExecuteRemote<TestThing>(null));
        }

        [Fact]
        public void GivenNonRemoteQueryWhenExecuteRemoteAsyncThenShouldThrowNullReference()
        {
            var query = IQueryableExtensions.CreateQueryTemplate<TestThing>();
            Assert.Throws<NullReferenceException>(
                () => query.ExecuteRemote());
        }

        [Fact]
        public void GivenRemoteQueryWhenExecuteRemoteAsyncThenShouldReturnIRemoteQueryable()
        {
            var query = DbClientContext<TestThingContext>.Query(context => context.Things)
                .Take(5);
            var actual = query.ExecuteRemote();
            Assert.IsAssignableFrom<IRemoteQueryable<TestThing>>(actual);
        }

        [Fact]
        public void GivenNullQueryThenSingleAsyncThrowsArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await ClientExtensions.FirstOrSingleAsync<TestThing>(null));
        }

        [Fact]
        public async Task GivenQueryThenSingleAsyncReturnsSingle()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(
                registration => registration.RegisterSingleton<IRemoteQueryClient>(
                    new MockRemoteQueryClient
                    {
                        QueryType = QueryTestCase.Single
                    }));
            ServiceHost.GetService<IClientHttpConfiguration>()
                .SetClientFactory(
                () => ServiceHost.GetService<IRemoteQueryClient>());
            var actual = await DbClientContext<TestThingContext>.Query(
                context => context.Things)
                .ExecuteRemote()
                .FirstOrSingleAsync();
            Assert.NotNull(actual);
            Assert.IsType<TestThing>(actual);
        }

        [Fact]
        public void GivenNullQueryThenCountAsyncThrowsArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await ClientExtensions.CountAsync<TestThing>(null));
        }

        [Fact]
        public async Task GivenQueryThenCountAsyncReturnsCount()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(
                registration => registration.RegisterSingleton<IRemoteQueryClient>(
                    new MockRemoteQueryClient()));
            ServiceHost.GetService<IClientHttpConfiguration>()
                .SetClientFactory(
                () => new MockRemoteQueryClient
                {
                    QueryType = QueryTestCase.Count
                });
            var actual = await DbClientContext<TestThingContext>.Query(
                context => context.Things)
                .ExecuteRemote()
                .CountAsync();
            Assert.Equal(5, actual);
        }

        [Fact]
        public void GiveNullQueryThenToArrayAsyncThrowsArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await ClientExtensions.ToArrayAsync<TestThing>(null));
        }

        [Fact]
        public async Task GivenQueryThenToArrayAsyncReturnsArray()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(
                registration => registration.RegisterSingleton<IRemoteQueryClient>(
                    new MockRemoteQueryClient
                    {
                        QueryType = QueryTestCase.Array
                    }));
            ServiceHost.GetService<IClientHttpConfiguration>()
                .SetClientFactory(
                () => ServiceHost.GetService<IRemoteQueryClient>());
            var actual = await DbClientContext<TestThingContext>.Query(
                context => context.Things)
                .ExecuteRemote()
                .ToArrayAsync();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Length);
        }

        [Fact]
        public void GiveNullQueryThenToHashSetAsyncThrowsArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await ClientExtensions.ToHashSetAsync<TestThing>(null));
        }

        [Fact]
        public async Task GivenQueryThenToHashSetAsyncReturnsHashSet()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(
                registration => registration.RegisterSingleton<IRemoteQueryClient>(
                    new MockRemoteQueryClient
                    {
                        QueryType = QueryTestCase.HashSet
                    }));
            ServiceHost.GetService<IClientHttpConfiguration>()
                .SetClientFactory(
                () => ServiceHost.GetService<IRemoteQueryClient>());
            var actual = await DbClientContext<TestThingContext>.Query(
                context => context.Things)
                .ExecuteRemote()
                .ToHashSetAsync();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Count);
        }

        [Fact]
        public void GiveNullQueryThenToListAsyncThrowsArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await ClientExtensions.ToListAsync<TestThing>(null));
        }

        [Fact]
        public async Task GivenQueryThenToListAsyncReturnsList()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(
                registration => registration.RegisterSingleton<IRemoteQueryClient>(
                    new MockRemoteQueryClient
                    {
                        QueryType = QueryTestCase.List
                    }));
            ServiceHost.GetService<IClientHttpConfiguration>()
                .SetClientFactory(
                () => ServiceHost.GetService<IRemoteQueryClient>());
            var actual = await DbClientContext<TestThingContext>.Query(
                context => context.Things)
                .ExecuteRemote()
                .ToListAsync();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Count);
        }

        [Fact]
        public void GiveNullQueryThenAsEnumerableAsyncThrowsArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await ClientExtensions.AsEnumerableAsync<TestThing>(null));
        }

        [Fact]
        public async Task GivenQueryThenAsEnumerableAsyncReturnsEnumerable()
        {
            ServiceHost.Reset();
            ServiceHost.Initialize(
                registration => registration.RegisterSingleton<IRemoteQueryClient>(
                    new MockRemoteQueryClient
                    {
                        QueryType = QueryTestCase.Enumerable
                    }));
            ServiceHost.GetService<IClientHttpConfiguration>()
                .SetClientFactory(
                () => ServiceHost.GetService<IRemoteQueryClient>());
            var actual = await DbClientContext<TestThingContext>.Query(
                context => context.Things)
                .ExecuteRemote()
                .AsEnumerableAsync();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Count());
        }
    }
}
