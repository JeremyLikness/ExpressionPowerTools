# ExpressionExtensions.IsEquivalentTo Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **IsEquivalentTo**

Uses [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) to determine equivalency.

## Overloads

| Overload | Description |
| :-- | :-- |
| [IsEquivalentTo(Expression source, Expression target)](#isequivalenttoexpression-source-expression-target) | Uses [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) to determine equivalency. |
## IsEquivalentTo(Expression source, Expression target)

Uses [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) to determine equivalency.

```csharp
public static Boolean IsEquivalentTo(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
