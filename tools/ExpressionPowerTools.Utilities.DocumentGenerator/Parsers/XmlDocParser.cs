// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.IO;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    /// <summary>
    /// Parses XML comments to enhance the reflected documentation.
    /// </summary>
    public class XmlDocParser
    {
        /// <summary>
        /// File helper instance.
        /// </summary>
        private readonly FileHelper fileHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDocParser"/> class.
        /// </summary>
        /// <param name="helper">The <see cref="FileHelper"/> to use.</param>
        public XmlDocParser(FileHelper helper)
        {
            fileHelper = helper;
        }

        /// <summary>
        /// Parse the comments for an assembly.
        /// </summary>
        /// <param name="path">The path that contains the XML comments.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to annotate.</param>
        public void ParseComments(string path, DocAssembly assembly)
        {
            var doc = fileHelper.LoadXmlDocs(path);
            if (doc != null)
            {
                ParseXml(doc, assembly);
            }
        }

        /// <summary>
        /// Gets the XML comments for a type.
        /// </summary>
        /// <param name="doc">The <see cref="XmlDocument"/> with XML documentation.</param>
        /// <param name="type">The <see cref="DocExportedType"/> to annotate.</param>
        /// <returns>The <see cref="XmlElement"/> if found, <c>null</c> if not.</returns>
        private XmlElement GetType(XmlDocument doc, DocExportedType type) =>
            doc.SelectSingleNode($"/doc/members/member[@name='T:{type.Name}']") as XmlElement;

        /// <summary>
        /// Parses the XML comments.
        /// </summary>
        /// <param name="doc">The <see cref="XmlDocument"/> for XML comments.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to annotate.</param>
        private void ParseXml(XmlDocument doc, DocAssembly assembly)
        {
            var typeList = assembly.Namespaces.SelectMany(ns => ns.Types);
            foreach (var type in typeList)
            {
                var node = GetType(doc, type);
                if (node != null)
                {
                    type.Description = GetTextBlock(node, assembly, ParserUtils.Summary);
                    type.Remarks = GetTextBlock(node, assembly, ParserUtils.Remarks);
                    ProcessTypeParamDescriptions(node, assembly, type.TypeParameters);
                }
            }
        }

        /// <summary>
        /// Enhance type parameters with comments.
        /// </summary>
        /// <param name="parent">The <see cref="XmlElement"/> that holds the type parameters.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to annotate.</param>
        /// <param name="tParams">The type parameters to process.</param>
        private void ProcessTypeParamDescriptions(XmlElement parent, DocAssembly assembly, IList<DocTypeParameter> tParams)
        {
            foreach (var tParam in tParams)
            {
                var node = parent.SelectSingleNode($"typeparam[@name='{tParam.Name}']");
                if (node != null)
                {
                    var sb = new StringBuilder();
                    node.ChildNodes.ParseChildNodes(sb, assembly);
                    tParam.Description = sb.ToString();
                }
            }
        }

        /// <summary>
        /// Extracts a text block.
        /// </summary>
        /// <param name="typeNode">The <see cref="XmlElement"/> that contains the text block.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> for reference.</param>
        /// <param name="name">The <see cref="name"/> of the text block to parse.</param>
        /// <returns>The parsed text with markdown enhancements.</returns>
        private string GetTextBlock(XmlElement typeNode, DocAssembly assembly, string name)
        {
            var node = typeNode.SelectSingleNode(name);
            if (node == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            node.ChildNodes.ParseChildNodes(sb, assembly);
            return sb.ToString().Trim();
        }
    }
}
