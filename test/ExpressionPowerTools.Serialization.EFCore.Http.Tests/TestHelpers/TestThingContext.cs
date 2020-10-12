using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers
{
    public class TestThingContext : DbContext
    {
        public TestThingContext()
        {
        }

        public TestThingContext(DbContextOptions<TestThingContext> options):
            base(options)
        {
        }

        public DbSet<TestThing> Things { get; set; }

        public string NotThings { get; set; }
    }
}
