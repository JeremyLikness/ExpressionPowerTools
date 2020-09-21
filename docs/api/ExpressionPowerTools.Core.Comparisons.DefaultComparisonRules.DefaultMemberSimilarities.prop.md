# DefaultComparisonRules.DefaultMemberSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultMemberSimilarities**

Gets the default rules for member similarity.

```csharp
public static Expression<Func<MemberExpression, MemberExpression, Boolean>> DefaultMemberSimilarities { get; }
```

## Remarks

The the types must be similar. Names and declarity types must be equal.
            If the expression is not `null` , the source must be part of the
            target.

### Property Value

 [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
