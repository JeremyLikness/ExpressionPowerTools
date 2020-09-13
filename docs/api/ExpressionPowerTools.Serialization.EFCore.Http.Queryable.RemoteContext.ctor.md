# RemoteContext Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) > **RemoteContext(Type context, PropertyInfo collection)**

Initializes a new instance of the [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) class with the
            type of the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) and the property info.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [RemoteContext(Type context, PropertyInfo collection)](#remotecontexttype-context-propertyinfo-collection) | Initializes a new instance of the [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) class with the            type of the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) and the property info. |

## RemoteContext(Type context, PropertyInfo collection)

Initializes a new instance of the [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) class with the
            type of the [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) and the property info.

```csharp
public RemoteContext(Type context, PropertyInfo collection)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `context` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type of [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |
| `collection` | [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) | The property for the `DbSet` . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
