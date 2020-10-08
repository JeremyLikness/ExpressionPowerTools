# MarkdownWriter.WriteLink Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Markdown](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.n.md) > [MarkdownWriter](ExpressionPowerTools.Utilities.DocumentGenerator.Markdown.MarkdownWriter.cs.md) > **WriteLink**

Write a link.

## Overloads

| Overload | Description |
| :-- | :-- |
| [WriteLink(String text, String link)](#writelinkstring-text-string-link) | Write a link. |
| [WriteLink(TypeRef type)](#writelinktyperef-type) | Writes the link for a type. |
| [WriteLink(ValueTuple&lt;String, String> link)](#writelinkvaluetuplestring-string-link) | Write a link. |
## WriteLink(String text, String link)

Write a link.

```csharp
public String WriteLink(String text, String link)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The markdown link.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `text` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The link text. |
| `link` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The link target. |


## WriteLink(TypeRef type)

Writes the link for a type.

```csharp
public String WriteLink(TypeRef type)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The link to the documentation for the type.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [TypeRef](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.TypeRef.cs.md) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) to create a link for. |


## WriteLink(ValueTuple&lt;String, String> link)

Write a link.

```csharp
public String WriteLink(ValueTuple<String, String> link)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The markdown link.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `link` | [ValueTuple&lt;String, String>](https://docs.microsoft.com/dotnet/api/system.valuetuple-2) | The named tuple with the text and link target. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
