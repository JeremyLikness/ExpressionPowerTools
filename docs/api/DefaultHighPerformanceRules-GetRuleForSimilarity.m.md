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
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
