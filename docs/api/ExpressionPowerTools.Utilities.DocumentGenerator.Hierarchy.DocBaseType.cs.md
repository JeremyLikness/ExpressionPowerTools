# DocBaseType Class

[ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocBaseType**

Base document for types.

```csharp
public class DocBaseType : DocBase
```

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → [DocBase](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.cs.md) → **DocBaseType**

Derived  [DocExportedType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocExportedType.cs.md) ,  [DocProperty](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocProperty.cs.md) 

# Constructors

| Ctor | Description |
| :-- | :-- |
| [DocBaseType()](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.ctor.md#ctor-0) | Initializes a new instance of the  [DocBaseType](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.cs.md)  class. |
### Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`IsInterface`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.IsInterface.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the type is an interface. |
| [`IsEnum`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.IsEnum.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the type is an enumeration. |
| [`IsClass`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.IsClass.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the type is a class. |
| [`ImplementedInterfaces`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.ImplementedInterfaces.prop.md) | [IList&lt;ValueTuple&lt;String, String>>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of implemented interfaces. |
| [`Inheritance`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Inheritance.prop.md) | [IList&lt;ValueTuple&lt;String, String>>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the inheritance chcain. |
| [`DerivedTypes`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.DerivedTypes.prop.md) | [IList&lt;ValueTuple&lt;String, String>>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of derived types. |
| [`Properties`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Properties.prop.md) | [IList&lt;DocProperty>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets or sets the list of properties. |
| [`TypeName`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.TypeName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the user-friendly name for the type. |
| [`Type`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Type.prop.md) | [Type](https://docs.microsoft.com/dotnet/api/system.type) | Gets or sets the associated type. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBaseType.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the extension. |

