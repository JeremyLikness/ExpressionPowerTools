# DefaultComparisonRules.CheckSimilarity Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **CheckSimilarity**

Perform the check.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CheckSimilarity(Expression source, Expression target)](#checksimilarityexpression-source-expression-target) | Checks for similarity against all types. |
| [CheckSimilarity&lt;T>(T source, Expression target)](#checksimilaritytt-source-expression-target) | Perform the check. |
## CheckSimilarity(Expression source, Expression target)

Checks for similarity against all types.

```csharp
public virtual Boolean CheckSimilarity(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether a match was found and was successful.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |


## CheckSimilarity&lt;T>(T source, Expression target)

Perform the check.

```csharp
public virtual Boolean CheckSimilarity<T>(T source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two expressions are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | T | The source expression. |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target expression. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |
