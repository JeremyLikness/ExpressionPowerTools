// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Base documentation class that contains most common properties that may be needed.
    /// </summary>
    public abstract class DocBase
    {
        /// <summary>
        /// Gets or sets name of the item.
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the code snippet that defines the type.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        public virtual string Remarks { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the example text.
        /// </summary>
        public virtual string Example { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of extensions that reference the type.
        /// </summary>
        public IList<TypeRef> Extensions { get; set; } = new List<TypeRef>();

        /// <summary>
        /// Gets or sets the list of exceptions that may be thrown.
        /// </summary>
        public virtual IList<(string exception, string description)> Exceptions { get; set; } =
            new List<(string exception, string description)>();

        /// <summary>
        /// Gets or sets the list of type parameters.
        /// </summary>
        public IList<DocTypeParameter> TypeParameters { get; set; } = new List<DocTypeParameter>();

        /// <summary>
        /// Gets the unique document extension.
        /// </summary>
        public abstract string Extension { get; }

        /// <summary>
        /// Gets the filename constructed from type and extension.
        /// </summary>
        public string FileName => $"{Name}.{Extension}.md";

        /// <summary>
        /// Gets or sets the XPath to the element in documentation.
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// String display.
        /// </summary>
        /// <returns>The type and the name.</returns>
        public override string ToString() => $"{GetType()}:{Name}";
    }
}
