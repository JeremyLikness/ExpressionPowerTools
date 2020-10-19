# RemoteQueryProvider&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > **RemoteQueryProvider<T>**

Custom provider for remote queries.

```csharp
public class RemoteQueryProvider<T> : CustomQueryProvider<T>, ICustomQueryProvider<T>, IRemoteQueryProvider
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type of the query. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **RemoteQueryProvider&lt;T>**

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) ,  [IRemoteQueryProvider](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryProvider.i.md) 

## Remarks

The main purpose is to provide a query to build the filters and sorts, and capture
            the original context for extension overloads that will fetch the remote results.

## Constructors

| Ctor | Description |
| :-- | :-- |
| [RemoteQueryProvider(IQueryable sourceQuery, RemoteContext remoteContext)](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.ctor.md#remotequeryprovideriqueryable-sourcequery-remotecontext-remotecontext) | Initializes a new instance of the [RemoteQueryProvider&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Context`](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.Context.prop.md) | [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) | Gets the [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) . |

## Methods

| Method | Description |
| :-- | :-- |
| [IQueryable CreateQuery(Expression expression)](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQueryProvider`1.CreateQuery.m.md) | Create a query. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |
