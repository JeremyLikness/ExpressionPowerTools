using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    public class DocFile
    {
        public string Name { get; set; }

        public ICollection<DocFile> Files { get; set; } = new List<DocFile>();

        public ICollection<string> Markdown { get; set; } = new List<string>();

        public void Add(string line) => Markdown.Add(line);

        public void AddBlankLine() => Markdown.Add(string.Empty);

        public void AddDivider() => AddThenBlankLine("---");

        public void AddThenBlankLine(string line)
        {
            Add(line);
            AddBlankLine();
        }
    }
}
