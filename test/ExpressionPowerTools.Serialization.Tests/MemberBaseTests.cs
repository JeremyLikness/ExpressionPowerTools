using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class TestHost<T>
    {
        public T GenericProperty { get; set; }
    }

    public class MemberBaseTests
    {
        public T First<T, TList>(TList list)
            where T : new()
            where TList : IList<T>
        {
            return list.FirstOrDefault();
        }

        public int Integer { get; set; }

        public static long Long { get; set; }

        public int SetOnly { set { } }

        public static int StaticSetOnly { set { } }

        public string stringField;

        public static int staticIntField;

        [Fact]
        public void GivenMethodInfoWhenMethodCreatedThenShouldSetProperties()
        {
            var methodInfo = GetType().GetMethod("First");
            var target = new Method(methodInfo);
            Assert.Equal(methodInfo.IsStatic, target.IsStatic);
            Assert.Equal(methodInfo.Name, target.Name);
            Assert.Equal(methodInfo.DeclaringType,
                TestSerializer.ReflectionHelper.DeserializeType(target.DeclaringType));
            Assert.Equal(methodInfo.ReturnType.Name, target.MemberValueType.TypeParamName);
            Assert.Equal(methodInfo.GetParameters().Select(p => p.Name),
                target.Parameters.Select(p => p.Key));
            Assert.Equal(methodInfo.GetParameters()
                .Where(p => p.ParameterType.FullName != null)
                .Select(p => p.ParameterType),
                target.Parameters.Select(p => TestSerializer.ReflectionHelper.DeserializeType(p.Value)).Where(p => p != null));
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

        public static IEnumerable<object[]> GetPropertyMatrix()
        {
            yield return new object[]
            {
                typeof(MemberBaseTests).GetProperty(nameof(Integer))
            };

            yield return new object[]
            {
                typeof(MemberBaseTests).GetProperty(nameof(SetOnly))
            };

            yield return new object[]
            {
                typeof(MemberBaseTests).GetProperty(nameof(Long),
                BindingFlags.Public | BindingFlags.Static)
            };

            yield return new object[]
            {
                typeof(MemberBaseTests).GetProperty(nameof(StaticSetOnly),
                BindingFlags.Public | BindingFlags.Static)
            };

            yield return new object[]
            {
                typeof(TestHost<int>).GetProperty(nameof(TestHost<int>.GenericProperty))
            };
        }

        [Theory]
        [MemberData(nameof(GetPropertyMatrix))]
        public void GivenPropertyInfoWhenPropertyCreatedThenShouldSetProperties(PropertyInfo property)
        {
            var target = new Property(property);
            Assert.Equal(property.CanRead ?
                property.GetMethod.IsStatic :
                property.SetMethod.IsStatic, target.IsStatic);
            Assert.Equal(property.Name, target.Name);
            Assert.Equal(property.DeclaringType,
                TestSerializer.ReflectionHelper.DeserializeType(target.DeclaringType));
            Assert.Equal(property.PropertyType,
                TestSerializer.ReflectionHelper.DeserializeType(target.MemberValueType));
            Assert.Equal(MemberTypes.Property, (MemberTypes)target.MemberType);
        }

        [Fact]
        public void GivenPropertyInfoWhenPropertyCreatedThenShouldCreateUniqueKey()
        {
            var list = new List<string>();
            foreach(object[] prop in GetPropertyMatrix())
            {
                list.Add(new Property(prop[0] as PropertyInfo).GetKey());
            }

            var hashSet = new HashSet<string>(list);
            Assert.Equal(list.Count, hashSet.Count);
        }

        [Fact]
        public void GivenPropertyInfoWhenPropertyCreatedThenShouldCacheKey()
        {
            var propertyInfo = (GetPropertyMatrix().First())[0] as PropertyInfo;
            var property = new Property(propertyInfo);
            Assert.Equal(property.GetKey(), property.CalculateKey());
            property.Name = nameof(propertyInfo);
            Assert.NotEqual(property.GetKey(), property.CalculateKey());
        }

        public static IEnumerable<object[]> GetFieldMatrix()
        {
            yield return new object[]
            {
                typeof(MemberBaseTests).GetField(nameof(stringField))
            };

            yield return new object[]
            {
                typeof(MemberBaseTests).GetField(nameof(staticIntField),
                BindingFlags.Public | BindingFlags.Static)
            };         
        }

        [Theory]
        [MemberData(nameof(GetFieldMatrix))]
        public void GivenFieldInfoWhenFieldCreatedThenShouldSetProperties(FieldInfo field)
        {
            var target = new Field(field);
            Assert.Equal(field.IsStatic, target.IsStatic);
            Assert.Equal(field.Name, target.Name);
            Assert.Equal(field.DeclaringType,
                TestSerializer.ReflectionHelper.DeserializeType(target.DeclaringType));
            Assert.Equal(field.FieldType,
                TestSerializer.ReflectionHelper.DeserializeType(target.MemberValueType));
            Assert.Equal(MemberTypes.Field, (MemberTypes)target.MemberType);
        }

        [Fact]
        public void GivenFieldInfoWhenFieldCreatedThenShouldCreateUniqueKey()
        {
            var list = new List<string>();
            foreach (object[] field in GetFieldMatrix())
            {
                list.Add(new Field(field[0] as FieldInfo).GetKey());
            }

            var hashSet = new HashSet<string>(list);
            Assert.Equal(list.Count, hashSet.Count);
        }

        [Fact]
        public void GivenFieldInfoWhenPropertyCreatedThenShouldCacheKey()
        {
            var fieldInfo = (GetFieldMatrix().First())[0] as FieldInfo;
            var field = new Field(fieldInfo);
            Assert.Equal(field.GetKey(), field.CalculateKey());
            field.Name = nameof(fieldInfo);
            Assert.NotEqual(field.GetKey(), field.CalculateKey());
        }
    }
}
