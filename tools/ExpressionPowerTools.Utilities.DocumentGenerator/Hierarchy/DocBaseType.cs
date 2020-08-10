// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Base document for types.
    /// </summary>
    public class DocBaseType : DocBase
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
        public IList<TypeRef> ImplementedInterfaces
        { get; set; } = new List<TypeRef>();

        /// <summary>
        /// Gets or sets the inheritance chcain.
        /// </summary>
        public IList<TypeRef> Inheritance
        { get; set; } = new List<TypeRef>();

        /// <summary>
        /// Gets or sets the list of derived types.
        /// </summary>
        public IList<TypeRef> DerivedTypes
        { get; set; } = new List<TypeRef>();

        /// <summary>
        /// Gets or sets the list of properties.
        /// </summary>
        public IList<DocProperty> Properties { get; set; } =
            new List<DocProperty>();

        /// <summary>
        /// Gets or sets the list of methods.
        /// </summary>
        public IList<DocMethod> Methods { get; set; } =
            new List<DocMethod>();

        /// <summary>
        /// Gets or sets the associated type.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets the associated type reference.
        /// </summary>
        public TypeRef TypeRef => TypeCache.Cache[Type];

        /// <summary>
        /// Gets the extension.
        /// </summary>
        public override string Extension => "t";
    }
}
