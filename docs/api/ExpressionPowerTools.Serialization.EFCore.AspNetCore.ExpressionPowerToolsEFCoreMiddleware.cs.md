﻿# ExpressionPowerToolsEFCoreMiddleware Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.n.md) > **ExpressionPowerToolsEFCoreMiddleware**

Middleware for managing requests for Entity Framework Core queries.

```csharp
public class ExpressionPowerToolsEFCoreMiddleware
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionPowerToolsEFCoreMiddleware**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionPowerToolsEFCoreMiddleware(RequestDelegate next, String path, Type[] dbContextTypes)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.ctor.md#expressionpowertoolsefcoremiddlewarerequestdelegate-next-string-path-type[]-dbcontexttypes) | Initializes a new instance of the [ExpressionPowerToolsEFCoreMiddleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Task Invoke(HttpContext httpContext, IServiceProvider provider)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.Invoke.m.md) | The main invocation of the middleware component. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |