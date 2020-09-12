// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Queryable
{
    /// <summary>
    /// Holds the remote context for the query.
    /// </summary>
    public class RemoteContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteContext"/> class with the
        /// type of the <see cref="DbContext"/> and the property info.
        /// </summary>
        /// <param name="context">The type of <see cref="DbContext"/>.</param>
        /// <param name="collection">The property for the <c>DbSet</c>.</param>
        public RemoteContext(Type context, PropertyInfo collection)
        {
            Context = context;
            Collection = collection;
        }

        /// <summary>
        /// Gets the type of the <see cref="DbContext"/>.
        /// </summary>
        public Type Context { get; private set; }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> for the collection.
        /// </summary>
        public PropertyInfo Collection { get; private set; }
    }
}
