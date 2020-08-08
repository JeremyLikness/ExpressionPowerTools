// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Represents an assembly to document.
    /// </summary>
    public class DocAssembly : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocAssembly"/> class.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to reference.</param>
        public DocAssembly(string assemblyName)
        {
            Name = assemblyName;
        }

        /// <summary>
        ///
        /// Gets or sets the list of <see cref="DocNamespace"/> instances.
        /// </summary>
        public ICollection<DocNamespace> Namespaces { get; set; } =
            new List<DocNamespace>();

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public override string Extension => "a";

        /// <summary>
        /// String representation.
        /// </summary>
        /// <returns>The filename.</returns>
        public override string ToString() => FileName;
    }
}
