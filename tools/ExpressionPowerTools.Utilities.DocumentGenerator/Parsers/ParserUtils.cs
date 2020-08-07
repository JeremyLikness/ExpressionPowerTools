using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    public static class ParserUtils
    { 
        public const string BclRef = "https://docs.microsoft.com/dotnet/api/";

        public static string see = nameof(see);

        public static string para = nameof(para);

        public static string summary = nameof(summary);

        public static string remarks = nameof(remarks);

        public static DocExportedType GetType(this DocAssembly assembly, string typeName) =>
            assembly.Namespaces.SelectMany(ns => ns.Types).FirstOrDefault(t => t.Name == typeName);

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

        public static string ParseInheritance(IList<(string name, string displayName)> implementedInterfaces,
            DocAssembly assembly)
        {
            var first = true;
            var sb = new StringBuilder("Inheritance");
            foreach ((string name, string displayName) i in implementedInterfaces)
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
                if (i == implementedInterfaces[^1])
                {
                    sb.Append($" **{text}**");
                    continue;
                }
                var type = i.name;
                sb.Append(ExtractLinkForType(assembly, type));
            }

            return sb.ToString();
        }

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
                link = $"{BclRef}{type.ToLowerInvariant().Replace('`', '-')}";
            }

            return $" [{display.NameOnly()}]({link}) "; ;
        }

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
                    if (elem.Name == see)
                    {
                        sb.Append(elem.ExtractLink(assembly));
                    }
                    if (elem.Name == para)
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

    }
}
