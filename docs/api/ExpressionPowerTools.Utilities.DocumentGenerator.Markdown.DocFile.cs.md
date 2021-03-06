﻿# DocFile Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > **DocFile**

Generic representation of a document.

```csharp
public class DocFile
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DocFile**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DocFile(String name)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.ctor.md#docfilestring-name) | Initializes a new instance of the [DocFile](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`FileCount`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.FileCount.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets count of files. |
| [`Files`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Files.prop.md) | [ICollection&lt;DocFile>](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1) | Gets the list of child documents. |
| [`Markdown`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Markdown.prop.md) | [ICollection&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1) | Gets the markdown lines for the file. |
| [`Name`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the name of the file. |

## Methods

| Method | Description |
| :-- | :-- |
| [Void Add(String line)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Add.m.md) | Add a line to the markdown. |
| [Void AddBlankLine()](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.AddBlankLine.m.md) | Add a blank line. |
| [Void AddDivider()](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.AddDivider.m.md) | Add a divider. |
| [Void AddThenBlankLine(String line)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.AddThenBlankLine.m.md) | Add a line, followed by a blank line. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
