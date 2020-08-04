// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Interface for service registration.
    /// </summary>
    public interface IServiceRegistration
    {
        /// <summary>
        /// Register a service with two parameters.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the instance.</typeparam>
        /// <typeparam name="TImpl">The <see cref="Type"/> of the implementation.</typeparam>
        /// <returns>The <see cref="IServices"/> for chaining.</returns>
        IServiceRegistration Register<T, TImpl>()
            where TImpl : T;

        /// <summary>
        /// Register a service with two parameters.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the instance.</typeparam>
        /// <param name="instance">The singleton to register.</param>
        /// <returns>The <see cref="IServices"/> for chaining.</returns>
        IServiceRegistration RegisterSingleton<T>(T instance);

        /// <summary>
        /// Register a generic service.
        /// </summary>
        /// <remarks>
        /// To register a generic type, register the open type descriptor and the open
        /// implementation. Request the typed implementation.
        /// </remarks>
        /// <example>
        /// For example:
        /// <code lang="csharp"><![CDATA[
        /// registration.RegisterGeneric(typeof(IQueryHost<,>), typeof(QueryHost<,>));
        /// var target = source.GetService<IQueryHost<IdType, ICustomQueryProvider<IdType>>>(
        ///     query.Expression, provider);
        /// ]]></code>
        /// </example>
        /// <param name="signature">The interface or base type of the registration.</param>
        /// <param name="implementation">The implementation.</param>
        /// <returns>The <see cref="IServices"/> for chaining.</returns>
        IServiceRegistration RegisterGeneric(Type signature, Type implementation);
    }
}
