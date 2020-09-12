// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using Microsoft.EntityFrameworkCore;

namespace SimpleBlazorWasm.Shared
{
    /// <summary>
    /// Simple <see cref="DbContext"/>.
    /// </summary>
    public class ThingContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThingContext"/> class.
        /// </summary>
        public ThingContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThingContext"/> class with
        /// <see cref="DbContextOptions{TContext}"/>.
        /// </summary>
        /// <param name="options">The optoins.</param>
        public ThingContext(DbContextOptions<ThingContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of things.
        /// </summary>
        public DbSet<Thing> Things { get; set; }
    }
}
