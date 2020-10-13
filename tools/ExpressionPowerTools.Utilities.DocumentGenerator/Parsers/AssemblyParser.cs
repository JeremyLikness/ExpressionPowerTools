// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Serialization;
using ExpressionPowerTools.Serialization.Serializers;
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
        /// <remarks>
        /// First pass creates the assembly and parses it. Second pass takes the
        /// assembly and processes for addition info that requires cross-referencing.
        /// </remarks>
        /// <param name="doc">The <see cref="DocAssembly"/> ref for pass 2.</param>
        /// <returns>The parsed <see cref="DocAssembly"/>.</returns>
        public DocAssembly Parse(DocAssembly doc = null)
        {
            if (doc == null)
            {
                doc = new DocAssembly(AssemblyName);
                IterateNamespaces(doc);
            }
            else
            {
                IterateNamespacesPass2(doc);
            }

            if (Assembly.GetTypes().Any(t => t == typeof(ExpressionSerializerAttribute)))
            {
                IterateSerializers(doc);
            }

            return doc;
        }

        /// <summary>
        /// Builds the serializer cross-reference.
        /// </summary>
        /// <param name="doc">The <see cref="DocAssembly"/> for serializers.</param>
        private void IterateSerializers(DocAssembly doc)
        {
            if (doc.CustomDocs.OfType<DocSerialization>().Any())
            {
                return;
            }

            var serializerDoc = new DocSerialization
            {
                Name = typeof(ExpressionSerializerAttribute).Namespace,
            };

            var types = Assembly.GetTypes()
                .Where(t => t.Namespace == typeof(BaseSerializer<,>).Namespace
                    && t.GetCustomAttributes(false)
                    .Any(c => c is ExpressionSerializerAttribute))
                .SelectMany(t => t.GetCustomAttributes(false).OfType<ExpressionSerializerAttribute>()
                    .Select(c => new { serializer = t, type = c.Type }));
            foreach (var serializer in types)
            {
                var name = serializer.serializer.FullName;
                var typeDoc = ParserUtils.GetTypeQuery(doc).Where(d => d.Name == name).Single();
                serializerDoc.Serializers.Add(serializer.type, typeDoc);
            }

            doc.CustomDocs.Add(serializerDoc);
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
        /// Second pass to handle relationships.
        /// </summary>
        /// <param name="doc">The <see cref="DocAssembly"/> to iterate.</param>
        private void IterateNamespacesPass2(DocAssembly doc)
        {
            // now go back and handle relationships
            foreach (var nsp in doc.Namespaces)
            {
                foreach (var type in nsp.Types)
                {
                    ProcessTypePass2(type);
                    if (!type.IsInterface)
                    {
                        type.Inheritance = ProcessInheritance(type.Type);
                    }

                    ProcessConstructors(type);
                    ProcessProperties(type);
                    ProcessMethods(type);
                }
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

                docNamespace.Types.Add(exportedType);
            }
        }

        /// <summary>
        /// Process property information.
        /// </summary>
        /// <param name="exportedType">The <see cref="DocExportedType"/> to parse.</param>
        private void ProcessProperties(DocExportedType exportedType)
        {
            var defaultRules = typeof(DefaultComparisonRules);
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
                    XPath = MemberUtils.GetSelector(prop),
                    Type = prop.PropertyType,
                    TypeParameters = ProcessTypeParameters(prop.PropertyType),
                    Code = MemberUtils.GenerateCodeFor(prop),
                };

                if (exportedType.Type == defaultRules && prop.GetMethod.IsStatic)
                {
                    var expression = prop.GetMethod.Invoke(null, null);
                    property.CustomInfo = expression.ToString();
                }

                LinkCache.Register(property);

                if (prop.GetIndexParameters().Length > 0)
                {
                    property.IsIndexer = true;
                    property.IndexerType = TypeCache.Cache[prop.GetIndexParameters().First().ParameterType];
                }

                property.TypeParameter = exportedType.TypeParameters.FirstOrDefault(
                    t => t.Name == property.Type.Name);

                exportedType.Properties.Add(property);
            }
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
            target.IsInterface = type.IsInterface;
            target.IsEnum = type.IsEnum;
            target.XPath = MemberUtils.GetSelector(type);
            LinkCache.Register(target);
        }

        /// <summary>
        /// Second pass that deals with relationships.
        /// </summary>
        /// <param name="type">The <see cref="DocExportedType"/> to process.</param>
        private void ProcessTypePass2(DocBaseType type)
        {
            type.Code = MemberUtils.GenerateCodeFor(type.Type);
            type.ImplementedInterfaces = ProcessImplementedInterfaces(type.Type);
            type.TypeParameters = ProcessTypeParameters(type.Type);
            type.DerivedTypes = ProcessDerivedTypes(type.Type);
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

            var ctors = exportedType.Type.GetConstructors().Concat(
                exportedType.Type.GetConstructors(BindingFlags.Static | BindingFlags.NonPublic)).Distinct()
                .OrderBy(c => c.IsStatic ? 1 : 0).ThenBy(c => c.GetParameters().Length);
            foreach (var ctor in ctors)
            {
                var overload = new DocOverload(ctor, exportedType.Constructor)
                {
                    Name = MemberUtils.GenerateCodeFor(ctor),
                    XPath = MemberUtils.GetSelector(ctor),
                };

                LinkCache.Register(overload);

                var staticText = ctor.IsStatic ? " static " : " ";

                overload.Code = $"public{staticText}{overload.Name}";

                ProcessParameters(ctor.GetParameters(), overload, overload.Parameters);

                exportedType.Constructor.Overloads.Add(overload);
            }
        }

        /// <summary>
        /// Processes the public method overloads.
        /// </summary>
        /// <param name="exportedType">The <see cref="DocExportedType"/>.</param>
        private void ProcessMethods(DocExportedType exportedType)
        {
            var typePropertyMethods = exportedType.Type.GetProperties()
                .Select(p => new[] { p.GetMethod, p.SetMethod })
                .SelectMany(p => p)
                .Where(p => p != null)
                .Distinct();

            var typeMethods = exportedType.Type.GetMethods(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance).Where(m => m.DeclaringType == exportedType.Type)
                .Except(typePropertyMethods);

            foreach (var methodInfo in typeMethods)
            {
                var method = exportedType.Methods.FirstOrDefault(m => m.Name == methodInfo.Name);

                if (method == null)
                {
                    method = new DocMethod(exportedType)
                    {
                        Name = methodInfo.Name,
                        MethodReturnType = TypeCache.Cache[methodInfo.ReturnType],
                    };
                    exportedType.Methods.Add(method);
                }

                var methodOverload = new DocMethodOverload(methodInfo, method)
                {
                    Name = MemberUtils.GenerateCodeFor(methodInfo),
                    XPath = MemberUtils.GetSelector(methodInfo),
                };

                LinkCache.Register(methodOverload);

                methodOverload.Code = methodOverload.Name;

                ProcessParameters(methodInfo.GetParameters(), methodOverload, methodOverload.Parameters);

                method.MethodOverloads.Add(methodOverload);
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
                ProcessTypePass2(param.ParameterType);
                target.Add(param);
            }
        }

        /// <summary>
        /// Process the derived types for a given type.
        /// </summary>
        /// <param name="type">The type to consider.</param>
        /// <returns>The list of derived typse.</returns>
        private IList<TypeRef> ProcessDerivedTypes(
            Type type)
        {
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

            return types.Where(t => t != type).Distinct().Select(t => TypeCache.Cache[t]).ToList();
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
                    var docParameter = new DocTypeParameter { Name = tParam.Name };
                    MemberUtils.ParseGenericTypeConstraints(tParam, docParameter);
                    result.Add(docParameter);
                }
            }

            return result;
        }

        /// <summary>
        /// Process the inheritance chain of a time.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to process.</param>
        /// <returns>The inheritance chain from base to current type.</returns>
        private IList<TypeRef> ProcessInheritance(Type type)
        {
            var stack = new Stack<Type>();
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var def = type.GetGenericTypeDefinition();
                    stack.Push(def);
                }
                else
                {
                    stack.Push(type);
                }

                type = type.BaseType;
            }

            return stack.Select(t => TypeCache.Cache[t]).ToList();
        }

        /// <summary>
        /// Process the implemented interfaces for the <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to process.</param>
        /// <returns>The list of implemented interfaces.</returns>
        private IList<TypeRef> ProcessImplementedInterfaces(Type type)
        {
            var result = new List<Type>();
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType)
                {
                    var def = i.GetGenericTypeDefinition();
                    result.Add(def);
                }
                else
                {
                    result.Add(i);
                }
            }

            return result.Select(t => TypeCache.Cache[t]).ToList();
        }
    }
}
