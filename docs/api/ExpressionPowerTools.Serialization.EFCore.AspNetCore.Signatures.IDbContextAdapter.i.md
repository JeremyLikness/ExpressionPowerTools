# IDbContextAdapter Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > **IDbContextAdapter**

Services to interface with a configured [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) .

```csharp
public interface IDbContextAdapter
```

Derived  [DbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [IQueryable CreateQuery(DbContext context, PropertyInfo collection)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.CreateQuery.m.md) | Creates an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) based on the context and collection. Takes an action for the            resolution of the context. This is typically `t => serviceProvider.GetService(t)` . |
| [Boolean TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.TryGetContext.m.md) | Tries to match the text to the context. |
| [Boolean TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.TryGetDbSet.m.md) | Tries to get the [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) to access the collection. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
