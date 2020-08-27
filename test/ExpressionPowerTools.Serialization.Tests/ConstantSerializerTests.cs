using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class ConstantSerializerTests
    {
        private readonly ConstantSerializer serializer =
            new ConstantSerializer(TestSerializer.ExpressionSerializer);

        public static IEnumerable<object[]> GetConstantExpressions()
        {

            yield return new object[]
            {
                Expression.Constant(5)
            };

            yield return new object[]
            {
                Expression.Constant(null, typeof(object))
            };

            yield return new object[]
            {
                Expression.Constant(new { foo = "bar", id = 42 })
            };

            yield return new object[]
            {
                Expression.Constant(new int[0])
            };

            yield return new object[]
            {
                Expression.Constant(new int[] { 1, 2 })
            };

            yield return new object[]
            {
                Expression.Constant(5, typeof(IComparable))
            };

            yield return new object[]
            {
                Expression.Constant(Expression.Constant(5))
            };
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void ConstantExpressionShouldSerialize(ConstantExpression constant)
        {
            var target = serializer.Serialize(constant, null);
            if (constant.Value is ConstantExpression ce)
            {
                var targetType = target.Value as Constant;
                Assert.NotNull(targetType);
                Assert.Equal(ce.Value, targetType.Value);
            }
            else
            {
                Assert.Equal(constant.Type.ToString(),
                    ReflectionHelper.Instance.DeserializeType(target.ConstantType).ToString());
                Assert.Equal(constant.Value, target.Value);
                Assert.Equal(constant.Value == null ? constant.Type.ToString() :
                    constant.Value.GetType().ToString(),
                    ReflectionHelper.Instance.DeserializeType(target.ValueType).ToString());
            }
        }

        [Theory]
        [MemberData(nameof(GetConstantExpressions))]
        public void ConstantExpressionShouldDeserialize(ConstantExpression constant)
        {
            var serialized = TestSerializer.GetSerializedFragment<Constant, ConstantExpression>(constant);
            var deserialized = serializer.Deserialize(serialized, null, null);
            if (constant.Type.FullName.Contains("AnonymousType"))
            {
                Assert.Equal(
                    constant.Type.GetProperties().Select(p => p.Name),
                    ((IDictionary<string, object>)deserialized.Value).Keys);            
            }
            else
            {
                if (constant.Value is ConstantExpression ce)
                {
                    var deserializedExpr = deserialized.Value as ConstantExpression;
                    Assert.Equal(ce.Value, deserializedExpr.Value);
                }
                else
                {
                    Assert.Equal(constant.Type, deserialized.Type);
                    Assert.Equal(constant.Value, deserialized.Value);
                }
            }            
        }
    }
}
