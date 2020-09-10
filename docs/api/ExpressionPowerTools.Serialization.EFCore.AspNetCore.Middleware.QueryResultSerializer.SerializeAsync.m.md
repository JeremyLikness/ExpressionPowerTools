# QueryResultSerializer.SerializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [QueryResultSerializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResultSerializer.cs.md) > **SerializeAsync**

Serializes the result of a query to the stream.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SerializeAsync(Stream response, IQueryable query, Boolean isCount)](#serializeasyncstream-response-iqueryable-query-boolean-iscount) | Serializes the result of a query to the stream. |
## SerializeAsync(Stream response, IQueryable query, Boolean isCount)

Serializes the result of a query to the stream.

```csharp
public virtual Task SerializeAsync(Stream response, IQueryable query, Boolean isCount)
```

### Return Type

 [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task)  - A [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task) representing the asynchronous operation.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `response` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) for the response. |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to resolve. |
| `isCount` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the result should be a count. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
