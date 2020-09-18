// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Helper class to cache <see cref="Type"/> and <see cref="MethodInfo"/> information.
    /// </summary>
    public class ReflectionHelper : IReflectionHelper
    {
       /// <summary>
        /// Gets the <see cref="BindingFlags"/> for public instance and static.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public BindingFlags AllPublic { get; private set; } =
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        /// <summary>
        /// Finds the generic counterpart of a <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> to check.</param>
        /// <param name="genericType">The generic <see cref="Type"/>.</param>
        /// <returns>The correleated member.</returns>
        public MemberInfo FindGenericVersion(MemberInfo member, Type genericType = null)
        {
            if (genericType == null)
            {
                var memberType = member is Type type ?
                    type : member.DeclaringType;
                if (memberType.IsGenericType && !memberType.IsGenericTypeDefinition)
                {
                    genericType = memberType.GetGenericTypeDefinition();
                }
            }

            if (genericType == null)
            {
                return null;
            }

            if (member is Type)
            {
                return genericType;
            }

            if (member is FieldInfo field)
            {
                return genericType.GetField(field.Name, AllPublic);
            }

            if (member is PropertyInfo property)
            {
                return genericType.GetProperty(property.Name, AllPublic);
            }

            if (member is ConstructorInfo constructorInfo)
            {
                var parameterCount = constructorInfo.GetParameters().Count();
                var parameterNames = constructorInfo.GetParameters()
                    .Select(p => p.Name).ToArray();
                var parameterTypes = constructorInfo.GetParameters()
                    .Select(p => p.ParameterType).ToArray();

                foreach (var candidate in genericType.GetConstructors()
                    .Where(m =>
                        m.GetParameters().Count() == parameterCount &&
                        !m.GetParameters().Select(p => p.Name).Except(parameterNames).Any()))
                {
                    if (parameterCount > 0)
                    {
                        var ctorParams = candidate.GetParameters().Select(p => p.ParameterType)
                                .ToArray();

                        // types match? we're done
                        if (ctorParams.Except(parameterTypes).Any())
                        {
                            // make the source generic to check for match
                            var typeParams = genericType.GetGenericArguments();

                            // now turn the closed parameters into type parameters
                            var resolvedParams = member.DeclaringType.GetGenericArguments();

                            for (var idx = 0; idx < typeParams.Length; idx += 1)
                            {
                                parameterTypes = parameterTypes.Select(
                                    p => p == resolvedParams[idx] ? typeParams[idx] : p).ToArray();
                            }

                            if (!ctorParams.Except(parameterTypes).Any())
                            {
                                return candidate;
                            }
                        }
                        else
                        {
                            return candidate;
                        }
                    }
                    else
                    {
                        return candidate;
                    }
                }

                return null;
            }

            if (member is MethodInfo methodInfo)
            {
                var parameterCount = methodInfo.GetParameters().Count();
                var parameterNames = methodInfo.GetParameters()
                    .Select(p => p.Name).ToArray();

                var candidate = genericType.GetMethods(AllPublic)
                    .FirstOrDefault(m =>
                        m.IsStatic == methodInfo.IsStatic &&
                        m.Name == methodInfo.Name &&
                        m.GetParameters().Count() == parameterCount &&
                        !m.GetParameters().Select(p => p.Name).Except(parameterNames).Any());

                return candidate;
            }

            return null;
        }
    }
}
