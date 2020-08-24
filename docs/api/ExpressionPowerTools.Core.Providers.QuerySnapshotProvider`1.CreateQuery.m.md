# QuerySnapshotProvider&lt;T>.CreateQuery Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QuerySnapshotProvider<T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) > **CreateQuery**

Creates the query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateQuery(Expression expression)](#createqueryexpression-expression) | Creates the query. |
| [CreateQuery&lt;TElement>(Expression expression)](#createquerytelementexpression-expression) | Creates the query. |
## CreateQuery(Expression expression)

Creates the query.

```csharp
public virtual IQueryable CreateQuery(Expression expression)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The query.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The query [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |

## CreateQuery&lt;TElement>(Expression expression)

Creates the query.

```csharp
public virtual IQueryable<TElement> CreateQuery<TElement>(Expression expression)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The query.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The query [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
