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
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
