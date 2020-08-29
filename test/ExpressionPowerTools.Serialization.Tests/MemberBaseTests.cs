using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class MemberBaseTests
    {
        public T First<T, TList>(TList list)
            where T : new()
            where TList : IList<T>
        {
            return list.FirstOrDefault();
        }

        [Fact]
        public void GivenMethodInfoWhenMethodCreatedThenShouldSetProperties()
        {
            var methodInfo = GetType().GetMethod("First");
            var target = new Method(methodInfo);
            Assert.Equal(methodInfo.IsStatic, target.IsStatic);
            Assert.Equal(methodInfo.Name, target.Name);
            Assert.Equal(methodInfo.DeclaringType,
                ReflectionHelper.Instance.DeserializeType(target.DeclaringType));
            Assert.Equal(methodInfo.ReturnType.Name, target.MemberValueType.TypeParamName);
            Assert.Equal(methodInfo.GetParameters().Select(p => p.Name),
                target.Parameters.Select(p => p.Key));
            Assert.Equal(methodInfo.GetParameters()
                .Where(p => p.ParameterType.FullName != null)
                .Select(p => p.ParameterType),
                target.Parameters.Select(p => ReflectionHelper.Instance.DeserializeType(p.Value)).Where(p => p != null));
        }

        [Fact]
        public void GivenMethodInfoWhenMethodCreatedThenShouldCreateUniqueKey()
        {
            var list = new List<string>();
            foreach (var methodInfo in typeof(MemberBaseTests).Assembly.GetTypes().SelectMany(t => t.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)))
            {
                var key = new Method(methodInfo).CalculateKey();
                list.Add(key);
            }

            var hashSet = new HashSet<string>(list);
            Assert.Equal(list.Count, hashSet.Count);
        }

        [Fact]
        public void GivenMethodInfoWhenMethodCreatedThenShouldCacheKey()
        {
            var methodInfo = GetType().GetMethods().First();
            var method = new Method(methodInfo);
            Assert.Equal(method.GetKey(), method.CalculateKey());
            method.Name = nameof(methodInfo);
            Assert.NotEqual(method.GetKey(), method.CalculateKey());
        }
    }
}
