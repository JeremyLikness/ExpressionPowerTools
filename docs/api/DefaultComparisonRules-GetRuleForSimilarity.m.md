# DefaultComparisonRules.GetRuleForSimilarity Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **GetRuleForSimilarity**

Gets a predicate to compare two expressions of a given type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetRuleForSimilarity&lt;T>()](#getruleforsimilarityt) | Gets a predicate to compare two expressions of a given type. |
## GetRuleForSimilarity&lt;T>()

Gets a predicate to compare two expressions of a given type.

```csharp
public virtual Func<T, T, Boolean> GetRuleForSimilarity<T>()
```

### Return Type

 [Func&lt;T, T, Boolean>](https://docs.microsoft.com/dotnet/api/system.func-3)  - The rule or null when not found.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
