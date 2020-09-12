using System;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Queryable;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests
{
    public class RemoteQueryTests
    {
        private readonly Type dbContextType = typeof(TestThingContext);
        private readonly PropertyInfo dbSet = typeof(TestThingContext).GetProperty(nameof(TestThingContext.Things));

        [Fact]
        public void GivenNullRemoteContextWhenRemoteQueryProviderInstantiatedThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoteQueryProvider<TestThing>(
                IQueryableExtensions.CreateQueryTemplate<TestThing>(), null));
        }

        [Fact]
        public void GivenRemoteQueryWhenFiltersAppliedThenShouldRetainResultContext()
        {
            var things = TestThing.GetThings(100);
            var remoteContext = new RemoteContext(dbContextType, dbSet);
            var queryable = things.AsRemoteQueryable(remoteContext).Where(t => t.Id.Contains("a") && t.IsActive).OrderBy(t => t.Value).Skip(2).Take(10);
            var remote = queryable as IRemoteQuery;
            Assert.Same(remoteContext, remote.CustomProvider.Context);           
        }

        [Fact]
        public void GivenRemoteQueryWithProjectionWhenFiltersAppliedThenShouldRetainResultContext()
        {
            var things = TestThing.GetThings(100);
            var remoteContext = new RemoteContext(dbContextType, dbSet);
            var queryable = things.AsRemoteQueryable(remoteContext).Where(t => t.Id.Contains("a") && t.IsActive).OrderBy(t => t.Value).Skip(2).Take(10)
                .Select(t => new { t.Id, t.Value });
            var remote = queryable as IRemoteQuery;
            Assert.Same(remoteContext, remote.CustomProvider.Context);            
        }

        [Fact]
        public void GivenRemoteQueryExecutionShouldInterceptToEmpty()
        {
            var things = TestThing.GetThings(100);
            var remoteContext = new RemoteContext(dbContextType, dbSet);
            var queryable = things.AsRemoteQueryable(remoteContext).OrderBy(t => t.Value).Skip(2).Take(10);
            var result = queryable.ToList();
            Assert.Empty(result);
        }
    }
}
