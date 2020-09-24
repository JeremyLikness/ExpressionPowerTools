# DefaultComparisonRules.DefaultMethodRules Property

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **DefaultMethodRules**

Gets the default rules for method calls.

```csharp
public static Expression<Func<MethodCallExpression, MethodCallExpression, Boolean>> DefaultMethodRules { get; }
```

## Remarks

The types must match. The method name and declaring type must match. If the `Object` property is not null, the properties must be equivalent. The
            source and target must have equivalent count of arguments and each argument
            must be equivalent.

### Property Value

 [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:29:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
