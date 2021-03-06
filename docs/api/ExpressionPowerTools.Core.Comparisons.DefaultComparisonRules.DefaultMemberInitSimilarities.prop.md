﻿# DefaultComparisonRules.DefaultMemberInitSimilarities Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultMemberInitSimilarities**

Gets the default rules for member initializer similarites.

```csharp
public static Expression<Func<MemberInitExpression, MemberInitExpression, Boolean>> DefaultMemberInitSimilarities { get; }
```

## Remarks

The types must be similar. The expression for initialization must
            be similar. All bindings must be similar.

### Property Value

 [Expression&lt;Func&lt;MemberInitExpression, MemberInitExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
