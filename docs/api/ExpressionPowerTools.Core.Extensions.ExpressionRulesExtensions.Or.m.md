# ExpressionRulesExtensions.Or Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **Or**

Start of tree with left and right "or" branches.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Or&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](#ortexpressionfunct-t-boolean-left-expressionfunct-t-boolean-right) | Start of tree with left and right "or" branches. |
## Or&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)

Start of tree with left and right "or" branches.

```csharp
public static Expression<Func<T, T, Boolean>> Or<T>(Expression<Func<T, T, Boolean>> left, Expression<Func<T, T, Boolean>> right)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value that indicates whether the left or the
            right resolved to `true` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `left` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Left rule. |
| `right` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Right rule. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
