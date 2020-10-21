# DbContextAdapter Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > **DbContextAdapter**

Adapter to [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) .

```csharp
public class DbContextAdapter : IDbContextAdapter
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DbContextAdapter**

Implements  [IDbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DbContextAdapter()](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.ctor.md#dbcontextadapter) | Initializes a new instance of the [DbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [IQueryable CreateQuery(DbContext context, PropertyInfo collection)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.CreateQuery.m.md) | Creates a query with the provided [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |
| [Boolean TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.TryGetContext.m.md) | Tries to match context name with the list of eligible types. |
| [Boolean TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.TryGetDbSet.m.md) | Tries to match the collection to a property on the context. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
