# ExpressionRulesExtensions.SourceTypeMustBeSimilarToExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **SourceTypeMustBeSimilarToExpression**

The source type must be similar to [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [SourceTypeMustBeSimilarToExpression&lt;T>()](#sourcetypemustbesimilartoexpressiont) | The source type must be similar to [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## SourceTypeMustBeSimilarToExpression&lt;T>()

The source type must be similar to [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public static Expression<Func<T, T, Boolean>> SourceTypeMustBeSimilarToExpression<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A flag indicating whether the source type is similar to an expression.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
