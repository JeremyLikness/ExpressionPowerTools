// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using Microsoft.EntityFrameworkCore;

namespace BlazorMvvmExample.Shared.Data
{
    /// <summary>
    /// Data context for <see cref="Contact"/>.
    /// </summary>
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactContext"/> class.
        /// </summary>
        public ContactContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactContext"/> class.
        /// </summary>
        /// <param name="options">The database configuration options.</param>
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets access to the <see cref="Contact"/> collection.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Check to see if the database exists and seed it with initial data.
        /// </summary>
        public void CheckAndSeed()
        {
            if (Database.EnsureCreated())
            {
                Contacts.AddRange(ContactSeed.GetContacts(500));
                SaveChanges();
            }
        }
    }
}
