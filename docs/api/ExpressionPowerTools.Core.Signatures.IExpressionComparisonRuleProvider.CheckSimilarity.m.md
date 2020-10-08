# IExpressionComparisonRuleProvider.CheckSimilarity Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) > **CheckSimilarity**

Perform the check.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CheckSimilarity(Expression source, Expression target)](#checksimilarityexpression-source-expression-target) | Perform the check against all cached types. |
| [CheckSimilarity&lt;T>(T source, Expression target)](#checksimilaritytt-source-expression-target) | Perform the check. |
## CheckSimilarity(Expression source, Expression target)

Perform the check against all cached types.

```csharp
public virtual Boolean CheckSimilarity(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two expressions are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source expression. |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target expression. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when either source or target are null. |

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
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |
