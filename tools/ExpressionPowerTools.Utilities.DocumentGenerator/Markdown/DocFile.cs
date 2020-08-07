// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    /// <summary>
    /// Generic representation of a document.
    /// </summary>
    public class DocFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFile"/> class.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        public DocFile(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the list of child documents.
        /// </summary>
        public ICollection<DocFile> Files { get; private set; } = new List<DocFile>();

        /// <summary>
        /// Gets the markdown lines for the file.
        /// </summary>
        public ICollection<string> Markdown { get; private set; } = new List<string>();

        /// <summary>
        /// Add a line to the markdown.
        /// </summary>
        /// <param name="line">The line of markdown.</param>
        public void Add(string line) => Markdown.Add(line);

        /// <summary>
        /// Add a blank line.
        /// </summary>
        public void AddBlankLine() => Markdown.Add(string.Empty);

        /// <summary>
        /// Add a divider.
        /// </summary>
        public void AddDivider() => AddThenBlankLine("---");

        /// <summary>
        /// Add a line, followed by a blank line.
        /// </summary>
        /// <param name="line">The line to add.</param>
        public void AddThenBlankLine(string line)
        {
            Add(line);
            AddBlankLine();
        }
    }
}
