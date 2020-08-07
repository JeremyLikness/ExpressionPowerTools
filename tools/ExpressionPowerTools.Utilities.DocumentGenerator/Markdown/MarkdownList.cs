using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    public class MarkdownList
    {
        private bool IsOrdered { get; set; }

        private string Ordinal => IsOrdered ? "1." : "-";

        private ICollection<string> Items { get; set; } = new List<string>();

        public MarkdownList(bool isOrdered = false)
        {
            IsOrdered = isOrdered;
        }

        public void AddItem(string item)
        {
            Items.Add($"{Ordinal} {MarkdownWriter.Normalize(item)}");
        }

        public ICollection<string> CloseList()
        {
            return Items;
        }
    }
}
