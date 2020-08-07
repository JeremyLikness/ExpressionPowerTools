// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    /// <summary>
    /// Utility to produce a table in markdown.
    /// </summary>
    /// <example>
    /// For example:
    /// <code lang="csharp"><![CDATA[
    /// var table = new MarkdownTable("Class", "Description");
    /// foreach (var item in items)
    /// {
    ///     table.AddRow(item.ClassName, item.Description);
    /// }
    /// IList<string> markdown = table.CloseTable();
    /// ]]></code>
    /// </example>
    public class MarkdownTable
    {
        /// <summary>
        /// The column headings.
        /// </summary>
        private readonly IList<string> headings;

        /// <summary>
        /// The list of column alignments.
        /// </summary>
        private readonly IList<MarkdownColumnAlignment> alignment;

        /// <summary>
        /// The rows of the table.
        /// </summary>
        private readonly IList<ICollection<string>> rows;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownTable"/> class.
        /// </summary>
        /// <param name="headings">The list of headings.</param>
        public MarkdownTable(params string[] headings)
        {
            if (headings == null || headings.Length < 2)
            {
                throw new InvalidOperationException();
            }

            this.headings = headings.ToList();

            alignment = new List<MarkdownColumnAlignment>(
                this.headings.Select(h => MarkdownColumnAlignment.Left).ToList());

            rows = new List<ICollection<string>>();
        }

        /// <summary>
        /// Pass in the alignment settings.
        /// </summary>
        /// <param name="alignment">The list of settings per column.</param>
        public void SetAlignment(params MarkdownColumnAlignment[] alignment)
        {
            if (alignment.Length > headings.Count)
            {
                throw new InvalidOperationException();
            }

            for (var idx = 0; idx < alignment.Length; idx += 1)
            {
                this.alignment[idx] = alignment[idx];
            }
        }

        /// <summary>
        /// Add a row to the table.
        /// </summary>
        /// <param name="data">The data for the row (each column).</param>
        public void AddRow(params string[] data)
        {
            if (data == null || data.Length > headings.Count)
            {
                throw new InvalidOperationException();
            }

            rows.Add(data.Select(d => MarkdownWriter.Normalize(d)).ToList());
        }

        /// <summary>
        /// Closes the table and generates the markdown.
        /// </summary>
        /// <returns>The generated markdown.</returns>
        public IList<string> CloseTable()
        {
            var result = new List<string>();
            var headline = string.Join('|', headings.Select(h => $" {h} ").ToArray());
            result.Add($"|{headline}|");
            var align = string.Join('|', alignment.Select(a => $" {ToAlignmentString(a)} "));
            result.Add($"|{align}|");
            foreach (var row in rows)
            {
                var rowText = string.Join('|', row.Select(r => $" {r} ").ToArray());
                result.Add($"|{rowText}|");
            }

            return result;
        }

        /// <summary>
        /// Converts alignment to the markdown convention.
        /// </summary>
        /// <param name="align">The alignment to parse.</param>
        /// <returns>The string that represents the alignment.</returns>
        private string ToAlignmentString(MarkdownColumnAlignment align)
        {
            return align switch
            {
                MarkdownColumnAlignment.Left => ":--",
                MarkdownColumnAlignment.Right => "--:",
                _ => ":-:",
            };
        }
    }
}
