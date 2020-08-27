using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ReflectionHelperTests
    {
        private readonly ReflectionHelper target = new ReflectionHelper();

        [Fact]
        public void GivenTypeFullNameWhenGetTypeFromCacheCalledThenShouldReturnType()
        {
            // might as well test everything
            foreach(var type in Assembly.GetExecutingAssembly().GetTypes().Distinct())
            {
                Assert.Equal(type.FullName, target.GetTypeFromCache(type.FullName).FullName);
            }
        }

        public class Test<T>
        {
            public T Prop { get; set; }
        }

        public class Tester<T, TTest>
            where TTest : Test<T>
        {
            public TTest Prop { get; set; }
        }

        [Fact]
        public void GivenOrdinaryTypeWhenSerializeTypeCalledThenShouldCreateTypeWithName()
        {
            var serialized = target.SerializeType(typeof(string));
            Assert.Equal(typeof(string).FullName, serialized.TypeName);
            Assert.Null(serialized.GenericTypeArguments);
        }

        [Fact]
        public void GivenGenericTypeDefinitionWhenSerializeTypeCalledThenShouldCreateTypeWithName()
        {
            var serialized = target.SerializeType(typeof(Test<>));
            Assert.Equal(typeof(Test<>).FullName, serialized.TypeName);
            Assert.Null(serialized.GenericTypeArguments);
        }

        [Fact]
        public void GivenGenericTypeWhenSerializeTypeCalledThenShouldCreateTypeWithDefinitionNameAndTypeArguments()
        {
            var serialized = target.SerializeType(typeof(Tester<int, Test<int>>));
            Assert.Equal(typeof(Tester<,>).FullName, serialized.TypeName);
            Assert.Equal(2, serialized.GenericTypeArguments.Length);
            Assert.Equal(typeof(int).FullName, serialized.GenericTypeArguments[0].TypeName);
            Assert.Equal(typeof(Test<>).FullName, serialized.GenericTypeArguments[1].TypeName);
            Assert.Equal(typeof(int).FullName, serialized.GenericTypeArguments[1].GenericTypeArguments[0].TypeName);
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(Test<>))]
        [InlineData(typeof(Tester<int,Test<int>>))]
        public void GivenTypeWhenSerializeTypeCalledThenShouldDeserialize(
            Type type)
        {
            var serialized = target.SerializeType(type);
            var deserialized = target.DeserializeType(serialized);
            Assert.Equal(type, deserialized);
        }

        [Theory]
        [InlineData(typeof(string), "System.String")]
        [InlineData(typeof(Test<>), "ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Test`1")]
        [InlineData(typeof(Tester<int, Test<int>>), "ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester`2" +
            "[System.Int32, ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Test`1[System.Int32]]")]
        public void GivenTypeWhenGetFullTypeNameCalledOnSerializedTypeThenShouldReturnTheType(
            Type type, string typeName)
        {
            var serialized = target.SerializeType(type);
            var computedTypeName = target.GetFullTypeName(serialized);
            Assert.Equal(typeName, computedTypeName);
        }

        public static IEnumerable<object[]> GetMethodInfos()
        {
            foreach (var methodInfo in typeof(Expression).GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                .Where(m => m.DeclaringType == typeof(Expression)))
            {
                yield return new object[]
                {
                    methodInfo
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetMethodInfos))]
        public void GivenMethodWhenGetMethodFromCacheCalledThenShouldReturnMethodInfo(MethodInfo item)
        {
            // might as well test several cases
            var method = new Method(item);
            Assert.Equal(item, target.GetMemberFromCache<MethodInfo, Method>(method));            
        }

        [Fact]
        public void GivenBadMethodWhenGetMethodFromCacheCalledThenShouldReturnNull()
        {
            var method = new Method
            {
                Name = "fake",
                DeclaringType =
                    ReflectionHelper.Instance.SerializeType(typeof(int))
            };

            var methodInfo = target.GetMemberFromCache<MethodInfo, Method>(method);
            Assert.Null(methodInfo);
        }        
    }
}
