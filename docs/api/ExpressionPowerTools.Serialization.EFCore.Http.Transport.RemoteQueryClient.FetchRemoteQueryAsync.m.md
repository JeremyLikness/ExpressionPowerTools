﻿# RemoteQueryClient.FetchRemoteQueryAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > [RemoteQueryClient](ExpressionPowerTools.Serialization.EFCore.Http.Transport.RemoteQueryClient.cs.md) > **FetchRemoteQueryAsync**

Performs the remote fetch.

## Overloads

| Overload | Description |
| :-- | :-- |
| [FetchRemoteQueryAsync(String path, HttpContent queryContent)](#fetchremotequeryasyncstring-path-httpcontent-querycontent) | Performs the remote fetch. |
## FetchRemoteQueryAsync(String path, HttpContent queryContent)

Performs the remote fetch.

```csharp
public virtual Task<String> FetchRemoteQueryAsync(String path, HttpContent queryContent)
```

### Return Type

 [Task&lt;String>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `path` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The path to the query server. |
| `queryContent` | [HttpContent](https://docs.microsoft.com/dotnet/api/system.net.http.httpcontent) | The content to post. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when path is empty. |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when query content is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |