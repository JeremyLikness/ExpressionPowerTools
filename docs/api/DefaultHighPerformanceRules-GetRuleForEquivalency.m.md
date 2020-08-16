# DefaultHighPerformanceRules.GetRuleForEquivalency Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultHighPerformanceRules](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.cs.md) > **GetRuleForEquivalency**

Get the equivalency rule.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetRuleForEquivalency&lt;T>()](#getruleforequivalencyt) | Get the equivalency rule. |
## GetRuleForEquivalency&lt;T>()

Get the equivalency rule.

```csharp
public virtual Func<T, T, Boolean> GetRuleForEquivalency<T>()
```

### Return Type

 [Func&lt;T, T, Boolean>](https://docs.microsoft.com/dotnet/api/system.func-3)  - A rule that determines equivalency between the two expressions.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |
