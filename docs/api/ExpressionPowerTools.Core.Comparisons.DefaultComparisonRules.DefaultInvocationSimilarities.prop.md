# DefaultComparisonRules.DefaultInvocationSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultInvocationSimilarities**

Gets the default similarities for lambda.

```csharp
public static Expression<Func<InvocationExpression, InvocationExpression, Boolean>> DefaultInvocationSimilarities { get; }
```

## Remarks

The return types must be similar. Argument counts must match and all arguments must be
            similar. The source expression must be part of the target expression.

### Property Value

 [Expression&lt;Func&lt;InvocationExpression, InvocationExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
