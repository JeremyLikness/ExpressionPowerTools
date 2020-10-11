using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Serialization.Signatures;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class NewArraySerializerTests
    {
        private readonly NewArraySerializer serializer =
            new NewArraySerializer(TestSerializer.ExpressionSerializer);

        [Fact]
        public void NewArrayExpressionShouldSerialize()
        {
            var newArray = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2));
            var state = ServiceHost.GetService<IConfigurationBuilder>().CompressTypes(false).Configure();
            var target = serializer.Serialize(newArray, state);
            Assert.Equal(newArray.Type.GetElementType(), TestSerializer.MemberAdapter.GetMemberForKey<Type>(
                target.ArrayTypeKey));
            Assert.True(target.Expressions.OfType<Constant>().Any());
        }

        [Fact]
        public void NewArrayExpressionShouldDeserialize()
        {
            var newArray = Expression.NewArrayInit(
                typeof(int),
                Expression.Constant(1),
                Expression.Constant(2));

            Func<IConfigurationBuilder, IConfigurationBuilder> config = builder =>
                builder.CompressTypes(false).CompressExpressionTree(false);
            var json = Serializer.Serialize(newArray, cfg => config(cfg));
            var doc = JsonDocument.Parse(json);

            var state = config(ServiceHost.GetService<IConfigurationBuilder>()).Configure();

            var deserialized = serializer.Deserialize(
                doc.RootElement.GetProperty(nameof(Expression)), state);

            Assert.Equal(newArray.Type, deserialized.Type);
            Assert.Equal(
                newArray.Expressions.OfType<ConstantExpression>().Select(ce => ce.Value),
                deserialized.Expressions.OfType<ConstantExpression>().Select(ce => ce.Value));
        }
    }
}
