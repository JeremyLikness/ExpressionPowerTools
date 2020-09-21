# AssemblyParser.Parse Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Parsers](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.n.md) > [AssemblyParser](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.AssemblyParser.cs.md) > **Parse**

Parses the assembly.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Parse(DocAssembly doc)](#parsedocassembly-doc) | Parses the assembly. |
## Parse(DocAssembly doc)

Parses the assembly.

```csharp
public DocAssembly Parse(DocAssembly doc)
```

### Return Type

 [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md)  - The parsed [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `doc` | [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) | The [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) ref for pass 2. |


## Remarks

First pass creates the assembly and parses it. Second pass takes the
            assembly and processes for addition info that requires cross-referencing.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
