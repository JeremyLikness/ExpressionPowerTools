# IQueryDeserializer.DeserializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IQueryDeserializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IQueryDeserializer.i.md) > **DeserializeAsync**

Performs the deserialization.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeAsync(IQueryable template, Stream json, ILogger logger)](#deserializeasynciqueryable-template-stream-json-ilogger-logger) | Performs the deserialization. |
## DeserializeAsync(IQueryable template, Stream json, ILogger logger)

Performs the deserialization.

```csharp
public virtual Task<QueryResult> DeserializeAsync(IQueryable template, Stream json, ILogger logger)
```

### Return Type

 [Task&lt;QueryResult>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The functional [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `template` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The template to use (built from a `DbSet` ). |
| `json` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The serialized query. |
| `logger` | [ILogger](https://docs.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger) | The logger. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
