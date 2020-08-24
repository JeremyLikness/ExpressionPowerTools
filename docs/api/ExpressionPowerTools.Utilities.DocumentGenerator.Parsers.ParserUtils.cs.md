# ParserUtils Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Parsers](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.n.md) > **ParserUtils**

Global parsing utilities.

```csharp
public static class ParserUtils
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ParserUtils**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static ParserUtils()](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ctor.md#static-parserutils) | Initializes a new instance of the [ParserUtils](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [String ExtractLink(XmlElement see)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ExtractLink.m.md) | Extracts a link by cross-referencing the type. |
| [String FriendlyDisplayType(String typeName)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.FriendlyDisplayType.m.md) | Convert a type to a display value. |
| [IQueryable&lt;DocExportedType> GetTypeQuery(DocAssembly assembly)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.GetTypeQuery.m.md) | Gets a queryable to examine types. |
| [String NameOnly(String fullName)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.NameOnly.m.md) | Strips the namespace qualification and normalizes the name. |
| [String NormalizeIndents(String source)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.NormalizeIndents.m.md) | Normalize the indents for a text block. |
| [Void ParseChildNodes(XmlNodeList childNodes, StringBuilder sb)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ParseChildNodes.m.md) | Parses the child nodes of XML documentation to resolve links and code blocks. |
| [String ParseDerivedTypes(IList&lt;TypeRef> derivedTypes)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ParseDerivedTypes.m.md) | Parse the derived types. |
| [String ParseImplementedInterfaces(IList&lt;TypeRef> implementedInterfaces)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ParseImplementedInterfaces.m.md) | Parses the list of implemented interfaces to a text list. |
| [String ParseInheritance(IList&lt;TypeRef> inheritance)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ParseInheritance.m.md) | Parses the inheritance chain into text. |
| [String ProcessBreadcrumb(Object doc)](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.ProcessBreadcrumb.m.md) | Process the breadcrumb for a document. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
