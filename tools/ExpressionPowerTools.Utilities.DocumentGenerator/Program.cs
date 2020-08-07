using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Utilities.DocumentGenerator.IO;
using ExpressionPowerTools.Utilities.DocumentGenerator.Parsers;
using System;
using System.IO;

namespace ExpressionPowerTools.Utilities.DocumentGenerator
{
    class Program
    {
        const string rootDir = "../../../../../docs/api/";
        static readonly Type[] ExampleTypes = new[]
        {
            typeof(DefaultComparisonRules)
        };

        static void Main(string[] args)
        {
            Parse();
        }

        static void Parse()
        {
            var location = Directory.GetCurrentDirectory();
            var fileChecker = new FileHelper(location);
            var xmlParser = new XmlDocParser(fileChecker);
            var markdown = new DocsToMarkdownParser();
            var writer = new FileWriter(Path.Combine(location, rootDir));
            Console.WriteLine("Parsing assemblies...");
            foreach(var type in ExampleTypes)
            {
                var fullname = type.Assembly.FullName;
                var assembly = fullname.Split(",")[0];
                Console.WriteLine($"Checking {assembly}...");
                var docName = $"{assembly}.xml";
                Console.Write("Documentation file: {docName} exists? ");
                var hasDocs = fileChecker.FileExists(docName);
                Console.WriteLine(hasDocs);
                var parser = new AssemblyParser(type.Assembly);
                var doc = parser.Parse();
                Console.WriteLine("Parsing XML documents...");
                xmlParser.ParseComments(docName, doc);
                Console.WriteLine("Transforming to markdown...");
                var docFile = markdown.Parse(doc);
                Console.WriteLine("Writing documentation...");
                writer.Write(docFile);
                Console.WriteLine("Success.");
            }
            Console.WriteLine("Finished parsing assemblies. Documentation has been generated.");
        }
    }
}
