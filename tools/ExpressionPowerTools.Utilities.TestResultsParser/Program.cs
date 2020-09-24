// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ExpressionPowerTools.Utilities.TestResultsParser
{
    /// <summary>
    /// Parser for tests and code coverage.
    /// </summary>
    public class Program
    {
        private const string Trx = "trx";
        private const string PathToTest = @"../../../../../test";
        private const string PathToTestDocs = @"../../../../../docs/test";
        private const string TestsExtension = ".Tests";
        private const string TestResults = @"TestResults/";
        private const string UnitTestResult = nameof(UnitTestResult);
        private const string Reports = @"reports/";
        private const string CoverageBadge = @"badge_combined.svg";
        private const string Summary = @"Summary.txt";

        private const string TestBadge = @"<?xml version=""1.0""?>
<svg xmlns=""http://www.w3.org/2000/svg"" width=""100"" height=""20"">
<linearGradient id=""a"" x2=""0"" y2=""100%"">
    <stop offset=""0"" stop-color=""#bbb"" stop-opacity="".1""/>
    <stop offset=""2"" stop-opacity="".1""/>
</linearGradient>

<rect rx=""3"" width=""60"" height=""20"" fill=""#555""/>
<rect rx=""3"" x=""60"" width=""40"" height=""20"" fill=""#4c1""/>

<path fill=""#4c1"" d=""M58 0h4v20h-4z""/>

<rect rx=""3"" width=""100"" height=""20"" fill=""url(#a)""/>
	<g fill=""#fff"" text-anchor=""middle"" font-family=""DejaVu Sans,Verdana,Geneva,sans-serif"" font-size=""11"">
	    <text x=""30"" y=""15"" fill=""#010101"" fill-opacity="".3"">Passing:</text>
	    <text x=""30"" y=""14"">Passing:</text>
	    <text x=""80"" y=""15"" fill=""#010101"" fill-opacity="".3"">{{count}}</text>
        <text x=""80"" y=""14"" >{{count}}</text>
    </g>
</svg>
";

        /// <summary>
        /// The list of targets to process.
        /// </summary>
        private readonly string[] targets = new string[]
        {
            "ExpressionPowerTools.Core",
            "ExpressionPowerTools.Serialization",
            "ExpressionPowerTools.Serialization.EFCore.AspNetCore",
            "ExpressionPowerTools.Serialization.EFCore.Http",
        };

        private string testDir;
        private string docsDir;

        /// <summary>
        /// Main program.
        /// </summary>
        /// <remarks>
        /// Part of CI/CD and expects to be run from release directory.
        /// </remarks>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Beginning test results processing...");
            var p = new Program();
            p.Parse();
            Console.WriteLine("Processing complete.");
        }

        /// <summary>
        /// Prepares the directories and parses the list of targets.
        /// </summary>
        public void Parse()
        {
            var location = Environment.CurrentDirectory;

            testDir = Path.Combine(location, PathToTest);

            if (!Directory.Exists(testDir))
            {
                throw new DirectoryNotFoundException(testDir);
            }

            docsDir = Path.Combine(location, PathToTestDocs);

            if (!Directory.Exists(docsDir))
            {
                throw new DirectoryNotFoundException(docsDir);
            }

            foreach (var target in targets)
            {
                ParseTarget(target);
            }
        }

        /// <summary>
        /// Parses the results for a target.
        /// </summary>
        /// <param name="target">The target to examine.</param>
        private void ParseTarget(string target)
        {
            Console.WriteLine($"Processing {target}...");
            var resultsDir = Path.Combine(testDir, $"{target}{TestsExtension}", TestResults);
            if (!Directory.Exists(resultsDir))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Results directory {resultsDir} not found. Skipping target.");
                Console.ResetColor();
                return;
            }

            ParseTrx(target, resultsDir);
            ParseCoverage(target, resultsDir);
        }

        /// <summary>
        /// Count passing tests.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="resultsDir">The directory containing tests.</param>
        private void ParseTrx(string target, string resultsDir)
        {
            foreach (var file in Directory.GetFiles(resultsDir))
            {
                if (file.EndsWith(Trx))
                {
                    var doc = new XmlDocument();
                    doc.Load(file);
                    var tests = doc.DocumentElement.ChildNodes[2];
                    var count = 0;
                    foreach (XmlNode child in tests.ChildNodes)
                    {
                        if (child.Name == UnitTestResult)
                        {
                            count++;
                        }
                    }

                    WriteBadge(target, count);
                }
            }
        }

        /// <summary>
        /// Writes the test badge.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="count">The count of tests.</param>
        private void WriteBadge(string target, int count)
        {
            var badgeName = $"{target}.Tests.svg";
            var targetPath = Path.Combine(docsDir, badgeName);
            File.WriteAllText(targetPath, TestBadge.Replace("{{count}}", count.ToString()));
            Console.WriteLine($"Generated badge {badgeName} for {count} tests.");
        }

        private void ParseCoverage(string target, string resultsDir)
        {
            var reportsDir = Path.Combine(resultsDir, Reports);
            if (!Directory.Exists(reportsDir))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Reports not found at {reportsDir}. Skipping coverage processing.");
                Console.ResetColor();
                return;
            }

            var badge = Path.Combine(reportsDir, CoverageBadge);
            var badgeContents = File.ReadAllText(badge);
            var badgeTargetName = $"{target}.Coverage.svg";
            var targetBadgePath = Path.Combine(docsDir, badgeTargetName);
            File.WriteAllText(targetBadgePath, badgeContents);

            var summary = Path.Combine(reportsDir, Summary);
            var summaryContent = File.ReadAllLines(summary);
            var markdown = new List<string>();
            bool header = true;
            bool firstCoverage = true;
            for (var idx = 0; idx < summaryContent.Length; idx++)
            {
                var line = summaryContent[idx];

                if (idx == 0)
                {
                    markdown.Add($"# Summary of Code Coverage for {target}");
                    markdown.Add(string.Empty);
                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                    DateTime newDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZoneInfo);
                    markdown.Add($"Report generated on {newDateTime}.");
                    markdown.Add(string.Empty);
                    markdown.Add("## Report Summary");
                    markdown.Add(string.Empty);
                    markdown.Add("| | |");
                    markdown.Add("|:--|:--|");
                }

                if (idx > 1 && header)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        header = false;
                        markdown.Add(string.Empty);
                        markdown.Add("## Report Detail");
                        markdown.Add(string.Empty);
                        markdown.Add("|Target|Coverage|");
                        markdown.Add("|:--|--:|");
                        continue;
                    }

                    var split = line.IndexOf(':');
                    var label = line.Substring(0, split).Trim();
                    var fact = line.Substring(split + 1).Trim();
                    markdown.Add($"|**{label}**|{fact}");
                }

                if (idx > 1 && !header)
                {
                    var targetPos = line.IndexOf(target);
                    var split = line.IndexOf(' ', targetPos);
                    var label = line.Substring(0, split).Trim();
                    var friendly = label;
                    if (label.IndexOf('`') > 0)
                    {
                        friendly = label.Substring(0, label.IndexOf('`'));
                    }

                    var coverage = line.Substring(split + 1).Replace("\t", string.Empty).Trim();
                    if (firstCoverage)
                    {
                        firstCoverage = false;
                        markdown.Add($"|[**{friendly} Summary**](..\\api\\{target}.n.md)|{coverage}|");
                    }
                    else
                    {
                        markdown.Add($"|[{friendly}](..\\api\\{label}.cs.md)|{coverage}|");
                    }
                }
            }

            markdown.Add(string.Empty);
            markdown.Add("[Go Back](./index.md)");

            var coverageDoc = $"{target}.coverage.md";
            var coveragePath = Path.Combine(docsDir, coverageDoc);
            File.WriteAllLines(coveragePath, markdown);
            Console.WriteLine($"Successed parsed coverage for {target} to {coverageDoc}.");
        }
    }
}
