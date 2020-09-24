# ExpressionRulesExtensions.AndExpressionsMustBeEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndExpressionsMustBeEquivalent**

Expressions must be equivalent.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](#andexpressionsmustbeequivalenttexpressionfunct-t-boolean-rule-funct-expression-member) | Expressions must be equivalent. |
## AndExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)

Expressions must be equivalent.

```csharp
public static Expression<Func<T, T, Boolean>> AndExpressionsMustBeEquivalent<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Expression> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether the expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Rule to combine with. |
| `member` | [Func&lt;T, Expression>](https://docs.microsoft.com/dotnet/api/system.func-2) | Reference the property that is an expression. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
