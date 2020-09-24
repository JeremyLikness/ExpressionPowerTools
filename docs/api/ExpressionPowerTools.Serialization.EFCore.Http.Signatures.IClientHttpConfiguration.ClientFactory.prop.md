# IClientHttpConfiguration.ClientFactory Property

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.i.md) > **ClientFactory**

Gets the factory to generate the client. Defaults to a call from the service provider.

```csharp
public virtual Func<IRemoteQueryClient> ClientFactory { get; }
```

### Property Value

 [Func&lt;IRemoteQueryClient>](https://docs.microsoft.com/dotnet/api/system.func-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
