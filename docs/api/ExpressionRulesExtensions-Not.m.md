# ExpressionRulesExtensions.Not Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **Not**

Logical NOT of result of rule.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Not&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](#nottexpressionfunct-t-boolean-rule) | Logical NOT of result of rule. |
## Not&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)

Logical NOT of result of rule.

```csharp
public static Expression<Func<T, T, Boolean>> Not<T>(Expression<Func<T, T, Boolean>> rule)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - The opposite of the rule evaluation.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to evaluate. |


## Examples

For example:

```csharp

var source = Expression.Constant(true);
var target = Expression.Constant(true);
var rule = rules.Not<ConstantExpression>(
   (s, t) => (bool)s.Value);
var result = rule.Compile())source, target);
             
```

Because of the call to `Not` , the result is `false` .


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 8:28:46 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
