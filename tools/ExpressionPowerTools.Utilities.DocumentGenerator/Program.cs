// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
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
            typeof(BaseSerializer),
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var location = Directory.GetCurrentDirectory();
            var fileChecker = new FileHelper(location);
            var xmlParser = new XmlDocParser(fileChecker);
            var markdown = new DocsToMarkdownParser();
            var writer = new FileWriter(Path.Combine(location, RootDir));
            Console.WriteLine("Parsing assemblies (pass 1)...");
            var assemblies = new List<(DocAssembly doc, AssemblyParser parser)>();
            foreach (var type in ExampleTypes)
            {
                var parser = new AssemblyParser(type.Assembly);
                var doc = parser.Parse();
                assemblies.Add((doc, parser));
            }

            Console.WriteLine($"Parsed {ExampleTypes.Length} assemblies. Starting pass 2...");

            int fileCount = 0;
            long elapsed = 0;

            bool deleted = false;

            foreach (var (doc, parser) in assemblies)
            {
                parser.Parse(doc);
                Console.WriteLine($"Checking {doc.Name}...");
                var docName = $"{doc.Name}.xml";
                Console.Write($"Documentation file: {docName} exists? ");
                var hasDocs = fileChecker.FileExists(docName);
                Console.WriteLine(hasDocs);
                Console.WriteLine("Parsing XML documents...");
                xmlParser.ParseComments(docName, doc);
                Console.WriteLine("Transforming to markdown...");
                var docFile = markdown.Parse(doc);
                if (deleted == false)
                {
                    Console.WriteLine("Purging existing docs....");
                    writer.Purge();
                    deleted = true;
                }

                Console.WriteLine("Writing documentation...");
                writer.Write(docFile);
                stopwatch.Stop();
                elapsed += stopwatch.ElapsedMilliseconds;
                fileCount += docFile.FileCount;
                Console.WriteLine("Success.");
            }

            Console.WriteLine($"Processed {TypeCache.Cache.TypeCount} types and generated {fileCount} files in {elapsed}ms.");
        }
    }
}
