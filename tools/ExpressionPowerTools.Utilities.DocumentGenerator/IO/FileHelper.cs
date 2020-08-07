using System;
using System.IO;
using System.Xml;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.IO
{
    public class FileHelper
    {
        private readonly string location;

        public FileHelper(string location)
        {
            this.location = location;
        }

        public bool FileExists(string path)
        {
            var pathToFile = Path.Combine(location, path);
            return File.Exists(pathToFile);
        }

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
