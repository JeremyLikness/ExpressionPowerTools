# ExpressionRulesExtensions.ExpressionsMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **ExpressionsMustBeSimilar**

Expressions must be similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ExpressionsMustBeSimilar&lt;T>(Func&lt;T, Expression> member)](#expressionsmustbesimilartfunct-expression-member) | Expressions must be similar. |
## ExpressionsMustBeSimilar&lt;T>(Func&lt;T, Expression> member)

Expressions must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> ExpressionsMustBeSimilar<T>(Func<T, Expression> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether the expressions are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Expression>](https://docs.microsoft.com/dotnet/api/system.func-2) | Reference the property that is an expression. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |
