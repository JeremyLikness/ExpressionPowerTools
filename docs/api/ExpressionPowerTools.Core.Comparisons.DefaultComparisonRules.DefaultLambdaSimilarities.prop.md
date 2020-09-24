# DefaultComparisonRules.DefaultLambdaSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultLambdaSimilarities**

Gets the default similarities for lambda.

```csharp
public static Expression<Func<LambdaExpression, LambdaExpression, Boolean>> DefaultLambdaSimilarities { get; }
```

## Remarks

The name must match, the count of parameters must match, and parameters must be similar.
            The source expression must be part of the target expression.

### Property Value

 [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
