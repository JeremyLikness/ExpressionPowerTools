# ParserUtils.GetTypeQuery Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Parsers](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.n.md) > [ParserUtils](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.cs.md) > **GetTypeQuery**

Gets a queryable to examine types.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetTypeQuery(DocAssembly assembly)](#gettypequerydocassembly-assembly) | Gets a queryable to examine types. |
## GetTypeQuery(DocAssembly assembly)

Gets a queryable to examine types.

```csharp
public static IQueryable<DocExportedType> GetTypeQuery(DocAssembly assembly)
```

### Return Type

 [IQueryable&lt;DocExportedType>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)  - The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `assembly` | [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) | The host [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |
