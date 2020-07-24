using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExpressionEnumeratorTests
    {
        public string Id => Guid.NewGuid().ToString();

        private ConstantExpression Forty => Expression.Constant(40);
        private ConstantExpression Two => Expression.Constant(2);
        private BinaryExpression Add => Expression.Add(Forty, Two);
        private Expression<Func<ExpressionEnumeratorTests, string>>
            TestId => test => test.Id;
        private LambdaExpression Lambda => TestId;

        public object Echo(object item) => item;

        [Fact]
        public void GivenNullExpressionWhenGetEnumeratorCalledThenShouldReturnEmpty()
        {
            var target = new ExpressionEnumerator(null)
                .ToList();
            Assert.Empty(target);
        }

        [Fact]
        public void WhenGetEnumeratorCalledWithConstantExpressionThenShouldReturnEnumerator()
        {
            var target = new ExpressionEnumerator(Forty)
                .ToList();
            Assert.Single(target);
            Assert.True(target.OfType<ConstantExpression>()
                .Any());
        }

        [Fact]
        public void WhenGetEnumeratorCalledWithNestedConstantExpressionThenShouldReturnEnumerator()
        {
            var wrapped = Expression.Constant(Forty);
            var target = new ExpressionEnumerator(wrapped)
                .ToList();
            Assert.Equal(2, target.Count);
            Assert.True(target.All(t => t.NodeType ==
            ExpressionType.Constant));
        }

        [Fact]
        public void GivenBinaryWhenGetEnumeratorCalledThenShouldReturnExpressions()
        {
            var target = new ExpressionEnumerator(Add)
                .ToList();
            Assert.True(target.OfType<BinaryExpression>().Any());
            Assert.Equal(2, target.OfType<ConstantExpression>().Count());
        }

        [Fact]
        public void GivenLambdaWhenEnumeratorCalledThenShouldReturnExpressions()
        {
            var target = new ExpressionEnumerator(Lambda)
                .ToList();
            Assert.True(target.OfType<LambdaExpression>().Any());
            Assert.True(target.OfType<ParameterExpression>().Any());
        }

        [Fact]
        public void GivenMemberAccessWhenEnumeratorCalledThenShouldReturnExpressions()
        {
            var member = Expression
                .MakeMemberAccess(
                    Expression.Constant(this),
                    GetType().GetMember(nameof(Id)).First());
            var target = new ExpressionEnumerator(member).ToList();
            Assert.True(target.OfType<MemberExpression>().Any());
            Assert.True(target.OfType<ConstantExpression>().Any());
        }

        [Fact]
        public void MethodCall()
        {
            var method = Expression.Call(
                typeof(DateTime),
                nameof(DateTime.Parse),
                null,
                Expression.Parameter(typeof(string)));
            var target = new ExpressionEnumerator(method)
                .ToList();
            Assert.True(target.OfType<MethodCallExpression>().Any());
            Assert.True(target.OfType<ParameterExpression>().Any());
        }

        [Fact]
        public void Unary()
        {
            var unary = Expression.Convert(Expression.Constant(this),
                typeof(object));
            var target = new ExpressionEnumerator(unary)
                .ToList();
            Assert.True(target.OfType<UnaryExpression>().Any());
            Assert.True(target.OfType<ConstantExpression>().Any());

        }

        [Fact]
        public void Default()
        {
            var invocation = Expression.Invoke(
                Lambda, Expression.Constant(this));
            var target = new ExpressionEnumerator(invocation)
                .ToList();
            Assert.True(target.OfType<InvocationExpression>().Any());
        }

        [Fact]
        public void WhenGetEnumeratorCalledWithQueryExpressionThenShouldReturnQueryParts()
        {
            var query = new List<ExpressionEnumeratorTests>()
                .AsQueryable()
                .Where(item => item.Id.StartsWith("b"))
                .Skip(1)
                .Take(5)
                .OrderBy(item => item.Id);
            var target = new ExpressionEnumerator(query.Expression)
                .ToList();
            Assert.True(target.OfType<ConstantExpression>()
                .Any());
            Assert.Contains(target, t =>
                t is MethodCallExpression mc
                && mc.Method.Name == nameof(Enumerable.Take));
        }
    }
}
