// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Helper class to cache <see cref="Type"/> and <see cref="MethodInfo"/> information.
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Type cache.
        /// </summary>
        private readonly IDictionary<string, Type> types = new
            Dictionary<string, Type>();

        /// <summary>
        /// Object for locking access to dictionary.
        /// </summary>
        private readonly object lockObj = new object();

        /// <summary>
        /// Method cache.
        /// </summary>
        private readonly IDictionary<int, MethodInfo> methods = new
            Dictionary<int, MethodInfo>();

        /// <summary>
        /// Gets the static instance.
        /// </summary>
        public static ReflectionHelper Instance { get; private set; }
            = new ReflectionHelper();

        /// <summary>
        /// Get a <see cref="Type"/> based on full name.
        /// </summary>
        /// <remarks>
        /// This will check the cache first, then try to create the type, and
        /// finally will scan all assemblies for the type.
        /// </remarks>
        /// <param name="name">The full name of the <see cref="Type"/>.</param>
        /// <returns>The <see cref="Type"/> or <c>null</c>.</returns>
        public Type GetTypeFromCache(string name)
        {
            if (types.ContainsKey(name))
            {
                return types[name];
            }

            var result = Type.GetType(name);

            if (result == null)
            {
                result = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.FullName == name);
            }

            if (result == null)
            {
                return null;
            }

            SafeMutate(
                () => !types.ContainsKey(name),
                () => types.Add(name, result));

            return types[name];
        }

        /// <summary>
        /// Gets the <see cref="MethodInfo"/> based on the hash computed
        /// by the <see cref="Method"/> signature.
        /// </summary>
        /// <param name="method">The <see cref="Method"/> template to use.</param>
        /// <returns>The <see cref="MethodInfo"/>.</returns>
        public MethodInfo GetMethodFromCache(Method method)
        {
            var hash = method.GetHashCode();
            if (methods.ContainsKey(hash))
            {
                return methods[hash];
            }

            var type = GetTypeFromCache(method.DeclaringType);
            if (type == null)
            {
                return null;
            }

            MethodInfo[] methodSearch;
            if (method.IsStatic)
            {
                methodSearch = type.GetMethods(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Static);
            }
            else
            {
                methodSearch = type.GetMethods();
            }

            var target = methodSearch.FirstOrDefault(
                m => new Method(m).GetHashCode() == hash);
            if (target != null)
            {
                SafeMutate(
                    () => !methods.ContainsKey(hash),
                    () => methods.Add(hash, target));
                return target;
            }

            return null;
        }

        /// <summary>
        /// Safely mutate the dictionary.
        /// </summary>
        /// <param name="test">Test that must pass.</param>
        /// <param name="action">The action to take.</param>
        private void SafeMutate(Func<bool> test, Action action)
        {
            if (test())
            {
                Monitor.Enter(lockObj);

                try
                {
                    if (test())
                    {
                        action();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Monitor.Exit(lockObj);
                }
            }
        }
    }
}
