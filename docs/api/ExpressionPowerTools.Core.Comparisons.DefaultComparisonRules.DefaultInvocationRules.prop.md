# DefaultComparisonRules.DefaultInvocationRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultInvocationRules**

Gets the default rules for invocations.

```csharp
public static Expression<Func<InvocationExpression, InvocationExpression, Boolean>> DefaultInvocationRules { get; }
```

## Remarks

The return types must match. The expressions must be equivalent. All arguments must be equivalent.

### Property Value

 [Expression&lt;Func&lt;InvocationExpression, InvocationExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
