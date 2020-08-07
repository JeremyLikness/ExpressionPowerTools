// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// A type parameter.
    /// </summary>
    public class DocTypeParameter : DocBase
    {
        /// <summary>
        /// Gets the unique extension.
        /// </summary>
        /// <exception cref="NotImplementedException">Throws because there are no unique files for type params.</exception>
        public override string Extension => throw new NotImplementedException();
    }
}
