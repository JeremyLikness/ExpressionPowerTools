// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
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
        /// Extension method to extra a type from an assembly.
        /// </summary>
        /// <param name="assembly">The <see cref="DocAssembly"/> to parse.</param>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>The <see cref="DocExportedType"/> if found, else <c>null</c>.</returns>
        public static DocExportedType GetType(this DocAssembly assembly, string typeName) =>
            assembly.Namespaces.SelectMany(ns => ns.Types).FirstOrDefault(t => t.Name == typeName);

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
            foreach ((string name, string displayName) in implementedInterfaces)
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
            display ??= type;
            string link;
            var localType = assembly.GetType(type);
            if (localType != null)
            {
                link = localType.FileName;
                display = localType.TypeName;
            }
            else
            {
                link = $"{MsftApiBaseRef}{type.ToLowerInvariant().Replace('`', '-')}";
            }

            return $" [{display.NameOnly()}]({link}) ";
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

                    if (elem.Name == Para)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            sb.Append("\r\n\r\n");
                        }

                        elem.ChildNodes.ParseChildNodes(sb, assembly);
                    }
                }
            }
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
                stack.Push((type.TypeName.NameOnly(), type.FileName));
                Traverse(type.Namespace, stack);
                return stack;
            }

            return stack;
        }
    }
}
