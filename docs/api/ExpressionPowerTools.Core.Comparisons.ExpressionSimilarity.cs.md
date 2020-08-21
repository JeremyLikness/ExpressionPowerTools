# ExpressionSimilarity Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **ExpressionSimilarity**

Expression similarity methods.

```csharp
public static class ExpressionSimilarity
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionSimilarity**

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean AreSimilar(Expression source, Expression target)](ExpressionSimilarity-AreSimilar.m.md) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [Boolean ArgumentsAreSimilar(IList&lt;Expression> source, IList&lt;Expression> target)](ExpressionSimilarity-ArgumentsAreSimilar.m.md) | Determines whether arguments are similar. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionSimilarity-IsPartOf.m.md) | Determines whether an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another expression. |
| [Boolean TypesAreSimilar(Type source, Type target)](ExpressionSimilarity-TypesAreSimilar.m.md) | Determines whether types are similar. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/20/2020 6:23:17 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
