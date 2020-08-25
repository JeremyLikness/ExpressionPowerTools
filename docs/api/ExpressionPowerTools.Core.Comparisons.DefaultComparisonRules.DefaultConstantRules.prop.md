# DefaultComparisonRules.DefaultConstantRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultConstantRules**

Gets the rules for equivalency of [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

```csharp
public static Expression<Func<ConstantExpression, ConstantExpression, Boolean>> DefaultConstantRules { get; }
```

## Remarks

Must be of same type. Both must be null or not null. If the value is an expression, the expressions
            must be equivalent. If the values are enumerable, the contents of the enumerable must match. The
            values must pass.

### Property Value

 [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
