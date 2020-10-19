# IQueryResultSerializer.SerializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IQueryResultSerializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IQueryResultSerializer.i.md) > **SerializeAsync**

Serializes the query result.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SerializeAsync(Stream response, IQueryable query, PayloadType type)](#serializeasyncstream-response-iqueryable-query-payloadtype-type) | Serializes the query result. |
## SerializeAsync(Stream response, IQueryable query, PayloadType type)

Serializes the query result.

```csharp
public virtual Task SerializeAsync(Stream response, IQueryable query, PayloadType type)
```

### Return Type

 [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `response` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) to serialize to. |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to execute. |
| `type` | [PayloadType](ExpressionPowerTools.Serialization.PayloadType.cs.md) | A value indicating whether a count or single should be run. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |
