# IExpressionComparisonRuleProvider Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IExpressionComparisonRuleProvider**

Interface for a class that provides rules for comparisons.

```csharp
public interface IExpressionComparisonRuleProvider
```

Derived  [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) ,  [DefaultHighPerformanceRules](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean CheckEquivalency&lt;T>(T source, Expression target)](IExpressionComparisonRuleProvider-CheckEquivalency.m.md) | Perform the check. |
| [Boolean CheckSimilarity&lt;T>(T source, Expression target)](IExpressionComparisonRuleProvider-CheckSimilarity.m.md) | Perform the check. |
| [Func&lt;T, T, Boolean> GetRuleForEquivalency&lt;T>()](IExpressionComparisonRuleProvider-GetRuleForEquivalency.m.md) | Gets a predicate to compare two expressions of a given type. |
| [Func&lt;T, T, Boolean> GetRuleForSimilarity&lt;T>()](IExpressionComparisonRuleProvider-GetRuleForSimilarity.m.md) | Gets a predicate to compare two expressions of a given type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
