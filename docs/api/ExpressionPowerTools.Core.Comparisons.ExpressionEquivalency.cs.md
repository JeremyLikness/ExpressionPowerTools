# ExpressionEquivalency Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **ExpressionEquivalency**

Host for comparisons.

```csharp
public static class ExpressionEquivalency
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionEquivalency**

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.NonGenericEnumerablesAreEquivalent.m.md) | Ensures two enumerables are same length an each value is equivalent. |
| [Boolean NullAndTypeCheck(Expression source, Expression other)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.NullAndTypeCheck.m.md) | Comparison matrix for types and nulls. |
| [Boolean ValuesAreEquivalent(Object source, Object target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ValuesAreEquivalent.m.md) | Attempts to compare values in various ways. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
