# DefaultComparisonRules.DefaultMemberRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultMemberRules**

Gets the default rules for member equivalency.

```csharp
public static Expression<Func<MemberExpression, MemberExpression, Boolean>> DefaultMemberRules { get; }
```

## Remarks

Must be the same type, have the same name and declaring type. If the
            member has an expression, the source and target expressions must be
            equivalent.

### Property Value

 [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
