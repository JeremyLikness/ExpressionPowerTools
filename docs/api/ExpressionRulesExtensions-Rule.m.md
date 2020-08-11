# Rule Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **Rule**

Basic rule definition. Exists as a base to provide typed template.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Rule&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](#ruletexpressionfunct-t-boolean-rule) | Basic rule definition. Exists as a base to provide typed template. |
## Rule&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)

Basic rule definition. Exists as a base to provide typed template.

```csharp
public static Expression<Func<T, T, Boolean>> Rule<T>(Expression<Func<T, T, Boolean>> rule)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - The rule as an expression.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to make. |


## Examples

For example:

```csharp

ExpressionRulesExtensions.Rule<ConstantExpression>((s, t) => s.Value == t.Vale);
            
```

