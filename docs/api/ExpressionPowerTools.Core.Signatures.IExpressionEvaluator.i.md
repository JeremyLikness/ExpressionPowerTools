# IExpressionEvaluator Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IExpressionEvaluator**

Evaluator as facade to equivalency and similarity.

```csharp
public interface IExpressionEvaluator
```

Derived  [ExpressionEvaluator](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean AnonymousValuesAreEquivalent(Object source, Object target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AnonymousValuesAreEquivalent.m.md) | Compares two anonymous values. |
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean AreSimilar(Expression source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreSimilar.m.md) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [Boolean DictionariesAreEquivalent(IDictionary source, IDictionary target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.DictionariesAreEquivalent.m.md) | Ensures two dictionaries are equivalent. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.IsPartOf.m.md) | Determines whether an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another expression. |
| [Boolean MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.MemberBindingsAreEquivalent.m.md) | Ensures that two [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) instances are equivalent. |
| [Boolean NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.NonGenericEnumerablesAreEquivalent.m.md) | Ensures two enumerables are same length an each value is equivalent. |
| [Boolean NullAndTypeCheck(Expression source, Expression other)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.NullAndTypeCheck.m.md) | Comparison matrix for types and nulls. |
| [Boolean TypesAreEquivalent(Type source, Type target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.TypesAreEquivalent.m.md) | Determine if a [Type](https://docs.microsoft.com/dotnet/api/system.type) is equivalent to another type. |
| [Boolean ValuesAreEquivalent(Object source, Object target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.ValuesAreEquivalent.m.md) | Attempts to compare values in various ways. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
