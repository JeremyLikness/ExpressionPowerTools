using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Serialization.Serializers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ReflectionHelperTests
    {
        private readonly ReflectionHelper target = new ReflectionHelper();

        public class Test<T>
        {
            public T Prop { get; set; }
        }

        public class Tester<T, TTest>
            where TTest : Test<T>
        {
            public Tester()
            { }

            public Tester(T init)
            { }

            public Tester(TTest init)
            { }

            public T ProcessType(TTest test) => default;

            public static void ProcessType(string str) { }

            public static string Id { get; set; }

            public int field;

            public static string Field;

            public TTest Prop { get; set; }
        }

        public static IEnumerable<object[]> GetClosedAndGenericMembers()
        {
            var closedType = typeof(Tester<int, Test<int>>);
            var genericType = typeof(Tester<,>);
            var allPublic = BindingFlags.Public |
                BindingFlags.DeclaredOnly |
                BindingFlags.Instance | BindingFlags.Static;

            yield return new object[]
            {
                closedType,
                genericType
            };

            var ctors = closedType.GetConstructors().ToArray();
            var genericCtors = genericType.GetConstructors().ToArray();

            for (var idx = 0; idx < ctors.Length; idx += 1)
            {
                yield return new object[]
                {
                    ctors[idx],
                    genericCtors[idx]
                };
            }

            var props = closedType.GetProperties(allPublic).ToArray();
            var genericProps = genericType.GetProperties(allPublic).ToArray();

            for (var idx = 0; idx < props.Length; idx += 1)
            {
                yield return new object[]
                {
                    props[idx],
                    genericProps[idx]
                };
            }

            var skipProps = props.Select(p => p.GetGetMethod())
                .Union(props.Select(p => p.GetSetMethod()));
            var methods = closedType.GetMethods(allPublic).Except(skipProps).ToArray();
            var skipGenerics = genericProps.Select(p => p.GetGetMethod())
                .Union(genericProps.Select(p => p.GetSetMethod()));
            var genericMethods = genericType.GetMethods(allPublic).Except(skipGenerics).ToArray();

            for (var idx = 0; idx < methods.Length; idx += 1)
            {
                yield return new object[]
                {
                    methods[idx],
                    genericMethods[idx]
                };
            }

            var fields = closedType.GetFields(allPublic).ToArray();
            var genericFields = genericType.GetFields(allPublic).ToArray();

            for (var idx = 0; idx < fields.Length; idx += 1)
            {
                yield return new object[]
                {
                    fields[idx],
                    genericFields[idx]
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetClosedAndGenericMembers))]
        public void GivenNonGenericMemberWhenGetGenericVersionCalledThenFindsGenericVersion(
            MemberInfo closed, MemberInfo generic)
        {
            var genericInfo = target.FindGenericVersion(closed);
            Assert.NotNull(genericInfo);
            Assert.Same(generic, genericInfo);
        }
        
        public class TestClass<T, T1>
        {
            static TestClass()
            {
            }

            public TestClass()
            {
            }

            public TestClass(int prop)
            {
                Prop = prop;
            }

            public TestClass(T thing)
            {
                Thing = thing;
            }

            public TestClass(T thing, T1 _)
                : this(thing)
            {                
            }

            public T Thing { get; set; }
            public IComparable<T1> Comparer { get; set; }
            public int Prop { get; set; }
        }

        public static IEnumerable<object[]> GetCtorMatrix()
        {
            var genericType = typeof(TestClass<,>);
            var closed = typeof(TestClass<int, string>);
            var pub = BindingFlags.Public | BindingFlags.Instance;
            var stat = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            var ctors = genericType.GetConstructors(pub)
                .Union(genericType.GetConstructors(stat))
                .Union(closed.GetConstructors(pub))
                .Union(closed.GetConstructors(stat)).Distinct();

            foreach (var ctor in ctors)
            {
                yield return new object[] { ctor };
            }            
        }

        [Fact]
        public void GivenTypeNotFoundWhenFindGenericVersionCalledThenShouldReturnNull()
        {
            var check = target.FindGenericVersion(typeof(int), null);
            Assert.Null(check);
        }

        [Fact]
        public void GivenGenericMemberNotFoundWhenGetGenericVersionCalledThenShouldReturnNull()
        {
            var member = typeof(string).GetMethods().First();
            var type = typeof(IQueryable<>);
            var check = target.FindGenericVersion(member, type);
            Assert.Null(check);
        }
    }
}
