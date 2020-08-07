// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    /// <summary>
    /// Utility to help with authoring markdown.
    /// </summary>
    public class MarkdownWriter
    {
        /// <summary>
        /// Normalize the text.
        /// </summary>
        /// <remarks>
        /// Strips newlines and converts opening tags to the HTML code for "less than."
        /// </remarks>
        /// <param name="source">The source text to normalize.</param>
        /// <returns>The normalized text.</returns>
        public static string Normalize(string source) => source.Replace("<", "&lt;")
            .Replace("\r", string.Empty)
            .Replace("\n", string.Empty)
            .Trim();

        /// <summary>
        /// Write a heading.
        /// </summary>
        /// <param name="heading">The heading text.</param>
        /// <returns>The heading markdown.</returns>
        public string WriteHeading1(string heading) => $"# {Normalize(heading)}";

        /// <summary>
        /// Write a sub-heading.
        /// </summary>
        /// <param name="heading">The heading text.</param>
        /// <returns>The sub-heading markdown.</returns>
        public string WriteHeading2(string heading) => $"## {Normalize(heading)}";

        /// <summary>
        /// Write a nested sub-heading.
        /// </summary>
        /// <param name="heading">The heading text.</param>
        /// <returns>The nested sub-heading markdown.</returns>
        public string WriteHeading3(string heading) => $"## {Normalize(heading)}";

        /// <summary>
        /// Write an inline code block.
        /// </summary>
        /// <param name="code">The inline code.</param>
        /// <returns>The code markdown.</returns>
        public string WriteInlineCode(string code) => $" `{code}` ";

        /// <summary>
        /// Write a link.
        /// </summary>
        /// <param name="link">The named tuple with the text and link target.</param>
        /// <returns>The markdown link.</returns>
        public string WriteLink((string text, string link) link) =>
            WriteLink(link.text, link.link);

        /// <summary>
        /// Write a link.
        /// </summary>
        /// <param name="text">The link text.</param>
        /// <param name="link">The link target.</param>
        /// <returns>The markdown link.</returns>
        public string WriteLink(string text, string link) =>
            $" [{text}]({link}) ";

        /// <summary>
        /// Write a code block.
        /// </summary>
        /// <param name="code">The code to write.</param>
        /// <returns>The code markdown.</returns>
        public ICollection<string> WriteCode(string code)
        {
            var result = new List<string>
            {
                "```csharp",
            };
            result.AddRange(code.Split("\r\n"));
            result.Add("```");
            return result;
        }

        /// <summary>
        /// Add a range of items to a list.
        /// </summary>
        /// <param name="target">The target to add the range to.</param>
        /// <param name="source">The source to add.</param>
        public void AddRange(ICollection<string> target, ICollection<string> source)
        {
            foreach (var src in source)
            {
                target.Add(src);
            }
        }
    }
}
