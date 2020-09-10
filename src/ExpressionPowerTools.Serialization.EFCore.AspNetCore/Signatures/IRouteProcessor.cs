// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using Microsoft.AspNetCore.Routing;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures
{
    /// <summary>
    /// Interface for extracting information from the route.
    /// </summary>
    public interface IRouteProcessor
    {
        /// <summary>
        /// Parse the path for segments.
        /// </summary>
        /// <remarks>
        /// Expects it in the format <c>/root/contextName/collectionName</c>.
        /// </remarks>
        /// <param name="route">The route.</param>
        /// <returns>A tuple with the name of the <c>DbContext</c> and the collection.</returns>
        (string context, string collection) ParseRoute(RouteValueDictionary route);
    }
}
