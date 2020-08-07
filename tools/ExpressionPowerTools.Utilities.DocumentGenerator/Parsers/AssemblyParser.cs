using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    public class AssemblyParser
    {
        private Assembly Assembly { get; set; }
        
        private string AssemblyName { get; set; } 

        private IList<Type> Types { get; set; }

        public AssemblyParser(Assembly assembly)
        {
            Assembly = assembly;
            AssemblyName = Assembly.FullName.Split(",")[0];
        }

        public DocAssembly Parse()
        {
            var doc = new DocAssembly(AssemblyName);
            IterateNamespaces(doc);
            return doc;
        }

        private void IterateNamespaces(DocAssembly doc)
        {
            Types = Assembly.GetExportedTypes();
            var namespaces = Types.Select(t => t.Namespace).Distinct().OrderBy(n => n);
            foreach(var nsp in namespaces)
            {
                Console.WriteLine($"Parsing namespace \"{nsp}\"...");
                var docNamespace = new DocNamespace(nsp)
                {
                    Assembly = doc
                };
                IterateTypes(docNamespace);
                doc.Namespaces.Add(docNamespace);
            }
        }

        private void IterateTypes(DocNamespace docNamespace)
        {
            foreach(var type in Types.Where(t => t.Namespace == docNamespace.Name))
            {
                Console.WriteLine($"Parsing type \"{type.FullName}\"...");
                var typeName = ProcessTypeName(type);
                var exportedType = new DocExportedType
                {
                    Namespace = docNamespace,
                    Name = type.FullName,
                    TypeName = typeName,
                    IsInterface = type.IsInterface,
                    Code = GenerateCodeSnippet(type, typeName),
                    ImplementedInterfaces = ProcessImplementedInterfaces(type),
                    TypeParameters = ProcessTypeParameters(type)
                };

                if (!exportedType.IsInterface)
                {
                    exportedType.Inheritance = ProcessInheritance(type);
                }

                docNamespace.Types.Add(exportedType);
            }
        }

        private IList<DocTypeParameter> ProcessTypeParameters(Type type)
        {
            var result = new List<DocTypeParameter>();
            if (type.IsGenericType)
            {
                foreach(var tParam in type.GetGenericArguments().Where(t => t.IsGenericParameter))
                {
                    result.Add(new DocTypeParameter { Name = tParam.Name });
                }
            }
            return result;
        }

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

        private IList<(string name, string displayName)> ProcessImplementedInterfaces(Type type)
        {
            var result = new List<(string name, string displayName)>();
            foreach(var i in type.GetInterfaces())
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

        private string GenerateCodeSnippet(Type type, string typeName)
        {
            var sb = new StringBuilder("public ");
            if (type.IsInterface)
            {
                sb.Append("interface ");
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

            var first = true;
            var allInterfaces = type.GetInterfaces();
            var directInterfaces = allInterfaces.Where(i => !allInterfaces.Any(t => t.GetInterfaces().Contains(i)));
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
            foreach(var tParam in type.GetGenericArguments().Where(t => t.IsGenericParameter))
            {
                foreach(var constraint in tParam.GetGenericParameterConstraints())
                {
                    sb.Append($"\r\n   where {tParam.Name} : {ProcessTypeName(constraint)}");
                }                           
            }

            return sb.ToString();
        }

        private string ProcessTypeName(Type type)
        {
            var sb = new StringBuilder();
            if (type.IsGenericType || type.IsGenericTypeDefinition)
            {
                sb.Append(type.Name.Substring(0, type.Name.IndexOf('`')));
                sb.Append("<");
                var parameters = type.GetGenericArguments();
                var first = true;
                foreach(Type paramType in parameters)
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
                        // add constraints
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
