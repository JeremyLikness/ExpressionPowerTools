# DbContextAdapter.TryGetDbSet Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [DbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.cs.md) > **TryGetDbSet**

Tries to match the collection to a property on the context.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)](#trygetdbsettype-context-string-collection-propertyinfo&-dbset) | Tries to match the collection to a property on the context. |
## TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)

Tries to match the collection to a property on the context.

```csharp
public virtual Boolean TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether the property matched.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `context` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type of the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |
| `collection` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the collection. |
| `dbSet` | [PropertyInfo&](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo&) | The [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) for the collection. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
