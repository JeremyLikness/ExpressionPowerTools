# CollectionHandle Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > **CollectionHandle**

A handle that points to a context type and the property for the collection.

```csharp
public class CollectionHandle
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **CollectionHandle**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [CollectionHandle(Type dbContext, PropertyInfo collection)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.ctor.md#collectionhandletype-dbcontext-propertyinfo-collection) | Initializes a new instance of the [CollectionHandle](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.cs.md) class with            a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) type and [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) for the collection. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Collection`](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.Collection.prop.md) | [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) | Gets the [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) of the collection. |
| [`DbContextType`](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.DbContextType.prop.md) | [Type](https://docs.microsoft.com/dotnet/api/system.type) | Gets the type of the context. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |
