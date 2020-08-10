// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Saves the "user-friendly" type and link.
    /// </summary>
    public class TypeCache
    {
        /// <summary>
        /// Base API URL for Microsoft documentation.
        /// </summary>
        private const string MsftApiBaseRef = "https://docs.microsoft.com/dotnet/api/";

        /// <summary>
        /// The cache. Maps type to user-friendly name and link.
        /// </summary>
        private readonly IDictionary<Type, TypeRef> cache =
            new Dictionary<Type, TypeRef>();

        /// <summary>
        /// Maps text type to the actual type.
        /// </summary>
        private readonly IDictionary<string, Type> stringToType =
            new Dictionary<string, Type>();

        /// <summary>
        /// List of assemblies for types.
        /// </summary>
        private readonly IList<DocAssembly> assemblies
            = new List<DocAssembly>();

        /// <summary>
        /// Gets the global cache instance.
        /// </summary>
        public static TypeCache Cache { get; private set; } = new TypeCache();

        /// <summary>
        /// Gets the count of cached types.
        /// </summary>
        public int TypeCount => cache.Keys.Count();

        /// <summary>
        /// Indexer to type cache.
        /// </summary>
        /// <remarks>
        /// Contains the logic for "one-sided" assignments, i.e. add type name
        /// without link or vice versa. On a get, will generate the needed links
        /// when not present.
        /// </remarks>
        /// <param name="index">The <see cref="Type"/> to reference.</param>
        /// <returns>The cache entry (type name and link).</returns>
        public TypeRef this[Type index]
        {
            get
            {
                var result = cache.ContainsKey(index) ?
                    cache[index] : new TypeRef
                    {
                        Name = index.Name,
                        FullName = index.FullName,
                    };

                if (string.IsNullOrWhiteSpace(result.FriendlyName))
                {
                    result.FriendlyName = BuildTypeName(index);
                }

                if (string.IsNullOrWhiteSpace(result.Link))
                {
                    result.Link = ExtractLinkForType(index);
                }

                cache[index] = result;
                return result;
            }

            set
            {
                if (cache.ContainsKey(index))
                {
                    if (string.IsNullOrWhiteSpace(value.FriendlyName) ||
                        string.IsNullOrWhiteSpace(value.Link))
                    {
                        var typeRef = cache[index];
                        if (!string.IsNullOrWhiteSpace(value.FriendlyName))
                        {
                            typeRef.FriendlyName = value.FriendlyName;
                        }

                        if (!string.IsNullOrWhiteSpace(value.Link))
                        {
                            typeRef.Link = value.Link;
                        }

                        return;
                    }
                }

                cache[index] = value;
            }
        }

        /// <summary>
        /// Register the <see cref="DocAssembly"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="DocAssembly"/> to register.</param>
        public void RegisterAssembly(DocAssembly assembly) =>
            assemblies.Add(assembly);

        /// <summary>
        /// Gets the friendly (with generic parameters) name for the method.
        /// </summary>
        /// <param name="method">The <see cref="MethodInfo"/> to parse.</param>
        /// <returns>The friendly type name.</returns>
        public string GetFriendlyMethodName(MethodInfo method)
            => BuildTypeName(method);

        /// <summary>
        /// Get a <see cref="Type"/> from the name.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <returns>The <see cref="Type"/>, if found, else null.</returns>
        public Type GetTypeFromName(string name)
        {
            if (stringToType.ContainsKey(name))
            {
                return stringToType[name];
            }

            var type = Type.GetType(name);

            if (type != null)
            {
                stringToType[name] = type;
                return type;
            }

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(name);
                if (type != null)
                {
                    stringToType[name] = type;
                    return type;
                }
            }

            return null;
        }

        /// <summary>
        /// Process a type name to something user-friend like.
        /// </summary>
        /// <example>
        /// For example, a type name might look like:
        /// <code><![CDATA[
        /// IQueryHost`2
        /// ]]></code>
        /// The call to this method will produce:
        /// <code><![CDATA[
        /// IQueryHost<T, ICustomQueryProvider<T>>
        /// ]]></code>
        /// </example>
        /// <param name="type">The type to process.</param>
        /// <returns>The user and code-friendly type name.</returns>
        private string BuildTypeName(MemberInfo type)
        {
            var sb = new StringBuilder();
            string rootName = "Unknown";
            var generic = false;
            Type[] genericArguments = new Type[0];

            if (type is Type typeInfo)
            {
                var name = typeInfo.FullName ?? typeInfo.Name;
                var withoutGeneric = name.Split('`')[0];
                rootName = withoutGeneric.Split('.')[^1];
                generic = typeInfo.IsGenericType || typeInfo.IsGenericTypeDefinition;
                if (generic)
                {
                    genericArguments = typeInfo.GetGenericArguments();
                }
            }
            else if (type is MethodInfo method)
            {
                rootName = method.Name;
                generic = method.IsGenericMethod || method.IsConstructedGenericMethod;
                if (generic)
                {
                    genericArguments = method.GetGenericArguments();
                }
            }

            sb.Append(rootName);

            if (generic)
            {
                sb.Append("<");
                var parameters = genericArguments;
                var first = true;
                foreach (Type paramType in parameters)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }

                    if (paramType.IsGenericParameter)
                    {
                        if ((paramType.GenericParameterAttributes & GenericParameterAttributes.Covariant) > 0)
                        {
                            sb.Append("out ");
                        }
                        else if ((paramType.GenericParameterAttributes & GenericParameterAttributes.Contravariant) > 0)
                        {
                            sb.Append("in ");
                        }

                        sb.Append(paramType.Name);
                    }
                    else
                    {
                        sb.Append(BuildTypeName(paramType));
                    }
                }

                sb.Append(">");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates the appropriate link for a type.
        /// </summary>
        /// <param name="type">The name of the type.</param>
        /// <returns>The link.</returns>
        private string ExtractLinkForType(Type type)
        {
            if (type.IsGenericType)
            {
                type = type.GetGenericTypeDefinition();
            }

            var localType = assemblies.SelectMany(a => a.Namespaces)
                .SelectMany(ns => ns.Types)
                .FirstOrDefault(t => t.Name == type.FullName);

            if (localType != null)
            {
                return localType.FileName;
            }
            else
            {
                if (type.FullName == null)
                {
                    return string.Empty;
                }

                return $"{MsftApiBaseRef}{type.FullName.ToLowerInvariant().Replace('`', '-')}";
            }
        }
    }
}
