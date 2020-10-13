# DefaultHighPerformanceRules.GetRuleForSimilarity Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultHighPerformanceRules](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.cs.md) > **GetRuleForSimilarity**

Get the similiarity rule.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetRuleForSimilarity&lt;T>()](#getruleforsimilarityt) | Get the similiarity rule. |
## GetRuleForSimilarity&lt;T>()

Get the similiarity rule.

```csharp
public virtual Func<T, T, Boolean> GetRuleForSimilarity<T>()
```

### Return Type

 [Func&lt;T, T, Boolean>](https://docs.microsoft.com/dotnet/api/system.func-3)  - A rule that determines similarity between the two expressions.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |
