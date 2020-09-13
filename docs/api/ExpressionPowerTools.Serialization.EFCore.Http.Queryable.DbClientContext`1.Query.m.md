# DbClientContext&lt;TContext>.Query Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [DbClientContext<TContext>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.DbClientContext`1.cs.md) > **Query**



## Overloads

| Overload | Description |
| :-- | :-- |
| [Queryable&lt;T> Query&lt;T>(Expression&lt;Func&lt;TContext, DbSet&lt;T>>> template)](#queryablet-querytexpressionfunctcontext-dbsett-template) |  |
## Queryable&lt;T> Query&lt;T>(Expression&lt;Func&lt;TContext, DbSet&lt;T>>> template)



```csharp
public static IQueryable<T> Query<T>(Expression<Func<TContext, DbSet<T>>> template)
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `template` | [Expression&lt;Func&lt;TContext, DbSet&lt;T>>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
