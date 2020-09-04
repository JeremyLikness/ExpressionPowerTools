using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Extensions;
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
            Assert.Equal(expr.Type.FullName, target.ConstantType.TypeName);
            Assert.Equal(expr.Value, target.Value);
            Assert.Equal(expr.Value.GetType().FullName, target.ValueType.TypeName);
        }

        public static IEnumerable<object[]> GetMethods()
        {
            yield return new object[]
            {
                typeof(string).GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .FirstOrDefault(m => m.Name == nameof(string.Intern) && m.IsStatic)
            };

            yield return new object[]
            {
                typeof(SerializableExpressionTests)
                .GetMethod(nameof(GivenMethodInfoWhenMethodCreatedThenShouldPopulateMethodProperties))
            };
        }

        [Theory]
        [MemberData(nameof(GetMethods))]
        public void GivenMethodInfoWhenMethodCreatedThenShouldPopulateMethodProperties(MethodInfo method)
        {
            var serializerMethod = new Method(method);
            Assert.Equal(method.IsStatic, serializerMethod.IsStatic);
            Assert.Equal(method.Name, serializerMethod.Name);
            Assert.Equal(method.DeclaringType, TestSerializer.ReflectionHelper.DeserializeType(serializerMethod.DeclaringType));
            Assert.Equal(method.ReturnType, TestSerializer.ReflectionHelper.DeserializeType(serializerMethod.MemberValueType));
            Assert.Equal(method.GetParameters().Select(p => new
            {
                p.Name,
                Type = TestSerializer.ReflectionHelper.SerializeType(p.ParameterType)
            }).ToDictionary(p => p.Name, p => p.Type),
            serializerMethod.Parameters);
        }

        [Fact]
        public void GivenMultipleMethodInfosWhenMethodCreatedThenShouldHaveUniqueHashCodes()
        {
            var listMayHaveDuplicates =
                typeof(Expression).GetMethods().Union(
                    typeof(Expression).GetMethods(
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                .Select(m => new Method(m).GetHashCode()).ToList();
            var noDuplicates = new HashSet<int>(listMayHaveDuplicates);
            Assert.Equal(listMayHaveDuplicates.Count, noDuplicates.Count);
        }

        [Fact]
        public void GivenNewArrayExpressionWhenNewArrayCreatedThenShouldSetArrayType()
        {
            var expr = Expression.NewArrayInit(typeof(int), Expression.Constant(1), Expression.Constant(2));
            var target = new NewArray(expr);
            Assert.Equal(expr.Type.GetElementType(), TestSerializer.ReflectionHelper.DeserializeType(target.ArrayType));
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
            Assert.Equal(expr.Type, TestSerializer.ReflectionHelper.DeserializeType(target.ParameterType));
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
                Assert.Equal(unary.Method.Name, target.UnaryMethod.Name);
            }
            Assert.Equal(unary.Type, TestSerializer.ReflectionHelper.DeserializeType(target.UnaryType));
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
            Assert.Equal(lambda.Type, TestSerializer.ReflectionHelper.DeserializeType(target.LambdaType));
            Assert.Equal(lambda.ReturnType, TestSerializer.ReflectionHelper.DeserializeType(target.ReturnType));
        }

        [Fact]
        public void GivenInvocationExpressionWhenInvocationCreatedThenShouldSetProperties()
        {
            Expression<Func<int>> template = () => 1;
            var invocationExpr = Expression.Invoke(template);
            var invocation = new Invocation(invocationExpr);
            Assert.Equal(
                invocationExpr.Type.FullName,
                invocation.InvocationType.TypeName);
            Assert.NotNull(invocation.Arguments);
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
            Assert.Equal(
                methodCall.Method.Name,
                methodExpr.MethodInfo.Name);
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
            Assert.NotNull(target.MemberTypeList);
            Assert.NotNull(target.Members);
            Assert.NotNull(target.Properties);
            Assert.NotNull(target.Fields);
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
                Assert.Equal(member.Name, ctor.Properties[0].Name);
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
            Assert.Equal(2, ctor.Properties.Count);
            Assert.Equal(2, ctor.Fields.Count);
            Assert.Equal(new[]
            {
                (int)MemberTypes.Field,
                (int)MemberTypes.Property,
                (int)MemberTypes.Property,
                (int)MemberTypes.Field
            }, ctor.MemberTypeList);
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
            Assert.Equal(nameof(Divide), target.BinaryMethod.Name);
            Assert.Equal(expr.IsLifted, target.LiftToNull);
        }
    }
}
