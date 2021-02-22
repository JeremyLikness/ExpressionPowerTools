# DefaultComparisonRules.DefaultBinarySimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultBinarySimilarities**

Gets the default rules for binary similarities.

```csharp
public static Expression<Func<BinaryExpression, BinaryExpression, Boolean>> DefaultBinarySimilarities { get; }
```

## Remarks

The node types must be equal. The left and right expressions must be
            similar.

### Property Value

 [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
