# ExpressionRulesExtensions.SourceTypeMustBeTypedEnumerable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **SourceTypeMustBeTypedEnumerable**

The source type must be an [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [SourceTypeMustBeTypedEnumerable&lt;T>()](#sourcetypemustbetypedenumerablet) | The source type must be an [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) . |
## SourceTypeMustBeTypedEnumerable&lt;T>()

The source type must be an [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) .

```csharp
public static Expression<Func<T, T, Boolean>> SourceTypeMustBeTypedEnumerable<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value that indicates whether the source type is a typed enumerable.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 5:55:15 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
