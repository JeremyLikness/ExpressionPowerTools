// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// A reference to a type.
    /// </summary>
    public class TypeRef
    {
        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the full name of the type. Can be null for type parameter.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the friendly, recursed name with generic type annotations.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the link to the type.
        /// </summary>
        public string Link { get; set; }
    }
}
