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
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
