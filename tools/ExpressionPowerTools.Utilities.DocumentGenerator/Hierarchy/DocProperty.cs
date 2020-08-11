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
        /// Gets or sets the associated type parameter.
        /// </summary>
        public DocTypeParameter TypeParameter { get; set; }

        /// <summary>
        /// Gets the parent the property belongs to.
        /// </summary>
        public DocExportedType ParentType { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is an indexer.
        /// </summary>
        public bool IsIndexer { get; set; }

        /// <summary>
        /// Gets or sets the type of the index.
        /// </summary>
        public TypeRef IndexerType { get; set; }

        /// <summary>
        /// Gets the name showing the indexer.
        /// </summary>
        public string IndexName => $"[{IndexerType?.FriendlyName}]";

        /// <summary>
        /// Gets the extension for properties.
        /// </summary>
        public override string Extension => "prop";
    }
}
