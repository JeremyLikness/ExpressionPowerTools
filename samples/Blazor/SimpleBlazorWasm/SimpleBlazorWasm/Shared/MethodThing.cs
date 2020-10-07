// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace SimpleBlazorWasm.Shared
{
    /// <summary>
    /// A method.
    /// </summary>
    public class MethodThing
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
        /// Gets or sets the method parameters.
        /// </summary>
        public virtual List<ParameterThing> Parameters { get; set; }
            = new List<ParameterThing>();

        /// <summary>
        /// Gets or sets the thing the method belongs to.
        /// </summary>
        public string TypeThingId { get; set; }

        /// <summary>
        /// Adds a parameter to a method.
        /// </summary>
        /// <param name="parameter">The parameter to add.</param>
        public void AddFeature(ParameterThing parameter)
        {
            parameter.MethodThingId = Id;
            Parameters.Add(parameter);
        }
    }
}
