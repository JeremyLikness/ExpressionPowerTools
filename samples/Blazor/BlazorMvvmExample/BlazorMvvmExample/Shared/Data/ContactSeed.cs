// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;

namespace BlazorMvvmExample.Shared.Data
{
    /// <summary>
    /// Generate random <see cref="Contact"/> entities.
    /// </summary>
    public static class ContactSeed
    {
        /// <summary>
        /// Use these to make names.
        /// </summary>
        private static readonly string[] Gems = new[]
        {
            "Diamond",
            "Crystal",
            "Morion",
            "Azore",
            "Sapphire",
            "Cobalt",
            "Aquamarine",
            "Montana",
            "Turquoise",
            "Lime",
            "Erinite",
            "Emerald",
            "Turmaline",
            "Jonquil",
            "Olivine",
            "Topaz",
            "Citrine",
            "Sun",
            "Quartz",
            "Opal",
            "Alabaster",
            "Rose",
            "Burgundy",
            "Siam",
            "Ruby",
            "Amethyst",
            "Violet",
            "Lilac",
        };

        /// <summary>
        /// Combined with things for last names.
        /// </summary>
        private static readonly string[] Colors = new[]
        {
            "Blue",
            "Aqua",
            "Red",
            "Green",
            "Orange",
            "Yellow",
            "Black",
            "Violet",
            "Brown",
            "Crimson",
            "Gray",
            "Hazel",
            "Cyan",
            "Magenta",
            "White",
            "Gold",
            "Pink",
            "Lavender",
        };

        /// <summary>
        /// Also helpful for names.
        /// </summary>
        private static readonly string[] Things = new[]
        {
            "beard",
            "finger",
            "hand",
            "toe",
            "stalk",
            "hair",
            "vine",
            "street",
            "son",
            "brook",
            "river",
            "lake",
            "stone",
            "ship",
            "hammer",
            "tree",
            "hill",
        };

        /// <summary>
        /// Street names.
        /// </summary>
        private static readonly string[] Streets = new[]
        {
            "Broad",
            "Wide",
            "Main",
            "Pine",
            "Ash",
            "Birch",
            "Elm",
            "Poplar",
            "First",
            "Third",
        };

        /// <summary>
        /// Types of streets.
        /// </summary>
        private static readonly string[] StreetTypes = new[]
        {
            "Street",
            "Lane",
            "Place",
            "Terrace",
            "Drive",
            "Way",
        };

        /// <summary>
        /// More uniqueness.
        /// </summary>
        private static readonly string[] Directions = new[]
        {
            "N",
            "NE",
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
        };

        /// <summary>
        /// A sampling of cities.
        /// </summary>
        private static readonly string[] Cities = new[]
        {
            "Austin",
            "Denver",
            "Deadwood",
            "Colorado Springs",
            "Granite Falls",
            "Portland",
            "Monroe",
            "Redmond",
            "Bothel",
            "Woodinville",
            "Kent",
            "Kennesaw",
            "Marietta",
            "Atlanta",
            "Lead",
            "Spokane",
            "Bellevue",
            "Seattle",
        };

        /// <summary>
        /// State list.
        /// </summary>
        private static readonly string[] States = new[]
        {
            "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL",
            "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA",
            "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE",
            "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK",
            "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT",
            "VA", "WA", "WV", "WI", "WY",
        };

        /// <summary>
        /// Get some randominzation in play.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Identifier.
        /// </summary>
        private static int id = 1;

        /// <summary>
        /// Gets generator for identifier.
        /// </summary>
        private static int IdGenerator => id++;

        /// <summary>
        /// Extension method to check and seed the database.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> for dependency injection.</param>
        public static void CheckAndSeedContacts(this IServiceProvider provider)
        {
            using (var ctx = provider.GetService(typeof(ContactContext)) as ContactContext)
            {
                ctx.CheckAndSeed();
            }
        }

        /// <summary>
        /// Generate random <see cref="Contact"/> instances and batch insert.
        /// </summary>
        /// <param name="totalCount">The count of contacts to generate.</param>
        /// <returns>A list of <see cref="Contact"/>.</returns>
        public static List<Contact> GetContacts(int totalCount)
        {
            var result = new List<Contact>();
            var count = 0;
            while (count++ < totalCount)
            {
                result.Add(MakeContact());
            }

            return result;
        }

        /// <summary>
        /// Picks a random item from a list.
        /// </summary>
        /// <param name="list">A list of <c>string</c> to parse.</param>
        /// <returns>A single item from the list.</returns>
        private static string RandomOne(string[] list)
        {
            var idx = Random.Next(list.Length - 1);
            return list[idx];
        }

        /// <summary>
        /// Make a new contact.
        /// </summary>
        /// <returns>A random <see cref="Contact"/> instance.</returns>
        private static Contact MakeContact()
        {
            var contact = new Contact
            {
                Id = IdGenerator,
                FirstName = RandomOne(Gems),
                LastName = $"{RandomOne(Colors)}{RandomOne(Things)}",
                Phone = $"({Random.Next(100, 999)})-555-{Random.Next(1000, 9999)}",
                Street = $"{Random.Next(1, 99999)} {Random.Next(1, 999)}" +
                $" {RandomOne(Streets)} {RandomOne(StreetTypes)} {RandomOne(Directions)}",
                City = RandomOne(Cities),
                State = RandomOne(States),
                ZipCode = $"{Random.Next(10000, 99999)}",
            };
            return contact;
        }
    }
}
