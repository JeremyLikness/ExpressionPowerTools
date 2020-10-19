# ExpressionRulesExtensions.SourceTypeMustBeArrayOrCollection Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **SourceTypeMustBeArrayOrCollection**

The source type must derive from or be an [Array](https://docs.microsoft.com/dotnet/api/system.array) or [ICollection](https://docs.microsoft.com/dotnet/api/system.collections.icollection) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [SourceTypeMustBeArrayOrCollection&lt;T>()](#sourcetypemustbearrayorcollectiont) | The source type must derive from or be an [Array](https://docs.microsoft.com/dotnet/api/system.array) or [ICollection](https://docs.microsoft.com/dotnet/api/system.collections.icollection) . |
## SourceTypeMustBeArrayOrCollection&lt;T>()

The source type must derive from or be an [Array](https://docs.microsoft.com/dotnet/api/system.array) or [ICollection](https://docs.microsoft.com/dotnet/api/system.collections.icollection) .

```csharp
public static Expression<Func<T, T, Boolean>> SourceTypeMustBeArrayOrCollection<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value that indicates whether the source type is array or collection.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |
