using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.EFCore.Http.Transport;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class HttpRemoteQueryResolverTests
    {
        private readonly IRemoteQueryResolver target = new HttpRemoteQueryResolver();
        private readonly RemoteContext context =
            new RemoteContext(
                typeof(TestThingContext),
                typeof(TestThingContext).GetProperty(nameof(TestThingContext.Things)));
        private readonly MockRemoteQueryClient client = new MockRemoteQueryClient();

        public HttpRemoteQueryResolverTests()
        {
            var config = ServiceHost.GetService<IClientHttpConfiguration>();
            config.SetClientFactory(() => client);
        }

        public enum QueryTestCase
        {
            Single,
            Count,
            Enumerable,
            List,
            HashSet,
            Array
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            foreach(QueryTestCase testCase in Enum.GetValues(typeof(QueryTestCase)))
            {
                yield return new object[] { testCase };
            }
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void GivenNullQueryWhenMethodCalledThenShouldThrowArgumentNull(
            QueryTestCase queryCase)
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await CallMethodAsync<TestThing>(queryCase, null));
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void GivenQueryNotIRemoteQueryWhenMethodCalledThenShouldThrowArgumentException(
            QueryTestCase queryCase)
        {
            Assert.ThrowsAsync<ArgumentException>(
                async () => await CallMethodAsync(queryCase, GetQuery(false)));
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public async Task QueryYieldsResults(QueryTestCase queryCase)
        {
            var query = GetQuery();
            client.QueryType = queryCase;
            var result = await CallMethodAsync(queryCase, query);
            Assert.NotNull(result);
            switch(queryCase)
            {
                case QueryTestCase.Array:
                    Assert.IsType<TestThing[]>(result);
                    Assert.Equal(5, ((TestThing[])result).Length);
                    break;
                case QueryTestCase.Count:
                    Assert.IsType<int>(result);
                    Assert.Equal(5, (int)result);
                    break;
                case QueryTestCase.Enumerable:
                    Assert.IsAssignableFrom<IEnumerable<TestThing>>(result);
                    break;
                case QueryTestCase.HashSet:
                    Assert.IsType<HashSet<TestThing>>(result);
                    Assert.Equal(5, ((HashSet<TestThing>)result).Count);
                    break;
                case QueryTestCase.List:
                    Assert.IsType<List<TestThing>>(result);
                    Assert.Equal(5, ((List<TestThing>)result).Count);
                    break;
                case QueryTestCase.Single:
                    Assert.IsType<TestThing>(result);
                    break;
            }
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public async Task EmptyResultReturnsDefaultOrNegative(QueryTestCase queryCase)
        {
            var query = GetQuery();
            client.QueryType = queryCase;
            client.EmptyQuery = true;
            var result = await CallMethodAsync(queryCase, query);
            switch (queryCase)
            {
                case QueryTestCase.Array:
                    Assert.IsType<TestThing[]>(result);
                    Assert.Empty(result as TestThing[]);
                    break;
                case QueryTestCase.Count:
                    Assert.IsType<int>(result);
                    Assert.Equal(-1, (int)result);
                    break;
                case QueryTestCase.Enumerable:
                    Assert.IsAssignableFrom<IEnumerable<TestThing>>(result);
                    break;
                case QueryTestCase.HashSet:
                    Assert.IsType<HashSet<TestThing>>(result);
                    Assert.Empty((HashSet<TestThing>)result);
                    break;
                case QueryTestCase.List:
                    Assert.IsType<List<TestThing>>(result);
                    Assert.Empty((List<TestThing>)result);
                    break;
                case QueryTestCase.Single:
                    Assert.Null(result);
                    break;
            }
        }

        private IQueryable<TestThing> GetQuery(bool remote = true)
        {
            var core = IQueryableExtensions.CreateQueryTemplate<TestThing>();
            if (remote)
            {
                core = core.AsRemoteQueryable(context);
            }
            return core.OrderBy(t => EF.Property<string>(t, nameof(TestThing.Id))).Take(5);
        }

        private async Task<object> CallMethodAsync<T>(
            QueryTestCase queryCase,
            IQueryable<T> query)
        {
            return queryCase switch
            {
                QueryTestCase.Array => await target.ToArrayAsync(query),
                QueryTestCase.Count => await target.CountAsync(query),
                QueryTestCase.Enumerable => await target.AsEnumerableAsync(query),
                QueryTestCase.HashSet => await target.ToHashSetAsync(query),
                QueryTestCase.List => await target.ToListAsync(query),
                QueryTestCase.Single => await target.FirstOrSingleAsync(query),
                _ => null,
            };
        }
    }
}
