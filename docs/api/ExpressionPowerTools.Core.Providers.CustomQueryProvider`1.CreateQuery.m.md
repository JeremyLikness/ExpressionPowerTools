# CustomQueryProvider&lt;T>.CreateQuery Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) > **CreateQuery**

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



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
