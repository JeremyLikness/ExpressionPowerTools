# MarkdownList Class

[ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > **MarkdownList**

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

# Constructors

| Ctor | Description |
| :-- | :-- |
| [MarkdownList(Boolean isOrdered)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownList.ctor.md#ctor-0) | Initializes a new instance of the [MarkdownList](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownList.cs.md) class. |
