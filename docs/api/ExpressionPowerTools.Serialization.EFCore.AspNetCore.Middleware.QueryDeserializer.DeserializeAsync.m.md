# QueryDeserializer.DeserializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [QueryDeserializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryDeserializer.cs.md) > **DeserializeAsync**

Deserializes the query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeAsync(IQueryable template, Stream json)](#deserializeasynciqueryable-template-stream-json) | Deserializes the query. |
## DeserializeAsync(IQueryable template, Stream json)

Deserializes the query.

```csharp
public virtual Task<QueryResult> DeserializeAsync(IQueryable template, Stream json)
```

### Return Type

 [Task&lt;QueryResult>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `template` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to run. |
| `json` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The stream with json info. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
