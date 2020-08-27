# DefaultComparisonRules.DefaultNewSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultNewSimilarities**

Gets the default rules for object initializer similarities.

```csharp
public static Expression<Func<NewExpression, NewExpression, Boolean>> DefaultNewSimilarities { get; }
```

## Remarks

The types must be similar, but the constructors must match.
            Arguments must be similar.

### Property Value

 [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
