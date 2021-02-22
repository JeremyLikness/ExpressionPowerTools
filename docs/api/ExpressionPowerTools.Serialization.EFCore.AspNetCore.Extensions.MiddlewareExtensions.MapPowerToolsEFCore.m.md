# MiddlewareExtensions.MapPowerToolsEFCore Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions.n.md) > [MiddlewareExtensions](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions.MiddlewareExtensions.cs.md) > **MapPowerToolsEFCore**

Map a route and allow two [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) instances.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MapPowerToolsEFCore(IEndpointRouteBuilder endpointRouteBuilder, RoutePattern pattern, Type[] dbContextTypes, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)](#mappowertoolsefcoreiendpointroutebuilder-endpointroutebuilder-routepattern-pattern-type[]-dbcontexttypes-actionirulesconfiguration-rules-boolean-nodefaultrules-actioniconfigurationbuilder-options) | Main configuration method for Power Tools EF Core middleware. |
| [MapPowerToolsEFCore&lt;T1Context, T2Context>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)](#mappowertoolsefcoret1context-t2contextiendpointroutebuilder-endpointroutebuilder-string-pattern-actionirulesconfiguration-rules-boolean-nodefaultrules-actioniconfigurationbuilder-options) | Map a route and allow two [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) instances. |
| [MapPowerToolsEFCore&lt;TContext>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)](#mappowertoolsefcoretcontextiendpointroutebuilder-endpointroutebuilder-string-pattern-actionirulesconfiguration-rules-boolean-nodefaultrules-actioniconfigurationbuilder-options) | Map a route and allow a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |
## MapPowerToolsEFCore(IEndpointRouteBuilder endpointRouteBuilder, RoutePattern pattern, Type[] dbContextTypes, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)

Main configuration method for Power Tools EF Core middleware.

```csharp
public static IEndpointConventionBuilder MapPowerToolsEFCore(IEndpointRouteBuilder endpointRouteBuilder, RoutePattern pattern, Type[] dbContextTypes, Action<IRulesConfiguration> rules, Boolean noDefaultRules, Action<IConfigurationBuilder> options)
```

### Return Type

 [IEndpointConventionBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder)  - The [IEndpointConventionBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `endpointRouteBuilder` | [IEndpointRouteBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) | The [IEndpointRouteBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) . |
| `pattern` | [RoutePattern](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.patterns.routepattern) | The pattern for the route (defaults to `/efcore` ). |
| `dbContextTypes` | [Type[]](https://docs.microsoft.com/dotnet/api/system.type) | The list of `DbContext` types to support. |
| `rules` | [Action&lt;IRulesConfiguration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) to configure serialization rules. |
| `noDefaultRules` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Determines whether the default rule set should be applied. |
| `options` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) to configure options. |


## MapPowerToolsEFCore&lt;T1Context, T2Context>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)

Map a route and allow two [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) instances.

```csharp
public static IEndpointConventionBuilder MapPowerToolsEFCore<T1Context, T2Context>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action<IRulesConfiguration> rules, Boolean noDefaultRules, Action<IConfigurationBuilder> options)
```

### Return Type

 [IEndpointConventionBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder)  - The [IEndpointConventionBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `endpointRouteBuilder` | [IEndpointRouteBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) | The [IEndpointRouteBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) . |
| `pattern` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The root path. The context and controller will be appended. |
| `rules` | [Action&lt;IRulesConfiguration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) to configure serialization rules. |
| `noDefaultRules` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Determines whether the default rule set should be applied. |
| `options` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) to configure options. |


## MapPowerToolsEFCore&lt;TContext>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)

Map a route and allow a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) .

```csharp
public static IEndpointConventionBuilder MapPowerToolsEFCore<TContext>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action<IRulesConfiguration> rules, Boolean noDefaultRules, Action<IConfigurationBuilder> options)
```

### Return Type

 [IEndpointConventionBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder)  - The [IEndpointConventionBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `endpointRouteBuilder` | [IEndpointRouteBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) | The [IEndpointRouteBuilder](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) . |
| `pattern` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The path pattern. |
| `rules` | [Action&lt;IRulesConfiguration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) to configure serialization rules. |
| `noDefaultRules` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Determines whether the default rule set should be applied. |
| `options` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) to configure options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |
