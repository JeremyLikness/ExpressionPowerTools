// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Represents a namespace.
    /// </summary>
    public class DocNamespace : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocNamespace"/> class.
        /// </summary>
        /// <param name="nspace">The namespace.</param>
        public DocNamespace(string nspace)
        {
            Name = nspace;
        }

        /// <summary>
        /// Gets or sets the <see cref="DocAssembly"/> the namespace belongs to.
        /// </summary>
        public DocAssembly Assembly { get; set; }

        /// <summary>
        /// Gets or sets the types that belong to the namespace.
        /// </summary>
        public ICollection<DocExportedType> Types { get; set; }
            = new List<DocExportedType>();

        /// <summary>
        /// Gets the unique file extension.
        /// </summary>
        public override string Extension => "n";
    }
}
