# ExpressionRulesExtensions.And Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **And**

Start of tree with left and right "and" branches.

## Overloads

| Overload | Description |
| :-- | :-- |
| [And&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](#andtexpressionfunct-t-boolean-left-expressionfunct-t-boolean-right) | Start of tree with left and right "and" branches. |
## And&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)

Start of tree with left and right "and" branches.

```csharp
public static Expression<Func<T, T, Boolean>> And<T>(Expression<Func<T, T, Boolean>> left, Expression<Func<T, T, Boolean>> right)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value that indicates wheter both left and right evaluated to `true` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `left` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Left rule. |
| `right` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Right rule. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
