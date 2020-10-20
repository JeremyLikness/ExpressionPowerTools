# ExpressionEvaluator Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **ExpressionEvaluator**

Implementation of [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) for advanced
            expression comparisons.

```csharp
public class ExpressionEvaluator : IExpressionEvaluator
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionEvaluator**

Implements  [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionEvaluator()](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.ctor.md#expressionevaluator) | Initializes a new instance of the [ExpressionEvaluator](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Boolean AnonymousValuesAreEquivalent(Object source, Object target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AnonymousValuesAreEquivalent.m.md) | Compares two anonymous values. |
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean AreSimilar(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreSimilar.m.md) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [Boolean DictionariesAreEquivalent(IDictionary source, IDictionary target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.DictionariesAreEquivalent.m.md) | Ensures two dictionaries are equivalent. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.IsPartOf.m.md) | Determines whether an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another expression. |
| [Boolean MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.MemberBindingsAreEquivalent.m.md) | Ensures that two [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) instances are equivalent. |
| [Boolean NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.NonGenericEnumerablesAreEquivalent.m.md) | Ensures two enumerables are same length an each value is equivalent. |
| [Boolean NullAndTypeCheck(Expression source, Expression other)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.NullAndTypeCheck.m.md) | Comparison matrix for types and nulls. |
| [Boolean TypesAreEquivalent(Type source, Type target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.TypesAreEquivalent.m.md) | Determine if a [Type](https://docs.microsoft.com/dotnet/api/system.type) is equivalent to another type. |
| [Boolean ValuesAreEquivalent(Object source, Object target)](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.ValuesAreEquivalent.m.md) | Attempts to compare values in various ways. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
