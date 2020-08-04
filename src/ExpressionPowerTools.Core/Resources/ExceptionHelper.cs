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
        /// Service host already initialized.
        /// </summary>
        public static readonly string
            AlreadyInitialized = nameof(AlreadyInitialized);

        /// <summary>
        /// Can't assign invalid implementation.
        /// </summary>
        public static readonly string
            InvalidGenericRegistration = nameof(InvalidGenericRegistration);

        /// <summary>
        /// The service is not registered.
        /// </summary>
        public static readonly string
            InvalidService = nameof(InvalidService);

        /// <summary>
        /// The interceptor was already registered.
        /// </summary>
        public static readonly string
            InterceptorAlreadyRegistered = nameof(InterceptorAlreadyRegistered);

        /// <summary>
        /// Service configuration in wrong state.
        /// </summary>
        public static readonly string
            InvalidConfiguration = nameof(InvalidConfiguration);

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

        /// <summary>
        /// Invalid operation messages.
        /// </summary>
        /// <param name="message">The message key.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The invalid operation.</returns>
        public static InvalidOperationException AsInvalidOperationException(
            this string message,
            params string[] parameters)
            => parameters.Length < 1 ? new InvalidOperationException(ResourceManager.GetString(message))
                : new InvalidOperationException(string.Format(ResourceManager.GetString(message), parameters));
    }
}
