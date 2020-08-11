// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Represents an overload of a <see cref="DocMethod"/>.
    /// </summary>
    public class DocMethodOverload : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocMethodOverload"/> class for
        /// the given <see cref="DocMethod"/>.
        /// </summary>
        /// <param name="info">The <see cref="MethodInfo"/>.</param>
        /// <param name="method">The <see cref="DocMethod"/>.</param>
        public DocMethodOverload(
            MethodInfo info,
            DocMethod method)
        {
            Info = info;
            Method = method;
        }

        /// <summary>
        /// Gets the constructor the overload belongs to.
        /// </summary>
        public DocMethod Method { get; private set; }

        /// <summary>
        /// Gets the constructor info.
        /// </summary>
        public MethodInfo Info { get; private set; }

        /// <summary>
        /// Gets the overload parameters.
        /// </summary>
        public IList<DocParameter> Parameters { get; private set; }
            = new List<DocParameter>();

        /// <summary>
        /// Gets or sets the return comments.
        /// </summary>
        public string Returns { get; set; }

        /// <summary>
        /// Gets the terse name for display.
        /// </summary>
        public string TerseName
        {
            get
            {
                var idx = Name.IndexOf(Info.Name);
                return Name.Substring(idx);
            }
        }

        /// <summary>
        /// Gets the extension (not implemented).
        /// </summary>
        public override string Extension => throw new NotImplementedException();
    }
}
