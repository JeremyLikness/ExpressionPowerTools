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
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionEvaluator-AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean AreSimilar(Expression source, Expression target)](ExpressionEvaluator-AreSimilar.m.md) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionEvaluator-IsPartOf.m.md) | Determines whether an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
