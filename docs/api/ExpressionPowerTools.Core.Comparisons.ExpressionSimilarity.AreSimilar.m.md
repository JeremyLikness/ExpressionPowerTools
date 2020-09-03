# ExpressionSimilarity.AreSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) > **AreSimilar**

Entry for similarity comparisons. Will cast to
            known types and compare.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AreSimilar(Expression source, Expression target)](#aresimilarexpression-source-expression-target) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [AreSimilar(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)](#aresimilarienumerableexpression-source-ienumerableexpression-target) | Comparison of multiple expressions. Similar            only when all elements match, in order, and            pass the similarity test. It's fine if the            source does not have the same number of entities            as the target. |
## AreSimilar(Expression source, Expression target)

Entry for similarity comparisons. Will cast to
            known types and compare.

```csharp
public static Boolean AreSimilar(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the source and target are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to compare to. |


## AreSimilar(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)

Comparison of multiple expressions. Similar
            only when all elements match, in order, and
            pass the similarity test. It's fine if the
            source does not have the same number of entities
            as the target.

```csharp
public static Boolean AreSimilar(IEnumerable<Expression> source, IEnumerable<Expression> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two sets of
            expressions are Similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The source expressions. |
| `target` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The target expressions. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |
