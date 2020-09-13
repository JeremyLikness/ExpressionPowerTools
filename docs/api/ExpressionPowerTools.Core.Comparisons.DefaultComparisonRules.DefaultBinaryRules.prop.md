# DefaultComparisonRules.DefaultBinaryRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultBinaryRules**

Gets the default rules for binaries.

```csharp
public static Expression<Func<BinaryExpression, BinaryExpression, Boolean>> DefaultBinaryRules { get; }
```

## Remarks

The node types (i.e. "Greater than", "Equals", etc.) must be equal.
            The left and right expressions must both be equivalent.

### Property Value

 [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
