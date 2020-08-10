// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// A given constructor overload.
    /// </summary>
    public class DocOverload : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocOverload"/> class for
        /// the given <see cref="DocConstructor"/>.
        /// </summary>
        /// <param name="info">The <see cref="ConstructorInfo"/>.</param>
        /// <param name="ctor">The <see cref="DocConstructor"/>.</param>
        public DocOverload(
            ConstructorInfo info,
            DocConstructor ctor)
        {
            Ctor = info;
            Constructor = ctor;
        }

        /// <summary>
        /// Gets the constructor the overload belongs to.
        /// </summary>
        public DocConstructor Constructor { get; private set; }

        /// <summary>
        /// Gets the constructor info.
        /// </summary>
        public ConstructorInfo Ctor { get; private set; }

        /// <summary>
        /// Gets a value indicating whether it is static.
        /// </summary>
        public bool IsStatic => Ctor.IsStatic;

        /// <summary>
        /// Gets the constructor parameters.
        /// </summary>
        public IList<DocParameter> Parameters { get; private set; }
            = new List<DocParameter>();

        /// <summary>
        /// Gets the extension (not implemented).
        /// </summary>
        public override string Extension => throw new NotImplementedException();
    }
}
