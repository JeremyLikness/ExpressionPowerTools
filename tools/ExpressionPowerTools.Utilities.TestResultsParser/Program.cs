// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
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
        private const string TestResults = @"TestDocResults/";
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
                    var rawResults = new List<TestResult>();
                    var doc = new XmlDocument();
                    doc.Load(file);
                    var tests = doc.DocumentElement.ChildNodes[2];
                    var count = 0;
                    foreach (XmlNode child in tests.ChildNodes)
                    {
                        if (child.Name == UnitTestResult)
                        {
                            count++;
                            var result = new TestResult(
                                TestNameParser(child.Attributes.GetNamedItem("testName").InnerText))
                            {
                                Duration = TimeSpan.Parse(child.Attributes.GetNamedItem("duration").InnerText),
                            };
                            rawResults.Add(result);
                        }
                    }

                    WriteBadge(target, count);
                    WriteTestReport(target, rawResults);
                }
            }
        }

        /// <summary>
        /// Writes the test report from the last tests run.
        /// </summary>
        /// <param name="target">The target it was run for.</param>
        /// <param name="rawResults">The raw results.</param>
        private void WriteTestReport(string target, List<TestResult> rawResults)
        {
            var reportHierarchy = new List<TestResult>();

            TestResult testHeader = null;
            TestResult groupHeader = null;

            foreach (var result in rawResults.OrderBy(r => r.Group).ThenBy(r => r.Test))
            {
                if (groupHeader == null || result.Group != groupHeader.Group)
                {
                    if (groupHeader != null)
                    {
                        reportHierarchy.Add(groupHeader);
                    }

                    groupHeader = new TestResult
                    {
                        Group = result.Group,
                        GroupHeader = true,
                        Duration = TimeSpan.FromSeconds(0),
                    };
                }

                if (testHeader == null || result.Test != testHeader.Test)
                {
                    if (testHeader != null)
                    {
                        groupHeader.AddChild(testHeader);
                    }

                    if (!string.IsNullOrWhiteSpace(result.Iteration))
                    {
                        testHeader = new TestResult
                        {
                            Group = result.Group,
                            TestHeader = true,
                            Test = result.Test,
                            Duration = TimeSpan.FromSeconds(0),
                        };
                    }
                    else
                    {
                        result.TestHeader = true;
                        testHeader = result;
                    }
                }

                if (!string.IsNullOrWhiteSpace(result.Iteration))
                {
                    testHeader.AddChild(result);
                }
            }

            groupHeader.AddChild(testHeader);
            reportHierarchy.Add(groupHeader);

            var markdown = new List<string>
            {
                $"# Summary of Test Runs for {target}",
                string.Empty,
                "Jump to group:",
                string.Empty,
            };

            static string GroupName(TestResult group) => $"{group.Group} ({group.DurationString})";

            static string GroupLink(TestResult group) => GroupName(group).Replace(' ', '-')
                .Replace(".", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .ToLowerInvariant();

            foreach (var group in reportHierarchy.OrderBy(g => g.Group))
            {
                markdown.Add($"- [{group.Group}](#{GroupLink(group)})");
            }

            markdown.Add(string.Empty);

            var slowestTest = reportHierarchy.SelectMany(g => g.ChildTests).Where(c => c.ChildTests.Count == 0)
                .Union(reportHierarchy.SelectMany(g => g.ChildTests).SelectMany(c => c.ChildTests))
                .OrderByDescending(c => c.Duration)
                .First();

            markdown.Add($"The slowest test was '{slowestTest}' at {slowestTest.DurationString}.");
            markdown.Add(string.Empty);

            foreach (var group in reportHierarchy
                .OrderByDescending(
                g => g.ChildTests.Max(t => t.Duration)))
            {
                var groupHasIterations = group.ChildTests.Any(t => t.ChildTests.Count > 0);
                markdown.Add($"## {GroupName(group)}");
                markdown.Add(string.Empty);
                markdown.Add(groupHasIterations ? "|Test Name|Test Iteration|Duration|"
                    : "|Test Name|Duration|");
                markdown.Add(groupHasIterations ? "|:--|:--|--:|" : "|:--|--:|");
                foreach (var test in group.ChildTests.OrderByDescending(
                    t => t.ChildTests.Count > 0 ?
                    t.ChildTests.Max(c => c.Duration) : t.Duration))
                {
                    var testHasIterations = test.ChildTests.Count > 0;
                    var testName = testHasIterations ?
                        $"**{test.Test}**" : test.Test;
                    var duration = testHasIterations ?
                        $"**{test.DurationString}**" : test.DurationString;
                    markdown.Add(groupHasIterations ? $"|{testName}| |{duration}|"
                        : $"|{testName}|{duration}|");
                    if (test.ChildTests.Count > 0)
                    {
                        foreach (var iteration in test.ChildTests.OrderByDescending(i => i.Duration))
                        {
                            markdown.Add($"| |{iteration.Iteration}|{iteration.DurationString}|");
                        }
                    }
                }
            }

            markdown.Add(string.Empty);
            markdown.Add("[Go Back](./index.md)");

            var testDoc = $"{target}.test.md";
            var testPath = Path.Combine(docsDir, testDoc);
            File.WriteAllLines(testPath, markdown);
            Console.WriteLine($"Successed parsed tests for {target} to {testDoc}.");
        }

        /// <summary>
        /// Parse out to human readable test name.
        /// </summary>
        /// <param name="fullTest">The full test identifier.</param>
        /// <returns>The parts of the test display.</returns>
        private IList<string> TestNameParser(string fullTest)
        {
            var parsed = fullTest.AsSpan();
            var sentence = new List<string>();
            var iteration = string.Empty;
            var methodPos = parsed.IndexOf('(');
            if (methodPos > 0)
            {
                iteration = new string(parsed.Slice(methodPos));
                parsed = parsed.Slice(0, methodPos);
            }

            var pos = parsed.LastIndexOf('.');
            var frontSegment = parsed.Slice(0, pos - 1);
            var testGroupPos = frontSegment.LastIndexOf('.');
            var testGroup = frontSegment.Slice(testGroupPos + 1);
            sentence.Add(new string(testGroup));
            var wordPos = ++pos;
            pos += 1;
            while (pos > 0 && pos < parsed.Length)
            {
                if (parsed[pos] >= 'A' && parsed[pos] <= 'Z')
                {
                    var length = pos - wordPos;
                    var word = new string(parsed.Slice(wordPos, length));
                    sentence.Add(word);
                    wordPos = pos;
                }

                pos++;
            }

            sentence.Add(new string(parsed[wordPos..]));
            if (!string.IsNullOrWhiteSpace(iteration))
            {
                sentence.Add(iteration);
            }

            return sentence;
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
                    markdown.Add($"Report generated on {DateTime.UtcNow} UTC.");
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
                    if (split > 0)
                    {
                        var label = line.Substring(0, split).Trim();
                        if (split + 1 < line.Length)
                        {
                            var fact = line.Substring(split + 1).Trim();
                            markdown.Add($"|**{label}**|{fact}");
                        }
                    }
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
                    string icon = string.Empty;
                    if (double.TryParse(coverage.Replace("%", string.Empty), out double pct))
                    {
                        if (pct >= 100)
                        {
                            icon = "✅";
                        }
                        else if (pct >= 90)
                        {
                            icon = "⚠";
                        }
                        else
                        {
                            icon = "🛑";
                        }
                    }

                    if (firstCoverage)
                    {
                        firstCoverage = false;
                        markdown.Add($"|**{icon} {friendly} Summary**|{coverage}|");
                    }
                    else
                    {
                        markdown.Add($"|{icon}   {friendly}|{coverage}|");
                    }
                }
            }

            markdown.Add(string.Empty);
            markdown.Add("[Go Back](./index.md)");

            var coverageDoc = $"{target}.coverage.md";

            var coveragePath = Path.Combine(docsDir, coverageDoc);
            File.WriteAllLines(coveragePath, markdown);
            Console.WriteLine($"Successfully parsed coverage for {target} to {coverageDoc}.");
        }
    }
}
