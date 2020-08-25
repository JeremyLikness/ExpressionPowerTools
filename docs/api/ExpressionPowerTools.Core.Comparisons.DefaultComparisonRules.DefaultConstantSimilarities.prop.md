# DefaultComparisonRules.DefaultConstantSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultConstantSimilarities**

Gets the default rule for similarities between constants.

```csharp
public static Expression<Func<ConstantExpression, ConstantExpression, Boolean>> DefaultConstantSimilarities { get; }
```

## Remarks

Type type of the values must be assignable to each other. Both values must either
            be `null` or not `null` . If the values are expressions, the expressions must
            be similar. If array, collection, or enumerable then the expressions are similar regardless
            of the contents. Otherwise, must pass.

### Property Value

 [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
