# DefaultComparisonRules.DefaultUnarySimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultUnarySimilarities**

Gets the default rules for unary similarities.

```csharp
public static Expression<Func<UnaryExpression, UnaryExpression, Boolean>> DefaultUnarySimilarities { get; }
```

## Remarks

The node types must match, the methods, if they exist, must have the
            same name and similar declaring type. The source operand must be part
            of the target operand.

### Property Value

 [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
