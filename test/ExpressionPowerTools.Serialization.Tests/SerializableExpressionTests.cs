using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Members;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializableExpressionTests
    {
        [Fact]
        public void GivenNullExpressionWhenConstructorCalledThenShouldThrowArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SerializableExpression(null));
        }

        [Fact]
        public void GivenNonNullExpressionWhenConstructorCalledThenShouldSetType()
        {
            var target = new SerializableExpression(Expression.Constant(5));
            Assert.Equal(ExpressionType.Constant, (ExpressionType)target.Type);
        }

        [Fact]
        public void GivenConstantExpressionWhenConstantCreatedThenShouldSetConstantTypeAndValueAndValueType()
        {
            var expr = Expression.Constant(5);
            var target = new Constant(expr);
            Assert.Contains(expr.Type.Name, target.ConstantTypeKey);
            Assert.Equal(expr.Value, target.Value);
            Assert.Contains(expr.Value.GetType().Name, target.ValueTypeKey);
        }

        [Fact]
        public void GivenNewArrayExpressionWhenNewArrayCreatedThenShouldSetArrayType()
        {
            var expr = Expression.NewArrayInit(typeof(int), Expression.Constant(1), Expression.Constant(2));
            var target = new NewArray(expr);
            Assert.Equal(expr.Type.GetElementType(), TestSerializer.MemberAdapter.GetMemberForKey<Type>(target.ArrayTypeKey));
        }

        [Fact]
        public void GivenNewArrayExpressionWhenNewArrayCreatedThenShouldInitializeExpressionsList()
        {
            var expr = Expression.NewArrayInit(typeof(int), Expression.Constant(1), Expression.Constant(2));
            var target = new NewArray(expr);
            Assert.NotNull(target.Expressions);
        }

        [Fact]
        public void GivenParameterExpressionWhenParameterCreatedThenShouldSetNameAndParameterType()
        {
            var expr = Expression.Parameter(typeof(int), nameof(GivenParameterExpressionWhenParameterCreatedThenShouldSetNameAndParameterType));
            var target = new Parameter(expr);
            Assert.Equal(expr.Type, TestSerializer.MemberAdapter.GetMemberForKey<Type>(target.ParameterTypeKey));
            Assert.Equal(expr.Name, target.Name);
        }

        public static string ToString(int i) => i.ToString();

        public static IEnumerable<object[]> GetUnaryExpressions()
        {
            yield return new object[]
            {
                Expression.ArrayLength(Expression.Constant(new int[0]))
            };

            yield return new object[]
            {
                Expression.Convert(
                    Expression.Constant(5),
                    typeof(string),
                    typeof(SerializableExpressionTests).GetMethod(
                        nameof(ToString),
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            };
        }

        [Theory]
        [MemberData(nameof(GetUnaryExpressions))]
        public void GivenUnaryExpressionWhenUnaryCreatedThenShouldSetUnaryTypeAndMethod(UnaryExpression unary)
        {
            var target = new Unary(unary);
            if (unary.Method != null)
            {
                Assert.Contains(unary.Method.Name, target.UnaryMethodKey);
            }
            Assert.Equal(unary.Type, TestSerializer.MemberAdapter.GetMemberForKey<Type>(target.UnaryTypeKey));
        }

        [Fact]
        public void GivenLambdaExpressionWhenLambdaCreatedThenShouldSetLambdaProperties()
        {
            Expression<Func<int, bool>> expr = i => i > 5;
            var parameter = Expression.Parameter(typeof(int), "i");
            var lambda = Expression.Lambda(expr, parameter);
            var target = new Lambda(lambda);
            Assert.NotNull(target.Parameters);
            Assert.Equal(lambda.Name, target.Name);
            Assert.Equal(lambda.Type, TestSerializer.MemberAdapter.GetMemberForKey<Type>(target.LambdaTypeKey));
            Assert.Equal(lambda.ReturnType, TestSerializer.MemberAdapter.GetMemberForKey<Type>(target.ReturnTypeKey));
        }

        public long Double(int x) => x * 2;

        [Fact]
        public void GivenMethodCallExpressionWhenMethodExprCreatedThenShouldSetProperties()
        {
            var method = GetType()
                .GetMethod(nameof(Double));
            var methodCall = Expression.Call(
                Expression.Constant(this),
                method,
                Expression.Constant(int.MaxValue));
            var methodExpr = new MethodExpr(methodCall);
            Assert.Contains(
                methodCall.Method.Name,
                methodExpr.MethodInfoKey);
            Assert.NotNull(methodExpr.Arguments);
        }

        public class CtorClass
        {
            public CtorClass()
            {
            }

            public CtorClass(int prop)
            {
                Prop = prop;
            }

            public int Prop { get; set; }
        }

        public static IEnumerable<object[]> GetCtorMatrix()
        {
            var ctors = typeof(CtorClass).GetConstructors();
            var defaultCtor = ctors.First(c => c.GetParameters().Length == 0);
            var propCtor = ctors.First(c => c.GetParameters().Length == 1);
            var prop = typeof(CtorClass).GetProperty(nameof(CtorClass.Prop));

            yield return new object[]
            {
                defaultCtor, null, null
            };

            yield return new object[]
            {
                propCtor, Expression.Constant(1), null
            };

            yield return new object[]
            {
                propCtor, Expression.Constant(1), prop
            };
        }

        [Fact]
        public void WhenCtorExprCreatedThenShouldInitializeLists()
        {
            var target = new CtorExpr();
            Assert.NotNull(target.Arguments);
            Assert.NotNull(target.MemberKeys);
        }

        [Theory]
        [MemberData(nameof(GetCtorMatrix))]
        public void GivenConstructorWhenCtorExprCreatedThenShouldSetProperties(
            ConstructorInfo info,
            Expression arg,
            MemberInfo member)
        {
            NewExpression expr;
            if (arg == null)
            {
                expr = Expression.New(info);
            }
            else if (member == null)
            {
                expr = Expression.New(info, new[] { arg });
            }
            else
            {
                expr = Expression.New(info, new[] { arg }, new[] { member });
            }
            var ctor = new CtorExpr(expr);
            Assert.NotNull(ctor.CtorInfo);
            if (member != null)
            {
                Assert.Contains(member.Name, ctor.MemberKeys[0]);
            }
        }

        public class FieldsAndProps
        {
            public FieldsAndProps(
                int inField,
                string inValueStr,
                int inValue,
                string inFieldStr)
            {
                field = inField;
                ValueStr = inValueStr;
                Value = inValue;
                fieldStr = inFieldStr;
            }

            public int field;
            public string fieldStr;
            public int Value { get; set; }
            public string ValueStr { get; set; }
        }

        [Fact]
        public void GivenMixedFieldsAndPropertiesWhenCtorExprCreatedThenShouldMapAppropriately()
        {
            var expr = Expression.New(
                typeof(FieldsAndProps).GetConstructors().Single(),
                new[]
                {
                    1.AsConstantExpression(),
                    nameof(SerializableExpressionTests).AsConstantExpression(),
                    2.AsConstantExpression(),
                    nameof(GivenMixedFieldsAndPropertiesWhenCtorExprCreatedThenShouldMapAppropriately)
                    .AsConstantExpression()
                },
                new MemberInfo[]
                {
                    typeof(FieldsAndProps).GetField(nameof(FieldsAndProps.field)),
                    typeof(FieldsAndProps).GetProperty(nameof(FieldsAndProps.ValueStr)),
                    typeof(FieldsAndProps).GetProperty(nameof(FieldsAndProps.Value)),
                    typeof(FieldsAndProps).GetField(nameof(FieldsAndProps.fieldStr)),
                });
            var ctor = new CtorExpr(expr);
            Assert.Equal(2, ctor.MemberKeys.Count(m => m.StartsWith("P:")));
            Assert.Equal(2, ctor.MemberKeys.Count(m => m.StartsWith("F:")));
        }

        public static IEnumerable<object[]> GetSerializableExpressionMatrix()
        {
            var baseType = typeof(SerializableExpression);
            foreach (var type in baseType.Assembly.GetTypes().Where(t => baseType.IsAssignableFrom(t)))
            {
                yield return new object[] { type };
            };
        }

        [Theory]
        [MemberData(nameof(GetSerializableExpressionMatrix))]
        public void DefaultCtorWorksForSerialization(Type serializableType)
        {
            var serializable = Activator.CreateInstance(serializableType);
            Assert.NotNull(serializable);
        }

        public static double Divide(double x, double y) => x / y;

        [Fact]
        public void GivenBinaryExpressionWithMethodWhenBinaryInstantiatedThenShouldSetMethod()
        {
            var method = GetType().GetMethod(
                nameof(Divide),
                BindingFlags.Public | BindingFlags.Static);
            var expr = Expression.Divide(
                4.0.AsConstantExpression(),
                2.0.AsConstantExpression(),
                method);
            var target = new Binary(expr);
            Assert.NotNull(target.BinaryMethod);
            Assert.Contains(nameof(Divide), target.BinaryMethod);
            Assert.Equal(expr.IsLifted, target.LiftToNull);
        }
    }
}
