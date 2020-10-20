using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class JsonWrapperTests
    {
        private readonly ISerializationWrapper<string, JsonSerializerOptions, JsonSerializerOptions> wrapper =
            ServiceHost.GetService<ISerializationWrapper<string, JsonSerializerOptions, JsonSerializerOptions>>();

        private readonly Lazy<IExpressionEvaluator> expressionEvaluator =
            ServiceHost.GetLazyService<IExpressionEvaluator>();

        public static IEnumerable<object[]> GetQueryMatrix() => QueryExprSerializerTests.GetQueryMatrix();

        public JsonWrapperTests()
        {
            QueryExprSerializer.ConfigureRules(rules =>
                rules.RuleForType<QueryExprSerializerTests>()
                    .RuleForType<TestableThing>()
                    .RuleForType(typeof(Tuple)));
        }

        [Theory]
        [MemberData(nameof(GetQueryMatrix))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "xUnit1026:Theory methods should use all of their parameters",
            Justification = "Clarifies the test.")]
        public void GivenQueryCanSerializeAndDeserialize(IQueryable query, QueryExprSerializerTests.Queries queryType)
        {
            var root = QueryExprSerializer.Serialize(query, config => config.CompressExpressionTree(false));
            var json = wrapper.FromSerializationRoot(root);
            var deserializedRoot = wrapper.ToSerializationRoot(json);
            Assert.NotNull(deserializedRoot);
            IQueryable queryHost = TestableThing.MakeQuery(10);
            var deserializedQuery = QueryExprSerializer.DeserializeQuery(queryHost, deserializedRoot);
            Assert.NotNull(deserializedQuery);
            Assert.True(query.Expression.IsEquivalentTo(deserializedQuery.Expression));
        }

        [Fact]
        public void MultipleSelectManyProjectionWorks()
        {
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
             }).Select(t => Tuple.Create(t.parentId, t.childId, t.grandChildId));

            var query = SelectMany(IQueryableExtensions.CreateQueryTemplate<TestableThing>());

            var root = QueryExprSerializer.Serialize(query);
            var json = wrapper.FromSerializationRoot(root);
            // make sure we're not just pulling from the cache
            var deserializedRoot = wrapper.ToSerializationRoot(json);
            var newQuery = QueryExprSerializer.DeserializeQuery<Tuple<string, string, string>>(deserializedRoot, dataQuery);

            var expected = SelectMany(dataQuery).ToList();
            var actual = newQuery.ToList();

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        public class MockType
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<MockMethod> Methods { get; set; } = new
                List<MockMethod>();
        }

        public class MockMethod
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<MockParameter> Parameters { get; set; } =
                new List<MockParameter>();
        }

        public class MockParameter
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class RelatedThing
        {
            public string TypeName { get; set; }
            public string MethodName { get; set; }
            public string ParameterName { get; set; }
        }

        [Fact]
        public void AlternateSelectManyWorks()
        {
            QueryExprSerializer.ConfigureRules(
                rules => rules.RuleForType<RelatedThing>());

            var db = typeof(JsonWrapperTests).Assembly.GetTypes()
                .Select(t => new MockType
                {
                    Id = t.ToString(),
                    Name = t.FullName,
                    Methods = t.GetMethods().Select(
                        m => new MockMethod
                        {
                            Id = m.ToString(),
                            Name = m.Name,
                            Parameters = m.GetParameters()
                            .Select(p => new MockParameter
                            {
                                Id = $"{p.Position}-{p.ParameterType}",
                                Name = p.Name,
                            }).ToList()
                        }).ToList()
                });

            Func<IQueryable<MockType>, IQueryable<RelatedThing>> makeQuery = q =>
                    q
                    .Where(t => t.Name != null)
                    .SelectMany(
                        t =>
                        t.Methods, (t, m) =>
                        new
                        {
                            t.Name,
                            MethodName = m.Name,
                            m.Parameters,
                        })
                    .SelectMany(
                        tm => tm.Parameters,
                        (tm, p) =>
                        new RelatedThing
                        {
                            TypeName = tm.Name,
                            MethodName = tm.MethodName,
                            ParameterName = p.Name,
                        })
                    .OrderBy(r => r.TypeName)
                    .ThenBy(r => r.MethodName)
                    .ThenBy(r => r.ParameterName);

            var queryToSerialize = makeQuery(new List<MockType>().AsQueryable());

            var root = QueryExprSerializer.Serialize(queryToSerialize);
            var json = wrapper.FromSerializationRoot(root);

            var deserializedRoot = wrapper.ToSerializationRoot(json);
            var newQuery = QueryExprSerializer.DeserializeQuery<RelatedThing>(deserializedRoot, db.AsQueryable());

            var result = makeQuery(db.AsQueryable());
            var expected = result.ToList();
            var actual = newQuery.ToList();

            Assert.NotNull(actual);
            Assert.Equal(expected.Count(), actual.Count());
        }

        [Fact]
        public void SerializesAndDeserializesAnonymousTypes()
        {
            var expected = new
            {
                Id = 1,
                SubAnon = new
                {
                    Id = 2,
                    Two = 2.ToString()
                }
            };

            var expr = expected.AsConstantExpression();
            var root = QueryExprSerializer.Serialize(expr);
            var json = wrapper.FromSerializationRoot(root);
            var deserializedRoot = wrapper.ToSerializationRoot(json);
            var deserializedExpr = QueryExprSerializer.Deserialize<ConstantExpression>(deserializedRoot);
            Assert.True(expressionEvaluator.Value.AnonymousValuesAreEquivalent(expr.Value, deserializedExpr.Value));
        }

        [Fact]
        public void HandlesNullAnonymousTypes()
        {
            var expected = new
            {
                Id = 1,
                SubAnon = default(object)
            };

            var expr = expected.AsConstantExpression();
            var root = QueryExprSerializer.Serialize(expr);
            var json = wrapper.FromSerializationRoot(root);
            var deserializedRoot = wrapper.ToSerializationRoot(json);
            var deserializedExpr = QueryExprSerializer.Deserialize<ConstantExpression>(deserializedRoot);
            Assert.True(expressionEvaluator.Value.AnonymousValuesAreEquivalent(expr.Value, deserializedExpr.Value));
        }

        public class DataElem
        {
            public string Name { get; set; }
        }

        public class DataElemToo
        {
            public string Name { get; set; }
        }

        public class DataHost
        {
            public List<DataElem> Elems { get; set; } = new List<DataElem>();
            public List<DataElemToo> ElemsToo { get; set; } = new List<DataElemToo>();
        }

        [Fact]
        public void HandlesElementInits()
        {
            Expression<Func<DataHost>> elemInit = () => new DataHost { Elems = { new DataElem() } };
            var root = QueryExprSerializer.Serialize(elemInit, config => config.CompressExpressionTree(false));
            var json = wrapper.FromSerializationRoot(root);
            var deserializedRoot = wrapper.ToSerializationRoot(json);
            QueryExprSerializer.ConfigureRules(rules => rules.RuleForType<DataHost>()
                .RuleForType<DataElem>());
            var deserializedExpr = QueryExprSerializer.Deserialize<LambdaExpression>(deserializedRoot);
            Assert.True(elemInit.IsEquivalentTo(deserializedExpr));
        }

        public interface IHaveId
        {
            string Id { get; }
        }

        public class IdContainer : IHaveId
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void HandlesInterfaces()
        {
            var expr = Expression.Constant(new IdContainer
            {
                Id = Guid.NewGuid().ToString(),
                Name = nameof(IdContainer),
            }, typeof(IHaveId));
            var root = QueryExprSerializer.Serialize(expr, config => config.CompressExpressionTree(false));
            var json = wrapper.FromSerializationRoot(root);
            var deserializedRoot = wrapper.ToSerializationRoot(json);
            var deserializedExpr = QueryExprSerializer.Deserialize<ConstantExpression>(deserializedRoot);
            Assert.Equal(typeof(IHaveId), deserializedExpr.Type);
            Assert.True(deserializedExpr.Value is IdContainer);
            Assert.Equal(nameof(IdContainer), ((IdContainer)deserializedExpr.Value).Name);
        }
    }
}
