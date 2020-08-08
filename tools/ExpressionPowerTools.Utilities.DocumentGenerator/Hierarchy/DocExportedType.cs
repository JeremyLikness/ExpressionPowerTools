// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// A class or intrface.
    /// </summary>
    public class DocExportedType : DocBaseType
    {
        /// <summary>
        /// Gets or sets the namespace the type belongs to.
        /// </summary>
        public DocNamespace Namespace { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DocConstructor"/>.
        /// </summary>
        public DocConstructor Constructor { get; set; }

        /// <summary>
        /// Gets the extension for a unique filename.
        /// </summary>
        public override string Extension => IsInterface ? "i" : "cs";
    }
}
