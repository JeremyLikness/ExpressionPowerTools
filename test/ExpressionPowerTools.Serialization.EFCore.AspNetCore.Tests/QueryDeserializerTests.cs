using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers;
using ExpressionPowerTools.Serialization.Json;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class QueryDeserializerTests
    {
        private readonly IQueryDeserializer target = new QueryDeserializer();

        private readonly JsonWrapper jsonWrapper = new JsonWrapper();

        private readonly IQueryable queryable = new List<TestWidget>()
            .AsQueryable();

        private readonly IQueryable query =
            new List<TestWidget>().AsQueryable()
            .Where(w => w.Id.ToString().Contains("aa") &&
            w.Name.StartsWith("T")).OrderBy(w => w.Name);

        private string GetJson(bool isCount = false) =>
            JsonSerializer.Serialize(
                new SerializationPayload(isCount ? PayloadType.Count : PayloadType.Array)
                {
                    Json = jsonWrapper.FromSerializationRoot(QueryExprSerializer.Serialize(query)),
                });

        private readonly string EmptyJson = "{}";

        private readonly string EmptyPayload =
            JsonSerializer.Serialize(new SerializationPayload());

        private Stream GetStream(string json = null) =>
            new MemoryStream(Encoding.UTF8.GetBytes(
                json ?? GetJson()));

        [Fact]
        public void GivenNullQueryWhenDeserializeAsyncCalledThenShouldThrowArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await target.DeserializeAsync(null, GetStream()));
        }

        [Fact]
        public void GivenNullStreamWhenDeserializeAsyncCalledThenShouldThrowArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await target.DeserializeAsync(query, null));
        }

        [Fact]
        public void GivenJsonNotSerializationPayloadWhenDeserializeAsyncCalledThenShouldThrowNullReference()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
            await target.DeserializeAsync(query, GetStream(EmptyJson)));
        }

        [Fact]
        public void GivenNoJsonPayloadWhenDeserializeAsyncCalledThenShouldThrowArgument()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            await target.DeserializeAsync(query, GetStream(EmptyPayload)));
        }

        [Fact]
        public async Task GivenValidInputsWhenDeserializeAsyncCalledThenShouldDeserializeQueryable()
        {
            var actual = await target.DeserializeAsync(queryable, GetStream(GetJson()));
            Assert.Equal(PayloadType.Array, actual.QueryType);
            Assert.True(query.IsEquivalentTo(actual.Query));
        }

        [Fact]
        public async Task GivenIsCountTrueInPayloadWhenDeserializeAsyncCalledThenShouldReturnIsCountTrue()
        {
            var actual = await target.DeserializeAsync(queryable, GetStream(GetJson(true)));
            Assert.Equal(PayloadType.Count, actual.QueryType);
            Assert.True(query.IsEquivalentTo(actual.Query));
        }
    }
}
