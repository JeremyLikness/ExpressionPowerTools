// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.IO;
using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;

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
        /// The <see cref="MarkdownWriter"/> for formatting..
        /// </summary>
        private readonly MarkdownWriter markdownWriter = new MarkdownWriter();

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
                    type.Description = GetTextBlock(node, ParserUtils.Summary);
                    type.Remarks = GetTextBlock(node, ParserUtils.Remarks);
                    type.Example = GetTextBlock(node, ParserUtils.Example);
                    ProcessTypeParamDescriptions(node, type.TypeParameters);
                }

                if (type.Constructor != null && type.Constructor.Overloads.Any())
                {
                    foreach (var overload in type.Constructor.Overloads)
                    {
                        var docNode = doc.SelectSingleNode(overload.XPath);
                        if (docNode is XmlElement ctorNode)
                        {
                            overload.Description = GetTextBlock(ctorNode, ParserUtils.Summary);
                            overload.Remarks = GetTextBlock(ctorNode, ParserUtils.Remarks);
                            overload.Example = GetTextBlock(ctorNode, ParserUtils.Example);
                            overload.Exceptions = GetExceptions(ctorNode);
                            ProcessParameters(overload.Parameters, ctorNode);
                            ProcessTypeParamDescriptions(ctorNode, overload.TypeParameters);
                        }

                        if (string.IsNullOrWhiteSpace(overload.Description))
                        {
                            var ctorType = overload.Constructor.ConstructorType.Type;
                            overload.Description =
                                $"Initializes a new instance of the [{MarkdownWriter.Normalize(TypeCache.Cache[ctorType].FriendlyName)}]({TypeCache.Cache[ctorType].Link}) class.";
                        }
                    }
                }

                if (type.Methods.Any())
                {
                    foreach (var method in type.Methods)
                    {
                        foreach (var overload in method.MethodOverloads)
                        {
                            var oNode = doc.SelectSingleNode(overload.XPath);
                            if (oNode is XmlElement methodNode)
                            {
                                overload.Description = GetTextBlock(methodNode, ParserUtils.Summary);
                                overload.Remarks = GetTextBlock(methodNode, ParserUtils.Remarks);
                                overload.Example = GetTextBlock(methodNode, ParserUtils.Example);
                                overload.Exceptions = GetExceptions(methodNode);
                                overload.Returns = GetTextBlock(methodNode, ParserUtils.Returns);
                                ProcessParameters(overload.Parameters, methodNode);
                                ProcessTypeParamDescriptions(methodNode, overload.Method.MethodType.TypeParameters);
                            }
                        }
                    }
                }

                if (type.Properties.Any())
                {
                    ProcessProperties(doc, type.Properties, type.TypeParameters);
                }
            }
        }

        /// <summary>
        /// Process the parameter comments.
        /// </summary>
        /// <param name="parameters">The list of parameters.</param>
        /// <param name="ctorNode">The parent element to search from.</param>
        private void ProcessParameters(IList<DocParameter> parameters, XmlElement ctorNode)
        {
            foreach (var parameter in parameters)
            {
                var parameterNode = ctorNode.SelectSingleNode($"param[@name='{parameter.Name}']");
                if (parameterNode is XmlElement param)
                {
                    var sb = new StringBuilder();
                    param.ChildNodes.ParseChildNodes(sb);
                    parameter.Description = sb.ToString();
                }
            }
        }

        /// <summary>
        /// Parse property comments.
        /// </summary>
        /// <param name="doc">The comments document.</param>
        /// <param name="properties">The property list.</param>
        /// <param name="parentTypeParameters">The parent type parameters to inherit descriptions.</param>
        private void ProcessProperties(
            XmlDocument doc,
            IList<DocProperty> properties,
            IList<DocTypeParameter> parentTypeParameters)
        {
            foreach (var property in properties)
            {
                var docNode = doc.SelectSingleNode(property.XPath);
                if (docNode is XmlElement ctorNode)
                {
                    property.Description = GetTextBlock(ctorNode, ParserUtils.Summary);
                    property.Remarks = GetTextBlock(ctorNode, ParserUtils.Remarks);
                    property.Example = GetTextBlock(ctorNode, ParserUtils.Example);
                }

                // inherit metadata from parents
                var typeParams = new List<DocTypeParameter>();
                foreach (var tParam in property.TypeParameters)
                {
                    var candidate = parentTypeParameters.FirstOrDefault(
                        p => p.Name == tParam.Name);
                    typeParams.Add(candidate ?? tParam);
                }

                property.TypeParameters = typeParams;
            }
        }

        /// <summary>
        /// Gets the exception list, if available.
        /// </summary>
        /// <param name="ctorNode">The node that contains exceptions.</param>
        /// <returns>The list of exceptions and related descriptions.</returns>
        private IList<(string exception, string description)> GetExceptions(XmlElement ctorNode)
        {
            var result = new List<(string exception, string description)>();
            string exception = nameof(exception);
            foreach (var node in ctorNode.SelectNodes(exception))
            {
                if (node is XmlElement exceptionNode)
                {
                    var exceptionName = exceptionNode.GetAttribute("cref").Split(":")[^1];
                    var exceptionType = TypeCache.Cache.GetTypeFromName(exceptionName);
                    var sb = new StringBuilder();
                    exceptionNode.ChildNodes.ParseChildNodes(sb);

                    result.Add((
                        markdownWriter.WriteLink(TypeCache.Cache[exceptionType]),
                        sb.ToString()));
                }
            }

            return result;
        }

        /// <summary>
        /// Enhance type parameters with comments.
        /// </summary>
        /// <param name="parent">The <see cref="XmlElement"/> that holds the type parameters.</param>
        /// <param name="tParams">The type parameters to process.</param>
        private void ProcessTypeParamDescriptions(XmlElement parent, IList<DocTypeParameter> tParams)
        {
            foreach (var tParam in tParams)
            {
                var node = parent.SelectSingleNode($"typeparam[@name='{tParam.Name}']");
                if (node != null)
                {
                    var sb = new StringBuilder();
                    node.ChildNodes.ParseChildNodes(sb);
                    tParam.Description = sb.ToString();
                }
            }
        }

        /// <summary>
        /// Extracts a text block.
        /// </summary>
        /// <param name="typeNode">The <see cref="XmlElement"/> that contains the text block.</param>
        /// <param name="name">The name of the text block to parse.</param>
        /// <returns>The parsed text with markdown enhancements.</returns>
        private string GetTextBlock(XmlElement typeNode, string name)
        {
            var node = typeNode.SelectSingleNode(name);
            if (node == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            node.ChildNodes.ParseChildNodes(sb);
            return sb.ToString().Trim();
        }
    }
}
