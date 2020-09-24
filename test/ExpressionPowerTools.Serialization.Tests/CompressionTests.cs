using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Compression;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class CompressionTests
    {
        private readonly TreeCompressionVisitor target = new TreeCompressionVisitor();

        [Fact]
        public void GivenSkipOrTakeWithVariableWhenVisitedThenExtractsConstants()
        {
            var skip = 1;
            var take = 2;
            var query = TestableThing.MakeQuery().Skip(skip).Take(take);
            var expression = target.EvalAndCompress(query.Expression);
            Assert.Contains(expression.AsEnumerable().OfType<ConstantExpression>(), ce => ce.Type == typeof(int) && (int)ce.Value == skip);
            Assert.Contains(expression.AsEnumerable().OfType<ConstantExpression>(), ce => ce.Type == typeof(int) && (int)ce.Value == take);
        }

        [Fact]
        public void GivenFilterWithVariableWhenVisitedThenExtractsValues()
        {
            var isActive = true;
            var query = TestableThing.MakeQuery().Where(t => t.IsActive == isActive);
            var expression = target.EvalAndCompress(query.Expression);
            Assert.Contains(expression.AsEnumerable().OfType<ConstantExpression>(), ce => ce.Type == typeof(bool) && (bool)ce.Value == true);
        }

        [Fact]
        public void GivenExpressionThatCanResolveWhenVisitedThenExtractsValues()
        {
            var x = 2;
            var y = 3;
            var query = TestableThing.MakeQuery().Where(t => (x < y) ? t.IsActive : !t.IsActive);
            var expression = target.EvalAndCompress(query.Expression);
            Assert.DoesNotContain(expression.AsEnumerable(), ex => ex is ConditionalExpression);
        }

        [Fact]
        public void GivenExpressionAgainstStringAndDateWhenVisitedWillCompress()
        {
            var days = 5;
            var str = "aa";
            var query = TestableThing.MakeQuery().Where(t => t.Created > DateTime.Now.AddDays(-1 * days) &&
            t.Id.Contains(str));
            var expression = target.EvalAndCompress(query.Expression);
            Assert.Contains(expression.AsEnumerable().ConstantsOfType<string>(), ce => ce.Value.ToString() == str);
        }

        [Fact]
        public void GivenNestedMethodsThenWillCompress()
        {
            var str = "aa ";
            var query = TestableThing.MakeQuery().Where(t => t.Id.Contains(str.Trim()));
            var expression = target.EvalAndCompress(query.Expression);
            Assert.Contains(expression.AsEnumerable().ConstantsOfType<string>(), ce => ce.Value.ToString() == str.Trim());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GivenConditionalIfTestCanBeEvaluatedThenShouldTransformToTestResult(int scenario)
        {
            if (scenario == 0 || scenario == 1)
            {
                var x = scenario == 0 ? 2 : 3;
                var expected = scenario == 0 ? 0 : 1;
                Expression<Func<int>> expr = () => x % 2 == 0 ? 0 : 1;
                var compiled = target.EvalAndCompress(expr);
                Assert.False(compiled.AsEnumerable().OfType<ConditionalExpression>().Any());
                var actual = ((Func<int>)((ConstantExpression)compiled).Value)();
                Assert.Equal(expected, actual);
            }
            else
            {
                var query = TestableThing.MakeQuery().Select(t => t.Created < DateTime.Now.AddDays(-7) ? 0 : 1);
                var compiledQuery = target.EvalAndCompress(query.Expression);
                Assert.True(compiledQuery.AsEnumerable().OfType<ConditionalExpression>().Any());
            }
        }

        public static IEnumerable<object[]> GetAndMatrix()
        {
            var core = TestableThing.MakeQuery();
            Expression<Func<bool>> eval = () => DateTime.Now.Ticks < 12;
            static BinaryExpression ExtractBinary(IQueryable<TestableThing> query) =>
                query.AsEnumerableExpression().OfType<BinaryExpression>().First();
            var noCompression = core.Where(t => t.Id.Contains("aa") && t.Created < DateTime.Now && t.Value < 5);
            var compressedLeftFalse = core.Where(t => 2 > 3 && t.Value < 2);
            var compressedLeftTrueRightBool = Expression.And(true.AsConstantExpression(), false.AsConstantExpression());
            var compressedLeftTrueRightNotBool = core.Where(t => 2 < 3 && t.Value < 2);
            var compressedRightFalse = core.Where(t => t.Value < 2 && 2 > 3);
            var compressedRightTrue = core.Where(t => t.Value < 2 && true);
            
            yield return new object[] { ExtractBinary(noCompression), 4 };
            yield return new object[] { ExtractBinary(compressedLeftFalse), 0 };
            yield return new object[] { compressedLeftTrueRightBool, 0 };
            yield return new object[] { ExtractBinary(compressedLeftTrueRightNotBool), 1 };
            yield return new object[] { ExtractBinary(compressedRightFalse), 0 };
            yield return new object[] { ExtractBinary(compressedRightTrue), 1 };
        }

        [Theory]
        [MemberData(nameof(GetAndMatrix))]
        public void GivenAndOrAndAlsoWhenNodeIsEvaluatedThenWillCompressNode(
            BinaryExpression node, int expectedBinaryCount)
        {
            var compiled = target.Compress(node);
            var actual = compiled.AsEnumerable().Count(e => e is BinaryExpression);
            Assert.Equal(expectedBinaryCount, actual);
        }

        public static IEnumerable<object[]> GetOrMatrix()
        {
            var core = TestableThing.MakeQuery();
            Expression<Func<bool>> eval = () => DateTime.Now.Ticks < 12;
            static BinaryExpression ExtractBinary(IQueryable<TestableThing> query) =>
                query.AsEnumerableExpression().OfType<BinaryExpression>().First();
            var noCompression = core.Where(t => t.Id.Contains("aa") || t.Created < DateTime.Now || t.Value < 5);
            var compressedLeftFalse = core.Where(t => 2 > 3 || t.Value < 2);
            var compressedLeftFalseRightBool = Expression.Or(false.AsConstantExpression(), true.AsConstantExpression());
            var compressedLeftTrueRightNotBool = core.Where(t => 2 < 3 || t.Value < 2);
            var compressedRightFalse = core.Where(t => t.Value < 2 || 2 > 3);
            var compressedRightTrue = core.Where(t => t.Value < 2 || true);

            yield return new object[] { ExtractBinary(noCompression), 4 };
            yield return new object[] { ExtractBinary(compressedLeftFalse), 1 };
            yield return new object[] { compressedLeftFalseRightBool, 0 };
            yield return new object[] { ExtractBinary(compressedLeftTrueRightNotBool), 0 };
            yield return new object[] { ExtractBinary(compressedRightFalse), 1 };
            yield return new object[] { ExtractBinary(compressedRightTrue), 0 };
        }

        [Theory]
        [MemberData(nameof(GetOrMatrix))]
        public void GivenOrOrOrElseWhenNodeIsEvaluatedThenWillCompressNode(
            BinaryExpression node, int expectedBinaryCount)
        {
            var compiled = target.Compress(node);
            var actual = compiled.AsEnumerable().Count(e => e is BinaryExpression);
            Assert.Equal(expectedBinaryCount, actual);
        }       
    }
}
