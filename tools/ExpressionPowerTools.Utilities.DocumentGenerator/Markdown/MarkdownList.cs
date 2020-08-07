// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    /// <summary>
    /// Utility to make a markdown list.
    /// </summary>
    /// <example>
    /// For example:
    /// <code lang="csharp"><![CDATA[
    /// var list = new MarkdownList();
    /// foreach(var item in items)
    /// {
    ///     list.AddItem(item);
    /// }
    /// ICollection<string> result = list.CloseList();
    /// ]]></code>
    /// </example>
    public class MarkdownList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownList"/> class.
        /// </summary>
        /// <param name="isOrdered">A value indicating whether the list should be ordered.</param>
        public MarkdownList(bool isOrdered = false)
        {
            IsOrdered = isOrdered;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the list should be ordered.
        /// </summary>
        private bool IsOrdered { get; set; }

        /// <summary>
        /// Gets the ordinal.
        /// </summary>
        private string Ordinal => IsOrdered ? "1." : "-";

        /// <summary>
        /// Gets or sets the constructed list.
        /// </summary>
        private ICollection<string> Items { get; set; } = new List<string>();

        /// <summary>
        /// Add an item to the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(string item)
        {
            Items.Add($"{Ordinal} {MarkdownWriter.Normalize(item)}");
        }

        /// <summary>
        /// Close the list and obtain the generated markdown.
        /// </summary>
        /// <returns>The generated markdown.</returns>
        public ICollection<string> CloseList()
        {
            return Items;
        }
    }
}
