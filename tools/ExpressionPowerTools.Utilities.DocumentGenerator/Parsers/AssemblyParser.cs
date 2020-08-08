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
                var exportedType = new DocExportedType
                {
                    Namespace = docNamespace,
                };

                ProcessType(type, exportedType);

                if (!exportedType.IsInterface)
                {
                    exportedType.Inheritance = ProcessInheritance(type);
                }

                ProcessConstructors(exportedType);
                ProcessProperties(exportedType);

                docNamespace.Types.Add(exportedType);
            }
        }

        /// <summary>
        /// Process property information.
        /// </summary>
        /// <param name="exportedType">The <see cref="DocExportedType"/> to parse.</param>
        private void ProcessProperties(DocExportedType exportedType)
        {
            foreach (var prop in exportedType.Type.GetProperties(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
            {
                if (prop.DeclaringType != exportedType.Type)
                {
                    continue;
                }

                var property = new DocProperty(exportedType)
                {
                    Name = $"{exportedType.Name}.{prop.Name}",
                    XPath = ParserUtils.GetSelector(prop),
                    Type = prop.PropertyType,
                    TypeName = ProcessTypeName(prop.PropertyType),
                    Code = GeneratePropertySignature(prop),
                };
                exportedType.Properties.Add(property);
            }
        }

        private string GeneratePropertySignature(PropertyInfo prop)
        {
            var sb = new StringBuilder();
            var methodInfo = prop.CanRead ? prop.GetMethod : prop.SetMethod;
            if (methodInfo.IsPublic)
            {
                sb.Append("public ");
            }
            else if (methodInfo.IsFamily)
            {
                sb.Append("protected ");
            }
            else if (methodInfo.IsPrivate)
            {
                sb.Append("private ");
            }

            if (methodInfo.IsStatic)
            {
                sb.Append("static ");
            }
            else if (methodInfo.IsVirtual)
            {
                sb.Append("virtual ");
            }

            sb.Append(ProcessTypeName(prop.PropertyType));
            sb.Append($" {prop.Name} {{ ");
            if (prop.CanRead)
            {
                sb.Append("get; ");
            }

            if (prop.CanWrite)
            {
                if (methodInfo.IsPublic && prop.SetMethod.IsPrivate)
                {
                    sb.Append("private ");
                }

                sb.Append("set; ");
            }

            sb.Append("}}");
            return sb.ToString();
        }

        /// <summary>
        /// Process type information.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to process.</param>
        /// <param name="target">The <see cref="DocBaseType"/> to process to.</param>
        private void ProcessType(Type type, DocBaseType target)
        {
            target.Name = type.FullName ?? $"{type.Namespace}.{type.Name}";
            target.Type = type;
            target.TypeName = ProcessTypeName(type);
            target.IsInterface = type.IsInterface;
            target.IsEnum = type.IsEnum;
            target.Code = GenerateCodeSnippet(type, target.TypeName);
            target.ImplementedInterfaces = ProcessImplementedInterfaces(type);
            target.TypeParameters = ProcessTypeParameters(type);
            target.DerivedTypes = ProcessDerivedTypes(type);
            target.XPath = ParserUtils.GetSelector(type);
        }

        /// <summary>
        /// Processes the public constructor overloads.
        /// </summary>
        /// <param name="exportedType">The <see cref="DocExportedType"/>.</param>
        private void ProcessConstructors(DocExportedType exportedType)
        {
            if (!exportedType.IsClass)
            {
                return;
            }

            exportedType.Constructor = new DocConstructor(exportedType)
            {
                Name = exportedType.Name,
            };

            var ctors = exportedType.Type.GetConstructors();
            foreach (var ctor in ctors)
            {
                var overload = new DocOverload(ctor, exportedType.Constructor)
                {
                    Name = GenerateCtorSignature(ctor, exportedType.TypeName),
                    XPath = ParserUtils.GetSelector(ctor),
                };

                var staticText = ctor.IsStatic ? " static " : " ";

                overload.Code = $"public{staticText}{overload.Name}";

                ProcessParameters(ctor.GetParameters(), overload, overload.Parameters);

                exportedType.Constructor.Overloads.Add(overload);
            }
        }

        /// <summary>
        /// Process the parameter list.
        /// </summary>
        /// <param name="parameterInfos">The parameter information.</param>
        /// <param name="doc">The parent <see cref="DocBase"/>.</param>
        /// <param name="target">The target list to process to.</param>
        private void ProcessParameters(
            ParameterInfo[] parameterInfos,
            DocBase doc,
            IList<DocParameter> target)
        {
            foreach (var parameter in parameterInfos)
            {
                var param = new DocParameter(doc)
                {
                    Name = parameter.Name,
                    ParameterType = new DocBaseType(),
                };
                ProcessType(parameter.ParameterType, param.ParameterType);
                target.Add(param);
            }
        }

        /// <summary>
        /// Generate the code for the constructor.
        /// </summary>
        /// <param name="ctor">The <see cref="ConstructorInfo"/>.</param>
        /// <param name="typeName">The type name.</param>
        /// <returns>The constructor code.</returns>
        private string GenerateCtorSignature(ConstructorInfo ctor, string typeName)
        {
            var sb = new StringBuilder($"{typeName}(");
            var first = true;
            foreach (var parameter in ctor.GetParameters())
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                var type = ProcessTypeName(parameter.ParameterType);
                var name = parameter.Name;
                sb.Append($"{type} {name}");
            }

            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Process the derived types for a given type.
        /// </summary>
        /// <param name="type">The type to consider.</param>
        /// <returns>The list of derived typse.</returns>
        private IList<(string name, string displayName)> ProcessDerivedTypes(
            Type type)
        {
            var result = new List<(string name, string displayName)>();
            var types = new List<Type>();
            var generic = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            if (type.IsInterface)
            {
                if (type.IsGenericType)
                {
                    types.AddRange(type.Assembly.GetExportedTypes()
                        .Where(t => t.GetInterfaces()
                            .Any(
                                i => i.IsGenericType &&
                                i.GetGenericTypeDefinition().Equals(generic))));
                }

                types.AddRange(type.Assembly.GetExportedTypes()
                    .Where(t => t.GetInterfaces()
                        .Any(i => i == type)));
            }
            else
            {
                if (type.IsGenericType)
                {
                    types.AddRange(type.Assembly.GetExportedTypes()
                        .Where(t => t.BaseType != null &&
                            t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition().Equals(generic)));
                }

                types.AddRange(type.Assembly.GetExportedTypes()
                    .Where(t => t.BaseType != null && t.BaseType.Equals(type)));
            }

            foreach (var item in types.Where(t => t != type).Distinct())
            {
                result.Add((item.FullName, ProcessTypeName(item)));
            }

            return result;
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

            return stack.Select(i => (i.name, i.displayName)).ToList();
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
                    sb.Append($"{ParserUtils.NewLine}   where {tParam.Name} : {ProcessTypeName(constraint)}");
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
                var name = type.FullName ?? type.Name;
                var withoutGeneric = name.Split('`')[0];
                var rootName = withoutGeneric.Split('.')[^1];
                sb.Append(rootName);
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
