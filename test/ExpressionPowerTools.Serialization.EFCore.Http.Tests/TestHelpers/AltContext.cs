using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers
{
    public class AltContext : DbContext
    {
        public AltContext()
        {
        }

        public AltContext(DbContextOptions<AltContext> options) :
            base(options)
        {
        }

        public DbSet<TestThing> AltThings { get; set; }
    }
}
