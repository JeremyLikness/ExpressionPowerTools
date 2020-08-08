// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Document representing public constructors for a type.
    /// </summary>
    public class DocConstructor : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocConstructor"/> class with
        /// the specified <see cref="DocExportedType"/>.
        /// </summary>
        /// <param name="type">The <see cref="DocExportedType"/> the constructor is for.</param>
        public DocConstructor(DocExportedType type)
        {
            ConstructorType = type;
        }

        /// <summary>
        /// Gets the constructor overloads.
        /// </summary>
        public IList<DocOverload> Overloads { get; private set; } =
            new List<DocOverload>();

        /// <summary>
        /// Gets the type the constructors belong to.
        /// </summary>
        public DocExportedType ConstructorType { get; private set; }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public override string Extension => "ctor";
    }
}
