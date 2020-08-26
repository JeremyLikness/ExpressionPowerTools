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
| [Boolean AreEquivalent(Expression source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreEquivalent.m.md) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [Boolean AreSimilar(Expression source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreSimilar.m.md) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.IsPartOf.m.md) | Determines whether an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/26/2020 6:58:17 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |
