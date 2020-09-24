# QueryResultSerializer.SerializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [QueryResultSerializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResultSerializer.cs.md) > **SerializeAsync**

Serializes the result of a query to the stream.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SerializeAsync(Stream response, IQueryable query, PayloadType type)](#serializeasyncstream-response-iqueryable-query-payloadtype-type) | Serializes the result of a query to the stream. |
## SerializeAsync(Stream response, IQueryable query, PayloadType type)

Serializes the result of a query to the stream.

```csharp
public virtual Task SerializeAsync(Stream response, IQueryable query, PayloadType type)
```

### Return Type

 [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task)  - A [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task) representing the asynchronous operation.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `response` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) for the response. |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to resolve. |
| `type` | [PayloadType](ExpressionPowerTools.Serialization.PayloadType.cs.md) | A value indicating whether the result should be a count, single or array. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:29:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
