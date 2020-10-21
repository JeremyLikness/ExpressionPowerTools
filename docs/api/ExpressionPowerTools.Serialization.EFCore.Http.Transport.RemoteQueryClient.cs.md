# RemoteQueryClient Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > **RemoteQueryClient**

Configured for the query client.

```csharp
public class RemoteQueryClient : IRemoteQueryClient
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **RemoteQueryClient**

Implements  [IRemoteQueryClient](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryClient.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [RemoteQueryClient(HttpClient client)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.RemoteQueryClient.ctor.md#remotequeryclienthttpclient-client) | Initializes a new instance of the [RemoteQueryClient](ExpressionPowerTools.Serialization.EFCore.Http.Transport.RemoteQueryClient.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Task&lt;String> FetchRemoteQueryAsync(String path, HttpContent queryContent)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.RemoteQueryClient.FetchRemoteQueryAsync.m.md) | Performs the remote fetch. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
