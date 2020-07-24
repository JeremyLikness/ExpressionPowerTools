// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Resources;

namespace ExpressionPowerTools.Core.Resources
{
    /// <summary>
    /// Helper for localized exceptions.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Name of resource file.
        /// </summary>
        private static readonly string
            ExceptionResources = nameof(ExceptionResources);

        /// <summary>
        /// Whitespace message.
        /// </summary>
        private static readonly string
            WhitespaceNotAllowed = nameof(WhitespaceNotAllowed);

        /// <summary>
        /// Null reference message.
        /// </summary>
        private static readonly string
            NullReference = nameof(NullReference);

        /// <summary>
        /// Method access message.
        /// </summary>
        private static readonly string
            MethodAccessRequired = nameof(MethodAccessRequired);

        /// <summary>
        /// Path to the resource file.
        /// </summary>
        private static readonly string ResourceFile =
            typeof(ExceptionHelper).FullName
            .Replace(nameof(ExceptionHelper), ExceptionResources);

        /// <summary>
        /// Resource manager to use.
        /// </summary>
        private static readonly ResourceManager ResourceManager =
            new ResourceManager(
                ResourceFile,
                typeof(ExceptionHelper).Assembly);

        /// <summary>
        /// Generates a <see cref="ArgumentException"/> for empty string.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The <see cref="ArgumentException"/>.</returns>
        public static ArgumentException WhitespaceNotAllowedException(
            string parameterName) =>
            new ArgumentException(
                ResourceManager.GetString(WhitespaceNotAllowed),
                parameterName);

        /// <summary>
        /// Generates a <see cref="ArgumentException"/> for invalid expression.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The <see cref="ArgumentException"/>.</returns>
        public static ArgumentException MethodCallOnTypeRequiredException(
            string parameterName) =>
            new ArgumentException(
                ResourceManager.GetString(MethodAccessRequired),
                parameterName);

        /// <summary>
        /// Null reference exception.
        /// </summary>
        /// <param name="memberName">The member that is null.</param>
        /// <returns>A <see cref="NullReferenceException"/>.</returns>
        public static NullReferenceException NullReferenceNotAllowedException(
            string memberName) =>
            new NullReferenceException(
                string.Format(
                    ResourceManager.GetString(NullReference),
                    memberName));
    }
}
