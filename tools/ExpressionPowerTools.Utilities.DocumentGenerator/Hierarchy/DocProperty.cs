// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Represents a property.
    /// </summary>
    public class DocProperty : DocBaseType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocProperty"/> class with a
        /// <see cref="DocExportedType"/>.
        /// </summary>
        /// <param name="parent">The parent <see cref="DocExportedType"/>.</param>
        public DocProperty(DocExportedType parent)
        {
            ParentType = parent;
        }

        /// <summary>
        /// Gets the parent the property belongs to.
        /// </summary>
        public DocExportedType ParentType { get; private set; }

        /// <summary>
        /// Gets the extension for properties.
        /// </summary>
        public override string Extension => "prop";
    }
}
