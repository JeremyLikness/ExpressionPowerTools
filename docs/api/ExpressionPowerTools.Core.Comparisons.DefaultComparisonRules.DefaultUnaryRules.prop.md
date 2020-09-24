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
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
