# DefaultComparisonRules.DefaultNewSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultNewSimilarities**

Gets the default rules for object initializer similarities.

```csharp
public static Expression<Func<NewExpression, NewExpression, Boolean>> DefaultNewSimilarities { get; }
```

## Remarks

The types must be similar, parameters and arguments must be similar.

### Property Value

 [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
