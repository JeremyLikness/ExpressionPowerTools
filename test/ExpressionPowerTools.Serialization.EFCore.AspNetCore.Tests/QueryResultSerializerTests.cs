using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class QueryResultSerializerTests
    {
        private readonly IQueryResultSerializer target =
            new QueryResultSerializer();

        private readonly TestWidget[] Widgets = new TestWidget[]
        {
            new TestWidget { Id = Guid.NewGuid(), Name = nameof(QueryResultSerializerTests) },
            new TestWidget { Id = Guid.NewGuid(), Name = nameof(target) }
        };

        private IQueryable getOne() => Widgets.AsQueryable().Skip(1);

        [Fact]
        public void GivenNullStreamWhenSerializeAsyncCalledThenShouldThrowArgumentNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await target.SerializeAsync(null, getOne()));
        }

        [Fact]
        public void GivenNullQueryWhenSerializeAsyncCalledThenShouldThrowArgumentException()
        {
            using var stream = new MemoryStream();
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await target.SerializeAsync(stream, null));
        }

        [Fact]
        public async Task GivenValidParametersWhenSerializeAsyncCalledThenShouldSerializeToStream()
        {
            using var stream = new MemoryStream();
            await target.SerializeAsync(stream, getOne());
            stream.Flush();
            stream.Position = 0;
            string json;
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            var widgets = JsonSerializer.Deserialize<TestWidget[]>(json);
            Assert.NotNull(widgets);
            Assert.Single(widgets);
        }

        [Fact]
        public async Task GivenValidParametersWithIsCountTrueWhenSerializeAsyncCalledThenShouldSerializeToStream()
        {
            using var stream = new MemoryStream();
            await target.SerializeAsync(stream, Widgets.AsQueryable(), true);
            stream.Flush();
            stream.Position = 0;
            string json;
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            var widgets = JsonSerializer.Deserialize<long>(json);
            Assert.Equal(Widgets.Length, widgets);
            stream.Dispose();
        }
    }
}
