# ClientExtensions.AsRemoteQueryable Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > [ClientExtensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) > **AsRemoteQueryable**

Takes an enumerable and builds a host for remote processing.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsRemoteQueryable&lt;T>(IEnumerable&lt;T> source, RemoteContext context)](#asremotequeryabletienumerablet-source-remotecontext-context) | Takes an enumerable and builds a host for remote processing. |
## AsRemoteQueryable&lt;T>(IEnumerable&lt;T> source, RemoteContext context)

Takes an enumerable and builds a host for remote processing.

```csharp
public static IQueryable<T> AsRemoteQueryable<T>(IEnumerable<T> source, RemoteContext context)
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)  - The [RemoteQuery&lt;T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) | The source to parse. |
| `context` | [RemoteContext](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteContext.cs.md) | The context of the query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
