# IRemoteQueryClient.FetchRemoteQueryAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryClient](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryClient.i.md) > **FetchRemoteQueryAsync**

Fetches the remote content.

## Overloads

| Overload | Description |
| :-- | :-- |
| [FetchRemoteQueryAsync(String path, HttpContent queryContent)](#fetchremotequeryasyncstring-path-httpcontent-querycontent) | Fetches the remote content. |
## FetchRemoteQueryAsync(String path, HttpContent queryContent)

Fetches the remote content.

```csharp
public virtual Task<String> FetchRemoteQueryAsync(String path, HttpContent queryContent)
```

### Return Type

 [Task&lt;String>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `path` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The relative path. |
| `queryContent` | [HttpContent](https://docs.microsoft.com/dotnet/api/system.net.http.httpcontent) | The query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:29:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
