// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Serialization cross-reference.
    /// </summary>
    public class DocSerialization : DocBase
    {
        /// <summary>
        /// Gets the list of serializers.
        /// </summary>
        public Dictionary<ExpressionType, DocExportedType> Serializers
        { get; private set; } =
            new Dictionary<ExpressionType, DocExportedType>();

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public override string Extension => "ser";
    }
}
