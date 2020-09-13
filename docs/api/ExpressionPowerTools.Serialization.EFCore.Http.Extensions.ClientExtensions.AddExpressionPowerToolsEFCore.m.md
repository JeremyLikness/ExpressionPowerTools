# ClientExtensions.AddExpressionPowerToolsEFCore Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > [ClientExtensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) > **AddExpressionPowerToolsEFCore**

Adds the client and provides the opportunity to configure it.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AddExpressionPowerToolsEFCore(IServiceCollection collection, Uri baseAddress, Action&lt;IClientHttpConfiguration> configure)](#addexpressionpowertoolsefcoreiservicecollection-collection-uri-baseaddress-actioniclienthttpconfiguration-configure) | Adds the client and provides the opportunity to configure it. |
## AddExpressionPowerToolsEFCore(IServiceCollection collection, Uri baseAddress, Action&lt;IClientHttpConfiguration> configure)

Adds the client and provides the opportunity to configure it.

```csharp
public static Void AddExpressionPowerToolsEFCore(IServiceCollection collection, Uri baseAddress, Action<IClientHttpConfiguration> configure)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `collection` | [IServiceCollection](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) | The [IServiceCollection](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) to extend. |
| `baseAddress` | [Uri](https://docs.microsoft.com/dotnet/api/system.uri) | The base address of the client. This should only incude the scheme, domain, and ports. Use            the "configure" option to modify the path to the server middleware. |
| `configure` | [Action&lt;IClientHttpConfiguration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The optional configuration. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |
