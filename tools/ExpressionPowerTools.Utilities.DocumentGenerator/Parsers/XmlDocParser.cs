// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// Parses the XML comments.
        /// </summary>
        /// <param name="doc">The <see cref="XmlDocument"/> for XML comments.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> to annotate.</param>
        private void ParseXml(XmlDocument doc, DocAssembly assembly)
        {
            var typeList = assembly.Namespaces.SelectMany(ns => ns.Types);
            foreach (var type in typeList)
            {
                var typeNode = doc.SelectSingleNode(type.XPath);
                if (typeNode is XmlElement node)
                {
                    type.Description = GetTextBlock(node, assembly, ParserUtils.Summary);
                    type.Remarks = GetTextBlock(node, assembly, ParserUtils.Remarks);
                    type.Example = GetTextBlock(node, assembly, ParserUtils.Example);
                    ProcessTypeParamDescriptions(node, assembly, type.TypeParameters);
                }

                if (type.Constructor != null && type.Constructor.Overloads.Any())
                {
                    foreach (var overload in type.Constructor.Overloads)
                    {
                        var docNode = doc.SelectSingleNode(overload.XPath);
                        if (docNode is XmlElement ctorNode)
                        {
                            overload.Description = GetTextBlock(ctorNode, assembly, ParserUtils.Summary);
                            overload.Remarks = GetTextBlock(ctorNode, assembly, ParserUtils.Remarks);
                            overload.Example = GetTextBlock(ctorNode, assembly, ParserUtils.Example);
                            overload.Exceptions = GetExceptions(ctorNode, assembly);
                            foreach (var parameter in overload.Parameters)
                            {
                                var parameterNode = ctorNode.SelectSingleNode($"param[@name='{parameter.Name}']");
                                if (parameterNode is XmlElement param)
                                {
                                    var sb = new StringBuilder();
                                    param.ChildNodes.ParseChildNodes(sb, assembly);
                                    parameter.Description = sb.ToString();
                                }
                            }
                        }

                        if (string.IsNullOrWhiteSpace(overload.Description))
                        {
                            overload.Description =
                                $"Initializes a new instance of the {ParserUtils.ExtractLinkForType(assembly, overload.Constructor.ConstructorType.Name)} class.";
                        }
                    }
                }

                if (type.Properties.Any())
                {
                    ProcessProperties(doc, type.Properties);
                }
            }
        }

        /// <summary>
        /// Parse property comments.
        /// </summary>
        /// <param name="doc">The comments document.</param>
        /// <param name="properties">The property list.</param>
        private void ProcessProperties(XmlDocument doc, IList<DocProperty> properties)
        {
            foreach (var property in properties)
            {
                var assembly = property.ParentType.Namespace.Assembly;
                var docNode = doc.SelectSingleNode(property.XPath);
                if (docNode is XmlElement ctorNode)
                {
                    property.Description = GetTextBlock(ctorNode, assembly, ParserUtils.Summary);
                    property.Remarks = GetTextBlock(ctorNode, assembly, ParserUtils.Remarks);
                    property.Example = GetTextBlock(ctorNode, assembly, ParserUtils.Example);
                }
            }
        }

        /// <summary>
        /// Gets the exception list, if available.
        /// </summary>
        /// <param name="ctorNode">The node that contains exceptions.</param>
        /// <param name="assembly">The <see cref="DocAssembly"/> for cross-referencce.</param>
        /// <returns>The list of exceptions and related descriptions.</returns>
        private IList<(string exception, string description)> GetExceptions(XmlElement ctorNode, DocAssembly assembly)
        {
            var result = new List<(string exception, string description)>();
            string exception = nameof(exception);
            foreach (var node in ctorNode.SelectNodes(exception))
            {
                if (node is XmlElement exceptionNode)
                {
                    var exceptionName = exceptionNode.GetAttribute("cref").Split(":")[^1];
                    var sb = new StringBuilder();
                    exceptionNode.ChildNodes.ParseChildNodes(sb, assembly);
                    result.Add((
                        ParserUtils.ExtractLinkForType(assembly, exceptionName),
                        sb.ToString()));
                }
            }

            return result;
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
        /// <param name="name">The name of the text block to parse.</param>
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
