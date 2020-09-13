# MarkdownWriter.Normalize Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > [MarkdownWriter](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.cs.md) > **Normalize**

Normalize the text.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Normalize(String source)](#normalizestring-source) | Normalize the text. |
## Normalize(String source)

Normalize the text.

```csharp
public static String Normalize(String source)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The normalized text.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The source text to normalize. |


## Remarks

Strips newlines and converts opening tags to the HTML code for "less than".


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
