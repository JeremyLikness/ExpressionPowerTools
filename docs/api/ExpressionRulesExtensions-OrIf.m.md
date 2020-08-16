# ExpressionRulesExtensions.OrIf Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **OrIf**

Logical OR applied to rule and `If` condition.

## Overloads

| Overload | Description |
| :-- | :-- |
| [OrIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](#oriftexpressionfunct-t-boolean-rule-expressionfunct-t-boolean-condition-expressionfunct-t-boolean-iftrue-expressionfunct-t-boolean-iffalse) | Logical OR applied to rule and `If` condition. |
## OrIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)

Logical OR applied to rule and `If` condition.

```csharp
public static Expression<Func<T, T, Boolean>> OrIf<T>(Expression<Func<T, T, Boolean>> rule, Expression<Func<T, T, Boolean>> condition, Expression<Func<T, T, Boolean>> ifTrue, Expression<Func<T, T, Boolean>> ifFalse)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - The result of the `If` OR the result of the rule.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule that might pass. |
| `condition` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The condition for if/then. |
| `ifTrue` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to evaluate for if/then. |
| `ifFalse` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to evaluate for if/else. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |
