// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.IO;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Utilities.DocumentGenerator.IO;
using ExpressionPowerTools.Utilities.DocumentGenerator.Parsers;

namespace ExpressionPowerTools.Utilities.DocumentGenerator
{
    /// <summary>
    /// Main documentatoin generation program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Root directory for documentation output.
        /// </summary>
        private const string RootDir = "../../../../../docs/api/";

        /// <summary>
        /// Example types that map to the assemblies to document.
        /// </summary>
        private static readonly Type[] ExampleTypes = new[]
        {
            typeof(DefaultComparisonRules),
            typeof(FileHelper),
        };

        /// <summary>
        /// The main entry method.
        /// </summary>
        /// <param name="args">Optional arguments (not used).</param>
        private static void Main(string[] args)
        {
            Parse();
        }

        /// <summary>
        /// Parse the files.
        /// </summary>
        private static void Parse()
        {
            var location = Directory.GetCurrentDirectory();
            var fileChecker = new FileHelper(location);
            var xmlParser = new XmlDocParser(fileChecker);
            var markdown = new DocsToMarkdownParser();
            var writer = new FileWriter(Path.Combine(location, RootDir));
            Console.WriteLine("Parsing assemblies...");
            foreach (var type in ExampleTypes)
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
