# ExpressionEquivalency.AreEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) > **AreEquivalent**

Entry for equivalency comparisons. Will cast to
            known types and compare.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AreEquivalent(Expression source, Expression target)](#areequivalentexpression-source-expression-target) | Entry for equivalency comparisons. Will cast to            known types and compare. |
| [AreEquivalent(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)](#areequivalentienumerableexpression-source-ienumerableexpression-target) | Comparison of multiple expressions. Equivalent            only when all elements match, in order, and            pass the equivalent test. |
## AreEquivalent(Expression source, Expression target)

Entry for equivalency comparisons. Will cast to
            known types and compare.

```csharp
public static Boolean AreEquivalent(Expression source, Expression target)
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
public static Boolean AreEquivalent(IEnumerable<Expression> source, IEnumerable<Expression> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two sets of
            expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The source expressions. |
| `target` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The target expressions. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |
