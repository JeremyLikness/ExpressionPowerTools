# DefaultComparisonRules.DefaultNewRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultNewRules**

Gets the default rules for object initializers.

```csharp
public static Expression<Func<NewExpression, NewExpression, Boolean>> DefaultNewRules { get; }
```

## Remarks

The types must be equal. The constructors must be identical (i.e. not a
            different override). The constuctor arguments must be equivalent.

### Property Value

 [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
