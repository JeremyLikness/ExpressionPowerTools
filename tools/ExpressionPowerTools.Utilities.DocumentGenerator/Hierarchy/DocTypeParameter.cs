// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// A type parameter.
    /// </summary>
    public class DocTypeParameter : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeParameter"/> class.
        /// </summary>
        public DocTypeParameter()
            : base()
        {
        }

        /// <summary>
        /// Gets the type constraints.
        /// </summary>
        public IList<TypeRef> TypeConstraints { get; private set; } = new List<TypeRef>();

        /// <summary>
        /// Gets or sets a value indicating whether the type is covariant.
        /// </summary>
        public bool IsCovariant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the type is contraviarant.
        /// </summary>
        public bool IsContravariant { get; set; }

        /// <summary>
        /// Gets the variance of the parameter.
        /// </summary>
        public string Variance => IsCovariant ? "out " : (IsContravariant ? "in " : string.Empty);

        /// <summary>
        /// Gets the unique extension.
        /// </summary>
        /// <exception cref="NotImplementedException">Throws because there are no unique files for type params.</exception>
        public override string Extension => throw new NotImplementedException();
    }
}
