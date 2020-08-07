// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    /// <summary>
    /// Parses an assembly into a set of document entities to enhance with documentation.
    /// </summary>
    public class AssemblyParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyParser"/> class.
        /// </summary>
        /// <param name="assembly">The assembly to parse.</param>
        public AssemblyParser(Assembly assembly)
        {
            Assembly = assembly;
            AssemblyName = Assembly.FullName.Split(",")[0];
        }

        /// <summary>
        /// Gets or sets he <see cref="Assembly"/> being referenced.
        /// </summary>
        private Assembly Assembly { get; set; }

        /// <summary>
        /// Gets or sets the name of the assembly.
        /// </summary>
        private string AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets the list of types in the assembly.
        /// </summary>
        private IList<Type> Types { get; set; }

        /// <summary>
        /// Parses the assembly.
        /// </summary>
        /// <returns>The parsed <see cref="DocAssembly"/>.</returns>
        public DocAssembly Parse()
        {
            var doc = new DocAssembly(AssemblyName);
            IterateNamespaces(doc);
            return doc;
        }

        /// <summary>
        /// Iterate the namespaces of the assembly.
        /// </summary>
        /// <param name="doc">The <see cref="DocAssembly"/> to iterate.</param>
        private void IterateNamespaces(DocAssembly doc)
        {
            Types = Assembly.GetExportedTypes();
            var namespaces = Types.Select(t => t.Namespace).Distinct().OrderBy(n => n);
            foreach (var nsp in namespaces)
            {
                Console.WriteLine($"Parsing namespace \"{nsp}\"...");
                var docNamespace = new DocNamespace(nsp)
                {
                    Assembly = doc,
                };
                IterateTypes(docNamespace);
                doc.Namespaces.Add(docNamespace);
            }
        }

        /// <summary>
        /// Iterate the types for the namespace.
        /// </summary>
        /// <param name="docNamespace">The <see cref="DocNamespace"/> to parse into.</param>
        private void IterateTypes(DocNamespace docNamespace)
        {
            foreach (var type in Types.Where(t => t.Namespace == docNamespace.Name))
            {
                Console.WriteLine($"Parsing type \"{type.FullName}\"...");
                var typeName = ProcessTypeName(type);
                var exportedType = new DocExportedType
                {
                    Namespace = docNamespace,
                    Name = type.FullName,
                    TypeName = typeName,
                    IsInterface = type.IsInterface,
                    IsEnum = type.IsEnum,
                    Code = GenerateCodeSnippet(type, typeName),
                    ImplementedInterfaces = ProcessImplementedInterfaces(type),
                    TypeParameters = ProcessTypeParameters(type),
                };

                if (!exportedType.IsInterface)
                {
                    exportedType.Inheritance = ProcessInheritance(type);
                }

                docNamespace.Types.Add(exportedType);
            }
        }

        /// <summary>
        /// Process the type parameters for a given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to process.</param>
        /// <returns>The list of parsed type parameters.</returns>
        private IList<DocTypeParameter> ProcessTypeParameters(Type type)
        {
            var result = new List<DocTypeParameter>();
            if (type.IsGenericType)
            {
                foreach (var tParam in type.GetGenericArguments().Where(t => t.IsGenericParameter))
                {
                    result.Add(new DocTypeParameter { Name = tParam.Name });
                }
            }

            return result;
        }

        /// <summary>
        /// Process the inheritance chain of a time.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to process.</param>
        /// <returns>The inheritance chain from base to current type.</returns>
        private IList<(string name, string displayName)> ProcessInheritance(Type type)
        {
            var stack = new Stack<(string name, string displayName)>();
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var def = type.GetGenericTypeDefinition();
                    stack.Push(($"{def.Namespace}.{def.Name}", ProcessTypeName(def)));
                }
                else
                {
                    stack.Push(($"{type.Namespace}.{type.Name}", ProcessTypeName(type)));
                }

                type = type.BaseType;
            }

            return stack.ToList();
        }

        /// <summary>
        /// Process the implemented interfaces for the <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to process.</param>
        /// <returns>The list of implemented interfaces.</returns>
        private IList<(string name, string displayName)> ProcessImplementedInterfaces(Type type)
        {
            var result = new List<(string name, string displayName)>();
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType)
                {
                    var def = i.GetGenericTypeDefinition();
                    result.Add(($"{def.Namespace}.{def.Name}", ProcessTypeName(def)));
                }
                else
                {
                    result.Add(($"{i.Namespace}.{i.Name}", ProcessTypeName(i)));
                }
            }

            return result;
        }

        /// <summary>
        /// Generate the code snippet that defines the type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to generate the code snippet for.</param>
        /// <param name="typeName">The code-friendly type name.</param>
        /// <returns>The generated code snippet.</returns>
        private string GenerateCodeSnippet(Type type, string typeName)
        {
            var sb = new StringBuilder("public ");
            if (type.IsInterface)
            {
                sb.Append("interface ");
            }
            else if (type.IsEnum)
            {
                sb.Append("enum ");
            }
            else
            {
                if (type.IsAbstract)
                {
                    sb.Append(type.IsSealed ? "static " : "abstract ");
                }

                sb.Append("class ");
            }

            sb.Append(typeName);

            if (type.IsEnum)
            {
                return sb.ToString();
            }

            var first = true;
            var allInterfaces = type.GetInterfaces();
            var directInterfaces = allInterfaces
                .Where(i => !allInterfaces.Any(t => t.GetInterfaces().Contains(i)));
            var implemented = type.BaseType == typeof(object) ?
                directInterfaces : new[] { type.BaseType }.Union(directInterfaces);
            foreach (var i in implemented.Where(i => i != null))
            {
                if (first)
                {
                    sb.Append(" : ");
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(ProcessTypeName(i));
            }

            // check constraints
            foreach (var tParam in type.GetGenericArguments().Where(t => t.IsGenericParameter))
            {
                foreach (var constraint in tParam.GetGenericParameterConstraints())
                {
                    sb.Append($"\r\n   where {tParam.Name} : {ProcessTypeName(constraint)}");
                }
            }

            return sb.ToString();
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
        private string ProcessTypeName(Type type)
        {
            var sb = new StringBuilder();
            if (type.IsGenericType || type.IsGenericTypeDefinition)
            {
                sb.Append(type.Name.Substring(0, type.Name.IndexOf('`')));
                sb.Append("<");
                var parameters = type.GetGenericArguments();
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
                        sb.Append(paramType.Name);
                    }
                    else
                    {
                        sb.Append(ProcessTypeName(paramType));
                    }
                }

                sb.Append(">");
            }
            else
            {
                sb.Append(type.Name);
            }

            return sb.ToString();
        }
    }
}
