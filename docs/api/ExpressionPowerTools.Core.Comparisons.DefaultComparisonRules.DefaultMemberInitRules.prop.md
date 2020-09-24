# DefaultComparisonRules.DefaultMemberInitRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultMemberInitRules**

Gets the default rules for member initializers.

```csharp
public static Expression<Func<MemberInitExpression, MemberInitExpression, Boolean>> DefaultMemberInitRules { get; }
```

## Remarks

The types must be equal. The expression for initialization must
            be equivalent. All bindings must be equivalent.

### Property Value

 [Expression&lt;Func&lt;MemberInitExpression, MemberInitExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
