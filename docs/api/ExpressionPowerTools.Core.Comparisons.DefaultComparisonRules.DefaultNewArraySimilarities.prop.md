# DefaultComparisonRules.DefaultNewArraySimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultNewArraySimilarities**

Gets the default rules for new array similarities.

```csharp
public static Expression<Func<NewArrayExpression, NewArrayExpression, Boolean>> DefaultNewArraySimilarities { get; }
```

## Remarks

Types must be similar. Each expression in the source must have a similar
            expression in the target.

### Property Value

 [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
