# MarkdownWriter Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > **MarkdownWriter**

Utility to help with authoring markdown.

```csharp
public class MarkdownWriter
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MarkdownWriter**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MarkdownWriter()](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.ctor.md#markdownwriter) | Initializes a new instance of the [MarkdownWriter](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void AddRange(ICollection&lt;String> target, ICollection&lt;String> source)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.AddRange.m.md) | Add a range of items to a list. |
| [String Normalize(String source)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.Normalize.m.md) | Normalize the text. |
| [ICollection&lt;String> WriteCode(String code)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteCode.m.md) | Write a code block. |
| [String WriteHeading1(String heading)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteHeading1.m.md) | Write a heading. |
| [String WriteHeading2(String heading)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteHeading2.m.md) | Write a sub-heading. |
| [String WriteHeading3(String heading)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteHeading3.m.md) | Write a nested sub-heading. |
| [String WriteInlineCode(String code)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteInlineCode.m.md) | Write an inline code block. |
| [String WriteLink(ValueTuple&lt;String, String> link)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteLink.m.md) | Write a link. |
| [String WriteRelativeLink(String text, String path)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.WriteRelativeLink.m.md) | Writes a relative link. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |
