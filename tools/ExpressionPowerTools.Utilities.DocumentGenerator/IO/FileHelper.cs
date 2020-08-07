// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.IO;
using System.Xml;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.IO
{
    /// <summary>
    /// Class to abstract file I/O.
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// The location this helper works with.
        /// </summary>
        private readonly string location;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileHelper"/> class.
        /// </summary>
        /// <param name="location">The base location.</param>
        public FileHelper(string location)
        {
            this.location = location;
        }

        /// <summary>
        /// Determine if a file exists at the path in the location.
        /// </summary>
        /// <param name="path">The partial file path.</param>
        /// <returns><c>true</c> if the file exists. <c>false</c> if the file does not exist..</returns>
        public bool FileExists(string path)
        {
            var pathToFile = Path.Combine(location, path);
            return File.Exists(pathToFile);
        }

        /// <summary>
        /// Loads an XML document from the specified path.
        /// </summary>
        /// <param name="path">The partial path to the document.</param>
        /// <returns>The <see cref="XmlDocument"/> instance.</returns>
        public XmlDocument LoadXmlDocs(string path)
        {
            if (FileExists(path))
            {
                var pathToFile = Path.Combine(location, path);
                var doc = new XmlDocument();
                doc.Load(pathToFile);
                return doc;
            }

            return null;
        }
    }
}
