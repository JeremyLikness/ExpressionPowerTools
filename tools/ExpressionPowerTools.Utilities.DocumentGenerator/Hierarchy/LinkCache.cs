// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;
using ExpressionPowerTools.Utilities.DocumentGenerator.Parsers;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Cache for grabbing links.
    /// </summary>
    public static class LinkCache
    {
        /// <summary>
        /// Document cache.
        /// </summary>
        private static readonly IDictionary<string, string> Documents =
            new Dictionary<string, string>();

        /// <summary>
        /// Markdonw writer to create links.
        /// </summary>
        private static readonly MarkdownWriter MarkdownWriter = new MarkdownWriter();

        /// <summary>
        /// Register the document with the cache.
        /// </summary>
        /// <param name="doc">The document to register.</param>
        public static void Register(DocBase doc)
        {
            var key = doc.XPath.Split('\'')[1];
            if (!Documents.ContainsKey(key))
            {
                string link;
                if (doc is DocOverload overload)
                {
                    var name = overload.Name.Split(".")[^1];

                    if (overload.IsStatic)
                    {
                        name = $"static {name}";
                    }

                    link = MarkdownWriter.WriteRelativeLink(
                        name,
                        overload.Constructor.FileName);
                }
                else if (doc is DocMethodOverload methodOverload)
                {
                    link = MarkdownWriter.WriteRelativeLink(
                        methodOverload.TerseName,
                        methodOverload.Method.FileName);
                }
                else
                {
                    link = MarkdownWriter.WriteLink(
                        ParserUtils.NameOnly(doc.Name),
                        doc.FileName);
                }

                Documents.Add(key, link);
            }
        }

        /// <summary>
        /// Gets the link for the selector.
        /// </summary>
        /// <param name="xpath">The selector.</param>
        /// <returns>The link.</returns>
        public static string GetLinkBySelector(string xpath) =>
            Documents.ContainsKey(xpath) ? Documents[xpath] : null;
    }
}
