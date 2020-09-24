# MarkdownList Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > **MarkdownList**

Utility to make a markdown list.

```csharp
public class MarkdownList
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MarkdownList**

## Examples

For example:

```csharp
var list = new MarkdownList();
            foreach(var item in items)
            {
                list.AddItem(item);
            }
            ICollection<string> result = list.CloseList();
            
```

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MarkdownList(Boolean isOrdered)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownList.ctor.md#markdownlistboolean-isordered) | Initializes a new instance of the [MarkdownList](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownList.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void AddItem(String item)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownList.AddItem.m.md) | Add an item to the list. |
| [ICollection&lt;String> CloseList()](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownList.CloseList.m.md) | Close the list and obtain the generated markdown. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
