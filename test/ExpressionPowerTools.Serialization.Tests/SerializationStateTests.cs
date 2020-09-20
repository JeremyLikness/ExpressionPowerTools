using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializationStateTests
    {
        [Fact]
        public void GivenSerializationStateWhenInstantiatedThenShouldInitializeTypeIndex()
        {
            var target = new SerializationState();
            Assert.NotNull(target.TypeIndex);
        }

        [Fact]
        public void GivenParametersOfSameNameWhenGetOrCacheCalledThenShouldReturnSameInstance()
        {
            var target = new SerializationState();
            var param1 = Expression.Parameter(typeof(int));
            var param2 = Expression.Parameter(typeof(int), nameof(target));
            var param3 = Expression.Parameter(typeof(int), nameof(param1));
            var param4 = Expression.Parameter(typeof(int));
            var param5 = Expression.Parameter(typeof(int), nameof(target));
            var cache1 = target.GetOrCacheParameter(param1);
            var cache2 = target.GetOrCacheParameter(param2);
            var cache3 = target.GetOrCacheParameter(param3);
            var cache4 = target.GetOrCacheParameter(param4);
            var cache5 = target.GetOrCacheParameter(param5);
            Assert.Same(param1, cache1);
            Assert.Same(param2, cache2);
            Assert.Same(param3, cache3);
            Assert.NotSame(param4, cache4);
            Assert.Same(param1, cache4);
            Assert.NotSame(param5, cache5);
            Assert.Same(param2, cache5);
        }
    }
}
