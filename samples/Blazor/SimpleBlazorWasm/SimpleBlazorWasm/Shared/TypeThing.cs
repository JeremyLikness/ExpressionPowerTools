// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace SimpleBlazorWasm.Shared
{
    /// <summary>
    /// A thing.
    /// </summary>
    public class TypeThing
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date is was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the list of widgets.
        /// </summary>
        public virtual List<MethodThing> Methods { get; set; } =
            new List<MethodThing>();

        /// <summary>
        /// Adds a method.
        /// </summary>
        /// <param name="method">The method.</param>
        public void AddWidget(MethodThing method)
        {
            method.TypeThingId = Id;
            Methods.Add(method);
        }
    }
}
