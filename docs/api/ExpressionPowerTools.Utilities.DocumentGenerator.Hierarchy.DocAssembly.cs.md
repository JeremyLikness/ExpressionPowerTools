# DocAssembly Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocAssembly**

Represents an assembly to document.

```csharp
public class DocAssembly : DocBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [DocBase](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.cs.md) → **DocAssembly**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DocAssembly(String assemblyName)](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.ctor.md#docassemblystring-assemblyname) | Initializes a new instance of the [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CustomDocs`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.CustomDocs.prop.md) | [ICollection&lt;DocBase>](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1) | Gets or sets custom documents associated with the assembly. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the file extension. |
| [`Namespaces`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.Namespaces.prop.md) | [ICollection&lt;DocNamespace>](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1) | Gets or sets the list of [DocNamespace](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocNamespace.cs.md) instances. |

## Methods

| Method | Description |
| :-- | :-- |
| [String ToString()](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.ToString.m.md) | String representation. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
