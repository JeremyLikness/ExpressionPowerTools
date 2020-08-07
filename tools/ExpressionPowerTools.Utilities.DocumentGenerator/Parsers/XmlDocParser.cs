using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    public class XmlDocParser
    {
        private readonly FileHelper fileHelper;

        private XmlElement GetType(XmlDocument doc, DocExportedType type) =>
            doc.SelectSingleNode($"/doc/members/member[@name='T:{type.Name}']") as XmlElement;

        public XmlDocParser(FileHelper helper)
        {
            fileHelper = helper;
        }

        public void ParseComments(string path, DocAssembly assembly)
        {
            var doc = fileHelper.LoadXmlDocs(path);
            if (doc != null)
            {
                ParseXml(doc, assembly);
            }
        }

        private void ParseXml(XmlDocument doc, DocAssembly assembly)
        {
            var typeList = assembly.Namespaces.SelectMany(ns => ns.Types);
            foreach (var type in typeList)
            {
                var node = GetType(doc, type);
                if (node != null)
                {
                    type.Description = GetTextBlock(node, assembly, ParserUtils.summary);
                    type.Remarks = GetTextBlock(node, assembly, ParserUtils.remarks);
                    ProcessTypeParamDescriptions(node, assembly, type.TypeParameters);
                }
            }
        }

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
