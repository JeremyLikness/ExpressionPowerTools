# IDbContextAdapter.TryGetDbSet Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IDbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.i.md) > **TryGetDbSet**

Tries to get the [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) to access the collection.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)](#trygetdbsettype-context-string-collection-propertyinfo&-dbset) | Tries to get the [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) to access the collection. |
## TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)

Tries to get the [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) to access the collection.

```csharp
public virtual Boolean TryGetDbSet(Type context, String collection, PropertyInfo& dbSet)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether nor not the collection on the context is valid.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `context` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type of the `DbContext` . |
| `collection` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the collection. This is the `DbSet&lt;T>` property name. |
| `dbSet` | [PropertyInfo&](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo&) | The resolved [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) for the collection. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |
