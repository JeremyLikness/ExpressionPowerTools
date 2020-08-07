using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Markdown
{
    public enum MarkdownColumnAlignment
    {
        Left,
        Center,
        Right
    }

    public class MarkdownTable
    {
        private readonly IList<string> headings;

        private readonly IList<MarkdownColumnAlignment> alignment;
        
        private readonly IList<ICollection<string>> rows;
        
        public MarkdownTable(params string[] headings)
        {
            if (headings == null || headings.Length < 2)
            {
                throw new InvalidOperationException();
            }

            this.headings = headings.ToList();

            alignment = new List<MarkdownColumnAlignment>(
                this.headings.Select(h => MarkdownColumnAlignment.Left).ToList());

            rows = new List<ICollection<string>>();
        }

        public void SetAlignment(params MarkdownColumnAlignment[] alignment)
        {
            if (alignment.Length > headings.Count)
            {
                throw new InvalidOperationException();
            }

            for (var idx = 0; idx < alignment.Length; idx+=1)
            {
                this.alignment[idx] = alignment[idx]; 
            }
        }

        public void AddRow(params string[] data)
        {
            if (data == null || data.Length > headings.Count)
            {
                throw new InvalidOperationException();
            }

            rows.Add(data.Select(d => MarkdownWriter.Normalize(d)).ToList());
        }

        public IList<string> CloseTable()
        {
            var result = new List<string>();
            var headline = string.Join('|', headings.Select(h => $" {h} ").ToArray());
            result.Add($"|{headline}|");
            var align = string.Join('|', alignment.Select(a => $" {ToAlignmentString(a)} "));
            result.Add($"|{align}|");
            foreach(var row in rows)
            {
                var rowText = string.Join('|', row.Select(r => $" {r} ").ToArray());
                result.Add($"|{rowText}|");
            }
            return result;
        }

        private string ToAlignmentString(MarkdownColumnAlignment align)
        {
            switch(align)
            {
                case MarkdownColumnAlignment.Left:
                    return ":--";
                case MarkdownColumnAlignment.Right:
                    return "--:";
                default:
                    return ":-:";
            }
        }
    }
}
