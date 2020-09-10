// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using Microsoft.AspNetCore.Routing;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware
{
    /// <summary>
    /// Parses the path for context and collection.
    /// </summary>
    public class RouteProcessor : IRouteProcessor
    {
        /// <summary>
        /// Parses the required segments from the path.
        /// </summary>
        /// <remarks>
        /// Expected is <c>/root/contextName/collectionName</c>.
        /// </remarks>
        /// <param name="values">The route values.</param>
        /// <returns>The parsed portions.</returns>
        public (string context, string collection) ParseRoute(RouteValueDictionary values)
        {
            if (values == null)
            {
                return (null, null);
            }

            string context = values.ContainsKey(MiddlewareExtensions.Context) ?
                values[MiddlewareExtensions.Context].ToString() : null;

            string collection = values.ContainsKey(MiddlewareExtensions.Collection) ?
                values[MiddlewareExtensions.Collection].ToString() : null;

            return (context, collection);
        }
    }
}
