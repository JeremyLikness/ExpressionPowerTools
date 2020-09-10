using System.Collections.Generic;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers
{
    public class TestCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TestProduct> Products { get; set; }
    }
}
