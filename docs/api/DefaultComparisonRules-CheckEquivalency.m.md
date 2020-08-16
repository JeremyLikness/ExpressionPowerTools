﻿# DefaultComparisonRules.CheckEquivalency Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) > **CheckEquivalency**

Perform the check.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CheckEquivalency(Expression source, Expression target)](#checkequivalencyexpression-source-expression-target) | Perform the check against all cached types. |
| [CheckEquivalency&lt;T>(T source, Expression target)](#checkequivalencytt-source-expression-target) | Perform the check. |
## CheckEquivalency(Expression source, Expression target)

Perform the check against all cached types.

```csharp
public virtual Boolean CheckEquivalency(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source expression. |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target expression. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when either source or target are null. |

## CheckEquivalency&lt;T>(T source, Expression target)

Perform the check.

```csharp
public virtual Boolean CheckEquivalency<T>(T source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | T | The source expression. |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target expression. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |