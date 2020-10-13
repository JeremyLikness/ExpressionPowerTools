using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class QueryExprSerializerTests
    {
        private readonly Lazy<IRulesConfiguration> rulesConfig =
            ServiceHost.GetLazyService<IRulesConfiguration>();

        public QueryExprSerializerTests()
        {
            QueryExprSerializer.ConfigureDefaults(
                config => config.CompressExpressionTree(false));
        }

        private void Reset()
        {
            ServiceHost.GetService<IMemberAdapter>().Reset();
            QueryExprSerializer.ConfigureRules(
                rules => rules.RuleForType<QueryExprSerializerTests>()
                    .RuleForType<TestableThing>()
                    .RuleForType<BinarySerializerTests>()
                    .RuleForType(typeof(KeyValuePair))
                    .RuleForType(typeof(Tuple)));
        }

        public static TPropertyType Property<TPropertyType>(object entity, string name) =>
            entity == null ? default :
            (TPropertyType)entity.GetType().GetProperty(name).GetValue(entity);

        [Fact]
        public void GivenSerializeWhenCalledWithNullExpressionThenShouldThrowArgumentNull()
        {
            Expression expression = null;
            Assert.Throws<ArgumentNullException>(() =>
                QueryExprSerializer.Serialize(expression));
        }

        [Fact]
        public void GivenSerializeWhenCalledWithNullQueryThenShouldThrowArgumentNull()
        {
            IQueryable query = null;
            Assert.Throws<ArgumentNullException>(() =>
                QueryExprSerializer.Serialize(query));
        }

        public static IEnumerable<object[]> GetSerializers()
        {
            foreach (var type in typeof(IBaseSerializer).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface &&
                    typeof(IBaseSerializer).IsAssignableFrom(t)))
            {
                yield return new object[]
                {
                    Activator
                    .CreateInstance(
                        type,
                        new[] { (object)TestSerializer.ExpressionSerializer })
                    as IBaseSerializer
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetSerializers))]
        public void GivenSerializerWhenSerializeCalledWithNullThenShouldReturnNull(IBaseSerializer serializer)
        {
            Assert.Null(serializer.Serialize(null, null));
        }

        public enum Queries
        {
            Skip1Take1,
            OrderByCreatedThenByDescendingId,
            WhereIdContainsAA,
            CustomGenericProperty,
            IdProjection,
            IdAnonymousType,
            IdOnly,
            Filtered,
            MemberInit,
            SelectMany
        }

        public static IEnumerable<object[]> GetQueryMatrix()
        {
            yield return new object[]
            {
                TestableThing.MakeQuery().Select(t => new { t.Id }),
                Queries.IdAnonymousType
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().SelectMany(t => t.ChildThings),
                Queries.SelectMany
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Where(t => t.ChildThings.Count > 2).Select(t => new TestableThing(t.Id)
                {
                    ChildThings =
                    {
                        new TestableThing { Id = Guid.NewGuid().ToString() },
                        new TestableThing { Id = t.ChildThings[0].Id }
                    }
                }),
                Queries.MemberInit
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Skip(1).Take(1),
                Queries.Skip1Take1
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().OrderBy(t => t.Created).ThenByDescending(t => t.Id),
                Queries.OrderByCreatedThenByDescendingId
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Where(t => t.Id.Contains("aa")),
                Queries.WhereIdContainsAA
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Where(t => Property<int>(t, nameof(TestableThing.Value)) > 500),
                Queries.CustomGenericProperty
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Select(t => t.Id),
                Queries.IdProjection
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().OrderBy(t => t.Id).Select(t => new TestableThing(t.Id)),
                Queries.IdOnly
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Where(t => t.Id.Contains("aa") && (t.IsActive || t.Value < int.MaxValue/2)),
                Queries.Filtered
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Where(t => t.Id.Contains("aa")).Select(t => new TestableThing { Id = t.Id }),
                Queries.MemberInit
            };

            yield return new object[]
            {
                TestableThing.MakeQuery().Select(t => new TestableThing(t.Id) { Data = { Data = t.ChildThings.Count.ToString() } }),
                Queries.MemberInit
            };
        }

        public static IEnumerable<object[]> GetTypedQueryMatrix()
        {
            foreach (object[] pair in GetQueryMatrix())
            {
                var queryType = (Queries)pair[1];
                if (queryType == Queries.IdProjection ||
                    queryType == Queries.IdAnonymousType)
                {
                    continue;
                }

                yield return pair;
            }
        }

        public bool ValidateQuery(IList<TestableThing> list, Queries type)
        {
            switch (type)
            {
                case Queries.Skip1Take1:
                    return list.Count() == 1;
                case Queries.OrderByCreatedThenByDescendingId:
                    var ordered = list.OrderBy(t => t.Created).ThenByDescending(t => t.Id)
                        .ToList();
                    for (var idx = 0; idx < list.Count; idx += 1)
                    {
                        if (ordered[idx].Id != list[idx].Id)
                        {
                            return false;
                        }
                    }
                    return true;
                case Queries.WhereIdContainsAA:
                    return list.All(t => t.Id.Contains("aa"));
                case Queries.IdOnly:
                    return list.All(t => t.IsActive && t.Value == int.MinValue);
                case Queries.Filtered:
                    return list.All(t => t.Id.Contains("aa") && (t.IsActive || t.Value < int.MaxValue / 2));
            }
            return false;
        }

        [Fact]
        public void DeserializeWithConfigurationUsesConfiguration()
        {
            var expr = 42.AsConstantExpression();
            var serialized = QueryExprSerializer.Serialize(expr);
            var deserialized = QueryExprSerializer.Deserialize(
                serialized,
                null,
                config => config.CompressExpressionTree(false),
                null);
            Assert.NotNull(deserialized);
        }

        [Theory]
        [MemberData(nameof(GetQueryMatrix))]
        public void GivenQueryWhenSerializeCalledThenShouldDeserialize(
            IQueryable query,
            Queries type)
        {
            var json = QueryExprSerializer.Serialize(query);

            // make sure we're not just pulling from the cache
            Reset();

            IQueryable queryHost = TestableThing.MakeQuery(10);

            var newQuery = QueryExprSerializer.DeserializeQuery(queryHost, json);

            // can't do equivalency check for anonymous types
            if (!query.AsEnumerableExpression().OfType<NewExpression>()
                .Any(t => t.Type.IsAnonymousType()))
            {
                Assert.True(query.IsEquivalentTo(newQuery));
            }

            if (newQuery is IQueryable<ExpandoObject> anonymousQuery)
            {
                var list = anonymousQuery.ToList();
                Assert.NotNull(list);
            }
            else if (newQuery is IQueryable<TestableThing> thingQuery)
            {
                var list = thingQuery.ToList();
                ValidateQuery(list, type);
            }
        }

        [Theory]
        [MemberData(nameof(GetTypedQueryMatrix))]
        public void GivenQueryWhenSerializeCalledThenShouldDeserializeForType(
            IQueryable<TestableThing> query,
            Queries type)
        {
            var json = QueryExprSerializer.Serialize(query);

            Reset();

            var queryHost = TestableThing.MakeQuery(100);
            var newQuery = QueryExprSerializer.DeserializeQuery<TestableThing>(json, queryHost);
            Assert.True(query.IsEquivalentTo(newQuery));
            ValidateQuery(newQuery.ToList(), type);
        }

        [Fact]
        public void MultipleSelectManyProjectionWorks()
        {
            Reset();

            var dataQuery = TestableThing.MakeQuery(5);

            IQueryable<Tuple<string, string, string>> SelectMany(IQueryable<TestableThing> query) =>
             query.SelectMany(t => t.ChildThings, (t, c) => new
                {
                    parentId = t.Id,
                    childId = c.Id,
                    children = c.ChildThings
                }).SelectMany(tc => tc.children, (tc, tcc) => new
                {
                    tc.parentId,
                    tc.childId,
                    grandChildId = tcc.Id
                }).Select( t => Tuple.Create(t.parentId, t.childId, t.grandChildId));

            var query = SelectMany(IQueryableExtensions.CreateQueryTemplate<TestableThing>());

            var json = QueryExprSerializer.Serialize(query);

            // make sure we're not just pulling from the cache
            Reset();

            var newQuery = QueryExprSerializer.DeserializeQuery<Tuple<string, string, string>>(json, dataQuery);

            var expected = SelectMany(dataQuery).ToList();
            var actual = newQuery.ToList();

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GroupByWorks()
        {
            Reset();

            var dataQuery = TestableThing.MakeQuery(10);

            static IQueryable<KeyValuePair<int,int>> GroupBy(IQueryable<TestableThing> query)
                => query
                .GroupBy(
                t => t.Value,
                t => t.ChildThings,
                (t, tc) => KeyValuePair.Create(t, tc.Count()));

            var query = GroupBy(IQueryableExtensions.CreateQueryTemplate<TestableThing>());

            var json = QueryExprSerializer.Serialize(query);

            // make sure we're not just pulling from the cache
            Reset();

            var expected = GroupBy(dataQuery).ToList();

            var newQuery = QueryExprSerializer.DeserializeQuery(dataQuery, json);
            var actual = AsTypedQueryable(newQuery, expected).ToList();
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Hack to close generic for anonymous type.
        /// </summary>
        /// <typeparam name="T">The anonymous type.</typeparam>
        /// <param name="query">The query to cast.</param>
        /// <param name="_">The template to extract the anonymous type from.</param>
        /// <returns></returns>
        private IQueryable<T> AsTypedQueryable<T>(IQueryable query, IList<T> _)
            => query as IQueryable<T>;

        [Fact]
        public void StateCapturesParameters()
        {
            SerializationState state = null;
            var query = TestableThing.MakeQuery(10)
                .Select(t => new { t.Id, t.IsActive })
                .OrderBy(anonT => anonT.Id);
            var json = QueryExprSerializer.Serialize(query);
            var newQuery = QueryExprSerializer.DeserializeQuery(
                TestableThing.MakeQuery(),
                json,
                stateCallback: s => state = s);
            var parms = state.GetParameters();
            Assert.NotNull(parms);
            Assert.True(parms.Length > 0);
        }

        [Fact]
        public void StateCapturesExpressionTree()
        {
            SerializationState state = null;
            var query = TestableThing.MakeQuery(10)
                .Select(t => new { t.Id, t.IsActive })
                .OrderBy(anonT => anonT.Id);
            var json = QueryExprSerializer.Serialize(query);
            var newQuery = QueryExprSerializer.DeserializeQuery(
                TestableThing.MakeQuery(),
                json,
                stateCallback: s => state = s);
            var tree = state.GetExpressionTree();
            Assert.NotEmpty(tree);
        }

        public static IEnumerable<object[]> GetConstantExpressions =
            ConstantSerializerTests.GetConstantExpressions();

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void GivenExpressionWhenSerializedThenShouldDeserialize(ConstantExpression constant)
        {
            var json = QueryExprSerializer.Serialize(constant);

            Reset();

            var target = QueryExprSerializer.Deserialize<ConstantExpression>(json);

            Assert.True(constant.IsEquivalentTo(target));
        }

        [Fact]
        public void GivenAnArrayWithExpressionsWhenSerializedThenShouldDeserialize()
        {
            var array = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2),
                Expression.Constant(3));
            var json = QueryExprSerializer.Serialize(array);

            Reset();

            var target = QueryExprSerializer.Deserialize<NewArrayExpression>(json);
            Assert.NotNull(target);
            Assert.Equal(typeof(int[]), target.Type);
            Assert.Equal(
                array.Expressions.OfType<ConstantExpression>().Select(c => c.Value),
                target.Expressions.OfType<ConstantExpression>().Select(c => c.Value));
            Assert.True(array.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetParameterExpressions() =>
            ParameterSerializerTests.GetParameterExpressions();

        [Theory]
        [MemberData(nameof(GetParameterExpressions))]
        public void GivenParameterExpressionWhenSerializedThenShouldDeserialize(ParameterExpression parameter)
        {
            var json = QueryExprSerializer.Serialize(parameter);

            Reset();

            var target = QueryExprSerializer.Deserialize<ParameterExpression>(json);
            Assert.Equal(parameter.Type, target.Type);
            Assert.Equal(parameter.Name, target.Name);
        }

        public static IEnumerable<object[]> GetUnaryExpressions() =>
            UnarySerializerTests.GetUnaryExpressions();

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void GivenUnaryExpressionWhenSerializedThenShouldDeserialize(UnaryExpression unary)
        {
            var json = QueryExprSerializer.Serialize(unary);

            Reset();

            var target = QueryExprSerializer.Deserialize<UnaryExpression>(json);
            Assert.Equal(unary.Type, target.Type);
            Assert.Equal(unary.Operand?.NodeType, target.Operand?.NodeType);

            if (unary.Method != null)
            {
                Assert.Equal(unary.Method, target.Method);
            }

            Assert.True(unary.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetLambdaExpressions() =>
            LambdaSerializerTests.GetLambdaExpressions();

        [Theory]
        [MemberData(nameof(GetLambdaExpressions))]
        public void GivenLambdaExpressionWhenSerializedThenShouldDeserialize(LambdaExpression lambda)
        {
            var json = QueryExprSerializer.Serialize(lambda);

            Reset();

            var target = QueryExprSerializer.Deserialize<LambdaExpression>(json);
            Assert.True(lambda.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetInvocationExpressions() =>
            InvocationSerializerTests.GetInvocationExpressionMatrix();

        [Theory]
        [MemberData(nameof(GetInvocationExpressions))]
        public void GivenInvocationExpressionWhenSerializedThenShouldDeserialize(InvocationExpression invocation)
        {
            var json = QueryExprSerializer.Serialize(invocation);

            Reset();

            var target = QueryExprSerializer.Deserialize<InvocationExpression>(json);
            Assert.Equal(invocation.Type, target.Type);
            Assert.True(invocation.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetMethodCallExpressions() =>
            MethodSerializerTests.GetMethodCallMatrix();

        [Theory]
        [MemberData(nameof(GetMethodCallExpressions))]
        public void GivenMethodCallExpressionWhenSerializedThenShouldDeserialize(
            MethodCallExpression method)
        {
            var json = QueryExprSerializer.Serialize(method);

            Reset();

            QueryExprSerializer.ConfigureRules(rule => rule.RuleForMethod(
                s => s.ByMemberInfo(method.Method)));

            var target = QueryExprSerializer.Deserialize<MethodCallExpression>(json);
            Assert.True(method.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetMemberMatrix() =>
            MemberSerializerTests.GetMemberMatrix();

        [Theory]
        [MemberData(nameof(GetMemberMatrix))]
        public void GivenMemberExpressionWhenSerializedThenShouldDeserialize(
            MemberExpression member)
        {
            var json = QueryExprSerializer.Serialize(member);

            Reset();

            var target = QueryExprSerializer.Deserialize<MemberExpression>(json);
            Assert.True(member.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetNewMatrix() =>
            CtorSerializerTests.GetCtorMatrix();

        [Theory]
        [MemberData(nameof(GetNewMatrix))]
        public void GivenNewExpressionWhenSerializedThenShouldDeserialize(
            ConstructorInfo info,
            Expression[] args,
            MemberInfo[] members)
        {
            var ctor = CtorSerializerTests.MakeNew(info, args, members);
            var json = QueryExprSerializer.Serialize(ctor);

            Reset();

            rulesConfig.Value.RuleForConstructor(selector => selector.ByMemberInfo(info));
            var target = QueryExprSerializer.Deserialize<NewExpression>(json);
            Assert.True(ctor.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetBinaryExpressions =
            BinarySerializerTests.GetBinaryExpressions();

        [Theory]
        [MemberData(nameof(GetBinaryExpressions))]
        public void GivenBinaryExpressionWhenSerializedThenShouldDeserialize(
            BinaryExpression binary)
        {
            var json = QueryExprSerializer.Serialize(binary);

            Reset();

            if (binary.Method != null)
            {
                rulesConfig.Value.RuleForMethod(selector => selector.ByMemberInfo(binary.Method));
            }

            var target = QueryExprSerializer.Deserialize<BinaryExpression>(json);
            Assert.True(binary.IsEquivalentTo(target));
        }
        
        [Fact]
        public void GivenRulesConfigThenReplacesExistingRules()
        {
            var engine = ServiceHost.GetService<IRulesEngine>();
            var rules = engine.Reset();
            var method = GetType().GetMethod(nameof(GivenRulesConfigThenReplacesExistingRules));
            var expr = Expression.Call(this.AsConstantExpression(), method);
            var json = QueryExprSerializer.Serialize(expr);
            QueryExprSerializer.ConfigureRules(
                rules => rules.RuleForMethod(selector => selector.ByResolver<MethodInfo, QueryExprSerializerTests>(
                test => test.GivenRulesConfigThenReplacesExistingRules())));
            var target = QueryExprSerializer.Deserialize<MethodCallExpression>(json);
            Assert.NotNull(target);
            QueryExprSerializer.ConfigureRules();
            Assert.Throws<UnauthorizedAccessException>(() =>
                QueryExprSerializer.Deserialize<MethodCallExpression>(json));
            engine.Restore(rules);
        }

        [Fact]
        public void GivenConfigureRulesThenShouldConfigureDefaults()
        {
            Expression<Func<string, bool>> expr = str => str.Contains("aa");
            var json = QueryExprSerializer.Serialize(expr);

            Reset();

            QueryExprSerializer.ConfigureRules();
            var target = QueryExprSerializer.Deserialize<LambdaExpression>(json);
            Assert.NotNull(target);
        }

        [Fact]
        public void GivenConfigureRulesNoDefaultsThenShouldConfigureNoDefaultRule()
        {

            Expression<Func<string, bool>> expr = str => str.Contains("aa");
            var json = QueryExprSerializer.Serialize(expr);

            Reset();

            QueryExprSerializer.ConfigureRules(noDefaults: true);

            Assert.Throws<UnauthorizedAccessException>(
                () => QueryExprSerializer.Deserialize<LambdaExpression>(json));

            Reset();
        }
    }
}
