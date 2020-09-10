using System.Text.Json.Serialization;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers
{
    public class TestProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual TestCategory Category { get; set; }
    }
}
