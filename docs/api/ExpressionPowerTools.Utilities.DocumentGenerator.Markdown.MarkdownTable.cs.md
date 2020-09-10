# MarkdownTable Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > **MarkdownTable**

Utility to produce a table in markdown.

```csharp
public class MarkdownTable
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MarkdownTable**

## Examples

For example:

```csharp

var table = new MarkdownTable("Class", "Description");
foreach (var item in items)
{
    table.AddRow(item.ClassName, item.Description);
}
IList<string> markdown = table.CloseTable();
            
```

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MarkdownTable(String[] headings)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownTable.ctor.md#markdowntablestring[]-headings) | Initializes a new instance of the [MarkdownTable](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownTable.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void AddRow(String[] data)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownTable.AddRow.m.md) | Add a row to the table. |
| [IList&lt;String> CloseTable()](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownTable.CloseTable.m.md) | Closes the table and generates the markdown. |
| [Void SetAlignment(MarkdownColumnAlignment[] alignment)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownTable.SetAlignment.m.md) | Pass in the alignment settings. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
