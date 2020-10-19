# IDbContextAdapter.CreateQuery Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IDbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.i.md) > **CreateQuery**

Creates an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) based on the context and collection. Takes an action for the
            resolution of the context. This is typically `t => serviceProvider.GetService(t)` .

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateQuery(DbContext context, PropertyInfo collection)](#createquerydbcontext-context-propertyinfo-collection) | Creates an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) based on the context and collection. Takes an action for the            resolution of the context. This is typically `t => serviceProvider.GetService(t)` . |
## CreateQuery(DbContext context, PropertyInfo collection)

Creates an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) based on the context and collection. Takes an action for the
            resolution of the context. This is typically `t => serviceProvider.GetService(t)` .

```csharp
public virtual IQueryable CreateQuery(DbContext context, PropertyInfo collection)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `context` | [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) | The [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |
| `collection` | [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) | The name of the collection used as the basis for the query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |
