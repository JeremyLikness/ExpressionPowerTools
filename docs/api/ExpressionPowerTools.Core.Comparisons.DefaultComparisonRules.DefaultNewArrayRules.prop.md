# DefaultComparisonRules.DefaultNewArrayRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultNewArrayRules**

Gets the default rules for new arrays.

```csharp
public static Expression<Func<NewArrayExpression, NewArrayExpression, Boolean>> DefaultNewArrayRules { get; }
```

## Remarks

The types must be equal. Each expression in the source array must have
            an equivalnet expression in the target array.

### Property Value

 [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/26/2020 6:58:17 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
