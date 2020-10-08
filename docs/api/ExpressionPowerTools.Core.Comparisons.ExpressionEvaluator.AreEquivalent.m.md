# ExpressionEvaluator.AreEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEvaluator](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.cs.md) > **AreEquivalent**

Entry for equivalency comparisons. Will cast to
            known types and compare.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AreEquivalent(Expression source, Expression target)](#areequivalentexpression-source-expression-target) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [AreEquivalent(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)](#areequivalentienumerableexpression-source-ienumerableexpression-target) | Comparison of multiple expressions. Equivalent            only when all elements match, in order, and            pass the equivalent test. |
| [AreEquivalent&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)](#areequivalenttiqueryablet-source-iqueryablet-target) | Entry for equivalency comparisons. Will cast to            known types and compare. |
## AreEquivalent(Expression source, Expression target)

Entry for equivalency comparisons. Will cast to
            known types and compare.

```csharp
public virtual Boolean AreEquivalent(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the source and target are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to compare to. |


## AreEquivalent(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)

Comparison of multiple expressions. Equivalent
            only when all elements match, in order, and
            pass the equivalent test.

```csharp
public virtual Boolean AreEquivalent(IEnumerable<Expression> source, IEnumerable<Expression> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two sets of
            expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The source expressions. |
| `target` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The target expressions. |


## AreEquivalent&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)

Entry for equivalency comparisons. Will cast to
            known types and compare.

```csharp
public virtual Boolean AreEquivalent<T>(IQueryable<T> source, IQueryable<T> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the source and target are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The source [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) . |
| `target` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The target [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to compare to. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
