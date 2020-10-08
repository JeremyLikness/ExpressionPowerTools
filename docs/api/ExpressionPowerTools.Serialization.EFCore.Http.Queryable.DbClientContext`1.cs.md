# DbClientContext&lt;TContext> Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > **DbClientContext<TContext>**

Provides a starting point for building remote queries.

```csharp
public static class DbClientContext<TContext>
   where TContext : DbContext
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `TContext` | [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) | The [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) the query is based on. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DbClientContext&lt;TContext>**

## Methods

| Method | Description |
| :-- | :-- |
| [IQueryable&lt;T> Queryable&lt;T> Query&lt;T>(Expression&lt;Func&lt;TContext, DbSet&lt;T>>> template)](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.DbClientContext`1.Query.m.md) | Creates a trackable query based on the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) reference. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
