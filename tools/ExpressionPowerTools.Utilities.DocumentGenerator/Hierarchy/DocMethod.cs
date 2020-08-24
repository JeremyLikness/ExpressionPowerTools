// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Represents a method on a type.
    /// </summary>
    public class DocMethod : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocMethod"/> class with
        /// the specified <see cref="DocExportedType"/>.
        /// </summary>
        /// <param name="type">The <see cref="DocExportedType"/> the method belongs to.</param>
        public DocMethod(DocExportedType type)
        {
            MethodType = type;
        }

        /// <summary>
        /// Gets the method overloads.
        /// </summary>
        public IList<DocMethodOverload> MethodOverloads { get; private set; } =
            new List<DocMethodOverload>();

        /// <summary>
        /// Gets the type the method belongs to.
        /// </summary>
        public DocExportedType MethodType { get; private set; }

        /// <summary>
        /// Gets or sets the return <see cref="Type"/> of the method.
        /// </summary>
        public TypeRef MethodReturnType { get; set; }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public override string Extension => "m";

        /// <summary>
        /// Gets the overridden filename to attach methods to related types.
        /// </summary>
        public override string FileName => $"{MethodType.Name}.{Name}.{Extension}.md";
    }
}
