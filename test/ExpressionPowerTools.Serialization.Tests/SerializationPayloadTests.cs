using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using ExpressionPowerTools.Serialization.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SerializationPayloadTests
    {
        private IQueryable query => TestableThing.MakeQuery()
            .Where(t => (!t.IsActive && t.Id.Contains("aa") &&
            t.Value < int.MaxValue) || t.IsActive)
            .Select(t => new { t.Id, t.Value })
            .OrderBy(t => t.Id)
            .ThenByDescending(t => t.Value)
            .Skip(2)
            .Take(10);

        private string Json => Serializer.Serialize(query);
        
        [Fact]
        public void GivenSerializationPayloadWhenSerializedThenShouldDeserialize()
        {
            var target = new SerializationPayload { Json = Json };
            var serialized = JsonSerializer.Serialize(target);
            Assert.True(!string.IsNullOrWhiteSpace(serialized));
            var deserialized = JsonSerializer.Deserialize<SerializationPayload>(serialized);
            Assert.Equal(Json, deserialized.Json);
        }

        [Theory]
        [InlineData(PayloadType.Array)]
        [InlineData(PayloadType.Count)]
        [InlineData(PayloadType.Single)]
        public void GivenPayloadWhenInitializedThenSetsPayloadValue(PayloadType type)
        {
            var target = new SerializationPayload(type);
            Assert.Equal((int)type, target.QueryType);
        }

        [Theory]
        [InlineData(PayloadType.Array)]
        [InlineData(PayloadType.Count)]
        [InlineData(PayloadType.Single)]
        public void GivenPayloadWhenInitializedThenGetQueryTypeGetsPayloadValue(PayloadType type)
        {
            var target = new SerializationPayload(type);
            Assert.Equal(type, target.GetQueryType());
        }

    }
}
