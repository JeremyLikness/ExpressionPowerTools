# ExpressionEvaluator.AreSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEvaluator](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.cs.md) > **AreSimilar**

Entry for similarity comparisons. Will cast to
            known types and compare.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AreSimilar(Expression source, Expression target)](#aresimilarexpression-source-expression-target) | Entry for similarity comparisons. Will cast to            known types and compare. |
| [AreSimilar(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)](#aresimilarienumerableexpression-source-ienumerableexpression-target) | Comparison of multiple expressions. Similar            only when all elements match, in order, and            pass the similarity test. It's fine if the            source does not have the same number of entities            as the target. |
| [AreSimilar&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)](#aresimilartiqueryablet-source-iqueryablet-target) | Entry for similarity comparisons. Will cast to            known types and compare. |
## AreSimilar(Expression source, Expression target)

Entry for similarity comparisons. Will cast to
            known types and compare.

```csharp
public virtual Boolean AreSimilar(Expression source, Expression target)
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
public virtual Boolean AreSimilar(IEnumerable<Expression> source, IEnumerable<Expression> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two sets of
            expressions are Similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The source expressions. |
| `target` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The target expressions. |


## AreSimilar&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)

Entry for similarity comparisons. Will cast to
            known types and compare.

```csharp
public virtual Boolean AreSimilar<T>(IQueryable<T> source, IQueryable<T> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the source and target are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The source [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) . |
| `target` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The target [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to compare to. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |
