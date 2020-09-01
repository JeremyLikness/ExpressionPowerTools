# DocBase Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocBase**

Base documentation class that contains most common properties that may be needed.

```csharp
public abstract class DocBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DocBase**

Derived  [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) ,  [DocBaseType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.cs.md) ,  [DocConstructor](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocConstructor.cs.md) ,  [DocMethod](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.cs.md) ,  [DocMethodOverload](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.cs.md) ,  [DocNamespace](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocNamespace.cs.md) ,  [DocOverload](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.cs.md) ,  [DocParameter](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocParameter.cs.md) ,  [DocTypeParameter](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocTypeParameter.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Code`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Code.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the code snippet that defines the type. |
| [`Description`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Description.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the description. |
| [`Example`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Example.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the example text. |
| [`Exceptions`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Exceptions.prop.md) | [IList&lt;ValueTuple&lt;String, String>>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of exceptions that may be thrown. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the unique document extension. |
| [`Extensions`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Extensions.prop.md) | [IList&lt;TypeRef>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of extensions that reference the type. |
| [`FileName`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.FileName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the filename constructed from type and extension. |
| [`Name`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets name of the item. |
| [`Remarks`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Remarks.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the remarks. |
| [`TypeParameters`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.TypeParameters.prop.md) | [IList&lt;DocTypeParameter>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of type parameters. |
| [`XPath`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.XPath.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the XPath to the element in documentation. |

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean Equals(Object obj)](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Equals.m.md) | Equality: selectors must match. |
| [Int32 GetHashCode()](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.GetHashCode.m.md) | Hash code. |
| [String ToString()](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.ToString.m.md) | String display. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |
