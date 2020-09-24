# IRemoteQueryClient Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > **IRemoteQueryClient**

Typed [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient) for queries.

```csharp
public interface IRemoteQueryClient
```

Derived  [RemoteQueryClient](ExpressionPowerTools.Serialization.EFCore.Http.Transport.RemoteQueryClient.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Task&lt;String> FetchRemoteQueryAsync(String path, HttpContent queryContent)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryClient.FetchRemoteQueryAsync.m.md) | Fetches the remote content. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
