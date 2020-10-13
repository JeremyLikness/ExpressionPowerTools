# DocMethod Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocMethod**

Represents a method on a type.

```csharp
public class DocMethod : DocBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [DocBase](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.cs.md) → **DocMethod**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DocMethod(DocExportedType type)](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.ctor.md#docmethoddocexportedtype-type) | Initializes a new instance of the [DocMethod](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.cs.md) class with            the specified [DocExportedType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocExportedType.cs.md) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the file extension. |
| [`FileName`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.FileName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the overridden filename to attach methods to related types. |
| [`MethodOverloads`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.MethodOverloads.prop.md) | [IList&lt;DocMethodOverload>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets the method overloads. |
| [`MethodReturnType`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.MethodReturnType.prop.md) | [TypeRef](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.TypeRef.cs.md) | Gets or sets the return [Type](https://docs.microsoft.com/dotnet/api/system.type) of the method. |
| [`MethodType`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.MethodType.prop.md) | [DocExportedType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocExportedType.cs.md) | Gets the type the method belongs to. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |
