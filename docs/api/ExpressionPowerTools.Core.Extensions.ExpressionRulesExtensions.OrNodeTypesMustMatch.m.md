# ExpressionRulesExtensions.OrNodeTypesMustMatch Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **OrNodeTypesMustMatch**

Or the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same.

## Overloads

| Overload | Description |
| :-- | :-- |
| [OrNodeTypesMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](#ornodetypesmustmatchtexpressionfunct-t-boolean-rule) | Or the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same. |
## OrNodeTypesMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)

Or the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same.

```csharp
public static Expression<Func<T, T, Boolean>> OrNodeTypesMustMatch<T>(Expression<Func<T, T, Boolean>> rule)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the node types match.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The existing rule. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
