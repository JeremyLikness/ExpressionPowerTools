# DbClientContext&lt;TContext>.Query Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [DbClientContext<TContext>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.DbClientContext`1.cs.md) > **Query**

Creates a trackable query based on the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) reference.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Queryable&lt;T> Query&lt;T>(Expression&lt;Func&lt;TContext, DbSet&lt;T>>> template)](#queryablet-querytexpressionfunctcontext-dbsett-template) | Creates a trackable query based on the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) reference. |
## Queryable&lt;T> Query&lt;T>(Expression&lt;Func&lt;TContext, DbSet&lt;T>>> template)

Creates a trackable query based on the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) reference.

```csharp
public static IQueryable<T> Query<T>(Expression<Func<TContext, DbSet<T>>> template)
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)  - A new [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to usee.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `template` | [Expression&lt;Func&lt;TContext, DbSet&lt;T>>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | A template to access the property. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when template is null. |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when template does not refer to the right context. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
