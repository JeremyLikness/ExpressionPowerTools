# DefaultHighPerformanceRules Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **DefaultHighPerformanceRules**

This version is named "tongue-in-cheek" due to the assumption that code will outperform compiled expressions.
            Although that can be true, and this is included for testing as well as referencing if it helps with application scale,
            you should find the rules-based works fine for most scenarios and performs close to par with the programmed verssion.
            So far the tests for this run slightly slower than the expression-based version.

```csharp
public class DefaultHighPerformanceRules : IExpressionComparisonRuleProvider
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DefaultHighPerformanceRules**

Implements  [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DefaultHighPerformanceRules()](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.ctor.md#defaulthighperformancerules) | Initializes a new instance of the [DefaultHighPerformanceRules](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Boolean CheckEquivalency&lt;T>(T source, Expression target)](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.CheckEquivalency.m.md) | Check equivalency for a given type. |
| [Boolean CheckSimilarity&lt;T>(T source, Expression target)](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.CheckSimilarity.m.md) | Perform the check. |
| [Func&lt;T, T, Boolean> GetRuleForEquivalency&lt;T>()](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.GetRuleForEquivalency.m.md) | Get the equivalency rule. |
| [Func&lt;T, T, Boolean> GetRuleForSimilarity&lt;T>()](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.GetRuleForSimilarity.m.md) | Get the similiarity rule. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
