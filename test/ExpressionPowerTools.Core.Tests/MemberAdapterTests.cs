using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Hosts;
using ExpressionPowerTools.Core.Members;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Core.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class MemberAdapterTests
    {
        private readonly IMemberAdapter target = new MemberAdapter();

        [Fact]
        public void GivenNullMemberWhenGetKeyForMemberCalledThenShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => target.GetKeyForMember(null));
        }

        public interface IThing<T, TComparable, U> : IComparable<IThing<T, TComparable, U>>
            where T : class
            where TComparable : IComparable<T>
            where U : struct
        {
            TComparable Comparer { get; set; }
            U Value { get; set; }

            int Compare<Z>(T thing, Z other)
                where Z : TComparable;
        }

        public class IndexerHost
        {
            private IDictionary<string, int> values =
                new Dictionary<string, int>();

            public int this[string key]
            {
                get => values[key];
                set
                {
                    if (values.ContainsKey(key))
                    {
                        values[key] = value;
                    }
                    else
                    {
                        values.Add(key, value);
                    }
                }
            }
        }

        public class ThingImplementation : IThing<ThingImplementation, IComparable<ThingImplementation>, char>
        {
            public ThingImplementation()
            {
                Comparer = this;
            }

            public IThing<ThingImplementation, IComparable<ThingImplementation>, char> Instance
            {
                get => this;
            }

            public IComparable<ThingImplementation> Comparer { get; set; }
            public char Value { get; set; }

            public int Compare<Z>(ThingImplementation thing, Z other) where Z : IComparable<ThingImplementation>
                => Comparer.CompareTo(other as ThingImplementation);

            public int CompareTo([AllowNull] IThing<ThingImplementation, IComparable<ThingImplementation>, char> other)
            {
                return -1;
            }
        }

        public static IEnumerable<object[]> GetKeyAndMemberMatrix()
        {
            var cacheInfo = typeof(DefaultComparisonRules).GetField("cache", BindingFlags.Instance | BindingFlags.NonPublic);
            var defaultCtor = typeof(DefaultComparisonRules).GetConstructor(new Type[0]);
            var defaultProperty = typeof(DefaultComparisonRules).GetProperty(nameof(DefaultComparisonRules.DefaultConstantRules));
            var checkEquivGeneric = typeof(DefaultComparisonRules).GetMethods().Single(
                m => m.Name == nameof(DefaultComparisonRules.CheckEquivalency)
                && m.IsGenericMethod);
            var checkEquivGenericClosed = checkEquivGeneric.MakeGenericMethod(new Type[] { typeof(ConstantExpression) });
            var checkEquivNonGeneric = typeof(DefaultComparisonRules).GetMethods().Single(
                    m => m.Name == nameof(DefaultComparisonRules.CheckEquivalency)
                && !m.IsGenericMethod);
            var createParameterExpression = typeof(ExpressionExtensions).GetMethod("CreateParameterExpression");
            var createParameterExpressionClosed = createParameterExpression.MakeGenericMethod(new Type[] { typeof(object), typeof(string) });
            var compare = typeof(IThing<,,>).GetMethods(BindingFlags.Public | BindingFlags.Instance).First(m => m.Name == "Compare");
            var compareClosed = typeof(ThingImplementation).GetMethods(BindingFlags.Public | BindingFlags.Instance).First(m => m.Name == "Compare");
            var valueGeneric = typeof(IThing<,,>).GetProperty("Value");
            var queryHost = typeof(QueryHost<,>).GetConstructors().Where(c => c.GetParameters().Length == 2).Single(c => c.GetParameters()[0].ParameterType == typeof(Expression));
            var anon = new { Id = 2 };
            var anonCtor = anon.GetType().GetConstructors()[0];
            var query = IQueryableExtensions.CreateQueryTemplate<IdType>().Select(t => new IdType(t.Id, 2));
            var method = query.AsEnumerableExpression().OfType<MethodCallExpression>()
                .Select(m => m.Method).Where(m => m.Name == nameof(Queryable.Select)).Single();
            var indexer = typeof(IndexerHost).GetProperties().First(p => p.GetIndexParameters().Length > 0);

            var matrix = new Dictionary<string, MemberInfo>
            {
                { "P:ExpressionPowerTools.Core.Tests.MemberAdapterTests+IndexerHost.Item(System.String)", indexer },
                { "T:System.String", typeof(string) },
                { "T:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules", typeof(DefaultComparisonRules) },
                { "F:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cache", cacheInfo },
                { "M:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.#ctor", defaultCtor },
                { "P:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantRules", defaultProperty },
                { "M:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.CheckEquivalency``1(``0,System.Linq.Expressions.Expression)", checkEquivGeneric },
                { "M:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.CheckEquivalency(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)", checkEquivNonGeneric },
                { "T:System.Linq.IQueryable`1", typeof(IQueryable<>) },
                { "T:System.Int32[]", typeof(int[]) },
                { "M:ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.CheckEquivalency``1(System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.Expression)", checkEquivGenericClosed },
                { "T:ExpressionPowerTools.Core.Dependencies.ServiceHost", typeof(ServiceHost) },
                { "M:ExpressionPowerTools.Core.Dependencies.ServiceHost.#cctor", typeof(ServiceHost).GetConstructors(BindingFlags.Static | BindingFlags.NonPublic).First() },
                { "M:ExpressionPowerTools.Core.Extensions.ExpressionExtensions.CreateParameterExpression``2(System.Linq.Expressions.Expression{System.Func{``0,``1}})", createParameterExpression },
                { "M:ExpressionPowerTools.Core.Extensions.ExpressionExtensions.CreateParameterExpression``2(System.Linq.Expressions.Expression{System.Func{System.Object,System.String}})", createParameterExpressionClosed },
                { "M:ExpressionPowerTools.Core.Dependencies.ServiceHost.GetService``1(System.Object[])", typeof(ServiceHost).GetMethod("GetService", BindingFlags.Static | BindingFlags.Public) },
                { "M:ExpressionPowerTools.Core.Members.MemberAdapter.TryGetMemberInfo(System.String,System.Reflection.MemberInfo@)", typeof(MemberAdapter).GetMethod("TryGetMemberInfo", BindingFlags.NonPublic | BindingFlags.Instance) },
                { "M:ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing`3.Compare``1(`0,``0)", compare },
                { "M:ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation.Compare``1(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation,``0)", compareClosed },
                { "T:ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing`3", typeof(IThing<,,>) },
                { "T:ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation", typeof(ThingImplementation) },
                { "T:ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation,System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation},System.Char}", typeof( IThing<ThingImplementation, IComparable<ThingImplementation>, char>) },
                { "P:ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing`3.Value", valueGeneric },
                { "M:ExpressionPowerTools.Core.Hosts.QueryHost`2.#ctor(System.Linq.Expressions.Expression,`1)",  queryHost },
                { "T:<>f__AnonymousType1{Id=System.Int32,Name=System.String}", new { Id = 1, Name = nameof(MemberAdapterTests) }.GetType() },
                { "M:System.Linq.Queryable.Select``2(System.Linq.IQueryable{ExpressionPowerTools.Core.Tests.TestHelpers.IdType},System.Linq.Expressions.Expression{System.Func{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}})", method }
            };

            foreach (var test in matrix)
            {
                yield return new object[]
                {
                    test.Key, test.Value
                };
            }
        }

        public class MethodEqualityComparer : IEqualityComparer<MethodInfo>
        {
            public bool Equals([AllowNull] MethodInfo x, [AllowNull] MethodInfo y)
            {
                if (x == null)
                {
                    return y == null;
                }

                return x.ToString() == y.ToString();
            }

            public int GetHashCode([DisallowNull] MethodInfo obj)
            {
                return obj.ToString().GetHashCode();
            }
        }

        public static MemberInfo[] AlmostAllMembersinCore()
        {
            var types = typeof(DefaultComparisonRules).Assembly.GetExportedTypes()
                .Where(t => t != typeof(QueryHost<,>));
            var methodComparer = new MethodEqualityComparer();
            var members = types.OfType<MemberInfo>()
                .Union(types.SelectMany(t => t.GetProperties()))
                .Union(types.SelectMany(t => t.GetFields()))
                .Union(types.SelectMany(t => t.GetMethods()
                .Where(m => !m.Name.StartsWith("get_")
                 && !m.Name.StartsWith("set_")))
                .Distinct(methodComparer));
            var result = members
                .Where(m => m.DeclaringType == null ||
                    (m.DeclaringType != null && m.DeclaringType.ToString().StartsWith("System")))
                .ToArray();
            return result;
        }

        [Fact]
        public void KeysAreUnique()
        {
            var list = AlmostAllMembersinCore().Select(m => target.GetKeyForMember(m))
                .OrderBy(i => i).ToList();
            var hash = new HashSet<string>(list);
            Assert.Equal(list.Count, hash.Count());
        }

        public static IEnumerable<object[]> AlmostAllMembersInCoreMatrix()
        {
            var localAdapter = new MemberAdapter();
            foreach (var member in AlmostAllMembersinCore())
            {
                var key = localAdapter.GetKeyForMember(member);
                yield return new object[] { member, key };
            }
        }

        [Theory]
        [MemberData(nameof(AlmostAllMembersInCoreMatrix))]
        public void CanRecreateAllMembers(MemberInfo expected, string key)
        {
            // just trying on core types
            if (key.Contains(":System"))
            {
                return;
            }

            var actual = target.GetMemberForKey(key);
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Theory]
        [MemberData(nameof(GetKeyAndMemberMatrix))]
        public void GivenMemberWhenGetKeyForMemberCalledThenShouldReturnKey(string expected, MemberInfo member)
        {
            var actual = target.GetKeyForMember(member);
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Theory]
        [MemberData(nameof(GetKeyAndMemberMatrix))]
        public void GivenKeyWhenGetMemberForKeyCalledThenShouldReturnKey(string key, MemberInfo expected)
        {
            var actual = target.GetMemberForKey(key);
            if (expected is Type type && type.IsAnonymousType())
            {
                Assert.Equal(typeof(ExpandoObject), actual);
            }
            else
            {
                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t\t\n")]
        public void GivenNullOrEmptyStringWhenCalledThenShouldThrowArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(
                () => target.GetMemberForKey(key));
        }

        [Fact]
        public void GetMemberForKeyTypedReturnsCorrectResult()
        {
            var (key, expected) = GetKeyAndMemberMatrix().Where(
                k => ((string)k[0]).StartsWith("F"))
                .Select(k => ((string)k[0], (FieldInfo)k[1]))
                .First();
            var actual = target.GetMemberForKey<FieldInfo>(key);
            Assert.Same(expected, actual);
        }
    }
}
