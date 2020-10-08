# DefaultComparisonRules.DefaultLambdaRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultLambdaRules**

Gets the default rules for lambda.

```csharp
public static Expression<Func<LambdaExpression, LambdaExpression, Boolean>> DefaultLambdaRules { get; }
```

## Remarks

The name of the lambda expressions must be equal. The main expression body must
            be equivalent between the source and target, and if one is tail call optimized, the other must be, too.

### Property Value

 [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |
