# RemoteQueryProvider&lt;T>.CreateQuery Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [RemoteQueryProvider<T>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.cs.md) > **CreateQuery**

Create a query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateQuery(Expression expression)](#createqueryexpression-expression) | Create a query. |
| [CreateQuery&lt;TElement>(Expression expression)](#createquerytelementexpression-expression) | Create a typed query. |
## CreateQuery(Expression expression)

Create a query.

```csharp
public virtual IQueryable CreateQuery(Expression expression)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The new [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to parse. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |

## CreateQuery&lt;TElement>(Expression expression)

Create a typed query.

```csharp
public virtual IQueryable<TElement> CreateQuery<TElement>(Expression expression)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .

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
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
