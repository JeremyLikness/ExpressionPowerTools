# ExpressionSimilarity Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **ExpressionSimilarity**

Expression similarity methods.

```csharp
public static class ExpressionSimilarity
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionSimilarity**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static ExpressionSimilarity()](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.ctor.md#static-expressionsimilarity) | Initializes a new instance of the [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Boolean AreSimilar(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.AreSimilar.m.md) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [Boolean ArgumentsAreSimilar(IList&lt;Expression> source, IList&lt;Expression> target)](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.ArgumentsAreSimilar.m.md) | Determines whether arguments are similar. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.IsPartOf.m.md) | Determines whether an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another expression. |
| [Boolean MemberBindingsAreSimilar(IList&lt;MemberBinding> source, IList&lt;MemberBinding> target)](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.MemberBindingsAreSimilar.m.md) | Determines whether two lists of [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) are similar. |
| [Boolean ParameterInfosAreSimilar(IList&lt;ParameterInfo> source, IList&lt;ParameterInfo> target)](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.ParameterInfosAreSimilar.m.md) | Determines whether a list of parameters for a method or constructor are similar. |
| [Boolean TypesAreSimilar(Type source, Type target)](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.TypesAreSimilar.m.md) | Determines whether types are similar. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
