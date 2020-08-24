# ExpressionRulesExtensions.Or Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **Or**



## Overloads

| Overload | Description |
| :-- | :-- |
| [Or&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](#ortexpressionfunct-t-boolean-left-expressionfunct-t-boolean-right) |  |
## Or&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)



```csharp
public static Expression<Func<T, T, Boolean>> Or<T>(Expression<Func<T, T, Boolean>> left, Expression<Func<T, T, Boolean>> right)
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
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
