# DocBase Class

[ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocBase**

Base documentation class that contains most common properties that may be needed.

```csharp
public abstract class DocBase
```

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → **DocBase**

Derived  [DocAssembly](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocAssembly.cs.md) ,  [DocBaseType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.cs.md) ,  [DocConstructor](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocConstructor.cs.md) ,  [DocNamespace](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocNamespace.cs.md) ,  [DocOverload](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocOverload.cs.md) ,  [DocParameter](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocParameter.cs.md) ,  [DocTypeParameter](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocTypeParameter.cs.md) 

### Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Name`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets name of the item. |
| [`Code`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Code.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the code snippet that defines the type. |
| [`Description`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Description.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the description. |
| [`Remarks`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Remarks.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the remarks. |
| [`Example`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Example.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the example text. |
| [`Extensions`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Extensions.prop.md) | [IList&lt;ValueTuple&lt;String, String>>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of extensions that reference the type. |
| [`Exceptions`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Exceptions.prop.md) | [IList&lt;ValueTuple&lt;String, String>>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of exceptions that may be thrown. |
| [`TypeParameters`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.TypeParameters.prop.md) | [IList&lt;DocTypeParameter>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of type parameters. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the unique document extension. |
| [`FileName`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.FileName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the filename constructed from type and extension. |
| [`XPath`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.XPath.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the XPath to the element in documentation. |

