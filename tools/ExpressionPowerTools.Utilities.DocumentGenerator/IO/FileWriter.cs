// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ExpressionPowerTools.Core;
using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.IO
{
    /// <summary>
    /// Performs the actual writing of documentation to disk.
    /// </summary>
    public class FileWriter
    {
        /// <summary>
        /// The target directory to write to.
        /// </summary>
        private readonly string targetDir;

        /// <summary>
        /// The footer for each page.
        /// </summary>
        private readonly List<string> footer = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="rootDir">The target root directory.</param>
        /// <param name="version">The version to generate.</param>
        public FileWriter(string rootDir, string version)
        {
            if (!Directory.Exists(rootDir))
            {
                throw new InvalidOperationException();
            }

            targetDir = rootDir;
            SetupFooter(version);
        }

        /// <summary>
        /// Purges the directory to write fresh documentation.
        /// </summary>
        public void Purge()
        {
            foreach (var file in Directory.GetFiles(targetDir).ToList())
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Write the document and related documents to disk.
        /// </summary>
        /// <param name="file">The <see cref="DocFile"/> to persist.</param>
        public void Write(DocFile file)
        {
            // add footer
            foreach (var line in footer)
            {
                file.Markdown.Add(line);
            }

            var filePath = Path.Combine(targetDir, file.Name);
            File.WriteAllLines(filePath, file.Markdown, Encoding.UTF8);
            foreach (var child in file.Files)
            {
                Write(child);
            }
        }

        /// <summary>
        /// Sets up the documentation footer.
        /// </summary>
        private void SetupFooter(string version)
        {
            var copyrightInfo = GetType().Assembly
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute;
            var copyright = copyrightInfo?.Copyright;
            var file = new DocFile("footer");
            file.AddBlankLine();
            file.AddDivider();
            var table = new MarkdownTable("Generated", "Copyright", "Version");
            table.SetAlignment(MarkdownColumnAlignment.Left, MarkdownColumnAlignment.Center, MarkdownColumnAlignment.Right);
            table.AddRow(DateTime.UtcNow.ToString(), copyright, version);
            foreach (var line in table.CloseTable())
            {
                file.Add(line);
            }

            footer.AddRange(file.Markdown);
        }
    }
}
