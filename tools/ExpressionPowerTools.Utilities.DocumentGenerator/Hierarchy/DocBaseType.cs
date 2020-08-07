// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Base document for types.
    /// </summary>
    public abstract class DocBaseType : DocBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the type is an interface.
        /// </summary>
        public bool IsInterface { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the type is an enumeration.
        /// </summary>
        public bool IsEnum { get; set; }

        /// <summary>
        /// Gets a value indicating whether the type is a class.
        /// </summary>
        public bool IsClass => !IsInterface && !IsEnum;

        /// <summary>
        /// Gets or sets the list of implemented interfaces.
        /// </summary>
        public IList<(string name, string displayName)> ImplementedInterfaces
        { get; set; } = new List<(string name, string displayName)>();

        /// <summary>
        /// Gets or sets the inheritance chcain.
        /// </summary>
        public IList<(string name, string displayName)> Inheritance
        { get; set; } = new List<(string name, string displayName)>();

        /// <summary>
        /// Gets or sets the list of derived types.
        /// </summary>
        public IList<(string name, string displayName)> DerivedTypes
        { get; set; } = new List<(string name, string displayName)>();

        /// <summary>
        /// Gets or sets the user-friendly name for the type.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the code snippet that defines the type.
        /// </summary>
        public string Code { get; set; }
    }
}
