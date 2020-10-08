# CollectionHandle Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [CollectionHandle](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.cs.md) > **CollectionHandle(Type dbContext, PropertyInfo collection)**

Initializes a new instance of the [CollectionHandle](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.cs.md) class with
            a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) type and [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) for the collection.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [CollectionHandle(Type dbContext, PropertyInfo collection)](#collectionhandletype-dbcontext-propertyinfo-collection) | Initializes a new instance of the [CollectionHandle](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.cs.md) class with            a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) type and [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) for the collection. |

## CollectionHandle(Type dbContext, PropertyInfo collection)

Initializes a new instance of the [CollectionHandle](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.CollectionHandle.cs.md) class with
            a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) type and [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) for the collection.

```csharp
public CollectionHandle(Type dbContext, PropertyInfo collection)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `dbContext` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type of the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |
| `collection` | [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) | The [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) of the collection. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the context or collection are null. |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the type is not a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
