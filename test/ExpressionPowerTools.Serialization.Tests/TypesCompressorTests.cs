using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Members;
using ExpressionPowerTools.Serialization.Compression;
using ExpressionPowerTools.Serialization.Signatures;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class TypesCompressorTests
    {
        private readonly ITypesCompressor compressor = new TypesCompressor();
        private readonly List<string> typeIndex = new List<string>();

        public class Simple
        {
            public int Id { get; set; }
        }

        public class Example<T>
            where T : class
        {
            public Example()
            {

            }

            public Example(T property)
            {
                Property = property;
            }

            public T Property { get; set; }

            public TReturn Method<TReturn>(T prop)
                where TReturn : class =>
                prop as TReturn;

            public IComparable<T> Comparer { get; set; }

            public char Value { get; set; }

            public Z Compare<Z>(Example<T> example, Z other) where Z : IComparable<Example<T>>
                => example is Z z ? z : other;

            public int field;
            public Lazy<object> LazyObject;
        }

        public static IEnumerable<object[]> GetMemberMatrix()
        {
            var openExample = typeof(Example<>);

            var builtInMethodNames = new[]
            {
                nameof(GetType),
                nameof(ToString),
                nameof(Equals),
                nameof(GetHashCode)
            };

            static IEnumerable<MemberInfo> GetMembers(Type type) =>
                type.GetMethods().OfType<MemberInfo>()
                .Union(type.GetProperties())
                .Union(type.GetFields())
                .Union(type.GetConstructors())
                .Union(new[] { type });

            static IEnumerable<MemberInfo> CloseMembers(IEnumerable<MemberInfo> members)
            {
                var result = new List<MemberInfo>();

                // close "Method"
                var methodOpen = members
                    .OfType<MethodInfo>()
                    .Single(m => m.Name.StartsWith("Method"));
                result.Add(methodOpen.MakeGenericMethod(new Type[] { typeof(Simple) }));

                // close "Compare"
                var compareOpen = members
                    .OfType<MethodInfo>()
                    .Single(m => m.Name.StartsWith("Compare"));
                result.Add(compareOpen.MakeGenericMethod(new Type[] { typeof(IComparable<Example<Simple>>) }));

                return result;
            }

            var openMembers = GetMembers(openExample);
            var simpleClosedExample = typeof(Example<Simple>);
            var simpleClosedMembers = GetMembers(simpleClosedExample);
            var closedMethods = CloseMembers(simpleClosedMembers);

            var allMembers = openMembers
                .Union(simpleClosedMembers)
                .Union(closedMethods);

            var memberAdapter = new MemberAdapter();

            yield return new object[]
            {
                typeof(string), "T:System.String"
            };

            foreach (var member in allMembers.Where(m => !builtInMethodNames.Contains(m.Name)))
            {               
                yield return new object[]
                {
                    member, memberAdapter.GetKeyForMember(member)
                };
            }
        }

        [Fact]
        public void GivenNullTypeIndexWhenCompressTypesCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => compressor.CompressTypes(null, null));
        }

        [Fact]
        public void GivenNullKeysWhenCompressTypesCalledThenShouldDoNothing()
        {
            compressor.CompressTypes(typeIndex, null);
        }

        [Fact]
        public void GivenNullTypeIndexWhenDecompressTypesCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => compressor.DecompressTypes(null, null));
        }

        [Fact]
        public void GivenNullKeysWhenDecompressTypesCalledThenShouldNotThrow()
        {
            compressor.DecompressTypes(typeIndex, null);
        }

        [Fact]
        public void GivenNullTypeIndexWhenCompressTypeIndexCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => compressor.CompressTypeIndex(null));
        }

        [Fact]
        public void GivenTypesWhenCompressTypeIndexCalledThenShouldCompressTypeKeys()
        {
            var decompressedTypes = new[]
            {
                "T:System.String",
                "T:System.Collections.Generic.IEnumerable{System.String}",
                "T:System.Collections.Generic.IEnumerable{System.Collections.Generic.IEnumerable{System.String}}",
            };

            typeIndex.AddRange(decompressedTypes);

            var expected = new[]
            {
                "T:System.String",
                "T:System.Collections.Generic.IEnumerable{^0}",
                "T:System.Collections.Generic.IEnumerable{^1}",
            };

            compressor.CompressTypeIndex(typeIndex);
            Assert.Equal(expected, typeIndex.ToArray());
        }

        [Fact]
        public void GivenKeysWhenCompressTypesCalledThenShouldCompressTypesInKeys()
        {
            var memberAdapter = new MemberAdapter();
            var matrix = GetMemberMatrix().Select(m => (m[0] as MemberInfo, m[1] as string)).ToArray();

            // verify these can be "made"
            var members = matrix.Select(m => memberAdapter.GetMemberForKey(m.Item2)).ToArray();
            var diff = members.Except(matrix.Select(m => m.Item1));
            Assert.Empty(diff);

            var compressedKeys = new List<string>();
            for (var idx = 0; idx < matrix.Length; idx++)
            {
                compressor.CompressTypes(typeIndex, (matrix[idx].Item2, key => compressedKeys.Add(key)));
            }

            Assert.True(compressedKeys.All(c => c.Contains("^")));
        }

        [Fact]
        public void GivenCompressedTypeIndexWhenDecompressedThenShouldRestoreTypes()
        {
            var expected = new[]
            {
                "T:ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Example`1",
                "T:T",
                "T:System.IComparable{`0}",
                "T:System.Object",
                "T:System.Lazy{System.Object}",
                "T:ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Simple",
                "T:ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Example{ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Simple}",
                "T:System.IComparable{ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Simple}",
                "T:System.IComparable{ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Example{ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Simple}}",
            };

            typeIndex.AddRange(new[]
            {
                "T:ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Example`1",
                "T:T",
                "T:System.IComparable{`0}",
                "T:System.Object",
                "T:System.Lazy{^3}",
                "T:ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Simple",
                "T:ExpressionPowerTools.Serialization.Tests.TypesCompressorTests+Example{^5}",
                "T:System.IComparable{^5}",
                "T:System.IComparable{^6}",
            });

            // should decompress on first de-reference
            compressor.DecompressTypes(typeIndex, null);
            Assert.Equal(expected, typeIndex.ToArray());          
        }

        [Fact]
        public void GivenMembersCompressedThenShouldDecompress()
        {
            var memberAdapter = new MemberAdapter();
            var matrix = GetMemberMatrix().Select(m => (m[0] as MemberInfo, m[1] as string)).ToArray();

            // verify these can be "made"
            var members = matrix.Select(m => memberAdapter.GetMemberForKey(m.Item2)).ToArray();
            var diff = members.Except(matrix.Select(m => m.Item1));
            Assert.Empty(diff);

            var compressedKeys = new List<string>();
            for (var idx = 0; idx < matrix.Length; idx++)
            {
                compressor.CompressTypes(typeIndex, (matrix[idx].Item2, key => compressedKeys.Add(key)));
            }

            compressor.CompressTypeIndex(typeIndex);

            // make sure we compressed these
            Assert.Contains(compressedKeys, k => k.Contains("^"));
            Assert.Contains(typeIndex, k => k.Contains("^"));

            var decompressedKeys = new List<string>();
            foreach (var compressedKey in compressedKeys)
            {
                compressor.DecompressTypes(
                    typeIndex,
                    (compressedKey,
                    decompressedKey => decompressedKeys.Add(decompressedKey)));
            }

            var decompressedMembers = decompressedKeys.Select(k => memberAdapter.GetMemberForKey(k));
            Assert.Empty(members.Except(decompressedMembers));
        }
    }
}
