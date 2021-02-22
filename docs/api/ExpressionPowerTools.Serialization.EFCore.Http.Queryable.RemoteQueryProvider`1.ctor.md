# RemoteQueryProvider&lt;T> Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [RemoteQueryProvider<T>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.cs.md) > **RemoteQueryProvider(IQueryable sourceQuery, RemoteContext remoteContext)**

Initializes a new instance of the [RemoteQueryProvider&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [RemoteQueryProvider(IQueryable sourceQuery, RemoteContext remoteContext)](#remotequeryprovideriqueryable-sourcequery-remotecontext-remotecontext) | Initializes a new instance of the [RemoteQueryProvider&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.cs.md) class. |

## RemoteQueryProvider(IQueryable sourceQuery, RemoteContext remoteContext)

Initializes a new instance of the [RemoteQueryProvider&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.cs.md) class.

```csharp
public RemoteQueryProvider(IQueryable sourceQuery, RemoteContext remoteContext)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The source query. |
| `remoteContext` | [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) | The [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when remote context is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
