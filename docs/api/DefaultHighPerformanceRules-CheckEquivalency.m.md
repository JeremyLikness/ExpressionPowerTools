# DefaultHighPerformanceRules.CheckEquivalency Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [DefaultHighPerformanceRules](ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules.cs.md) > **CheckEquivalency**

Check equivalency for a given type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CheckEquivalency(Expression source, Expression target)](#checkequivalencyexpression-source-expression-target) | Generic equivilency check. |
| [CheckEquivalency&lt;T>(T source, Expression target)](#checkequivalencytt-source-expression-target) | Check equivalency for a given type. |
## CheckEquivalency(Expression source, Expression target)

Generic equivilency check.

```csharp
public virtual Boolean CheckEquivalency(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether the expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when source or target are null. |

## CheckEquivalency&lt;T>(T source, Expression target)

Check equivalency for a given type.

```csharp
public virtual Boolean CheckEquivalency<T>(T source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether the expressions are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | T | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when source or target are null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
