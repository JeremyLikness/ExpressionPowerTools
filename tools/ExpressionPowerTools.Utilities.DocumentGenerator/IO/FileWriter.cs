using ExpressionPowerTools.Utilities.DocumentGenerator.Markdown;
using System;
using System.IO;
using System.Text;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.IO
{
    public class FileWriter
    {
        private readonly string targetDir;

        public FileWriter(string rootDir)
        {
            if (!Directory.Exists(rootDir))
            {
                throw new InvalidOperationException();
            }
            targetDir = rootDir;
        }

        public void Write(DocFile file)
        {
            var filePath = Path.Combine(targetDir, file.Name);
            File.WriteAllLines(filePath, file.Markdown, Encoding.UTF8);
            foreach(var child in file.Files)
            {
                Write(child);
            }
        }
    }
}
