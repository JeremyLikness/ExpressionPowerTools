# IExpressionComparisonRuleProvider Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IExpressionComparisonRuleProvider**



```csharp
public interface IExpressionComparisonRuleProvider
```

Derived  [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) ,  [DefaultHighPerformanceRules](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean CheckEquivalency&lt;T>(T source, Expression target)](IExpressionComparisonRuleProvider-CheckEquivalency.m.md) |  |
| [Boolean CheckSimilarity&lt;T>(T source, Expression target)](IExpressionComparisonRuleProvider-CheckSimilarity.m.md) |  |
| [Func&lt;T, T, Boolean> GetRuleForEquivalency&lt;T>()](IExpressionComparisonRuleProvider-GetRuleForEquivalency.m.md) |  |
| [Func&lt;T, T, Boolean> GetRuleForSimilarity&lt;T>()](IExpressionComparisonRuleProvider-GetRuleForSimilarity.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
