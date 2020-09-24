# ExpressionPowerToolsEFCoreMiddleware Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.n.md) > [ExpressionPowerToolsEFCoreMiddleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.cs.md) > **ExpressionPowerToolsEFCoreMiddleware(RequestDelegate next, String path, Type[] dbContextTypes)**

Initializes a new instance of the [ExpressionPowerToolsEFCoreMiddleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [ExpressionPowerToolsEFCoreMiddleware(RequestDelegate next, String path, Type[] dbContextTypes)](#expressionpowertoolsefcoremiddlewarerequestdelegate-next-string-path-type[]-dbcontexttypes) | Initializes a new instance of the [ExpressionPowerToolsEFCoreMiddleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.cs.md) class. |

## ExpressionPowerToolsEFCoreMiddleware(RequestDelegate next, String path, Type[] dbContextTypes)

Initializes a new instance of the [ExpressionPowerToolsEFCoreMiddleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.cs.md) class.

```csharp
public ExpressionPowerToolsEFCoreMiddleware(RequestDelegate next, String path, Type[] dbContextTypes)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `next` | [RequestDelegate](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.requestdelegate) | The next middleware in the processing pipeline. |
| `path` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The path configured for the endpoint. |
| `dbContextTypes` | [Type[]](https://docs.microsoft.com/dotnet/api/system.type) | The list of eligible context types. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |
