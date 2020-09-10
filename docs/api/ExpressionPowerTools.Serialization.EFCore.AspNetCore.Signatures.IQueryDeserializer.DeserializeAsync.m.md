# IQueryDeserializer.DeserializeAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IQueryDeserializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IQueryDeserializer.i.md) > **DeserializeAsync**

Performs the deserialization.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeAsync(IQueryable template, Stream json)](#deserializeasynciqueryable-template-stream-json) | Performs the deserialization. |
## DeserializeAsync(IQueryable template, Stream json)

Performs the deserialization.

```csharp
public virtual Task<QueryResult> DeserializeAsync(IQueryable template, Stream json)
```

### Return Type

 [Task&lt;QueryResult>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The functional [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `template` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The template to use (built from a `DbSet` ). |
| `json` | [Stream](https://docs.microsoft.com/dotnet/api/system.io.stream) | The serialized query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |
