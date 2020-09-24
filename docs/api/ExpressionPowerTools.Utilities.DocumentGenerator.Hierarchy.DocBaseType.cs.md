# DocBaseType Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocBaseType**

Base document for types.

```csharp
public class DocBaseType : DocBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [DocBase](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.cs.md) → **DocBaseType**

Derived  [DocExportedType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocExportedType.cs.md) ,  [DocProperty](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocProperty.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DocBaseType()](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.ctor.md#docbasetype) | Initializes a new instance of the [DocBaseType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DerivedTypes`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.DerivedTypes.prop.md) | [IList&lt;TypeRef>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of derived types. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the extension. |
| [`ImplementedInterfaces`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.ImplementedInterfaces.prop.md) | [IList&lt;TypeRef>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of implemented interfaces. |
| [`Inheritance`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Inheritance.prop.md) | [IList&lt;TypeRef>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the inheritance chcain. |
| [`IsClass`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.IsClass.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the type is a class. |
| [`IsEnum`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.IsEnum.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the type is an enumeration. |
| [`IsInterface`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.IsInterface.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the type is an interface. |
| [`Methods`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Methods.prop.md) | [IList&lt;DocMethod>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of methods. |
| [`Properties`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Properties.prop.md) | [IList&lt;DocProperty>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of properties. |
| [`Type`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Type.prop.md) | [Type](https://docs.microsoft.com/dotnet/api/system.type) | Gets or sets the associated type. |
| [`TypeRef`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.TypeRef.prop.md) | [TypeRef](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.TypeRef.cs.md) | Gets the associated type reference. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
