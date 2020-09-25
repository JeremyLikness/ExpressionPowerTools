# IClientHttpConfiguration Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > **IClientHttpConfiguration**

Configuration for connecting to the remote services.

```csharp
public interface IClientHttpConfiguration
```

Derived  [ClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`ClientFactory`](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.ClientFactory.prop.md) | [Func&lt;IRemoteQueryClient>](https://docs.microsoft.com/dotnet/api/system.func-1) | Gets the factory to generate the client. Defaults to a call from the service provider. |
| [`PathTemplate`](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.PathTemplate.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the template to use, defaults to `/efcore/{context}/{collection}` . |

## Methods

| Method | Description |
| :-- | :-- |
| [IClientHttpConfiguration SetClientFactory(Func&lt;IRemoteQueryClient> factory)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.SetClientFactory.m.md) | Set the client factory. |
| [IClientHttpConfiguration SetPathTemplate(String path)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.SetPathTemplate.m.md) | Sets the template for the path. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
