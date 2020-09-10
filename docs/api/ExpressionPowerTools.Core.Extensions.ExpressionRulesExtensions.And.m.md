# ExpressionRulesExtensions.And Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **And**



## Overloads

| Overload | Description |
| :-- | :-- |
| [And&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](#andtexpressionfunct-t-boolean-left-expressionfunct-t-boolean-right) |  |
## And&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)



```csharp
public static Expression<Func<T, T, Boolean>> And<T>(Expression<Func<T, T, Boolean>> left, Expression<Func<T, T, Boolean>> right)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `left` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `right` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
