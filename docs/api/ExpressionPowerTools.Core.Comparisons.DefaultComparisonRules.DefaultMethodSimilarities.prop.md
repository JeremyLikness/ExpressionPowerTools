# DefaultComparisonRules.DefaultMethodSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultMethodSimilarities**

Gets the defeault rules for method call similarities.

```csharp
public static Expression<Func<MethodCallExpression, MethodCallExpression, Boolean>> DefaultMethodSimilarities { get; }
```

## Remarks

The types must be similar. The name and count of arguments must be equal. If the `Object` property exists, the source object must be part of the target.
            Arguments must be similar.

### Property Value

 [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
