using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Core.Extensions;
using Xunit;
using System.Linq;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializationStateTests
    {
        private readonly string[] keys = new[]
        {
            "T:System.String",
            "T:System.Collections.Generic.IEnumerable{System.String}",
            "T:System.Collections.Generic.IEnumerable{System.Collections.Generic.IEnumerable{System.String}}",
        };

        private readonly string[] compressedKeys = new[]
        {
            "T:^0",
            "T:^1",
            "T:^2",
        };

        private readonly string[] typeIndex = new[]
        {
            "T:System.String",
            "T:System.Collections.Generic.IEnumerable{^0}",
            "T:System.Collections.Generic.IEnumerable{^1}"
        };

        private readonly SerializationState state = new SerializationState
        {
            CompressTypes = true
        };

        [Fact]
        public void GivenSerializationStateWhenInstantiatedThenShouldInitializeTypeIndex()
        {
            var target = new SerializationState();
            Assert.NotNull(target.TypeIndex);
        }

        [Fact]        
        public void ToGetExpressionTreeReturnsLastExpression()
        {
            var expr = Expression.Constant(nameof(SerializationStateTests));
            state.LastExpression = expr;
            Assert.Equal(state.GetExpressionTree(), expr.AsEnumerable().ToString());
        }

        [Fact]
        public void GetExpressionTreeResetsExpression()
        {
            var expr = Expression.Constant(nameof(SerializationStateTests));
            state.LastExpression = expr;
            state.GetExpressionTree();
            Assert.Null(state.LastExpression);
        }

        [Fact]
        public void GivenOverrideWhenToStringCalledThenShouldKeepExpression()
        {
            var expr = Expression.Constant(nameof(SerializationStateTests));
            state.LastExpression = expr;
            state.GetExpressionTree(preventReset: true);
            Assert.Same(expr, state.LastExpression);
        }

        [Fact]
        public void CompressTypesCompressesTypes()
        {
            var (str, enumStr, enumEnumStr) = (keys[0], keys[1], keys[2]);
            state.CompressTypesForKeys(
                (str, key => str = key),
                (enumStr, key => enumStr = key),
                (enumEnumStr, key => enumEnumStr = key));
            Assert.Equal(new[]
            {
                str, enumStr, enumEnumStr
            }, compressedKeys);
        }

        [Fact]
        public void DecompressTypesDecompressesTypes()
        {
            var (str, enumStr, enumEnumStr) = (keys[0], keys[1], keys[2]);
            state.CompressTypesForKeys(
                (str, key => str = key),
                (enumStr, key => enumStr = key),
                (enumEnumStr, key => enumEnumStr = key));
            state.DecompressTypesForKeys(
                (str, key => str = key),
                (enumStr, key => enumStr = key),
                (enumEnumStr, key => enumEnumStr = key));
            Assert.Equal(new[]
            {
                str, enumStr, enumEnumStr
            }, keys);
        }

        [Fact]
        public void DoneCompressesTypeIndex()
        {
            var (str, enumStr, enumEnumStr) = (keys[0], keys[1], keys[2]);
            state.CompressTypesForKeys(
                (str, key => str = key),
                (enumStr, key => enumStr = key),
                (enumEnumStr, key => enumEnumStr = key));
            state.Done();
            Assert.Equal(typeIndex, state.TypeIndex.ToArray());
        }

        [Fact]
        public void GivenCompressTypesFalseWhenCompressTypesCalledThenDoesNothing()
        {
            state.CompressTypes = false;
            var (str, enumStr, enumEnumStr) = (keys[0], keys[1], keys[2]);
            state.CompressTypesForKeys(
                (str, key => str = key),
                (enumStr, key => enumStr = key),
                (enumEnumStr, key => enumEnumStr = key));
            Assert.Equal(new[]
            {
                str, enumStr, enumEnumStr
            }, keys);
        }

        [Fact]
        public void GivenCompressTypesFalseWhenCompressTypeIndexCalledThenDoesNothing()
        {
            state.CompressTypes = false;
            var (str, enumStr, enumEnumStr) = (keys[0], keys[1], keys[2]);
            state.CompressTypesForKeys(
                (str, key => str = key),
                (enumStr, key => enumStr = key),
                (enumEnumStr, key => enumEnumStr = key));
            state.Done();
            Assert.DoesNotContain(state.TypeIndex, t => t.Contains("^"));
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
