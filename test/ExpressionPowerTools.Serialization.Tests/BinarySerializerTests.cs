using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class BinarySerializerTests
    {
        public BinarySerializerTests()
        {
            Serializer.ConfigureRules(config => config.RuleForType<BinarySerializerTests>());            
        }

        private readonly BinarySerializer binarySerializer =
            new BinarySerializer(TestSerializer.ExpressionSerializer);

        private SerializationState NewSerializationState =>
            ServiceHost.GetService<IDefaultConfiguration>().GetDefaultState();
       
        public static int DoMath(int x, int y) => x + y;

        public static double Pow(double x, double y) => Math.Pow(x, y);

        public static bool Logic(bool left, bool right) => left & right;

        public static bool IntComparison(int _, int __) => true;

        public static BinarySerializerTests CustomLogic(
            BinarySerializerTests left,
            BinarySerializerTests right) => left & right;

        public static bool operator true(BinarySerializerTests _) => true;
        public static bool operator false(BinarySerializerTests _) => false;

        public static BinarySerializerTests operator &(
            BinarySerializerTests left,
            BinarySerializerTests _) => left;

        public static bool Or(bool left, bool right) => left || right;

        public static MethodInfo Method(string name)
        {
            return typeof(BinarySerializerTests)
                .GetMethod(name, BindingFlags.Public | BindingFlags.Static);
        }

        public static IEnumerable<object[]> GetBinaryExpressions()
        {
            int result = 1;
            bool logicalResult = true;
            double doubleResult = 1.0;

            var intParam = result.AsParameterExpression();
            var logicalParam = logicalResult.AsParameterExpression();
            var testParam = typeof(BinarySerializerTests).AsParameterExpression();
            var doubleParam = doubleResult.AsParameterExpression();
            var one = 1.AsConstantExpression();
            var two = 2.AsConstantExpression();
            var onedot = 1.0.AsConstantExpression();
            var twodot = 2.0.AsConstantExpression();
            var test = new BinarySerializerTests().AsConstantExpression();
            var truth = true.AsConstantExpression();
            Expression<Func<BinarySerializerTests, BinarySerializerTests>> conversion =
                val => new BinarySerializerTests();
            Expression<Func<int, int>> intConversion = val => val;
            Expression<Func<double, double>> doubleConversion = val => val;

            yield return Expression.Add(one, two)
                .AsObjectArray();

            yield return Expression.Add(
                one,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.AddAssign(intParam, two)
                .AsObjectArray();

            yield return Expression.AddAssign(
                intParam,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.AddAssignChecked(intParam, two)
                .AsObjectArray();

            yield return Expression.AddAssignChecked(
                intParam,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.AddChecked(one, two)
               .AsObjectArray();

            yield return Expression.AddChecked(
                one,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.And(truth, truth).AsObjectArray();

            yield return Expression.And(truth, truth, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.AndAlso(truth, truth).AsObjectArray();

            yield return Expression.AndAlso(test, test, Method(nameof(CustomLogic)))
                .AsObjectArray();

            yield return Expression.AndAssign(logicalParam, truth)
                .AsObjectArray();

            yield return Expression.AndAssign(logicalParam, truth, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.AndAssign(
                testParam,
                test,
                Method(nameof(CustomLogic)),
                conversion).AsObjectArray();

            yield return Expression.Assign(testParam, test)
                .AsObjectArray();

            yield return Expression.Coalesce(testParam, test).AsObjectArray();

            yield return Expression.Coalesce(testParam, test, conversion)
                .AsObjectArray();

            yield return Expression.Divide(one, two).AsObjectArray();

            yield return Expression.Divide(one, two, Method(nameof(DoMath)))
                .AsObjectArray();

            yield return Expression.DivideAssign(intParam, one).AsObjectArray();

            yield return Expression.DivideAssign(
                intParam,
                one,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.DivideAssign(
                intParam,
                one,
                Method(nameof(DoMath)),
                intConversion).AsObjectArray();

            yield return Expression.Equal(truth, truth).AsObjectArray();

            yield return Expression.Equal(truth, truth, false, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.ExclusiveOr(truth, truth).AsObjectArray();

            yield return Expression.ExclusiveOr(test, test, Method(nameof(CustomLogic)))
                .AsObjectArray();

            yield return Expression.ExclusiveOrAssign(logicalParam, truth)
                .AsObjectArray();

            yield return Expression.ExclusiveOrAssign(logicalParam, truth, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.ExclusiveOrAssign(
                testParam,
                test,
                Method(nameof(CustomLogic)),
                conversion).AsObjectArray();

            yield return Expression.GreaterThan(one, two).AsObjectArray();

            yield return Expression.GreaterThan(one, two, false, Method(nameof(IntComparison)))
                .AsObjectArray();

            yield return Expression.GreaterThanOrEqual(one, two).AsObjectArray();

            yield return Expression.GreaterThanOrEqual(one, two, false, Method(nameof(IntComparison)))
                .AsObjectArray();

            yield return Expression.LeftShift(one, two).AsObjectArray();

            yield return Expression.LeftShift(one, two, Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.LeftShiftAssign(intParam, two).AsObjectArray();

            yield return Expression.LeftShiftAssign(intParam, two, Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.LeftShiftAssign(
                intParam,
                two,
                Method(nameof(DoMath)),
                intConversion).AsObjectArray();

            yield return Expression.LessThan(one, two).AsObjectArray();

            yield return Expression.LessThan(one, two, false, Method(nameof(IntComparison)))
                .AsObjectArray();

            yield return Expression.LessThanOrEqual(one, two).AsObjectArray();

            yield return Expression.LessThanOrEqual(one, two, false, Method(nameof(IntComparison)))
                .AsObjectArray();

            yield return Expression.Modulo(one, two).AsObjectArray();

            yield return Expression.Modulo(one, two, Method(nameof(DoMath)))
                .AsObjectArray();

            yield return Expression.ModuloAssign(intParam, one).AsObjectArray();

            yield return Expression.ModuloAssign(
                intParam,
                one,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.ModuloAssign(
                intParam,
                one,
                Method(nameof(DoMath)),
                intConversion).AsObjectArray();

            yield return Expression.Multiply(one, two)
                .AsObjectArray();

            yield return Expression.Multiply(
                one,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.MultiplyAssign(intParam, two)
                .AsObjectArray();

            yield return Expression.MultiplyAssign(
                intParam,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.MultiplyAssignChecked(intParam, two)
                .AsObjectArray();

            yield return Expression.MultiplyAssignChecked(
                intParam,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.MultiplyChecked(one, two)
               .AsObjectArray();

            yield return Expression.MultiplyChecked(
                one,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.NotEqual(truth, truth).AsObjectArray();

            yield return Expression.NotEqual(truth, truth, false, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.Or(truth, truth).AsObjectArray();

            yield return Expression.Or(truth, truth, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.OrElse(truth, truth).AsObjectArray();

            yield return Expression.OrElse(test, test, Method(nameof(CustomLogic)))
                .AsObjectArray();

            yield return Expression.OrAssign(logicalParam, truth)
                .AsObjectArray();

            yield return Expression.OrAssign(logicalParam, truth, Method(nameof(Logic)))
                .AsObjectArray();

            yield return Expression.OrAssign(
                testParam,
                test,
                Method(nameof(CustomLogic)),
                conversion).AsObjectArray();

            yield return Expression.Power(onedot, twodot).AsObjectArray();

            yield return Expression.Power(onedot, twodot, Method(nameof(Pow)))
                .AsObjectArray();

            yield return Expression.PowerAssign(doubleParam, onedot).AsObjectArray();

            yield return Expression.PowerAssign(
                doubleParam,
                onedot,
                Method(nameof(Pow))).AsObjectArray();

            yield return Expression.PowerAssign(
                doubleParam,
                onedot,
                Method(nameof(Pow)),
                doubleConversion).AsObjectArray();

            yield return Expression.RightShift(one, two).AsObjectArray();

            yield return Expression.RightShift(one, two, Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.RightShiftAssign(intParam, two).AsObjectArray();

            yield return Expression.RightShiftAssign(intParam, two, Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.RightShiftAssign(
                intParam,
                two,
                Method(nameof(DoMath)),
                intConversion).AsObjectArray();

            yield return Expression.Subtract(one, two)
                 .AsObjectArray();

            yield return Expression.Subtract(
                one,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.SubtractAssign(intParam, two)
                .AsObjectArray();

            yield return Expression.SubtractAssign(
                intParam,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.SubtractAssignChecked(intParam, two)
                .AsObjectArray();

            yield return Expression.SubtractAssignChecked(
                intParam,
                two,
                Method(nameof(DoMath))).AsObjectArray();

            yield return Expression.SubtractChecked(one, two)
               .AsObjectArray();

            yield return Expression.SubtractChecked(
                one,
                two,
                Method(nameof(DoMath))).AsObjectArray();
        }

        [Theory]
        [MemberData(nameof(GetBinaryExpressions))]
        public void BinaryExpressionShouldSerialize(BinaryExpression binary)
        {
            var target = binarySerializer.Serialize(binary, NewSerializationState);
            Assert.Equal((ExpressionType)target.Type, binary.NodeType);
        }

        [Theory]
        [MemberData(nameof(GetBinaryExpressions))]
        public void BinaryExpressionShouldDeserialize(BinaryExpression binary)
        {
            var serialized = TestSerializer.GetSerializedFragment<Binary, BinaryExpression>(binary);
            var deserialized = binarySerializer.Deserialize(serialized, TestSerializer.State);          
            Assert.Equal(binary.Type.FullName, deserialized.Type.FullName);
        }

        [Fact]
        public void GivenOptionsIgnoreNullWhenBinarySerializedThenShouldDeserialize()
        {
            var binary = Expression.LessThan(
                1.AsConstantExpression(),
                2.AsConstantExpression());

            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };

            var serialized = TestSerializer.GetSerializedFragment<Binary, BinaryExpression>(binary, options);
            var deserialized = binarySerializer.Deserialize(serialized, TestSerializer.State);
            Assert.Equal(binary.Type.FullName, deserialized.Type.FullName);
        }

        [Fact]
        public void GivenAuthorizedMethodWhenDeserializeCalledThenShouldDeserialize()
        {
            var method = GetType().GetMethod(nameof(DoMath));
            var expr = Expression.Multiply(
                1.AsConstantExpression(),
                2.AsConstantExpression(),
                method);
            var serialized = TestSerializer.GetSerializedFragment<Binary, BinaryExpression>(expr);
            ServiceHost.GetService<IRulesConfiguration>().RuleForMethod(
                selector => selector.ByMemberInfo(method)).Allow();
            var deserialized = binarySerializer.Deserialize(serialized, TestSerializer.State);
            Assert.NotNull(deserialized);
        }

        [Fact]
        public void GivenUnauthorizedMethodWhenDeserializeCalledThenShouldThrowUnauthorizedAccess()
        {
            var method = GetType().GetMethod(nameof(DoMath));
            var expr = Expression.Multiply(
                1.AsConstantExpression(),
                2.AsConstantExpression(),
                method);
            var serialized = TestSerializer.GetSerializedFragment<Binary, BinaryExpression>(expr);
            ServiceHost.GetService<IRulesConfiguration>().RuleForMethod(
                selector => selector.ByMemberInfo(method)).Deny();
            Assert.Throws<UnauthorizedAccessException>(() =>
                binarySerializer.Deserialize(serialized, TestSerializer.State));
        }

        public override bool Equals(object obj) => obj is BinarySerializerTests;

        public override int GetHashCode() 
        {
            return HashCode.Combine(binarySerializer);
        }
    }
}
