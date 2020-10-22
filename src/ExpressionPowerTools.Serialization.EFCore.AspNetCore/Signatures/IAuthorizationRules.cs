// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using Microsoft.AspNetCore.Http;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures
{
    /// <summary>
    /// Rules engine for authorization.
    /// </summary>
    public interface IAuthorizationRules
    {
        /// <summary>
        /// One time setup of the HttpContext.
        /// </summary>
        /// <param name="func">The function to return the <see cref="HttpContext"/>.</param>
        void SetContextGetter(Func<HttpContext> func);

        /// <summary>
        /// Determines whether the user is authorized to query.
        /// </summary>
        /// <returns>A value indicating whether the user is authorized.</returns>
        bool IsAuthorized();
    }
}
