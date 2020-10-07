// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace SimpleBlazorWasm.Shared
{
    /// <summary>
    /// A parameter of a <see cref="MethodThing"/>.
    /// </summary>
    public class ParameterThing
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the method id.
        /// </summary>
        public string MethodThingId { get; set; }
    }
}
