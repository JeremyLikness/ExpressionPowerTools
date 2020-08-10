# DocMethodOverload Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > **DocMethodOverload**

Represents an overload of a [DocMethod](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.cs.md) .

```csharp
public class DocMethodOverload : DocBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [DocBase](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocBase.cs.md) → **DocMethodOverload**

# Constructors

| Ctor | Description |
| :-- | :-- |
| [DocMethodOverload(MethodInfo info, DocMethod method)](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.ctor.md#docmethodoverloadmethodinfo-info-docmethod-method) | Initializes a new instance of the [DocMethodOverload](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.cs.md) class for            the given [DocMethod](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.cs.md) . |
### Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Method`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.Method.prop.md) | [DocMethod](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethod.cs.md) | Gets the constructor the overload belongs to. |
| [`Info`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.Info.prop.md) | [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) | Gets the constructor info. |
| [`Parameters`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.Parameters.prop.md) | [IList&lt;DocParameter>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | Gets the overload parameters. |
| [`Extension`](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.DocMethodOverload.Extension.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the extension (not implemented). |

