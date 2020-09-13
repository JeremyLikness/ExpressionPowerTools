# QueryDeserializer.DeserializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [QueryDeserializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryDeserializer.cs.md) > **DeserializeAsync**

Deserializes the query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeAsync(IQueryable template, Stream json, ILogger logger)](#deserializeasynciqueryable-template-stream-json-ilogger-logger) | Deserializes the query. |
## DeserializeAsync(IQueryable template, Stream json, ILogger logger)

Deserializes the query.

```csharp
public virtual Task<QueryResult> DeserializeAsync(IQueryable template, Stream json, ILogger logger)
```

### Return Type

 [Task&lt;QueryResult>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `template` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to run. |
| `json` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The stream with json info. |
| `logger` | [ILogger](https://docs.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger) | The logger. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
