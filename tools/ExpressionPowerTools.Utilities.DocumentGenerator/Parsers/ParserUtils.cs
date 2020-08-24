// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Data;
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
        /// Returns comments.
        /// </summary>
        public static readonly string Returns = nameof(Returns).ToLowerInvariant();

        /// <summary>
        /// The code element.
        /// </summary>
        public static readonly string Code = nameof(Code).ToLowerInvariant();

        /// <summary>
        /// The <see cref="MarkdownWriter"/> to help with link generation.
        /// </summary>
        private static readonly MarkdownWriter Writer = new MarkdownWriter();

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
        /// <returns>The extracted link.</returns>
        public static string ExtractLink(this XmlElement see)
        {
            string cref = see.GetAttribute(nameof(cref));
            var result = string.Empty;
            if (!string.IsNullOrEmpty(cref))
            {
                var targets = cref.Split(":");
                var text = targets[1];
                switch (targets[0])
                {
                    case "T":
                        var type = TypeCache.Cache.GetTypeFromName(text);
                        result = Writer.WriteLink(TypeCache.Cache[type]);
                        break;
                    case "P":
                        var link = LinkCache.GetLinkBySelector(cref);
                        result = link ?? $"`{FriendlyDisplayType(text)}`";
                        break;
                    default:
                        var refLink = LinkCache.GetLinkBySelector(cref);

                        if (refLink == null)
                        {
                            // assume it is a Microsoft reference
                            string baseHref, methodExt = string.Empty;
                            var parts = text.Split('.').ToList();
                            var method = parts.FirstOrDefault(p => p.Contains("("));
                            if (!string.IsNullOrEmpty(method))
                            {
                                baseHref = string.Join(
                                    '.',
                                    parts.GetRange(0, parts.IndexOf(method)));
                                methodExt = NameOnly(method.Split('(')[0]);
                            }
                            else
                            {
                                baseHref = text;
                            }

                            link = baseHref.Replace('`', '-');
                            var linkText = FriendlyDisplayType(baseHref);
                            if (!string.IsNullOrWhiteSpace(methodExt))
                            {
                                link += $".{methodExt}";
                                linkText += $".{methodExt}";
                            }

                            result = Writer.WriteLink(linkText, $"{TypeCache.MsftApiBaseRef}{link}");
                        }

                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Parses the inheritance chain into text.
        /// </summary>
        /// <param name="inheritance">The inheritance chain.</param>
        /// <returns>The parsed inheritance.</returns>
        public static string ParseInheritance(
            IList<TypeRef> inheritance)
        {
            var first = true;
            var sb = new StringBuilder("Inheritance");
            foreach (TypeRef i in inheritance)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append("→");
                }

                if (i == inheritance[^1])
                {
                    sb.Append($" **{MarkdownWriter.Normalize(i.FriendlyName)}**");
                    continue;
                }

                sb.Append(Writer.WriteLink(i));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parse the derived types.
        /// </summary>
        /// <param name="derivedTypes">The list of derived types.</param>
        /// <returns>The parsed list.</returns>
        public static string ParseDerivedTypes(
            IList<TypeRef> derivedTypes)
        {
            var first = true;
            var sb = new StringBuilder("Derived ");
            foreach (var type in derivedTypes.OrderBy(t => t.FriendlyName))
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(Writer.WriteLink(type));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parses the list of implemented interfaces to a text list.
        /// </summary>
        /// <param name="implementedInterfaces">The implemented interfaces.</param>
        /// <returns>The string representation of the list.</returns>
        public static string ParseImplementedInterfaces(
            IList<TypeRef> implementedInterfaces)
        {
            var first = true;
            var sb = new StringBuilder("Implements ");
            foreach (var type in
                implementedInterfaces.OrderBy(i => i.FriendlyName))
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(Writer.WriteLink(type));
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
            var sb = new StringBuilder("[Index](../index.md) > ");
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
                if (!int.TryParse(parts[1], out int count))
                {
                    return typeName;
                }

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
        public static void ParseChildNodes(this XmlNodeList childNodes, StringBuilder sb)
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
                        sb.Append(elem.ExtractLink());
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

                        elem.ChildNodes.ParseChildNodes(sb);
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
                stack.Push((type.TypeRef.FriendlyName, type.FileName));
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

            if (doc is DocMethod method)
            {
                stack.Push((method.Name.NameOnly(), method.FileName));
                Traverse(method.MethodType, stack);
                return stack;
            }

            return stack;
        }
    }
}
