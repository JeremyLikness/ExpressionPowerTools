# IQueryResultSerializer.SerializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IQueryResultSerializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IQueryResultSerializer.i.md) > **SerializeAsync**

Serializes the query result.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SerializeAsync(Stream response, IQueryable query, Boolean isCount)](#serializeasyncstream-response-iqueryable-query-boolean-iscount) | Serializes the query result. |
## SerializeAsync(Stream response, IQueryable query, Boolean isCount)

Serializes the query result.

```csharp
public virtual Task SerializeAsync(Stream response, IQueryable query, Boolean isCount)
```

### Return Type

 [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `response` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) to serialize to. |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to execute. |
| `isCount` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | A value indicating whether a count should be run. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
