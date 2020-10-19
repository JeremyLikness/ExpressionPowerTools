# ClientHttpConfiguration Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Configuration](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.n.md) > **ClientHttpConfiguration**

Class to handle configuration of the client.

```csharp
public class ClientHttpConfiguration : IClientHttpConfiguration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ClientHttpConfiguration**

Implements  [IClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ClientHttpConfiguration()](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.ctor.md#clienthttpconfiguration) | Initializes a new instance of the [ClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`ClientFactory`](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.ClientFactory.prop.md) | [Func&lt;IRemoteQueryClient>](https://docs.microsoft.com/dotnet/api/system.func-1) | Gets the client factory to generate the [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient) . |
| [`PathTemplate`](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.PathTemplate.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the template for the server path. Default is `/efcore/{context}/{collection}` . |

## Methods

| Method | Description |
| :-- | :-- |
| [IClientHttpConfiguration SetClientFactory(Func&lt;IRemoteQueryClient> factory)](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.SetClientFactory.m.md) | Set the factory to generate instances of [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient) . |
| [IClientHttpConfiguration SetPathTemplate(String pathTemplate)](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.SetPathTemplate.m.md) | Set the path template. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |
