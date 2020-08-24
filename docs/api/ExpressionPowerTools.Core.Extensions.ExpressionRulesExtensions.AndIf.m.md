# ExpressionRulesExtensions.AndIf Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndIf**

Logical AND applied to rule and `If` condition.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](#andiftexpressionfunct-t-boolean-rule-expressionfunct-t-boolean-condition-expressionfunct-t-boolean-iftrue-expressionfunct-t-boolean-iffalse) | Logical AND applied to rule and `If` condition. |
## AndIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)

Logical AND applied to rule and `If` condition.

```csharp
public static Expression<Func<T, T, Boolean>> AndIf<T>(Expression<Func<T, T, Boolean>> rule, Expression<Func<T, T, Boolean>> condition, Expression<Func<T, T, Boolean>> ifTrue, Expression<Func<T, T, Boolean>> ifFalse)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - The result of the `If` AND the result of the rule.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule that must pass. |
| `condition` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The condition for if/then. |
| `ifTrue` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to evaluate for if/then. |
| `ifFalse` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to evaluate for if/else. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
