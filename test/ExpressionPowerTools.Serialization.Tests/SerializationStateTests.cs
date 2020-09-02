using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Extensions;
using Xunit;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializationStateTests
    {
        public IEqualityComparer<SerializableType> comparer =
            new SerializableTypeComparer();

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

        [Fact]
        public void GivenCompressTypesFalseWhenCompressTypeCalledThenDoesNothing()
        {
            var target = new SerializationState { CompressTypes = false };
            var type = TestSerializer.ReflectionHelper.SerializeType(typeof(int));
            Assert.True(comparer.Equals(type, target.CompressType(type)));
        }

        [Fact]
        public void GivenCompressTypesTrueWhenCompressTypeCalledThenCompressesType()
        {
            var target = new SerializationState { CompressTypes = true };
            var type = TestSerializer.ReflectionHelper.SerializeType(typeof(int));
            var compressedType = target.CompressType(type);
            Assert.False(comparer.Equals(type, compressedType));
            Assert.Equal("^0", compressedType.TypeName);
        }

        [Fact]
        public void GivenComplexTypeWhenCompressTypeCalledThenSholdRecursivelyCompressType()
        {
            var target = new SerializationState { CompressTypes = true };
            var type = TestSerializer.ReflectionHelper.SerializeType(typeof(IComparable<IQueryable<int>>));
            var compressedType = target.CompressType(type);
            Assert.False(comparer.Equals(type, compressedType));
            Assert.Equal(3, target.TypeIndex.Count);
            Assert.Single(target.TypeIndex.Where(t => t.TypeName.Contains(typeof(int).Name)));
            Assert.Single(target.TypeIndex.Where(t => t.TypeName.Contains(typeof(IQueryable<>).Name)));
        }

        public class Something<T>
        {
            T Thing { get; set; }
        }

        public class UberSomething<TSomething, T, Z>
            where TSomething : Something<T>
        {
            TSomething Something { get; set; }
            Z Other { get; set; }
        }

        public Type[] TypeList => new[]
        {
                typeof(int),
                typeof(Something<>),
                typeof(Something<int>),
                typeof(UberSomething<,,>),
                typeof(long),
                typeof(UberSomething<Something<int>, int, long>)
        };

        [Fact]
        public void GivenTypesWhenCompressedThenShouldDecompress()
        {
            var target = new SerializationState { CompressTypes = true };
            var types = TypeList;
            var serialized = types.Select(t => TestSerializer.ReflectionHelper.SerializeType(t)).ToArray();
            // compressing raw type
            var compressed = types.Select(t => target.CompressType(t)).ToArray();
            var decompressed = compressed.Select(t => target.DecompressType(t)).ToArray();
            Assert.NotEqual(serialized, compressed, comparer);
            Assert.Equal(serialized, decompressed, comparer);
        }

        [Fact]
        public void GivenSerializedTypesWhenCompressedThenShouldDecompress()
        {
            var target = new SerializationState { CompressTypes = true };
            var types = TypeList;
            var serialized = types.Select(t => TestSerializer.ReflectionHelper.SerializeType(t)).ToArray();
            // compressing serialized type
            var compressed = serialized.Select(t => target.CompressType(t)).ToArray();
            var decompressed = compressed.Select(t => target.DecompressType(t)).ToArray();
            Assert.NotEqual(serialized, compressed, comparer);
            Assert.Equal(serialized, decompressed, comparer);
        }

        [Fact]
        public void GivenCompressedTypesWhenDecompressCalledTheShouldDecompressFullTypeIndex()
        {
            var target = new SerializationState { CompressTypes = true };
            var types = TypeList;
            var serialized = types.Select(t => TestSerializer.ReflectionHelper.SerializeType(t)).ToArray();
            // compressing raw type
            var compressed = types.Select(t => target.CompressType(t)).ToArray();
            var decompressed = target.DecompressType(compressed.First());
            bool foundCompressedType = false;
            var queue = new Queue<SerializableType>();
            void RecurseType(SerializableType type)
            {
                queue.Enqueue(type);
                if (type.GenericTypeArguments?.Length > 0)
                {
                    foreach(var childType in type.GenericTypeArguments)
                    {
                        RecurseType(childType);
                    }
                }
            }
            foreach(var type in target.TypeIndex)
            {
                RecurseType(type);
            }
            while (queue.Count > 0 && foundCompressedType == false)
            {
                var type = queue.Dequeue();
                foundCompressedType = type.TypeName.StartsWith("^");
            }

            Assert.False(foundCompressedType);
        }

        public Method GetMethod => new Method
        {
            DeclaringType = TestSerializer.ReflectionHelper.SerializeType(
                typeof(UberSomething<Something<Guid>, Guid, string>)),
            ReflectedType = TestSerializer.ReflectionHelper.SerializeType(
                typeof(Something<Method>)),
            MemberValueType = TestSerializer.ReflectionHelper.SerializeType(
                typeof(IComparable<Something<byte[]>>))
        };

        [Fact]
        public void GivenMemberWhenCompressTypesCalledThenShouldCompressTypes()
        {
            var target = new SerializationState { CompressTypes = true };
            var method = GetMethod;
            target.CompressMemberTypes(method);
            Assert.StartsWith("^", method.DeclaringType.TypeName);
            Assert.StartsWith("^", method.ReflectedType.TypeName);
            Assert.StartsWith("^", method.MemberValueType.TypeName);
        }

        [Fact]
        public void GivenMemberWhenDecompressTypesCalledThenShouldDecompressTypeS()
        {
            var target = new SerializationState { CompressTypes = true };
            var method = GetMethod;
            var refMethod = GetMethod;
            target.CompressMemberTypes(method);
            target.DecompressMemberTypes(method);
            Assert.True(comparer.Equals(method.DeclaringType, refMethod.DeclaringType));
            Assert.True(comparer.Equals(method.ReflectedType, refMethod.ReflectedType));
            Assert.True(comparer.Equals(method.MemberValueType, refMethod.MemberValueType));
        }

        [Fact]
        public void GivenSerializableTypeWithNoFullNameWhenCompressTypeCalledThenShouldResolveFullName()
        {
            var target = new SerializationState { CompressTypes = true };
            var type = TestSerializer.ReflectionHelper.SerializeType(
                typeof(UberSomething<Something<Guid>, Guid, string>));
            type.FullTypeName = null;
            var compressed = target.CompressType(type);
            Assert.NotEqual(default, compressed);
        }

        [Fact]
        public void GivenTypeNotInIndexWhenIndexOfTypeExtensionCalledThenShouldReturnNegative()
        {
            var list = new List<SerializableType>();
            var type = TestSerializer.ReflectionHelper.SerializeType(typeof(int));
            Assert.Equal(-1, list.IndexOfType(type));
        }
    }
}
