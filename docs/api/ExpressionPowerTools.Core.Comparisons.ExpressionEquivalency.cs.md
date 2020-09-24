# ExpressionEquivalency Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **ExpressionEquivalency**

Host for comparisons.

```csharp
public static class ExpressionEquivalency
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionEquivalency**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static ExpressionEquivalency()](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ctor.md#static-expressionequivalency) | Initializes a new instance of the [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean DictionariesAreEquivalent(IDictionary source, IDictionary target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.DictionariesAreEquivalent.m.md) | Ensures two dictionaries are equivalent. |
| [Boolean MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.MemberBindingsAreEquivalent.m.md) | Ensures that two [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) instances are equivalent. |
| [Boolean NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.NonGenericEnumerablesAreEquivalent.m.md) | Ensures two enumerables are same length an each value is equivalent. |
| [Boolean NullAndTypeCheck(Expression source, Expression other)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.NullAndTypeCheck.m.md) | Comparison matrix for types and nulls. |
| [Boolean TypesAreEquivalent(Type source, Type target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.TypesAreEquivalent.m.md) | Determine if a [Type](https://docs.microsoft.com/dotnet/api/system.type) is equivalent to another type. |
| [Boolean ValuesAreEquivalent(Object source, Object target)](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ValuesAreEquivalent.m.md) | Attempts to compare values in various ways. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
