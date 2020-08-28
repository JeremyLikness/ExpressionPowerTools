using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializerTests
    {
        [Fact]
        public void GivenSerializeWhenCalledWithNullExpressionThenShouldThrowArgumentNull()
        {
            Expression expression = null;
            Assert.Throws<ArgumentNullException>(() =>
                Serializer.Serialize(expression));
        }

        [Fact]
        public void GivenSerializeWhenCalledWithNullQueryThenShouldThrowArgumentNull()
        {
            IQueryable query = null;
            Assert.Throws<ArgumentNullException>(() =>
                Serializer.Serialize(query));
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

        [Fact]
        public void WhenDeserializeCalledWithEmptyJsonThenShouldReturnNull()
        {
            Assert.Null(Serializer.Deserialize("{}"));
        }

        [Fact]
        public void WhenDeserializeQueryCalledWithNullHostThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                Serializer.DeserializeQuery(null, "{}"));
        }

        [Fact]
        public void WhenDeserializeQueryForTypeCalledWithNullHostThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                Serializer.DeserializeQuery<TestableThing>(null, "{}"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void WhenDeserializeQueryCalledWithEmptyOrNullJsonThenShouldThrowArgument(string json)
        {
            Assert.Throws<ArgumentException>(() =>
                Serializer.DeserializeQuery((IQueryable)TestableThing.MakeQuery(), json));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void WhenDeserializeQueryForTypeCalledWithEmptyOrNullJsonThenShouldThrowArgument(string json)
        {
            Assert.Throws<ArgumentException>(() =>
                Serializer.DeserializeQuery(TestableThing.MakeQuery(), json));
        }

        public enum Queries
        {
            Skip1Take1,
            OrderByCreatedThenByDescendingId,
            WhereIdContainsAA,

        }

        public static IEnumerable<object[]> GetQueryMatrix()
        {
            yield return new object[]
            {
                TestableThing.MakeQuery().Skip(1).Take(1),
                Queries.Skip1Take1
            };

            //yield return new object[]
            //{
            //    TestableThing.MakeQuery().OrderBy(t => t.Created).ThenByDescending(t => t.Id),
            //    Queries.OrderByCreatedThenByDescendingId
            //};

            //yield return new object[]
            //{
            //    TestableThing.MakeQuery().Where(t => t.Id.Contains("aa")),
            //    Queries.WhereIdContainsAA
            //};
        }

        public bool ValidateQuery(IList<TestableThing> list, Queries type)
        {
            switch(type)
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
            }
            return false;
        }

        [Theory]
        [MemberData(nameof(GetQueryMatrix))]
        public void GivenQueryWhenSerializeCalledThenShouldDeserialize(
            IQueryable query,
            Queries type)
        {
            var json = Serializer.Serialize(query);
            var queryHost = TestableThing.MakeQuery(100);
            var newQuery = Serializer.DeserializeQuery(queryHost, json);
            Assert.True(query.IsEquivalentTo(newQuery));
            var list = newQuery.ToList();
            ValidateQuery(list, type);
        }

        [Theory]
        [MemberData(nameof(GetQueryMatrix))]
        public void GivenQueryWhenSerializeCalledThenShouldDeserializeForType(
            IQueryable<TestableThing> query,
            Queries type)
        {
            var json = Serializer.Serialize(query);
            var queryHost = TestableThing.MakeQuery(100);
            var newQuery = Serializer.DeserializeQuery(queryHost, json);
            Assert.True(query.IsEquivalentTo(newQuery));
            var list = newQuery.ToList();
            ValidateQuery(list, type);
        }

        [Fact]
        public void WhenGetExpressionTypeForCalledWithInvalidStringThenShouldReturnDefault()
        {
            Assert.Equal(default, new TestBaseSerializer().GetExpressionType("fake"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenDeserializeWhenCalledWithNullOrEmptyStringThenShouldThrowArgument(string json)
        {
            Assert.Throws<ArgumentException>(() =>
                Serializer.Deserialize(json));
        }

        public static IEnumerable<object[]> GetConstantExpressions =
            ConstantSerializerTests.GetConstantExpressions();

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void GivenExpressionWhenSerializedThenShouldDeserialize(ConstantExpression constant)
        {
            var json = Serializer.Serialize(constant);
            var target = Serializer.Deserialize<ConstantExpression>(json);

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
            var json = Serializer.Serialize(array);
            var target = Serializer.Deserialize<NewArrayExpression>(json);
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
            var json = Serializer.Serialize(parameter);
            var target = Serializer.Deserialize<ParameterExpression>(json);
            Assert.Equal(parameter.Type, target.Type);
            Assert.Equal(parameter.Name, target.Name);
        }

        public static IEnumerable<object[]> GetUnaryExpressions() =>
            UnarySerializerTests.GetUnaryExpressions();

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void GivenUnaryExpressionWhenSerializedThenShouldDeserialize(UnaryExpression unary)
        {
            var json = Serializer.Serialize(unary);
            var target = Serializer.Deserialize<UnaryExpression>(json);
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
            var json = Serializer.Serialize(lambda);
            var target = Serializer.Deserialize<LambdaExpression>(json);
            Assert.True(lambda.IsEquivalentTo(target));
        }

        public static IEnumerable<object[]> GetInvocationExpressions() =>
            InvocationSerializerTests.GetInvocationExpressionMatrix();

        [Theory]
        [MemberData(nameof(GetInvocationExpressions))]
        public void GivenInvocationExpressionWhenSerializedThenShouldDeserialize(InvocationExpression invocation)
        {
            var json = Serializer.Serialize(invocation);
            var target = Serializer.Deserialize<InvocationExpression>(json);
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
            var json = Serializer.Serialize(method);
            var target = Serializer.Deserialize<MethodCallExpression>(json);
            Assert.True(method.IsEquivalentTo(target));
        }
    }
}
