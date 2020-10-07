// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionPowerTools.Utilities.TestResultsParser
{
    /// <summary>
    /// A test result.
    /// </summary>
    public class TestResult
    {
        private string iteration = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestResult"/> class.
        /// </summary>
        public TestResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestResult"/> class.
        /// </summary>
        /// <param name="parts">The test parts.</param>
        public TestResult(ICollection<string> parts)
        {
            var copy = parts.Select(p => p).ToList();
            Group = copy[0];
            copy.RemoveAt(0);
            if (copy[^1].StartsWith('('))
            {
                Iteration = copy[^1];
                copy.RemoveAt(copy.Count - 1);
            }

            Test = string.Join(' ', copy);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is a group header.
        /// </summary>
        public bool GroupHeader { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether this is a header for test results.
        /// </summary>
        public bool TestHeader { get; set; } = false;

        /// <summary>
        /// Gets or sets the group the test belongs to.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the name of the test.
        /// </summary>
        public string Test { get; set; }

        /// <summary>
        /// Gets or sets the test iteration.
        /// </summary>
        public string Iteration
        {
            get => iteration.Replace('`', '^')
                .Replace('[', '{')
                .Replace(']', '}')
                .Replace("<", "{")
                .Replace(">", "}")
                .Replace('|', '$');
            set => iteration = value;
        }

        /// <summary>
        /// Gets or sets the duration of the test.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets duration as a string.
        /// </summary>
        public string DurationString =>
            Duration < TimeSpan.FromMilliseconds(1) ?
                $"{Math.Floor(Duration.TotalMilliseconds * 1000)} ns" :
                Duration < TimeSpan.FromSeconds(1) ?
                    $"{Math.Floor(Duration.TotalMilliseconds)} ms" :
                    $"{Math.Floor(Duration.TotalSeconds * 10) / 10} s";

        /// <summary>
        /// Gets the list of child results.
        /// </summary>
        public IList<TestResult> ChildTests { get; private set; } = new List<TestResult>();

        /// <summary>
        /// Adds a child to the collection.
        /// </summary>
        /// <param name="child">The child to add.</param>
        public void AddChild(TestResult child)
        {
            ChildTests.Add(child);
            Duration = Duration.Add(child.Duration);
        }

        /// <summary>
        /// To string override.
        /// </summary>
        /// <returns>The appropriate title based on level.</returns>
        public override string ToString()
        {
            if (GroupHeader)
            {
                return Group;
            }

            if (TestHeader)
            {
                return Test;
            }

            return $"{Test} {Iteration}";
        }
    }
}
