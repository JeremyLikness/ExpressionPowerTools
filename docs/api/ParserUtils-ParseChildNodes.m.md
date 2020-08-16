# ParserUtils.ParseChildNodes Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Parsers](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.n.md) > [ParserUtils](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.cs.md) > **ParseChildNodes**

Parses the child nodes of XML documentation to resolve links and code blocks.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ParseChildNodes(XmlNodeList childNodes, StringBuilder sb)](#parsechildnodesxmlnodelist-childnodes-stringbuilder-sb) | Parses the child nodes of XML documentation to resolve links and code blocks. |
## ParseChildNodes(XmlNodeList childNodes, StringBuilder sb)

Parses the child nodes of XML documentation to resolve links and code blocks.

```csharp
public static Void ParseChildNodes(XmlNodeList childNodes, StringBuilder sb)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `childNodes` | [XmlNodeList](https://docs.microsoft.com/dotnet/api/system.xml.xmlnodelist) | The child nodes. |
| `sb` | [StringBuilder](https://docs.microsoft.com/dotnet/api/system.text.stringbuilder) | The [StringBuilder](https://docs.microsoft.com/dotnet/api/system.text.stringbuilder) to write to. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
