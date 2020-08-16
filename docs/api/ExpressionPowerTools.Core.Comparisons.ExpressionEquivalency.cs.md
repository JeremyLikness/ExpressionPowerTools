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
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionEquivalency-AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)](ExpressionEquivalency-NonGenericEnumerablesAreEquivalent.m.md) | Ensures two enumerables are same length an each value is equivalent. |
| [Boolean NullAndTypeCheck(Expression source, Expression other)](ExpressionEquivalency-NullAndTypeCheck.m.md) | Comparison matrix for types and nulls. |
| [Boolean ValuesAreEquivalent(Object source, Object target)](ExpressionEquivalency-ValuesAreEquivalent.m.md) | Attempts to compare values in various ways. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |
