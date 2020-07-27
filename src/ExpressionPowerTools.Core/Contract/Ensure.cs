// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Resources;

namespace ExpressionPowerTools.Core.Contract
{
    /// <summary>
    /// Helper methods for validation.
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Ensures that the result of an argument expression is
        /// not null.
        /// </summary>
        /// <example>
        /// <code lang="csharp">
        /// Ensure.NotNull(() => parameter);
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the value to test.</typeparam>
        /// <param name="value">An expression that resolves to the value.</param>
        public static void NotNull<T>(Expression<Func<T>> value)
        {
            var fn = value.Compile();
            if (fn() == null)
            {
                throw new ArgumentNullException(value.MemberName());
            }
        }

        /// <summary>
        /// Ensures that the result of an expression is not null.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// Ensure.VariableNotNull(() => localVariable);
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the value to test.</typeparam>
        /// <param name="value">An expression that resolves to the value.</param>
        public static void VariableNotNull<T>(Expression<Func<T>> value)
        {
            var fn = value.Compile();
            if (fn() == null)
            {
                throw ExceptionHelper
                    .NullReferenceNotAllowedException(
                    value.MemberName());
            }
        }

        /// <summary>
        /// Ensure the value is not null or whitespace.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// Ensure.NotNullOrWhiteSpace(() => value);
        /// </code>
        /// </example>
        /// <param name="value">An expression that resolves to the value.</param>
        public static void NotNullOrWhitespace(
            Expression<Func<string>> value)
        {
            var fn = value.Compile();
            if (string.IsNullOrWhiteSpace(fn()))
            {
                throw ExceptionHelper.WhitespaceNotAllowedException(
                    value.MemberName());
            }
        }
    }
}
