using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExpressionPowerTools.Serialization.EFCore.Http.Signatures;
using qt = ExpressionPowerTools.Serialization.EFCore.Http.Tests.HttpRemoteQueryResolverTests.QueryTestCase;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers
{
    public class MockRemoteQueryClient : IRemoteQueryClient
    {
        public string CapturedPath { get; private set; }
        public qt QueryType { get; set; }
        public bool EmptyQuery { get; set; } = false;

        private string GetResult()
        {
            if (EmptyQuery)
            {
                return string.Empty;
            }

            object payload;
            switch (QueryType)
            {
                case qt.Count:
                    payload = 5;
                    break;
                case qt.Array:
                case qt.Enumerable:
                case qt.HashSet:
                case qt.List:
                    payload = TestThing.GetThings(5);
                    break;
                default:
                    payload = new TestThing();
                    break;
            }
            return JsonSerializer.Serialize(payload);            
        }

        public Task<string> FetchRemoteQueryAsync(string path, HttpContent _)
        {
            CapturedPath = path;
            return Task.FromResult(GetResult());
        }
    }
}
