# DefaultComparisonRules.DefaultUnaryRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultUnaryRules**

Gets the default rules for unaries.

```csharp
public static Expression<Func<UnaryExpression, UnaryExpression, Boolean>> DefaultUnaryRules { get; }
```

## Remarks

The types, node type, "is lifted" flag, "is lifted to null" flag must be equal.
            If the method is not null, the method name and declaring type must match.
            The operands must be equivalent.

### Property Value

 [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |
