# ClientExtensions.ExecuteRemote Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > [ClientExtensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) > **ExecuteRemote**

Use this to indicate you are about to run a remote query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ExecuteRemote&lt;T>(IQueryable&lt;T> query)](#executeremotetiqueryablet-query) | Use this to indicate you are about to run a remote query. |
## ExecuteRemote&lt;T>(IQueryable&lt;T> query)

Use this to indicate you are about to run a remote query.

```csharp
public static IRemoteQueryable<T> ExecuteRemote<T>(IQueryable<T> query)
```

### Return Type

 [IRemoteQueryable&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryable`1.i.md)  - The remote query.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query to run remotely. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when query is null. |
| [NullReferenceException](https://docs.microsoft.com/dotnet/api/system.nullreferenceexception) | Thrown when query is not a remote query. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |
