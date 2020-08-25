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
| [Boolean CheckEquivalency&lt;T>(T source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.CheckEquivalency.m.md) | Perform the check. |
| [Boolean CheckSimilarity&lt;T>(T source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.CheckSimilarity.m.md) | Perform the check. |
| [Func&lt;T, T, Boolean> GetRuleForEquivalency&lt;T>()](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.GetRuleForEquivalency.m.md) | Gets a predicate to compare two expressions of a given type. |
| [Func&lt;T, T, Boolean> GetRuleForSimilarity&lt;T>()](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.GetRuleForSimilarity.m.md) | Gets a predicate to compare two expressions of a given type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
