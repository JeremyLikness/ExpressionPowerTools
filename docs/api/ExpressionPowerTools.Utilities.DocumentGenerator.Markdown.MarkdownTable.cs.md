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
| [Void AddRow(String[] data)](MarkdownTable-AddRow.m.md) | Add a row to the table. |
| [IList&lt;String> CloseTable()](MarkdownTable-CloseTable.m.md) | Closes the table and generates the markdown. |
| [Void SetAlignment(MarkdownColumnAlignment[] alignment)](MarkdownTable-SetAlignment.m.md) | Pass in the alignment settings. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
