// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    /// <summary>
    /// Global parsing utilities.
    /// </summary>
    public static class ParserUtils
    {
        /// <summary>
        /// Base API URL for Microsoft documentation.
        /// </summary>
        public const string MsftApiBaseRef = "https://docs.microsoft.com/dotnet/api/";

        /// <summary>
        /// New line.
        /// </summary>
        public const string NewLine = "\r\n";

        /// <summary>
        /// Blank line.
        /// </summary>
        public const string BlankLine = NewLine + NewLine;

        /// <summary>
        /// The "see" element.
        /// </summary>
        public static readonly string See = nameof(See).ToLowerInvariant();

        /// <summary>
        /// Paragraph element.
        /// </summary>
        public static readonly string Para = nameof(Para).ToLowerInvariant();

        /// <summary>
        /// The summary element.
        /// </summary>
        public static readonly string Summary = nameof(Summary).ToLowerInvariant();

        /// <summary>
        /// The remarks element.
        /// </summary>
        public static readonly string Remarks = nameof(Remarks).ToLowerInvariant();

        /// <summary>
        /// The example element.
        /// </summary>
        public static readonly string Example = nameof(Example).ToLowerInvariant();

        /// <summary>
        /// The code element.
        /// </summary>
        public static readonly string Code = nameof(Code).ToLowerInvariant();

        /// <summary>
        /// Extension method to extra a type from an assembly.
        /// </summary>
        /// <param name="assembly">The <see cref="DocAssembly"/> to parse.</param>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>The <see cref="DocExportedType"/> if found, else <c>null</c>.</returns>
        public static DocExportedType GetType(this DocAssembly assembly, string typeName) =>
            assembly.Namespaces.SelectMany(ns => ns.Types).FirstOrDefault(t => t.Name == typeName);

        /// <summary>
        /// Gets a queryable to examine types.
        /// </summary>
        /// <param name="assembly">The host <see cref="DocAssembly"/>.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public static IQueryable<DocExportedType> GetTypeQuery(this DocAssembly assembly) =>
            assembly.Namespaces.SelectMany(ns => ns.Types).AsQueryable();

        /// <summary>
        /// Extracts a link by cross-referencing the type.
        /// </summary>
        /// <param name="see">The <see cref="XmlElement"/> with the reference.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to search.</param>
        /// <returns>The extracted link.</returns>
        public static string ExtractLink(this XmlElement see, DocAssembly assembly)
        {
            string cref = see.GetAttribute(nameof(cref));
            var result = string.Empty;
            if (!string.IsNullOrEmpty(cref))
            {
                var targets = cref.Split(":");
                var text = targets[1];
                if (targets[0] == "T")
                {
                    result = ExtractLinkForType(assembly, text);
                }
            }

            return result;
        }

        /// <summary>
        /// Parses the inheritance chain into text.
        /// </summary>
        /// <param name="inheritance">The inheritance chain.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to reference.</param>
        /// <returns>The parsed inheritance.</returns>
        public static string ParseInheritance(
            IList<(string name, string displayName)> inheritance,
            DocAssembly assembly)
        {
            var first = true;
            var sb = new StringBuilder("Inheritance");
            foreach ((string name, string displayName) i in inheritance)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append("→");
                }

                var text = MarkdownWriter.Normalize(i.displayName);
                if (i == inheritance[^1])
                {
                    sb.Append($" **{text}**");
                    continue;
                }

                var type = i.name;
                sb.Append(ExtractLinkForType(assembly, type));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parse the derived types.
        /// </summary>
        /// <param name="derivedTypes">The list of derived types.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to reference.</param>
        /// <returns>The parsed list.</returns>
        public static string ParseDerivedTypes(
            IList<(string name, string displayName)> derivedTypes,
            DocAssembly assembly)
        {
            var first = true;
            var sb = new StringBuilder("Derived ");
            foreach ((string name, string displayName) in derivedTypes.OrderBy(t => t.displayName))
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                var text = MarkdownWriter.Normalize(displayName);
                var type = name;
                sb.Append(ExtractLinkForType(assembly, name, text));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parses the list of implemented interfaces to a text list.
        /// </summary>
        /// <param name="implementedInterfaces">The implemented interfaces.</param>
        /// <param name="assembly">The <seealso cref="DocAssembly"/> to search.</param>
        /// <returns>The string representation of the list.</returns>
        public static string ParseImplementedInterfaces(
            IList<(string name, string displayName)> implementedInterfaces,
            DocAssembly assembly)
        {
            var first = true;
            var sb = new StringBuilder("Implements ");
            foreach ((string name, string displayName) in
                implementedInterfaces.OrderBy(i => i.displayName))
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                var text = MarkdownWriter.Normalize(displayName);
                var type = name;
                sb.Append(ExtractLinkForType(assembly, name, text));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Process the breadcrumb for a document.
        /// </summary>
        /// <param name="doc">The document that is being considered.</param>
        /// <returns>A breadcrumb menu.</returns>
        public static string ProcessBreadcrumb(object doc)
        {
            var sb = new StringBuilder();
            var breadcrumb = Traverse(doc, new Stack<(string text, string link)>()).ToList();
            for (var idx = 0; idx < breadcrumb.Count; idx += 1)
            {
                var (text, link) = breadcrumb[idx];
                var isLast = idx == (breadcrumb.Count - 1);
                if (idx == 0)
                {
                    sb.Append($"[{text}]({link})");
                }
                else if (isLast)
                {
                    sb.Append($" > **{text}**");
                }
                else
                {
                    sb.Append($" > [{text}]({link})");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates the appropriate link for a type.
        /// </summary>
        /// <param name="assembly">The <see cref="DocAssembly"/> to search.</param>
        /// <param name="type">The name of the type.</param>
        /// <param name="display">The optional display name of the type.</param>
        /// <returns>The markdown link.</returns>
        public static string ExtractLinkForType(DocAssembly assembly, string type, string display = null)
        {
            string link;
            var localType = assembly.GetType(type);
            if (localType != null)
            {
                link = localType.FileName;
                display = localType.TypeName;
            }
            else
            {
                display = display != null ? MarkdownWriter.Normalize(display) : FriendlyDisplayType(type);
                var linkType = type.Split("[")[0];
                link = $"{MsftApiBaseRef}{linkType.ToLowerInvariant().Replace('`', '-')}";
            }

            return $" [{display}]({link}) ";
        }

        /// <summary>
        /// Convert a type to a display value.
        /// </summary>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>The displayable value.</returns>
        public static string FriendlyDisplayType(string typeName)
        {
            var result = typeName;
            if (result.IndexOf('`') > 0)
            {
                var parts = result.Split('`');
                var count = int.Parse(parts[1]);
                result = $"{parts[0]}&lt;";
                for (var idx = 0; idx < count; idx += 1)
                {
                    if (idx > 0)
                    {
                        result += ",";
                    }

                    result += $"T{idx + 1}";
                }

                result += ">";
            }

            return result;
        }


        /// <summary>
        /// Parses the child nodes of XML documentation to resolve links and code blocks.
        /// </summary>
        /// <param name="childNodes">The child nodes.</param>
        /// <param name="sb">The <see cref="StringBuilder"/> to write to.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> for reference.</param>
        public static void ParseChildNodes(this XmlNodeList childNodes, StringBuilder sb, DocAssembly assembly)
        {
            var first = true;
            foreach (var innerElement in childNodes)
            {
                if (innerElement is XmlText text)
                {
                    sb.Append(text.Value.Trim());
                }

                if (innerElement is XmlElement elem)
                {
                    if (elem.Name == See)
                    {
                        sb.Append(elem.ExtractLink(assembly));
                    }

                    if (elem.Name == "c")
                    {
                        sb.Append($" `{elem.InnerText}` ");
                    }

                    if (elem.Name == Code)
                    {
                        string code = string.Empty;
                        var child = elem.ChildNodes[0];
                        if (child is XmlText txt)
                        {
                            code = NormalizeIndents(txt.Data);
                        }

                        if (child is XmlCDataSection cdata)
                        {
                            code = NormalizeIndents(cdata.Data);
                        }

                        sb.Append($"{BlankLine}```csharp{NewLine}{code}{NewLine}```{BlankLine}");
                    }

                    if (elem.Name == Para)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            sb.Append(BlankLine);
                        }

                        elem.ChildNodes.ParseChildNodes(sb, assembly);
                    }
                }
            }
        }

        /// <summary>
        /// Normalize the indents for a text block.
        /// </summary>
        /// <param name="source">The source block.</param>
        /// <returns>The normalize source.</returns>
        public static string NormalizeIndents(string source)
        {
            var lines = source.Split(NewLine);

            var min = lines.Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.TakeWhile(c => char.IsWhiteSpace(c)).Count())
                .Min();

            if (min == 0)
            {
                return source;
            }

            var trimmed = lines.Select(line => string.IsNullOrWhiteSpace(line) ? line :
                line.Substring(min)).ToArray();

            return string.Join(NewLine, trimmed);
        }

        /// <summary>
        /// Strips the namespace qualification and normalizes the name.
        /// </summary>
        /// <example>
        /// For example, the name <c>Sytem.Foo.IBar`2</c> would get transformed to:
        /// <code lang="csharp"><![CDATA[
        /// IBar<>
        /// ]]></code>
        /// </example>
        /// <param name="fullName">The source name.</param>
        /// <returns>The name by itself.</returns>
        public static string NameOnly(this string fullName)
        {
            var parts = fullName.Split(".");
            var stub = parts[^1];
            if (stub.IndexOf('`') > 0)
            {
                var generic = stub.Split('`');
                stub = $"{generic[0]}&lt;>";
            }

            return stub.Replace("<", "&lt;");
        }

        /// <summary>
        /// Gets the selector in XML docs for the provided member.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/>.</param>
        /// <returns>The selector.</returns>
        public static string GetSelector(MemberInfo member)
        {
            var typeGenericMap = new Dictionary<string, int>();
            var methodGenericMap = new Dictionary<string, int>();
            var parameters = new List<string>();

            char prefixCode;

            string memberName = (member is Type mbr)
                ? mbr.FullName
                : (member.DeclaringType.FullName + "." + member.Name);

            if (member.DeclaringType != null && member.DeclaringType.IsGenericType)
            {
                var tempTypeGeneric = 0;
                foreach (var genericArg in member.DeclaringType.GetGenericArguments())
                {
                    typeGenericMap[genericArg.Name] = tempTypeGeneric++;
                }
            }

            Type[] genericArguments = null;
            var parameterInfos = new ParameterInfo[0];

            if (member is MethodInfo method)
            {
                if (method.IsGenericMethod)
                {
                    genericArguments = method.GetGenericArguments();
                }

                parameterInfos = method.GetParameters();
            }
            else if (member is ConstructorInfo ctor)
            {
                if (ctor.IsGenericMethod)
                {
                    genericArguments = ctor.GetGenericArguments();
                }

                parameterInfos = ctor.GetParameters();
            }

            if (genericArguments != null)
            {
                var tempMethodGeneric = 0;
                foreach (var methodGenericArg in genericArguments)
                {
                    methodGenericMap[methodGenericArg.Name] = tempMethodGeneric++;
                }
            }

            // fix up parameters
            foreach (var parameter in parameterInfos)
            {
                var paramType = parameter.ParameterType;
                var param = string.Empty;
                if (paramType.HasElementType)
                {
                    if (paramType.IsArray)
                    {
                        param = $"{paramType.FullName}[]";
                    }
                    else if (paramType.IsPointer)
                    {
                        param = $"{paramType.FullName}*";
                    }
                    else if (paramType.IsByRef)
                    {
                        param = $"{paramType.FullName}@";
                    }
                }
                else if (paramType.IsGenericParameter)
                {
                    if (paramType.FullName == null && typeGenericMap.ContainsKey(paramType.Name))
                    {
                        param = $"`{typeGenericMap[paramType.Name]}";
                    }
                }
                else if (paramType.ContainsGenericParameters)
                {
                    var fullname = paramType.FullName ?? $"{paramType.Namespace}.{paramType.Name}";
                    fullname = fullname.Substring(0, fullname.IndexOf('`')) + "{";
                    var first = true;
                    foreach (var typeArg in paramType.GenericTypeArguments)
                    {
                        if (typeGenericMap.ContainsKey(typeArg.Name))
                        {
                            if (first)
                            {
                                first = false;
                            }
                            else
                            {
                                fullname += ",";
                            }

                            fullname += $"`{typeGenericMap[typeArg.Name]}";
                        }
                    }

                    param = $"{fullname}}}";
                }
                else
                {
                    param = paramType.FullName ?? paramType.Name;
                }

                parameters.Add(param);
            }

            switch (member.MemberType)
            {
                case MemberTypes.Constructor:
                    memberName = memberName.Replace(".ctor", "#ctor");
                    goto case MemberTypes.Method;

                case MemberTypes.Method:
                    prefixCode = 'M';
                    string paramTypesList = string.Join(
                        ",",
                        parameters.ToArray());
                    if (!string.IsNullOrEmpty(paramTypesList))
                    {
                        memberName += "(" + paramTypesList + ")";
                    }

                    break;

                case MemberTypes.Event: prefixCode = 'E'; break;

                case MemberTypes.Field: prefixCode = 'F'; break;

                case MemberTypes.NestedType:
                    memberName = memberName.Replace('+', '.');
                    goto case MemberTypes.TypeInfo;

                case MemberTypes.TypeInfo:
                    prefixCode = 'T';
                    break;

                case MemberTypes.Property: prefixCode = 'P'; break;

                default:
                    throw new ArgumentException("Unknown member type", "member");
            }

            return string.Format("/doc/members/member[@name='{0}:{1}']", prefixCode, memberName);
        }

        /// <summary>
        /// Traverses the hierarchy from the root to produce a breadcrumb list.
        /// </summary>
        /// <param name="doc">The document to start at.</param>
        /// <param name="stack">A stack of traversed items.</param>
        /// <returns>The recursed stack of items.</returns>
        private static Stack<(string text, string link)> Traverse(object doc, Stack<(string text, string link)> stack)
        {
            if (doc is DocAssembly assembly)
            {
                stack.Push((assembly.Name, assembly.FileName));
                return stack;
            }

            if (doc is DocNamespace ns)
            {
                stack.Push((ns.Name, ns.FileName));
                Traverse(ns.Assembly, stack);
                return stack;
            }

            if (doc is DocExportedType type)
            {
                stack.Push((type.TypeName, type.FileName));
                Traverse(type.Namespace, stack);
                return stack;
            }

            if (doc is DocConstructor ctor)
            {
                stack.Push((ctor.Overloads[0].Name.NameOnly(), ctor.FileName));
                Traverse(ctor.ConstructorType, stack);
                return stack;
            }

            if (doc is DocProperty prop)
            {
                stack.Push((prop.Name.NameOnly(), prop.FileName));
                Traverse(prop.ParentType, stack);
                return stack;
            }

            return stack;
        }
    }
}
