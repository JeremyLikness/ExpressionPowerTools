# DocFile Class

[ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > **DocFile**

Generic representation of a document.

```csharp
public class DocFile
```

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → **DocFile**

# Constructors

| Ctor | Description |
| :-- | :-- |
| [DocFile(String name)](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.ctor.md#ctor-0) | Initializes a new instance of the [DocFile](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.cs.md) class. |
### Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Name`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the name of the file. |
| [`Files`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Files.prop.md) | [ICollection&lt;DocFile>](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1) | Gets the list of child documents. |
| [`Markdown`](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.DocFile.Markdown.prop.md) | [ICollection&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1) | Gets the markdown lines for the file. |

