using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    public class MarkdownWriter
    {
        public string WriteHeading1(string heading) => $"# {Normalize(heading)}";

        public string WriteHeading2(string heading) => $"## {Normalize(heading)}";

        public string WriteHeading3(string heading) => $"## {Normalize(heading)}";

        public string WriteInlineCode(string code) => $" `{code}` ";

        public string WriteLink((string text, string link) link) =>
            WriteLink(link.text, link.link);

        public string WriteLink(string text, string link) =>
            $" [{text}]({link}) ";

        public ICollection<string> WriteCode(string code)
        {
            var result = new List<string>
            {
                "```csharp"
            };
            result.AddRange(code.Split("\r\n"));
            result.Add("```");
            return result;
        }

        public void AddRange(ICollection<string> target, ICollection<string> source)
        {
            foreach(var src in source)
            {
                target.Add(src);
            }
        }

        public static string Normalize(string source) => source.Replace("<", "&lt;")
            .Replace("\r", string.Empty)
            .Replace("\n", string.Empty)
            .Trim();
    }
}
