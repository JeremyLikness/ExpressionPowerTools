// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.IO;
using System.Text;
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
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="rootDir">The target root directory.</param>
        public FileWriter(string rootDir)
        {
            if (!Directory.Exists(rootDir))
            {
                throw new InvalidOperationException();
            }

            targetDir = rootDir;
        }

        /// <summary>
        /// Purges the directory to write fresh documentation.
        /// </summary>
        public void Purge()
        {
            foreach (var file in Directory.GetFiles(targetDir))
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
            var filePath = Path.Combine(targetDir, file.Name);
            File.WriteAllLines(filePath, file.Markdown, Encoding.UTF8);
            foreach (var child in file.Files)
            {
                Write(child);
            }
        }
    }
}
