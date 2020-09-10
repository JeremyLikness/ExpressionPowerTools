using System;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers
{
    public class TestWidgetsContext : DbContext
    {
        public TestWidgetsContext()
        {
        }

        public TestWidgetsContext(DbContextOptions<TestWidgetsContext> options)
            : base(options)
        {
        }

        public string Decoy { get => Guid.NewGuid().ToString(); }

        public DbSet<TestWidget> Widgets { get; set; }
    }
}
