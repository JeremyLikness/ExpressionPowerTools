# ExpressionRulesExtensions.AndExpressionsMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndExpressionsMustBeSimilar**

And expressions must be similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](#andexpressionsmustbesimilartexpressionfunct-t-boolean-rule-funct-expression-member) | And expressions must be similar. |
## AndExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)

And expressions must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> AndExpressionsMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Expression> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether the expressions are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to consider. |
| `member` | [Func&lt;T, Expression>](https://docs.microsoft.com/dotnet/api/system.func-2) | Reference the property that is an expression. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
