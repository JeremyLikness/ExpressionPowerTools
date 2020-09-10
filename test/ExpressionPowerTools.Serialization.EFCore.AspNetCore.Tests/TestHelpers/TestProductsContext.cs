using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers
{
    public class TestProductsContext : DbContext
    {
        public TestProductsContext()
        {
        }

        public TestProductsContext(DbContextOptions<TestProductsContext> options) : base(options)
        {
        }

        public DbSet<TestCategory> Categories { get; set; }
        public DbSet<TestProduct> Products { get; set; }
    }
}
