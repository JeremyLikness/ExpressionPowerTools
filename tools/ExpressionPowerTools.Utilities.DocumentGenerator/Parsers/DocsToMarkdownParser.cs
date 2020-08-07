// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    /// <summary>
    /// Class to transform documentation objects into markdown.
    /// </summary>
    public class DocsToMarkdownParser
    {
        /// <summary>
        /// The <see cref="MarkdownWriter"/> to use.
        /// </summary>
        private readonly MarkdownWriter writer = new MarkdownWriter();

        /// <summary>
        /// Parses a <see cref="DocAssembly"/> to return a <see cref="DocFile"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="DocAssembly"/> to parse.</param>
        /// <returns>The transformed <see cref="DocFile"/>.</returns>
        public DocFile Parse(DocAssembly assembly)
        {
            var result = new DocFile(assembly.FileName);

            result.AddThenBlankLine(writer.WriteHeading1($"{assembly.Name} API Reference"));
            var list = new MarkdownList();

            foreach (var ns in assembly.Namespaces.OrderBy(ns => ns.Name))
            {
                list.AddItem(writer.WriteLink(ns.Name, ns.FileName));
                result.Files.Add(ProcessNamespace(ns));
            }

            writer.AddRange(result.Markdown, list.CloseList());
            return result;
        }

        /// <summary>
        /// Parses a <see cref="DocNamespace"/> into a <see cref="DocFile"/>.
        /// </summary>
        /// <param name="ns">The <see cref="DocNamespace"/> to parse.</param>
        /// <returns>The transformed <see cref="DocFile"/>.</returns>
        private DocFile ProcessNamespace(DocNamespace ns)
        {
            var result = new DocFile(ns.FileName);

            result.AddThenBlankLine(writer.WriteHeading1($"{ns.Name} Namespace"));
            result.AddThenBlankLine(ParserUtils.ProcessBreadcrumb(ns));

            if (ns.Types.Any(t => t.IsClass))
            {
                result.AddThenBlankLine(writer.WriteHeading2("Classes"));
                var table = new MarkdownTable("Class", "Description");
                foreach (var c in ns.Types.Where(t => t.IsClass).OrderBy(t => t.TypeName))
                {
                    table.AddRow(writer.WriteLink(c.TypeName, c.FileName), c.Description);
                    result.Files.Add(ProcessType(c));
                }

                writer.AddRange(result.Markdown, table.CloseTable());
                result.AddBlankLine();
            }

            if (ns.Types.Any(t => t.IsInterface))
            {
                result.AddThenBlankLine(writer.WriteHeading2("Interfaces"));
                var table = new MarkdownTable("Interface", "Description");
                foreach (var i in ns.Types.Where(t => t.IsInterface).OrderBy(t => t.TypeName))
                {
                    table.AddRow(writer.WriteLink(i.TypeName, i.FileName), i.Description);
                    result.Files.Add(ProcessType(i));
                }

                writer.AddRange(result.Markdown, table.CloseTable());
                result.AddBlankLine();
            }

            if (ns.Types.Any(t => t.IsEnum))
            {
                result.AddThenBlankLine(writer.WriteHeading2("Enumerations"));
                var table = new MarkdownTable("Enumeration", "Description");
                foreach (var i in ns.Types.Where(t => t.IsEnum).OrderBy(t => t.TypeName))
                {
                    table.AddRow(writer.WriteLink(i.TypeName, i.FileName), i.Description);
                    result.Files.Add(ProcessType(i));
                }

                writer.AddRange(result.Markdown, table.CloseTable());
                result.AddBlankLine();
            }

            return result;
        }

        /// <summary>
        /// Parses a <see cref="DocExportedType"/> to a <see cref="DocFile"/>.
        /// </summary>
        /// <param name="t">The <see cref="DocExportedType"/> to parse.</param>
        /// <returns>The transformed <see cref="DocFile"/>.</returns>
        private DocFile ProcessType(DocExportedType t)
        {
            var result = new DocFile(t.FileName);

            var classification = t.IsInterface ? "Interface" : "Class";
            result.AddThenBlankLine(writer.WriteHeading1($"{MarkdownWriter.Normalize(t.TypeName)} {classification}"));
            result.AddThenBlankLine(ParserUtils.ProcessBreadcrumb(t));
            result.AddThenBlankLine(t.Description);
            ExtractCode(t.Code, result);

            ExtractTypeParameters(t.TypeParameters, result);

            if (t.Inheritance.Any())
            {
                result.AddThenBlankLine(ParserUtils.ParseInheritance(t.Inheritance, t.Namespace.Assembly));
            }

            if (t.ImplementedInterfaces.Any())
            {
                result.AddThenBlankLine(ParserUtils
                    .ParseImplementedInterfaces(t.ImplementedInterfaces, t.Namespace.Assembly));
            }

            ExtractRemarks(t.Remarks, result);

            result.AddThenBlankLine(writer.WriteHeading2("Examples"));

            return result;
        }

        /// <summary>
        /// Extracts type parameters into a <see cref="DocFile"/>.
        /// </summary>
        /// <param name="typeParameters">The type parameters to parse.</param>
        /// <param name="result">The <see cref="DocFile"/> to write to.</param>
        private void ExtractTypeParameters(IList<DocTypeParameter> typeParameters, DocFile result)
        {
            if (typeParameters.Any())
            {
                result.AddThenBlankLine(writer.WriteHeading3("Type Parameters"));
                foreach (var tParam in typeParameters)
                {
                    result.Add($"**`{tParam.Name}`**");
                    result.AddThenBlankLine(tParam.Description);
                }

                result.AddDivider();
            }
        }

        /// <summary>
        /// Extracts remarks.
        /// </summary>
        /// <param name="remarks">The remarks to parse.</param>
        /// <param name="result">The <see cref="DocFile"/> to parse to.</param>
        private void ExtractRemarks(string remarks, DocFile result)
        {
            if (!string.IsNullOrWhiteSpace(remarks))
            {
                result.AddThenBlankLine(writer.WriteHeading2("Remarks"));
                result.AddThenBlankLine(remarks);
            }
        }

        /// <summary>
        /// Extracts code.
        /// </summary>
        /// <param name="code">The code to parse.</param>
        /// <param name="result">The <see cref="DocFile"/> to parse to.</param>
        private void ExtractCode(string code, DocFile result)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                writer.AddRange(result.Markdown, writer.WriteCode(code));
                result.AddBlankLine();
            }
        }
    }
}
