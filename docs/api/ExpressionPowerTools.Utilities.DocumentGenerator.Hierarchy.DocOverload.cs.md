# DocOverload Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocOverload**

A given constructor overload.

```csharp
public class DocOverload : DocBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [DocBase](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.cs.md) → **DocOverload**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DocOverload(ConstructorInfo info, DocConstructor ctor)](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.ctor.md#docoverloadconstructorinfo-info-docconstructor-ctor) | Initializes a new instance of the [DocOverload](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.cs.md) class for            the given [DocConstructor](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocConstructor.cs.md) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Constructor`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.Constructor.prop.md) | [DocConstructor](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocConstructor.cs.md) | Gets the constructor the overload belongs to. |
| [`Ctor`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.Ctor.prop.md) | [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) | Gets the constructor info. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the extension (not implemented). |
| [`IsStatic`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.IsStatic.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether it is static. |
| [`Parameters`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.Parameters.prop.md) | [IList&lt;DocParameter>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets the constructor parameters. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
