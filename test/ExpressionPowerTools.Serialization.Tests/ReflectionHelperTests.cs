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

        [Fact]
        public void GivenMethodWhenGetMethodFromCacheCalledThenShouldReturnMethodInfo()
        {
            // might as well test several cases
            foreach (var methodInfo in typeof(Expression).GetMethods().Union(typeof(Expression).GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                .Where(m => m.DeclaringType == typeof(Expression)))
            {
                var method = new Method(methodInfo);
                Assert.Equal(methodInfo, target.GetMethodFromCache(method));
            }
        }

        [Theory]
        [InlineData("foo", "bar")]
        [InlineData("System.Int32", "fake")]
        public void GivenBadMethodWhenGetMethodFromCacheCalledThenShouldReturnNull(
            string typeName, string methodName)
        {
            var method = new Method
            {
                Name = methodName,
                DeclaringType = typeName
            };

            var methodInfo = target.GetMethodFromCache(method);
            Assert.Null(methodInfo);
        }
    }
}
